<template>
    <v-window-item
        key="collaborateurs"
        value="collaborateurs"
    >
        <v-card
        class="pt-5"
        flat
        >
        <v-card-text> 
            <v-row>
            <v-col cols="12">
                <v-select
                  label="Collaborateurs"
                  :items="storeDroit.comboxBoxItemsCollab"
                  v-model="selectedCollab"
                  multiple
                  clearable
                />
            </v-col>
            <v-col cols="6">
                <v-select 
                label="Rôles"
                :items="storeDroit.comboxBoxItemsRoles"
                v-model="selectedRole"
                />
            </v-col>
            <v-col cols="3"><v-btn  class="mt-1" size="large" color="error" block :disabled="loading" :loading="loading" @click="deleteRole">Retirer</v-btn></v-col>
            <v-col cols="3"><v-btn  class="mt-1" size="large" color="primary" block :disabled="loading" :loading="loading" @click="addRole">Ajouter</v-btn></v-col>
            <v-col>
                <v-table fixed-header density="compact" class="mb-12">
                <thead>
                    <tr>
                    <th class="text-left">Collaborateurs</th>
                    <th class="text-left">Droits</th>
                    <th class="text-left">Description</th>
                    </tr>
                </thead>
                <tbody>
                  <template v-for="collabsWithRoles in collabs" :key="collabsWithRoles.collaborateur">
                    <tr v-for="collabRole in collabsWithRoles.roles" :key="collabRole.role" style="cursor: pointer;" @click="selectRole(collabRole.role)" :class="selectedRole === collabRole.role ? `bg-blue-lighten-4` : ``">
                      <td>{{ collabsWithRoles.collaborateur }}</td>
                      <td>{{ collabRole.role }}</td>
                      <td>{{ collabRole.description }}</td>
                    </tr>
                  </template>  
                </tbody>
                </v-table>
            </v-col>
            </v-row>
        </v-card-text>
        </v-card>
    </v-window-item>
</template>
        
        
<script setup lang="ts">
import { Collaborateur } from '@/models/Admin/Droits/Collaborateur';
import CreateCollaborateursRolesDTO from '@/models/Admin/Droits/CreateCollaborateurRoleDTO';
import { useNotificationStore } from '@/stores/Shared/ToastStore';
import { useAdminDroitStoreStore } from '@/stores/admin/DroitsStore';
import { computed, ref } from 'vue';
      
  const storeDroit = useAdminDroitStoreStore();
  const toaster = useNotificationStore();

  const selectedCollab = ref([] as string[]);
  const selectedRole = ref('');
  const loading = ref(false);

  const collabs = computed(() => {
    console.log(selectedCollab)
    const returnValue = [] as Collaborateur[];
    selectedCollab.value.forEach(sc => {
      returnValue.push(storeDroit.collaborateurs.find(c => c.collaborateur === sc) ?? new Collaborateur())
    });
    return returnValue;
  });

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

  function selectRole(role : string){
    selectedRole.value = role;
  }
  
</script>
      