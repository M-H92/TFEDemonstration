<template>
  <v-container
    v-if="shouldDisplay"
    :style="style"
    style="
      position: fixed;
      bottom: 10px;
      left: 10px;
      display: flex;
      justify-content: center;
      align-items: center;
      border-radius: 50%;
      cursor: pointer;
      z-index: 100;
      box-shadow: 0px 0px 8px grey;
    "
    class="bg-white pa-0 ma-0"
    @mouseenter="bigContainer = true"
    @mouseleave="bigContainer = false"
  >
    <!-- @click="displayForm = true" -->
    <v-progress-circular
      :indeterminate="store.loading"
      :width="bigContainer ? 10 : 8"
      :model-value="store.dailyTotalPercentage"
      :color="color"
      :size="bigContainer ? '75' : '35'"
    >
      <span style="color: black" class="pt-1">
        {{ bigContainer ? store.dailyTotal : "" }}
      </span>
    </v-progress-circular>
  </v-container>
  <v-dialog v-model="displayForm">
    <formPrestation @close="displayForm = false" />
  </v-dialog>
</template>

<script setup lang="ts">
import router from "@/router";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { useUtilisateurStore } from "@/stores/UtilisateurStore/UtilisateurStore";
import { useTheDailyWheelStore } from "@/stores/Widget/TheDailyWheelStore";
import formPrestation from "@/views/shared/FormPrestationView.vue";
import { onMounted } from "vue";
import { watch } from "vue";
import { computed, reactive, ref } from "vue";

const toaster = useNotificationStore();
const utilisateurStore = useUtilisateurStore();
const store = useTheDailyWheelStore();

const bigContainer = ref(false);
const displayForm = ref(false);

const style = computed(() => {
  if (bigContainer.value)
    return {
      width: "100px",
      height: "100px",
    };
  return {
    width: "50px",
    height: "50px",
  };
});

const color = computed(() => {
  if (store.loading) return "primary";
  if (store.dailyTotal < 480 - 120) return "error";
  if (store.dailyTotal < 480 - 60) return "warning";
  if (store.dailyTotal < 480 + 60) return "success";
  if (store.dailyTotal < 480 + 120) return "warning";
  return "error";
});

const shouldDisplay = computed(() => {
  const userRoles = utilisateurStore.roles as string[];
  if (userRoles && userRoles.length !== 0) {
    store.initialyze();
    return userRoles.includes("ENCODAGE");
  }
  return false;
});
</script>
