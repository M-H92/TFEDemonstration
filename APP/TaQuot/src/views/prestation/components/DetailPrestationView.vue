<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent width="1024">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" block v-bind="props" @click="open()">
          Ajouter
        </v-btn>
      </template>
      <v-card>
        <v-card-title class="pt-5">
          <span class="text-h5"
            >{{ titleText }}
            <v-progress-circular
              v-show="fetchLoading"
              color="teal"
              indeterminate
          /></span>
        </v-card-title>
        <v-card-text>
          <v-form v-model="form.isValid" ref="refForm">
            <v-container>
              <v-row v-show="!fetchLoading">
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Date"
                    required
                    v-model="form.date"
                    type="date"
                    :rules="dateRules"
                    :readonly="crudMode == CrudMode.Read"
                  />
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    v-if="prestationStore.configuration.tempsAsInputTypeTime"
                    ref="refInputTime"
                    autofocus
                    label="Temps"
                    required
                    v-model="form.temps"
                    :readonly="crudMode == CrudMode.Read"
                    hint="En minutes"
                    :rules="tempsRules"
                    type="time"
                  />

                  <v-text-field
                    v-else
                    ref="refInputTime"
                    autofocus
                    label="Temps"
                    required
                    v-model="form.temps"
                    :readonly="crudMode == CrudMode.Read"
                    hint="En minutes"
                    :rules="tempsRules"
                  />
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-autocomplete
                    :readonly="crudMode == CrudMode.Read"
                    :items="typetachesItems"
                    label="Type tache*"
                    required
                    :auto="false"
                    v-model="form.typeTacheId"
                    :rules="typeTacheRules"
                  />
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-autocomplete
                    :readonly="crudMode == CrudMode.Read"
                    :items="commanditairesItems"
                    :label="`${nom.commanditaireCapitalized}*`"
                    required
                    :auto="false"
                    v-model="form.commanditaireId"
                    :no-data-text="`Données non chargés`"
                    @update:modelValue="resetApplicationId"
                    :rules="commanditaireRules"
                  />
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-autocomplete
                    :readonly="crudMode == CrudMode.Read"
                    :items="applicationsItems"
                    :label="`${nom.applicationCapitalized}*`"
                    required
                    :auto="false"
                    :no-data-text="`Données non chargées`"
                    v-model="form.applicationId"
                    @update:modelValue="resetModuleId"
                    :rules="applicationRule"
                  />
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-autocomplete
                    :items="moduleItems"
                    :label="`${nom.moduleCapitalized}*`"
                    required
                    :auto="false"
                    :readonly="crudMode == CrudMode.Read"
                    no-data-text="Pas de données chargés"
                    v-model="form.moduleId"
                    :rules="moduleRule"
                  />
                </v-col>
                <v-col cols="12">
                  <v-text-field
                    :label="`${nom.tacheCapitalized}`"
                    required
                    v-model="form.tache"
                    :rules="tacheRules"
                    :counter="tailleMaxTache"
                    :readonly="crudMode == CrudMode.Read"
                    :maxLength="tailleMaxTache"
                  />
                </v-col>
                <v-col cols="12">
                  <v-text-field
                    label="Commentaire"
                    required
                    v-model="form.commentaire"
                    :rules="commentaireRules"
                    :readonly="crudMode == CrudMode.Read"
                    :counter="tailleMaxCommentaire"
                    :maxLength="tailleMaxCommentaire"
                  />
                </v-col>
              </v-row>
            </v-container>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-btn
            color="blue-darken-1"
            v-show="crudMode === CrudMode.Read"
            variant="text"
            @click="modify()"
          >
            Modifier
          </v-btn>
          <v-spacer></v-spacer>
          <v-btn color="blue-darken-1" variant="text" @click="close()">
            Fermer
          </v-btn>
          <v-btn
            v-show="crudMode !== CrudMode.Read"
            :loading="saveLoading"
            color="blue-darken-1"
            variant="text"
            @click="submit()"
          >
            Sauvegarder
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script setup lang="ts">
import PrestationApi from "@/api/PrestationApi";
import CreateprestationDTO from "@/models/prestation/createPrestationDTO";
import type DetailPrestationDTO from "@/models/prestation/detailPrestationDTO";
import UpdatePrestationDTO from "@/models/prestation/updatePrestationDTO";
import SelectItem from "@/models/Vuetify/SelectItem";
import { useApplicationsStore } from "@/stores/ApplicationStore/ApplicationsStore";
import { useCommanditairesStore } from "@/stores/CommanditaireStore/CommanditairesStore";
import { useModulesStore } from "@/stores/ModuleStore/ModulesStore";
import { usePrestationStore } from "@/stores/PrestationStore/PrestationStore";
import { useNommenclatureStore } from "@/stores/Shared/NommenclatureStore";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { useTypeTachesStore } from "@/stores/TypeTacheStore/EnumerableTypesTacheStore";
import { useUtilisateurStore } from "@/stores/UtilisateurStore/UtilisateurStore";
import { CrudMode } from "@/utils/CrudMode";
import { Rule } from "@/utils/Rules";
import { computed, reactive, ref } from "vue";

const refForm = ref(null as any);
const refInputTime = ref(null as any);
const crudMode = ref(CrudMode.Create);

const commanditaireStore = useCommanditairesStore();
const applicationsStore = useApplicationsStore();
const modulesStore = useModulesStore();
const typeTachesStore = useTypeTachesStore();
const utilisateurStore = useUtilisateurStore();
const prestationStore = usePrestationStore();
const nom = useNommenclatureStore();
const toaster = useNotificationStore();

const dialog = ref(false);
const saveLoading = ref(false);
const fetchLoading = ref(false);

const form = reactive({
  id: "",
  date: "",
  commanditaireId: "",
  applicationId: "",
  moduleId: "",
  tache: "",
  commentaire: "",
  typeTacheId: "",
  temps: "",
  isValid: true,
});

function formReset() {
  form.id = "";
  form.date = prestationStore.dateInitialisationCreationTaQuot;
  form.temps = "";
  if (prestationStore.configuration.resetTypeTache) form.typeTacheId = "";
  if (prestationStore.configuration.resetCommanditaire)
    form.commanditaireId = "";
  if (
    prestationStore.configuration.resetCommanditaire ||
    prestationStore.configuration.resetApplication
  )
    form.applicationId = "";
  if (
    prestationStore.configuration.resetCommanditaire ||
    prestationStore.configuration.resetApplication ||
    prestationStore.configuration.resetModule
  )
    form.moduleId = "";
  form.tache = "";
  form.commentaire = "";
  form.isValid = true;
  refForm.value.resetValidation();
}

const tailleMaxTache = 100;
const tailleMaxCommentaire = 200;

//#region rules
const dateRules = new Rule().required().isDate().build();
const tempsRules = new Rule()
  .required()
  .isNumber()
  .isInteger()
  .isPositive()
  .build();
const typeTacheRules = new Rule().required().build();
const commanditaireRules = new Rule().required().build();
const applicationRule = new Rule().required().build();
const moduleRule = new Rule().required().build();
const commentaireRules = new Rule().maxLength(tailleMaxCommentaire).build();
const tacheRules = new Rule()
  .required()
  .maxLength(tailleMaxCommentaire)
  .build();

//#endregion

const titleText = computed(() => {
  switch (crudMode.value) {
    case CrudMode.Create:
      return `Création d'une tâche quotidienne`;
    case CrudMode.Read:
      return `Lecture d'une tâche quotidienne`;
    case CrudMode.Update:
      return `Modification d'une tâche quotidienne`;
    case CrudMode.Delete:
      return `Suppression d'une tâche quotidienne`;
    default:
      return `TaQuot !`;
  }
});

const commanditairesItems = computed(() =>
  commanditaireStore.commanditaires.map((c) => new SelectItem(c.nom, c.id))
);
const applicationsItems = computed(() =>
  applicationsStore.applications
    .filter((a) => a.commanditaireId === form.commanditaireId)
    .map((a) => new SelectItem(a.libelle, a.id))
);
const moduleItems = computed(() =>
  modulesStore.modules
    .filter((a) => a.applicationId === form.applicationId)
    .map((a) => new SelectItem(a.libelle, a.id))
);
const typetachesItems = computed(() =>
  typeTachesStore.typeTaches.map((t) => new SelectItem(t.libelle, t.id))
);

function resetApplicationId() {
  form.applicationId = "";
  resetModuleId();
}

function resetModuleId() {
  form.moduleId = "";
}

async function submit() {
  await refForm.value?.validate();
  if (!form.isValid) return;

  if (crudMode.value === CrudMode.Create) await create();
  else if (crudMode.value === CrudMode.Update) await update();
}

async function create() {
  saveLoading.value = true;
  try {
    await PrestationApi.postPrestation(formToCreateModel());
    toaster.addSuccess(`Tâche enregistrée`);
    prestationStore.loadPrestations();
    formReset();
  } finally {
    saveLoading.value = false;
    refInputTime.value.focus();
  }
}

async function update() {
  saveLoading.value = true;
  try {
    await PrestationApi.putPrestation(form.id, formToUpdateModel());
    prestationStore.loadPrestations();
    toaster.addSuccess(`Tâche mise à jour`);
  } finally {
    saveLoading.value = false;
    refInputTime.value.focus();
  }
}

const open = async (prestationId = "", openingCrudMode = CrudMode.Read) => {
  dialog.value = true;
  if (prestationId.length === 0) {
    refForm.value?.reset();
    form.date = prestationStore.dateInitialisationCreationTaQuot;
    dialog.value = true;
    crudMode.value = CrudMode.Create;
    refInputTime.value?.focus();
    return;
  }

  fetchLoading.value = true;
  try {
    const resp = await PrestationApi.get(prestationId);
    modelToForm(resp);
    if (openingCrudMode === CrudMode.Create) form.id = "";
    refForm.value.resetValidation();
  } finally {
    crudMode.value = openingCrudMode;
    fetchLoading.value = false;
  }
};

function modify() {
  crudMode.value = CrudMode.Update;
}

function close() {
  emit("close");
  refForm.value.reset();
  crudMode.value = CrudMode.Create;
  dialog.value = false;
}

function calculateTimeFromInput(): number {
  if (prestationStore.configuration.tempsAsInputTypeTime) {
    const hours = parseInt(form.temps.substring(0, 2));
    const minutes = parseInt(form.temps.substring(3));
    return minutes + hours * 60;
  }
  return parseInt(form.temps);
}

function calculateTimeFromModel(temps: number): string {
  if (prestationStore.configuration.tempsAsInputTypeTime) {
    const hours = Math.floor(temps / 60)
      .toString()
      .padStart(2, "0");
    const minutes = (temps % 60).toString().padStart(2, "0");
    return `${hours}:${minutes}`;
  }
  return temps.toString();
}

function formToUpdateModel(): UpdatePrestationDTO {
  const returnValue = new UpdatePrestationDTO();

  returnValue.commentaire = form.commentaire;
  returnValue.tache = form.tache;
  returnValue.date = form.date;
  returnValue.temps = calculateTimeFromInput();
  returnValue.typeTacheId = form.typeTacheId;

  return returnValue;
}

function formToCreateModel(): CreateprestationDTO {
  const returnValue = new CreateprestationDTO();

  returnValue.id = form.id;
  returnValue.commentaire = form.commentaire;
  returnValue.tache = form.tache;
  returnValue.date = form.date;
  returnValue.temps = calculateTimeFromInput();
  returnValue.utilisateur = utilisateurStore.id ?? "ERR";
  returnValue.typeTacheId = form.typeTacheId;
  returnValue.commanditaireId = form.commanditaireId;
  returnValue.applicationId = form.applicationId;
  returnValue.moduleId = form.moduleId;

  return returnValue;
}

function modelToForm(prestation: DetailPrestationDTO) {
  form.id = prestation.id;
  form.commentaire = prestation.commentaire;
  form.tache = prestation.tache;
  form.date = prestation.date.substring(0, 10);
  form.temps = calculateTimeFromModel(prestation.temps);
  form.typeTacheId = prestation.typeTacheId;
  form.commanditaireId = prestation.commanditaireId;
  form.applicationId = prestation.applicationId;
  form.moduleId = prestation.moduleId;
}

const emit = defineEmits(["close"]);
defineExpose({
  open,
});
</script>
