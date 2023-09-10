<template>
  <v-container>
    <v-row>
      <v-col cols="1"></v-col>
      <v-col cols="10">
        <v-form v-model="form.isValid" validate-on="blur">
          <v-row>
            <v-col cols="2"> <v-text-field type="date" @change="onDateChange" :readonly="canExport || store.loading" :rules="rules.date" v-model="form.dateDebut" label="Date de début"/> </v-col>
            <v-col cols="2"> <v-text-field type="date" @change="onDateChange" :readonly="canExport || store.loading" :rules="rules.date" v-model="form.dateFin" label="Date de fin"/> </v-col>
            <v-col v-if="!canExport" cols="2"> <v-btn :loading="store.loading" size="large" class="my-2" block color="primary" @click="onChargerClicked" :disabled="canExport" >Charger</v-btn> </v-col>
            <v-col v-if="canExport" cols="2"> <v-btn :loading="store.loading" size="large" class="my-2" block color="warning" @click="reset" :disabled="!canExport">Réinitialiser</v-btn> </v-col>
            <v-col cols="2"> <v-btn :loading="store.loading" size="large" class="my-2" block color="success" @click="onExporterClicked" :disabled="!canExport">Exporter</v-btn> </v-col>
          </v-row>
        </v-form>
        <v-row>
          <v-col cols="12">
            <v-table fixed-header density="compact" max-height="600px">
              <thead>
                <tr>
                  <th class="text-left">Commanditaire</th>
                  <th class="text-left">Application</th>
                  <th class="text-left">Module</th>
                  <th class="text-left">Tâche</th>
                  <th class="text-left">Type de tâche</th>
                  <th class="text-left">Temps</th>
                  <th class="text-left">Facturable</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="facturable in store.ligneFacturables" :style="rowColor(facturable.statutId)">
                  <td>{{ facturable.commanditaire }}</td>
                  <td>{{ facturable.application }}</td>
                  <td>{{ facturable.module }}</td>
                  <td>{{ facturable.tache }}</td>
                  <td>{{ facturable.typeTache }}</td>
                  <td>{{ facturable.timeSpent }}</td>
                  <td  style="width: 175px;" class="pa-0 ma-0">
                    <v-select
                      density="compact"
                      :items="storeStatut.comboxBoxItems"
                      v-model="facturable.statutId"
                      hide-details
                      class="pa-0 ma-0"
                    />
                  </td>
                </tr>
              </tbody>
            </v-table>
          </v-col>
        </v-row>
      </v-col>
      <v-col cols="1"></v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ExportableLigneFacturable } from "@/models/Facturation/ExportableLigneFacturable";
import { useFacturationStore } from "@/stores/FacturationStore/FacturationStore";
import { useStatutStore } from "@/stores/Shared/StatutStore";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { Rule } from "@/utils/Rules";
import { onMounted, reactive, ref } from "vue";

const store = useFacturationStore();
const storeStatut = useStatutStore();
const toaster = useNotificationStore();

const form = reactive({
  dateDebut : '',
  dateFin : '',
  isValid: true
})

const canExport = ref(false);

const rules = {
  date : new Rule()
    .required()
    .isDate()
    .build(),
};

function onDateChange(){
  if(form.dateDebut !== '' && form.dateFin !== '') {
    validateBothDates();
  }
}

function validateBothDates(){
  let toastMessage = '';
  if(form.dateDebut === '' || form.dateFin === ''){
    toastMessage = `Date de début et fin requises`
  }else if(new Date(form.dateDebut).getTime() >=  new Date(form.dateFin).getTime()){
    toastMessage  = `La date de début doit être inférieure à la date de fin`;
  } else {
    return true;
  }
  toaster.addError(toastMessage);
  return false;
}

function onChargerClicked(){
  if(!validateBothDates()) return;
  canExport.value = true;
  store.charger(form.dateDebut, form.dateFin)
}

async function onExporterClicked(){
  if(!validateBothDates()) {
    toaster.addWarning(`Veuillez recharger la période comptable souhaitée`);
    return;
  }

  const exportableLigneFacturable = new ExportableLigneFacturable();
  exportableLigneFacturable.addLignesFacturables(store.ligneFacturables);
  exportableLigneFacturable.dateDebut = form.dateDebut;
  exportableLigneFacturable.dateFin = form.dateFin;

  const resp = await store.exporter(exportableLigneFacturable);
  const href = URL.createObjectURL(resp.data);
  const link = document.createElement('a');
  link.href = href;
  link.setAttribute('download', `${form.dateDebut}facturable`);
  document.body.appendChild(link);
  link.click();
  document.body.removeChild(link);
  URL.revokeObjectURL(href);
  reset();
}

onMounted(async () => {
  await storeStatut.initialize();
});

async function reset(){
  store.$reset();
  const promise = storeStatut.initialize();
  form.dateDebut = '';
  form.dateFin = '';
  form.isValid = true;
  await promise;
  canExport.value = false;
}

function rowColor(a : string){ 
  if(a.toUpperCase() == "A6209F00-E501-4A7C-9CBB-8FF410E9FBF7") return 'background-color: #E8F5E9' //facturable 
  if(a.toUpperCase() == "4CFE1B05-A5DC-4C46-B9BC-288835116C0C") return 'background-color: #FFEBEE' //non facturable
  return ''
}
</script>
