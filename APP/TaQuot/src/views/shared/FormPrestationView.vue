<template>
  <v-row justify="center">
    <v-card width="1500px">
      <v-card-title>
        <span class="text-h5">Prestations journalières</span>
      </v-card-title>
      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12">
              <v-table fixed-header density="compact" class="mb-12">
                <thead>
                  <tr>
                    <th class="text-left" style="width: 16%">Commanditaire</th>
                    <th class="text-left" style="width: 16%">Application</th>
                    <th class="text-left" style="width: 16%">Module</th>
                    <th class="text-left" style="width: 6%">Temps</th>
                    <th class="text-left" style="width: 16%">Type de tâche</th>
                    <th class="text-left" style="width: 26%">Tâche</th>
                    <th class="text-left" style="width: 4%"></th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td class="pa-0 ma-0">
                      <v-select
                        :loading="loading"
                        hide-details
                        class="pa-0 ma-0"
                        density="compact"
                        :items="commanditaireStore.comboxBoxItems"
                        v-model="form.commanditaire"
                      />
                    </td>
                    <td class="pa-0 ma-0">
                      <v-select
                        :loading="loading"
                        hide-details
                        class="pa-0 ma-0"
                        density="compact"
                        :items="applicationsStore.comboxBoxItems"
                        v-model="form.application"
                      />
                    </td>
                    <td class="pa-0 ma-0">
                      <v-select
                        :loading="loading"
                        hide-details
                        class="pa-0 ma-0"
                        density="compact"
                        :items="modulesStore.comboxBoxItems"
                        v-model="form.module"
                      />
                    </td>
                    <td class="pa-0 ma-0">
                      <v-text-field
                        :loading="loading"
                        hide-details
                        class="pa-0 ma-0"
                        density="compact"
                        v-model="form.temps"
                      />
                    </td>
                    <td class="pa-0 ma-0">
                      <v-select
                        :loading="loading"
                        hide-details
                        class="pa-0 ma-0"
                        density="compact"
                        :items="typeTachesStore.comboxBoxItems"
                        v-model="form.typeTache"
                      />
                    </td>
                    <td class="pa-0 ma-0">
                      <v-text-field
                        :loading="loading"
                        hide-details
                        class="pa-0 ma-0"
                        density="compact"
                        v-model="form.tache"
                      />
                    </td>
                    <td class="py-0 my-0">
                      <v-btn
                        :loading="loading"
                        density="compact"
                        icon="mdi-plus-circle"
                        variant="text"
                        color="success"
                        @click="create()"
                      />
                    </td>
                  </tr>
                  <tr
                    v-for="prestation in theDailyWheelStore.prestationJournalieres"
                  >
                    <td>{{ prestation.commanditaire }}</td>
                    <td>{{ prestation.application }}</td>
                    <td>{{ prestation.module }}</td>
                    <td>{{ prestation.temps }}</td>
                    <td>{{ prestation.typeTache }}</td>
                    <td>{{ prestation.tache }}</td>
                    <td class="py-0 my-0">
                      <v-btn
                        :loading="loading"
                        density="compact"
                        icon="mdi-trash-can"
                        variant="text"
                        color="error"
                        @click.stop="deletePrestation($event, prestation)"
                      />
                    </td>
                  </tr>
                </tbody>
              </v-table>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="blue-darken-1" variant="text" @click="emits('close')">
          Close
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-row>
</template>

<script setup lang="ts">
import { onMounted } from "vue";
import { watch } from "vue";
import { computed, reactive, ref } from "vue";
import { useApplicationsStore } from "@/stores/ApplicationStore/ApplicationsStore";
import { useModulesStore } from "@/stores/ModuleStore/ModulesStore";
import { useCommanditairesStore } from "@/stores/CommanditaireStore/CommanditairesStore";
import { useTypeTachesStore } from "@/stores/TypeTacheStore/EnumerableTypesTacheStore";
import { useTheDailyWheelStore } from "@/stores/Widget/TheDailyWheelStore";
import { useUtilisateurStore } from "@/stores/UtilisateurStore/UtilisateurStore";
import type Prestation from "@/models/prestation/prestation";
import api from "@/api/PrestationApi";
import CreateprestationDTO from "@/models/prestation/createPrestationDTO";

const commanditaireStore = useCommanditairesStore();
const applicationsStore = useApplicationsStore();
const modulesStore = useModulesStore();
const typeTachesStore = useTypeTachesStore();
const utilisateurStore = useUtilisateurStore();
const theDailyWheelStore = useTheDailyWheelStore();
const loading = ref(false);

const form = reactive({
  commanditaire: "",
  application: "",
  module: "",
  temps: "",
  typeTache: "",
  tache: "",
});

async function create() {
  try {
    loading.value = true;
    api.postPrestation(formToCreateDTO());
  } finally {
    loading.value = false;
  }
}

function deletePrestation(event: any, prestation: Prestation) {
  console.warn(prestation);
  throw "Not implemented exception";
}

function formToCreateDTO() {
  const dto = new CreateprestationDTO();
  dto.commentaire = "";
  dto.tache = form.tache;
  const today = new Date(Date.now());
  dto.date = `${today.getFullYear()}-${(today.getMonth() + 1)
    .toString()
    .padStart(2, "0")}-${today.getDate().toString().padStart(2, "0")}`;
  dto.temps = parseInt(form.temps);
  dto.utilisateur = utilisateurStore.id ?? "ERR";
  dto.typeTacheId = form.typeTache;
  dto.commanditaireId = form.commanditaire;
  dto.applicationId = form.application;
  dto.moduleId = form.module;
  return dto;
}

onMounted(async () => await initStores());

async function initStores() {
  try {
    loading.value = true;
    await Promise.all([
      commanditaireStore.initialize(),
      applicationsStore.initialize(),
      modulesStore.initialize(),
      typeTachesStore.initialize(),
    ]);
  } finally {
    loading.value = false;
  }
}

const emits = defineEmits(["close"]);
</script>
