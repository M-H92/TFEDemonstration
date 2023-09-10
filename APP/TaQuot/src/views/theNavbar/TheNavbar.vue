<template>
  <v-container id="the-navbar" class="px-16 bg-teal-lighten-2" fluid style="">
    <div class="d-flex justify-start">
      <div v-for="route in displayedRoutes" :key="route.name">
        <router-link :to="route.path" class="text-grey-lighten-5 mr-10">{{
          route.meta.displayName
        }}</router-link>
      </div>
      <v-spacer />
      <div
        v-if="utilisateurStore.id && utilisateurStore.id.length > 0"
        class="justify-self-end"
      >
        <a style="cursor: pointer" @click="deconnexion">Déconnexion</a>
      </div>
    </div>
    <h1>{{ current }}</h1>
  </v-container>
</template>

<script setup lang="ts">
import router from "@/router";
import { useNotificationStore } from "@/stores/Shared/ToastStore";
import { useUtilisateurStore } from "@/stores/UtilisateurStore/UtilisateurStore";
import { getActivePinia } from "pinia";
import { computed, reactive, ref } from "vue";
import { useRoute } from "vue-router";

const toaster = useNotificationStore();
const utilisateurStore = useUtilisateurStore();
const route = useRoute();
const current = computed(() => {
  return route.meta.displayName;
});

const displayedRoutes = computed(() => {
  const namedRoutes = router
    .getRoutes()
    .filter((r) => r.name !== undefined && reactive.name.length > 0);

  const userRoles = utilisateurStore.roles as string[];
  if (userRoles && userRoles.length !== 0) {
    const allowedRoutes = [] as any[];

    for (let i = 0; i < namedRoutes.length; i++) {
      if (namedRoutes[i].meta.allowAnonymous) continue;
      if ((namedRoutes[i].meta.roles as string).length === 0) {
        allowedRoutes.push(namedRoutes[i]);
        continue;
      }
      for (let j = 0; j < userRoles.length; j++) {
        if (
          (namedRoutes[i].meta.roles as string[]).some(
            (r) => r === userRoles[j]
          )
        ) {
          allowedRoutes.push(namedRoutes[i]);
          break;
        }
      }
    }

    return allowedRoutes;
  }
  return namedRoutes.filter((r) => r.meta.allowAnonymous);
});

function deconnexion() {
  utilisateurStore.deconnexion();
  const pinias = (getActivePinia() as any)._s;
  if (!pinias) return;
  pinias.forEach((store: any) => {
    store.$reset();
  });
  toaster.addSuccess("Déconnecté");
  router.replace("/Account/Index");
}
</script>
<style scoped>
a {
  font-size: 1.3rem;
  font-weight: bolder;
  text-decoration: none;
}
</style>
