<template>
  <v-window-item
      key="droit"
      value="droit"
  >
    <v-card
    class="pt-5"
    flat
    >
    <v-card-text> 
      <v-row>
        <v-col cols="12">
          <v-select
            label="Rôles"
            :items="storeDroit.comboxBoxItemsRoles"
            v-model="selectedRole"
          />
        </v-col>
        <v-col cols="6">
          <v-select
            label="Collaborateurs"
            :items="storeDroit.comboxBoxItemsCollab"
            multiple
            clearable
            v-model="selectedCollab"
          />
        </v-col>
        <v-col cols="3"><v-btn  class="mt-1" size="large" color="error" block  :disabled="loading" :loading="loading" @click="deleteRole">Retirer</v-btn></v-col>
        <v-col cols="3"><v-btn  class="mt-1" size="large" color="primary" block  :disabled="loading" :loading="loading" @click="addRole">Ajouter</v-btn></v-col>
        <v-col cols="12">
          <v-btn  
            v-for="collab in storeDroit.collaborateurs" :key="collab.collaborateur" 
            rounded="0" 
            size="x-large" 
            variant="text"  
            width="95px" 
            :class="isSelected(collab.collaborateur) ? `bg-blue-lighten-4` : collab.hasRole(selectedRole) ? `bg-green-lighten-4` : ``"
            @click="selectCollaborateur(collab.collaborateur)"
          > {{ collab.collaborateur }}</v-btn>
        </v-col>
      </v-row>
    </v-card-text>
    </v-card>
  </v-window-item>
</template>
        
<script setup lang="ts">
import CreateCollaborateursRolesDTO from '@/models/Admin/Droits/CreateCollaborateurRoleDTO';
import { useNotificationStore } from '@/stores/Shared/ToastStore';
import { useAdminDroitStoreStore } from '@/stores/admin/DroitsStore';
import { computed, onMounted, reactive, ref } from 'vue';
      
const storeDroit = useAdminDroitStoreStore();
const toaster = useNotificationStore();
const loading = ref(false);

const selectedRole = ref('');
const selectedCollab = ref([] as string[]);

async function addRole(){
    loading.value = true;
    try {
      await storeDroit.addRole(getCreateCollaborateursRolesDTO());
      resetInputs();
      toaster.addSuccess(`Role(s) mis à jour `);
    } finally {
      loading.value = false;
    }
  }

  async function deleteRole(){
    loading.value = true;
    try {
      await storeDroit.deleteRolesCollaborateurs(getCreateCollaborateursRolesDTO());
      resetInputs();
      toaster.addSuccess(`Role(s) mis à jour `);
    } finally {
      loading.value = false;
    }
  }

  async function resetInputs(){
    selectedCollab.value.splice(0,selectedCollab.value.length);
    selectedRole.value = '';
  }

  function getCreateCollaborateursRolesDTO() : CreateCollaborateursRolesDTO{
    const collabRole = new CreateCollaborateursRolesDTO();
    collabRole.collaborateurs = [...selectedCollab.value];
    collabRole.roles = [selectedRole.value];
    return collabRole;
  }

  function isSelected(collaborateur : string){
    return selectedCollab.value.some(c => c === collaborateur);
  }

  function selectCollaborateur(collaborateur : string){
    const index = selectedCollab.value.findIndex(c => c === collaborateur);
    if(index !== -1)
      selectedCollab.value.splice(index,1);
    else
      selectedCollab.value.push(collaborateur);
  }

</script>
        