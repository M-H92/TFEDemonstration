<template>
  <v-container>
    <v-row>
      <v-col cols="1"></v-col>
      <v-col cols="10">
        <v-table fixed-header density="compact" class="mb-12">
          <thead>
            <tr>
              <th class="text-left" style="width: 30%">Commanditaire</th>
              <th class="text-left" style="width: 30%">Type de tâche</th>
              <th class="text-left" style="width: 30%">Statut par défaut</th>
              <th class="text-left" style="width: 5%"></th>
              <th class="text-left" style="width: 5%"></th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td class="pa-0 ma-0">
                <v-select
                  :loading="store.loading"
                  hide-details
                  class="pa-0 ma-0"
                  density="compact"
                  :items="store.commanditaires"
                  v-model="form.commanditaire"
                  clearable
                  @update:model-value="reloadTable()"
                />
              </td>
              <td class="pa-0 ma-0">
                <v-select
                  :loading="store.loading"
                  hide-details
                  class="pa-0 ma-0"
                  density="compact"
                  :items="store.typeTache"
                  v-model="form.typeTache"
                  clearable
                  @update:model-value="reloadTable()"
                />
              </td>
              <td class="pa-0 ma-0">
                <v-select
                  :loading="store.loading"
                  hide-details
                  class="pa-0 ma-0"
                  density="compact"
                  :items="store.statut"
                  v-model="form.statutDefaut"
                  clearable
                  @update:model-value="reloadTable()"
                />
              </td>
              <td class="py-0 my-0">
                <v-btn
                  :loading="store.loading"
                  density="compact"
                  icon="mdi-plus-circle"
                  variant="text"
                  color="success"
                  @click="create()"
                />
              </td>
              <td class="py-0 my-0">
                <v-btn
                  :loading="store.loading"
                  density="compact"
                  icon="mdi-close-circle"
                  variant="text"
                  color="error"
                  @click.stop="resetForm()"
                />
              </td>
            </tr>
            <tr v-for="(pm, index) in store.parametresFacturations">
              <td class="py-0 my-0">
                {{ labelCommanditaire(pm.commanditaireId) }}
              </td>
              <td class="py-0 my-0">
                {{ labelTypeTache(pm.typeTacheId) }}
              </td>
              <td class="pa-0 ma-0">
                <v-select
                  :loading="store.loading"
                  class="pa-0 ma-0"
                  density="compact"
                  :items="store.statut"
                  v-model="pm.statutDefautId"
                  hide-details
                />
              </td>
              <td class="py-0 my-0">
                <v-btn
                  :loading="store.loading"
                  density="compact"
                  icon="mdi-note-edit"
                  variant="text"
                  color="primary"
                  @click.stop="update($event, pm)"
                />
              </td>
              <td class="py-0 my-0">
                <v-btn
                  :loading="store.loading"
                  density="compact"
                  icon="mdi-trash-can"
                  variant="text"
                  color="error"
                  @click.stop="deleteParam($event, pm)"
                />
              </td>
            </tr>
          </tbody>
        </v-table>
      </v-col>
      <v-col cols="1"></v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { onMounted, reactive } from "vue";

import { useParametresFacturationStore } from "@/stores/params/parametresFacturation/ParametresFacturationStore";
import ParametresFacturationDTO from "@/models/Params/ParametresFacturation";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import ParametresCommanditaireTypeTacheStatutGet from "@/models/Params/ParametresCommanditaireTypeTacheStatutGet";

const store = useParametresFacturationStore();
const toaster = useNotificationStore();

const form = reactive({
  commanditaire: "",
  typeTache: "",
  statutDefaut: "",
});

onMounted(async () => {
  await store.initialize();
});

async function create() {
  const dto = new ParametresFacturationDTO();
  dto.commanditaireId = form.commanditaire;
  dto.typeTacheId = form.typeTache;
  dto.statutDefautId = form.statutDefaut;
  await store.create(dto);
  toaster.addSuccess("Paramètre créé");
}

async function update(event: any, param: ParametresFacturationDTO) {
  await store.update(param);
  toaster.addSuccess("Paramètre mis à jour");
}

async function deleteParam(event: any, param: ParametresFacturationDTO) {
  await store.delete(param);
  toaster.addSuccess("Paramètre supprimé");
}

async function reloadTable() {
  const paginationParameter = new ParametresCommanditaireTypeTacheStatutGet();
  paginationParameter.commanditaireId = form.commanditaire;
  paginationParameter.typeTacheId = form.typeTache;
  paginationParameter.statutDefautId = form.statutDefaut;
  paginationParameter.skip = 0;
  paginationParameter.take = 10;
  store.loadParams(paginationParameter);
}

async function resetForm() {
  form.commanditaire = "";
  form.typeTache = "";
  form.statutDefaut = "";
  reloadTable();
}

function labelCommanditaire(id: string) {
  return (
    store.commanditaires.find((c) => c.value.toUpperCase() === id.toUpperCase())
      ?.title ?? "ERR"
  );
}

function labelTypeTache(id: string) {
  return (
    store.typeTache.find((c) => c.value.toUpperCase() === id.toUpperCase())
      ?.title ?? "ERR"
  );
}
</script>
