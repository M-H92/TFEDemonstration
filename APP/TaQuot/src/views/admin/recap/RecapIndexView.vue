<template>
  <v-container id="the-content">
    <v-row class="px-16">
      <v-col cols="2" class="mx-5">
        <router-link
          :to="{
            name: 'admin.recap',
            params: { date: previousWeek },
          }"
          class="text-grey-lighten-5 text-decoration-none"
        >
          <v-btn block color="primary"> Semaine précédente </v-btn>
        </router-link>
      </v-col>
      <v-spacer />
      <v-col cols="3">
        <v-text-field
          autofocus
          label="Date"
          type="date"
          v-model="observedDate"
        />
      </v-col>
      <v-spacer />
      <v-col cols="2" class="mx-5">
        <router-link
          :to="{
            name: 'admin.recap',
            params: { date: nextWeek },
          }"
          class="text-grey-lighten-5 text-decoration-none"
        >
          <v-btn block color="primary"> Semaine suivante </v-btn>
        </router-link>
      </v-col>
    </v-row>
    <v-row class="px-16">
      <v-col
        class="mx-5"
        style="width: 120px; height: 100px"
        v-for="day in days"
      >
        <v-card class="d-flex" style="height: 90px">
          <v-card-title class="text-center align-self-center">{{
            day
          }}</v-card-title>
        </v-card>
      </v-col>
    </v-row>
    <v-row class="px-16" v-if="loadingRecap">
      <v-col
        class="mx-5"
        style="width: 120px; height: 100px"
        v-for="day in days"
      >
        <v-card class="d-flex" style="height: 90px" variant="tonal">
          <v-card-text class="text-center pt-7">
            <v-progress-circular width="8" indeterminate />
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
    <v-row
      class="px-16"
      v-for="prestationPerCollab in prestations"
      :key="prestationPerCollab.user"
    >
      <v-col class="mx-5" style="width: 120px; height: 100px">
        <v-card class="d-flex" style="height: 90px">
          <v-card-title class="text-center align-self-center">{{
            prestationPerCollab.user
          }}</v-card-title>
        </v-card>
      </v-col>
      <v-col
        class="mx-5"
        style="width: 120px; height: 100px"
        v-for="prest in prestationPerCollab.prestations"
      >
        <v-card
          :variant="prest.getTime() === 'NA' ? 'tonal' : 'elevated'"
          style="height: 90px"
          class="mx-1"
        >
          <v-card-title class="text-center">{{ prest.getTime() }}</v-card-title>
          <v-card-text class="text-center">
            <v-progress-circular
              :model-value="prest.getPercent()"
              width="10"
              :color="prest.getColor()"
            />
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import AdminRecapApi from "@/api/Admin/AdminRecapApi";
import { WeeklyRecap } from "@/models/Admin/Recap/weeklyRecap";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { computed, onMounted, ref } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();
const toaster = useNotificationStore();

const observedDate = ref("");
const loadingRecap = ref(false);
const nextWeek = computed(() => {
  const currentDate = new Date(observedDate.value);
  const nextDate = new Date(currentDate.getTime() + 7 * 24 * 60 * 60 * 1000);
  return `${nextDate.getFullYear()}-${
    nextDate.getMonth() + 1 < 10
      ? `0${nextDate.getMonth() + 1}`
      : `${nextDate.getMonth() + 1}`
  }-${
    nextDate.getDate() < 10 ? `0${nextDate.getDate()}` : `${nextDate.getDate()}`
  }`;
});
const previousWeek = computed(() => {
  const currentDate = new Date(observedDate.value);
  const previousWeek = new Date(
    currentDate.getTime() - 7 * 24 * 60 * 60 * 1000
  );
  return `${previousWeek.getFullYear()}-${
    previousWeek.getMonth() + 1 < 10
      ? `0${previousWeek.getMonth() + 1}`
      : `${previousWeek.getMonth() + 1}`
  }-${
    previousWeek.getDate() < 10
      ? `0${previousWeek.getDate()}`
      : `${previousWeek.getDate()}`
  }`;
});

onMounted(async () => {
  setDate(route.params.date as string);
  try {
    loadingRecap.value = true;
    const dtos = await AdminRecapApi.getWeeklyRecap(observedDate.value);
    prestations.value = dtos.map((d) => new WeeklyRecap(d));
  } catch {
    toaster.addError(`Impossible de récupérer le récapitulatif hebdomadaire`);
  } finally {
    loadingRecap.value = false;
  }
});

function setDate(inputDate: string) {
  if (!new RegExp(/[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}/).test(inputDate)) {
    const today = new Date();
    const dayOffset = today.getDay() - 1;
    const date = new Date(today.getTime() - dayOffset * 24 * 60 * 60 * 1000);
    observedDate.value = `${date.getFullYear()}-${
      date.getMonth() + 1 < 10
        ? `0${date.getMonth() + 1}`
        : `${date.getMonth() + 1}`
    }-${date.getDate() < 10 ? `0${date.getDate()}` : `${date.getDate()}`}`;
  } else {
    const paramDate = new Date(inputDate);
    const dayOffset = paramDate.getDay() - 1;
    const date = new Date(
      paramDate.getTime() - dayOffset * 24 * 60 * 60 * 1000
    );
    observedDate.value = `${date.getFullYear()}-${
      date.getMonth() + 1 < 10
        ? `0${date.getMonth() + 1}`
        : `${date.getMonth() + 1}`
    }-${date.getDate() < 10 ? `0${date.getDate()}` : `${date.getDate()}`}`;
  }
}

const currentWeek = computed(() => {
  let currentDate = new Date(observedDate.value);
  let startDate = new Date(currentDate.getFullYear(), 0, 1);
  let totalDays = Math.floor(
    ((currentDate as any) - (startDate as any)) / (24 * 60 * 60 * 1000)
  );
  return Math.ceil(totalDays / 7 + 1);
});

const days = computed(() => [
  `S${currentWeek.value}`,
  "Lundi",
  "Mardi",
  "Mercredi",
  "Jeudi",
  "Vendredi",
  "Moyenne",
]);
const prestations = ref<WeeklyRecap[]>();
</script>
