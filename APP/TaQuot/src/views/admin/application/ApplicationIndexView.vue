<template>
<v-form v-model="form.isValid">
    <v-container>
      <v-row>
        <v-spacer/>
        <v-col cols="12" md="6" lg="3" class="px-2">
          <v-table fixed-header density="compact" class="mb-12">
            <thead>
              <tr>
                <th class="text-left">{{ nom.commanditaireCapitalized }}</th>
                <th class="text-left">{{nom.applicationCapitalized}}</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="a in applicationStore.applicationList" :key="a.id">
                <td>{{ commanditairesStore.GetName( a.commanditaireId) }}</td>
                <td>{{ a.libelle }}</td>
              </tr>
            </tbody>
          </v-table>
        </v-col>
        <v-col cols="12" md="6" lg="3" class="mt-2 px-2" >
            <v-row no-gutters>
              <v-col cols="12" md="6" class="px-2">
                  <v-autocomplete  
                    label="Commanditaire"
                    required :auto="false" 
                    v-model="form.commanditaireId"
                    no-data-text="Pas de clients chargés"
                    :items="commanditairesStore.comboxBoxItems"
                    />
              </v-col>  
              <v-col cols="12" md="6" class="px-2">
                  <v-text-field 
                  label="Application"
                  v-model="form.application"
                  />
                </v-col>
                <v-col cols="0" md="12"/>
                <v-col cols="12" md="12" class="px-2">
                  <v-btn 
                  block 
                  color="primary" 
                  @click="ajouterApplication()"
                  :loading="loadingCreateApplication"
                  > Ajouter
                </v-btn>
              </v-col>
            </v-row>
          </v-col>
          <v-spacer/>
        </v-row>
      </v-container>
    </v-form>
  </template>
  
  
  <script setup lang="ts">
import ApplicationApi from '@/api/ApplicationApi';
import ApplicationDTO from '@/models/Application/Application';
import { useApplicationsStore } from '@/stores/ApplicationStore/ApplicationsStore';
import { useCommanditairesStore } from '@/stores/CommanditaireStore/CommanditairesStore';
import { useNommenclatureStore } from '@/stores/Shared/NommenclatureStore';
import { useNotificationStore } from '@/stores/Shared/ToastStore';
import { onMounted, reactive, ref } from 'vue';
  
  const applicationStore = useApplicationsStore();
  const commanditairesStore = useCommanditairesStore();
  const toaster = useNotificationStore();
  const nom = useNommenclatureStore();

  const form = reactive({
    commanditaireId : '',
    application : '',
    isValid : true
  });
  

  const loadingApplications = ref(false);
  const loadingCreateApplication = ref(false);
  
  onMounted(async () => {
    try {
      loadingApplications.value = true;
      await initializeStores();
    } finally {
      loadingApplications.value = false;
    }
  })

  async function initializeStores(){
    await Promise.all([
        commanditairesStore.initialize(),
        applicationStore.initialize()
      ]);
  }
  
  async function ajouterApplication(){
    try{
      loadingCreateApplication.value = true;
      await ApplicationApi.postApplication(formToCreateModel())
      await initializeStores();
      resetForm();
      toaster.addSuccess(`${nom.applicationCapitalized} crée`)
    }finally{
      loadingCreateApplication.value = false;
    }
  }

  function formToCreateModel() : ApplicationDTO{
    const nouvelleApplication = new ApplicationDTO()
    nouvelleApplication.libelle = form.application;
    nouvelleApplication.commanditaireId = form.commanditaireId;
    return nouvelleApplication;
  }

  function resetForm(): void{
    form.application = '';
    form.commanditaireId = '';
  }
  </script>
  