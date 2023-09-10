<template>
    <v-container>
      <v-row>
        <v-spacer/>
        <v-col cols="12" md="6" lg="2">
          <v-table fixed-header density="compact" class="mb-12">
            <thead>
              <tr>
                <th class="text-left">commanditaire</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="c in commanditairesStore.commanditaires" :key="c.id">
                <td>{{ c.nom }}</td>
              </tr>
            </tbody>
          </v-table>
        </v-col>
        <v-col cols="12" md="4" lg="2" class="mt-2">
          <v-row no-gutters>
            <v-col cols="12" md="12">
              <v-text-field 
              label="Commanditaire"
              v-model="newCommanditaire"
              />
            </v-col>
            <v-col cols="12" md="12">
              <v-btn 
                block 
                color="primary" 
                @click="ajouterCommanditaire()"
                :loading="loadingCreateCommanditaires"
              > Ajouter
              </v-btn>
            </v-col>
          </v-row>
        </v-col>
        <v-spacer/>
      </v-row>
    </v-container>
  </template>
  
  
  <script setup lang="ts">
  import CommanditaireApi from '@/api/CommanditaireApi';
  import CommanditaireDTO from '@/models/Commanditaire/Commanditaire';
  import { useCommanditairesStore } from '@/stores/CommanditaireStore/CommanditairesStore';
import { useNommenclatureStore } from '@/stores/Shared/NommenclatureStore';
import { useNotificationStore } from '@/stores/Shared/ToastStore';
  import { onMounted, ref } from 'vue';
  
  const nom = useNommenclatureStore();
  const toaster = useNotificationStore();
  const commanditairesStore = useCommanditairesStore();

  const newCommanditaire = ref('');
  const loadingCommanditaires = ref(false);
  const loadingCreateCommanditaires = ref(false);
  
  onMounted(async () => {
    try {
      loadingCommanditaires.value = true;
      await commanditairesStore.initialize();
    } finally {
      loadingCommanditaires.value = false;
    }
  })
  
  async function ajouterCommanditaire(){
    if(newCommanditaire.value === '')
      return;
    try{
      loadingCreateCommanditaires.value = true;
      let nouveauCommanditaire = new CommanditaireDTO()
      nouveauCommanditaire.nom = newCommanditaire.value;
      await CommanditaireApi.postCommanditaire(nouveauCommanditaire)
      toaster.addSuccess(`${nom.commanditaireCapitalized} créé`);
      newCommanditaire.value = '';
      commanditairesStore.initialize();
    } finally {
      loadingCreateCommanditaires.value = false;
    }
  }
  </script>
  