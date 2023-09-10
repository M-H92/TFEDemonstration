<template>
    <v-container>
      <v-row>
        <v-col cols="1"></v-col>
        <v-col cols="10">
          <v-row>
            <v-col cols="2">
              <v-btn
                block
                color="primary"
                @click="onPrecedentClicked"
                v-show="showPrecedentBtn"
              >
                Précédent
              </v-btn>
            </v-col>
            <v-spacer/>
            <v-col cols="4">
              <h1>{{ monthDisplay }} - {{ store.joursPrestes }} jours ({{ store.totalTime }} minutes)</h1>
            </v-col>
            <v-spacer/>
            <v-col cols="2">
              <v-btn
                block
                color="primary"
                @click="onSuivantClicked"
                v-show="showSuivantBtn"
              >
                Précédent
              </v-btn>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12">
              <v-table fixed-header density="compact" height="600px">
                <thead>
                  <tr>
                    <th class="text-left">Type de tâche</th>
                    <th v-for="collab in store.collaborateurs" class="text-left">{{ collab }}</th>
                    <th class="text-left">Total</th>
                    <th>%</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="stat in store.typeTacheStats">
                    <td>{{stat.label}}</td>
                    <td v-for="collab in store.collaborateurs">{{stat.getTimeForCollaborateur(collab)}}</td>
                    <td>{{ stat.getTotalTime() }}</td>
                    <td>{{ stat.getTotalTime() === 0 ? 0 :((stat.getTotalTime()/store.totalTime)*100).toFixed(2) }}</td>
                  </tr>
                  <tr>
                    <td>Totaux</td>
                    <td v-for="collab in store.collaborateurs">{{ TotalTimePerCollaborateur(collab) }}</td>
                    <td>{{ store.totalTime }}</td>
                    
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
  import { useRecapDetailleStore } from "@/stores/RecapDetailleStore/RecapDetailleStore";
  import { onMounted } from "vue";
import type CollaborateurTime from "@/models/SprintReview/CollaborateurTime";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { computed } from "vue";
  
  const store = useRecapDetailleStore();
  const toaster = useNotificationStore();

    onMounted(async () => {
      await store.initialize();
      await store.analyze();
    });

    function TotalTimePerCollaborateur(collab : string){
      const collaborateurTime = [] as CollaborateurTime[];
      store.typeTacheStats.forEach(a => collaborateurTime.push(...a.collaborateurTimes));
      if(collaborateurTime.length === 0) return 0;
      const spentTime = collaborateurTime?.filter(a => a.collaborateur.toUpperCase() === collab.toUpperCase())
        ?.map(a => a.spentTime);
      return spentTime.length > 0 ? spentTime.reduce((a,b) => a+b) : 0
    }

    function onPrecedentClicked(){
      if(!showPrecedentBtn){
        toaster.addWarning(`Impossible de remonter plus loin`);
        return;
      }

      analyze(1);
    }
    function onSuivantClicked(){
      if(!showSuivantBtn){
        toaster.addWarning(`Impossible de voir le futur`);
        return;
      }

      analyze(-1);
    }
    function analyze(offset = 0){
      store.backwardMonths += offset;
      store.analyze();
    }

    const monthDisplay = computed(() => {
      const format = Intl.DateTimeFormat('fr-FR', {month : 'long'}).format;
      const today = new Date();
      const analyzedDate = new Date(`${today.getFullYear()}-${today.getMonth() - (store.backwardMonths%12) + 1}-01`);
      today.getMonth()
      return format(analyzedDate);
    });

    const showPrecedentBtn = computed(() =>  store.backwardMonths !== (new Date()).getMonth())
    const showSuivantBtn = computed(() =>  store.backwardMonths !== 0)
  
  </script>
  