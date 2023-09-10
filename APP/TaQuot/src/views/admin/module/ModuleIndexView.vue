<template>
    <v-form v-model="form.isValid">
        <v-container>
          <v-row>
            <v-spacer/>
            <v-col cols="12" md="6" lg="3" class="px-2">
              <v-table fixed-header density="compact" class="mb-12">
                <thead>
                  <tr>
                    <th class="text-left">commanditaire</th>
                    <th class="text-left">application</th>
                    <th class="text-left">module</th>
                  </tr>
                </thead>
                <tbody>
                  
                  <tr v-for="m in moduleTable" :key="m.id">
                    <td>{{ commanditairesStore.GetName( applicationStore.GetCommanditaireId(m.applicationId)) }}</td>
                    <td>{{ applicationStore.GetName(m.applicationId) }}</td>
                    <td>{{ m.libelle }}</td>
                  </tr>
                </tbody>
              </v-table>
            </v-col>
            <v-col cols="12" md="6" lg="3" class="mt-2 px-2" >
                <v-row no-gutters>
                  <v-col cols="12">
                      <v-autocomplete  
                        label="Commanditaire"
                        required :auto="false" 
                        v-model="form.commanditaireId"
                        no-data-text="Pas de clients chargés"
                        :items="commanditairesStore.comboxBoxItems"
                        @update:modelValue="resetApplicationId"
                        />
                  </v-col>  
                  
                  <v-col cols="12">
                    <v-autocomplete 
                      :items="applicationsItems" 
                      label="Application"
                      required 
                      :auto="false" 
                      no-data-text="Pas d'applications chargées" 
                      v-model="form.applicationId"
                    />
                  </v-col>
                  <v-col cols="12">
                    <v-text-field 
                    label="Module"
                    v-model="form.module"
                    />
                  </v-col>
                  <v-col cols="0" md="12"/>
                  <v-col cols="12" md="12">
                    <v-btn 
                    block 
                    color="primary" 
                    @click="ajouterModule()"
                    :loading="loadingCreateModule"
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
import ModuleApi from '@/api/ModuleApi';
import CreateModuleDTO from '@/models/Module/CreateModule';
import SelectItem from '@/models/Vuetify/SelectItem';
import { useApplicationsStore } from '@/stores/ApplicationStore/ApplicationsStore';
import { useCommanditairesStore } from '@/stores/CommanditaireStore/CommanditairesStore';
import { useModulesStore } from '@/stores/ModuleStore/ModulesStore';
import { useNommenclatureStore } from '@/stores/Shared/NommenclatureStore';
import { useNotificationStore } from '@/stores/Shared/ToastStore';
import { computed, onMounted, reactive, ref } from 'vue';
      
  const applicationStore = useApplicationsStore();
  const commanditairesStore = useCommanditairesStore();
  const modulesStore = useModulesStore();
  const nom = useNommenclatureStore();
  const toaster = useNotificationStore();

  const form = reactive({
    commanditaireId : '',
    applicationId : '',
    module: '',
    isValid : true
  });
  

  const loadingModules = ref(false);
  const loadingCreateModule = ref(false);
  const applicationsItems = computed(() => applicationStore.applications.filter(a => a.commanditaireId === form.commanditaireId).map(a => new SelectItem(a.libelle, a.id)))
  
  const moduleTable = computed(() => {
    if(form.applicationId && form.applicationId.length > 0){
      return modulesStore.modules.filter(m => m.applicationId === form.applicationId);
    } else if(form.commanditaireId && form.commanditaireId.length > 0){
      const applicationsId = [...applicationStore.applications.filter(a => a.commanditaireId === form.commanditaireId).map(a => a.id)];
      return modulesStore.modules.filter(m => applicationsId.some(a => a === m.applicationId))
    }
    return modulesStore.modules;
  })

  onMounted(async () => {
    try {
      loadingModules.value = true;
      await initializeStores();
    } finally {
      loadingModules.value = false;
    }
  })

  async function initializeStores(){
    await Promise.all([
        commanditairesStore.initialize(),
        applicationStore.initialize(),
        modulesStore.initialize()
      ]);
  }
  
  async function ajouterModule(){
    try{
      loadingCreateModule.value = true;
      await ModuleApi.postModule(formToCreateModel())
      await initializeStores();
      resetForm();
      toaster.addSuccess(`${nom.moduleCapitalized} créé`);
    } finally {
      loadingCreateModule.value = false;
    }
  }

  function formToCreateModel() : CreateModuleDTO{
    const nouveauModule = new CreateModuleDTO()
    nouveauModule.libelle = form.module;
    nouveauModule.applicationId = form.applicationId;
    nouveauModule.commanditaireId=  form.commanditaireId;
    return nouveauModule;
  }

  function resetForm(): void{
    form.module = '';
    form.applicationId = '';
    form.commanditaireId = '';
    form.isValid = true;
  }
  
  function resetApplicationId() {
    form.applicationId = '';
  }
</script>
      