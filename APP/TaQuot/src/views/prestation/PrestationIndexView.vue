<template>
  <v-container>
    <v-row>
      <v-col cols="11"></v-col>
      <v-col cols="1">
        <EncodagePrestationCOnfigurationView />
      </v-col>
      <v-col cols="12">
        <v-table fixed-header density="compact" height="600px">
          <thead>
            <tr>
              <th></th>
              <th class="text-left">Date</th>
              <th class="text-left">Temps (min)</th>
              <th class="text-left">{{ nom.commanditaireCapitalized }}</th>
              <th class="text-left">{{ nom.applicationCapitalized }}</th>
              <th class="text-left">{{ nom.moduleCapitalized }}</th>
              <th class="text-left">{{ nom.tacheCapitalized }}</th>
              <th class="text-left">Commentaire</th>
              <th class="text-left">Type tache</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="pr in prestationStore.prestationsPaginated"
              :key="pr.id"
              @click="openModify($event, pr.id)"
            >
              <td @click.stop>
                <input
                  type="checkbox"
                  :value="pr.id"
                  v-model="selectedPrestations"
                />
              </td>
              <td>{{ pr.formatedDate }}</td>
              <td>{{ pr.temps }}</td>
              <td>{{ pr.commanditaire }}</td>
              <td>{{ pr.application }}</td>
              <td>{{ pr.module }}</td>
              <td>{{ pr.tache }}</td>
              <td>{{ pr.commentaire }}</td>
              <td>{{ pr.typeTache }}</td>
              <td>
                <v-btn
                  density="compact"
                  icon="mdi-content-duplicate"
                  variant="text"
                  color="primary"
                  @click.stop="openDuplicate($event, pr.id)"
                />
              </td>
            </tr>
          </tbody>
        </v-table>
      </v-col>
      <v-col cols="3">
        <v-btn block color="error" @click="deleteSelection()">Supprimer</v-btn>
      </v-col>
      <v-spacer />
      <v-col cols="3">
        <DetailPrestationView
          :display-btn="true"
          ref="refDetailPrestationView"
          @close="prestationStore.loadPrestations()"
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import PrestationApi from "@/api/PrestationApi";
import { useApplicationsStore } from "@/stores/ApplicationStore/ApplicationsStore";
import { useCommanditairesStore } from "@/stores/CommanditaireStore/CommanditairesStore";
import { useModulesStore } from "@/stores/ModuleStore/ModulesStore";
import { usePrestationStore } from "@/stores/PrestationStore/PrestationStore";
import { useTypeTachesStore } from "@/stores/TypeTacheStore/EnumerableTypesTacheStore";
import { CrudMode } from "@/utils/CrudMode";
import { onMounted, ref } from "vue";
import DetailPrestationView from "./components/DetailPrestationView.vue";
import EncodagePrestationCOnfigurationView from "./components/EncodatePrestationConfigurationView.vue";
import { useNommenclatureStore } from "@/stores/Shared/NommenclatureStore";
import { useNotificationStore } from "@/stores/Shared/ToastStore";

const refDetailPrestationView = ref(null as null | any);

const typeTachesStore = useTypeTachesStore();
const commanditairesStore = useCommanditairesStore();
const applicationsStore = useApplicationsStore();
const modulesStore = useModulesStore();
const prestationStore = usePrestationStore();
const nom = useNommenclatureStore();
const toaster = useNotificationStore();

const selectedPrestations = ref([] as string[]);
const loadingPrestations = ref(false);

onMounted(async () => {
  try {
    loadingPrestations.value = true;
    typeTachesStore.initialize();
    commanditairesStore.initialize();
    applicationsStore.initialize();
    modulesStore.initialize();
    await prestationStore.initialize();
  } finally {
    loadingPrestations.value = false;
  }
});

async function deleteSelection() {
  try {
    const awaitables = [] as Promise<any>[];
    selectedPrestations.value.forEach((v) => {
      awaitables.push(PrestationApi.deletePrestations(v));
    });
    await Promise.all(awaitables);
    await prestationStore.loadPrestations();
    toaster.addSuccess(`Tâche(s) supprimée(s)`);
  } finally {
    console.log("finally");
  }
}

function openDetails(event: any, clickedPrestationId: string) {
  refDetailPrestationView.value?.open(clickedPrestationId, CrudMode.Read);
}

function openModify(event: any, clickedPrestationId: string) {
  refDetailPrestationView.value?.open(clickedPrestationId, CrudMode.Update);
}

function openDuplicate(event: any, clickedPrestationId: string) {
  refDetailPrestationView.value?.open(clickedPrestationId, CrudMode.Create);
}
</script>
