<template>
  <v-container fluid>
    <v-row>
      <v-col cols="3" />
      <v-col>
        <v-tabs
          v-model="tab"
          align-tabs="title"
          bg-color="primary"
          density="default"
          height="60px"
        >
          <v-tab key="collaborateurs" value="collaborateurs">
            Collaborateurs
          </v-tab>
          <v-tab key="droit" value="droit"> Droits </v-tab>
        </v-tabs>
        <v-window v-model="tab">
          <TabCollaborateurView />
          <TabRolesView />
        </v-window>
      </v-col>
      <v-col cols="3" />
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { useNommenclatureStore } from "@/stores/Shared/NommenclatureStore";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { useAdminDroitStoreStore } from "@/stores/admin/DroitsStore";
import TabCollaborateurView from "@/views/admin/droits/tabs/TabCollaborateursView.vue";
import TabRolesView from "@/views/admin/droits/tabs/TabRolesView.vue";
import { computed, onMounted, reactive, ref } from "vue";

const storeDroit = useAdminDroitStoreStore();
const nom = useNommenclatureStore();
const toaster = useNotificationStore();

const tab = ref("");
const loading = ref(false);

onMounted(async () => {
  try {
    loading.value = true;
    await storeDroit.initialize();
  } finally {
    loading.value = false;
  }
});
</script>
