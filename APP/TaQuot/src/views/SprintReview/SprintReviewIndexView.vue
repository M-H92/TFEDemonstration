<template>
  <v-container>
    <v-row>
      <v-col cols="1"/>
      <v-col cols="10">
        <v-form v-model="form.isValid" validate-on="blur">
          <v-row>
            <v-col cols="5">
              <v-combobox
                multiple
                label="Collaborateurs"
                chips
                clearable
                v-model="form.selectedCollaborateurs"
                :items="store.collaborateurs"
                autofocus
                closable-chips
                :rules="rules.collaborateurs"
              />
            </v-col>
            <v-col cols="2">
              <v-text-field
                type="Date"
                label="Début"
                v-model="form.dateDebut"
                :rules="rules.date"
                @blur="onDateChange"
              />
            </v-col>
            <v-col cols="2">
              <v-text-field
                type="Date"
                label="Fin"
                v-model="form.dateFin"
                :rules="rules.date"
                @blur="onDateChange"
              />
            </v-col>
            <v-spacer/>
            <v-col cols="1">
              <v-btn
                block
                color="primary"
                @click="analyze"
                :loading="store.isLoading"
                :disabled="store.isLoading"
              >
                Analyser
              </v-btn>
            </v-col>
          </v-row>
        </v-form>
      </v-col>
      <v-col cols="1"/>
    </v-row>
    <v-row>
      <v-col cols="1"/>
      <v-col cols="10">
        <v-table fixed-header density="compact" height="600px">
          <thead>
            <tr>
              <th class="text-left">Tâche</th>
              <th v-for="collaborateur in sortedCollaborateurs" class="text-left">
                {{ collaborateur }}
              </th>
              <th class="text-left">Total</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="sprintReviewStat in store.sprintReviewStats">
              <td>{{sprintReviewStat.label}}</td>
              <td v-for="collaborateur in sortedCollaborateurs">
                {{ sprintReviewStat.getTimeForCollaborateur(collaborateur) }}
              </td>
              <td>
                {{ sprintReviewStat.getTotalTime() }}
              </td>
            </tr>
          </tbody>
        </v-table>
      </v-col>
      <v-col cols="1"/>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ParamsGetSprintReviewStatDTO } from "@/models/SprintReview/ParamsGetSprintReviewStat";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { useSprintReviewStore } from "@/stores/SprintReview/SprintReviewStore";
import { Rule } from "@/utils/Rules";
import { computed, onMounted, reactive, ref } from "vue";

const store = useSprintReviewStore();
const toaster = useNotificationStore()

const form = reactive({
  selectedCollaborateurs: [] as string[],
  dateDebut: '',
  dateFin: '',
  isValid: true
})

const rules = {
  date : new Rule()
    .required()
    .isDate()
    .build(),
  collaborateurs : new Rule()
    .required()
    .isArray(false)
    .build(),
};


const sortedCollaborateurs = computed(() => store.selectedCollaborateurs.sort());

function onDateChange(){
  if(form.dateDebut !== '' && form.dateFin !== '') {
    validateBothDates();
  }
}

function validateBothDates(){
  let toastMessage = '';
  const dateDebut = new Date(form.dateDebut);
  if(form.dateDebut === '' || form.dateFin === ''){
    toastMessage = `Date de début et fin d'analyse requises`
  }else if(dateDebut.getTime() >=  new Date(form.dateFin).getTime()){
    toastMessage  = `La date de début d'analyse doit être inférieure à la date de fin d'analyse`;
  } else if(dateDebut.getTime() >= new Date().getTime()){
    toastMessage = `La date de début d'analyse doit être inférieure à la date du jour`;
  } else {
    return true;
  }
  toaster.addError(toastMessage);
  return false;
}

async function analyze(){
  if(!validateBothDates()) return;
  if(!form.isValid) return;
  await store.analyze(formToDTO());
}

function formToDTO():ParamsGetSprintReviewStatDTO{
  const dto = new ParamsGetSprintReviewStatDTO();
  dto.collaborateurs = form.selectedCollaborateurs;
  dto.dateDebut = form.dateDebut;
  dto.dateFin = form.dateFin;
  return dto;
}

  onMounted(async () => {
    await store.initialize();
  });

</script>
