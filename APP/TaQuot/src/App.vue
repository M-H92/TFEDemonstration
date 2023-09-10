<script setup lang="ts">
import { RouterView } from "vue-router";
import TheNavbar from "@/views/theNavbar/TheNavbar.vue";
import TheDailyWheel from "@/views/widget/dailyWheel/TheDailyWheel.vue";
</script>

<template>
  <v-container
    id="the_container"
    fluid
    class="pa-0 mx-0"
    full-height
    style="background-color: #eceff1; min-height: 100vh"
  >
    <TheNavbar />
    <RouterView :key="$route.fullPath" />
    <TheDailyWheel />
  </v-container>
</template>

<style scoped></style>
