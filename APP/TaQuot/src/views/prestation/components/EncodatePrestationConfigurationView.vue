<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent width="400">
      <template v-slot:activator="{ props }">
        <v-btn color="primary" block v-bind="props" @click="open()">
          Configuration
        </v-btn>
      </template>
      <v-card>
        <v-card-title class="pt-5">
          <span class="text-h5">
            Paramètres de l'encodage
            <v-progress-circular
              v-show="fetchLoading"
              color="teal"
              indeterminate
            />
          </span>
        </v-card-title>
        <v-card-text>
          <v-form v-model="form.isValid" ref="refForm">
            <v-container class="px-12">
              <v-row v-show="!fetchLoading">
                <v-col cols="12">
                  <v-checkbox
                    color="primary"
                    density="compact"
                    hide-details
                    class="my-0 py-0"
                    v-model="form.initAtLastDate"
                    label="Dernière date"
                    append-icon="mdi-information"
                  />
                  <v-checkbox
                    color="primary"
                    density="compact"
                    hide-details
                    class="my-0 py-0"
                    v-model="form.tempsAsInputTypeTime"
                    label="Format temps hh:mm"
                    append-icon="mdi-information"
                  />
                  <v-checkbox
                    color="primary"
                    density="compact"
                    hide-details
                    class="my-0 py-0"
                    v-model="form.resetTypeTache"
                    label="Reset type de tâches"
                    append-icon="mdi-information"
                  />
                  <v-checkbox
                    color="primary"
                    density="compact"
                    hide-details
                    class="my-0 py-0"
                    v-model="form.resetCommanditaire"
                    label="Reset commanditaire"
                    append-icon="mdi-information"
                    @change="onResetCommanditaireChange()"
                  />
                  <v-checkbox
                    :disabled="form.resetCommanditaire"
                    color="primary"
                    density="compact"
                    hide-details
                    class="my-0 py-0"
                    v-model="form.resetApplication"
                    label="Reset application"
                    append-icon="mdi-information"
                    @change="onResetApplicationChange()"
                  />
                  <v-checkbox
                    :disabled="form.resetApplication"
                    color="primary"
                    density="compact"
                    hide-details
                    class="my-0 py-0"
                    v-model="form.resetModule"
                    label="Reset module"
                    append-icon="mdi-information"
                  />
                </v-col>
              </v-row>
            </v-container>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-btn color="blue-darken-1" variant="text" @click="close()">
            Fermer
          </v-btn>
          <v-spacer></v-spacer>
          <v-btn
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
import UpdateConfigurationDTO from "@/models/prestation/updateConfigurationDTO";
import { usePrestationStore } from "@/stores/PrestationStore/PrestationStore";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { useUtilisateurStore } from "@/stores/UtilisateurStore/UtilisateurStore";
import { reactive, ref } from "vue";

const refForm = ref(null as any);

const utilisateurStore = useUtilisateurStore();
const prestationStore = usePrestationStore();
const toaster = useNotificationStore();

const dialog = ref(false);
const saveLoading = ref(false);
const fetchLoading = ref(false);

function onResetCommanditaireChange() {
  if (form.resetCommanditaire) {
    form.resetApplication = true;
    onResetApplicationChange();
  }
}

function onResetApplicationChange() {
  if (form.resetApplication) {
    form.resetModule = true;
  }
}

const form = reactive({
  resetTypeTache: false,
  resetCommanditaire: false,
  resetApplication: false,
  resetModule: false,
  initAtLastDate: false,
  tempsAsInputTypeTime: false,
  isValid: true,
});

async function submit() {
  await refForm.value?.validate();
  if (!form.isValid) return;

  await update();
  close();
}

async function update() {
  saveLoading.value = true;
  try {
    const configuration = formToUpdateModel();
    await PrestationApi.putConfiguration(configuration);
    prestationStore.setConfiguration(configuration);
    prestationStore.loadPrestations();
    toaster.addSuccess(`Configuration mise à jour`);
  } finally {
    saveLoading.value = false;
  }
}

const open = async () => {
  initFormValuesFromStore();
};

function close() {
  emit("close");
  refForm.value.reset();
  dialog.value = false;
}

function formToUpdateModel(): UpdateConfigurationDTO {
  const returnValue = new UpdateConfigurationDTO();

  returnValue.user = utilisateurStore.id;
  returnValue.resetTypeTache = form.resetTypeTache;
  returnValue.resetCommanditaire = form.resetCommanditaire;
  returnValue.resetApplication = form.resetApplication;
  returnValue.resetModule = form.resetModule;
  returnValue.initAtLastDate = form.initAtLastDate;
  returnValue.tempsAsInputTypeTime = form.tempsAsInputTypeTime;

  return returnValue;
}

function initFormValuesFromStore() {
  form.resetTypeTache = prestationStore.configuration.resetTypeTache;
  form.resetCommanditaire = prestationStore.configuration.resetCommanditaire;
  form.resetApplication = prestationStore.configuration.resetApplication;
  form.resetModule = prestationStore.configuration.resetModule;
  form.initAtLastDate = prestationStore.configuration.initAtLastDate;
  form.tempsAsInputTypeTime =
    prestationStore.configuration.tempsAsInputTypeTime;
  form.isValid = true;
}

const emit = defineEmits(["close"]);
defineExpose({
  open,
});
</script>
