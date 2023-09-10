import { useUtilisateurStore } from "@/stores/UtilisateurStore/UtilisateurStore";
import { createRouter, createWebHistory } from "vue-router";
// import PrestationIndexView from "../views/prestation/PrestationIndexView.vue";
// import RecapIndexView from "../views/admin/recap/RecapIndexView.vue";
// import HomeView from "../views/HomeView.vue";

const routes =  [
  {
    path: "/",
    name: "Home",
    meta : {
      allowAnonymous : false,
      displayName : 'Home',
      roles : []
    },
    component: () => import('@/views/HomeView.vue'),
  },
  {
    path: "/encodage",
    name: "TaQuot",
    meta : {
      allowAnonymous : false,
      displayName : 'Encodage',
      roles : ['ENCODAGE']
    },
    component: () => import('@/views/prestation/PrestationIndexView.vue'),
  },
  {
    path: "/facturation",
    name: "Facturation",
    meta : {
      allowAnonymous : false,
      displayName : 'Facturation',
      roles : ['FACTURATION']
    },
    component: () => import('@/views/facturation/FacturationIndexView.vue'),
  },
  {
    path: "/Stats/Sprint",
    name: "Statistiques de sprint",
    meta : {
      allowAnonymous : false,
      displayName : 'Sprint review',
      roles : ['STATS']
    },
    component: () => import('@/views/SprintReview/SprintReviewIndexView.vue'),
  },
  {
    path: "/params/facturation",
    name: "Param facturation",
    meta : {
      allowAnonymous : false,
      displayName : 'Param facturation',
      roles : ['ADMIN']
    },
    component: () => import('@/views/params/facturation/ParametresFacturationIndexView.vue'),
  },
  {
    path: "/admin/droits",
    name: "Droits",
    meta : {
      allowAnonymous : false,
      displayName : 'Gestion droits',
      roles : ['ADMIN']
    },
    component: () => import('@/views/admin/droits/DroitsCollaborateursView.vue'),
  },
  {
    path: "/admin/commanditaire",
    name: "Commanditaire",
    meta : {
      allowAnonymous : false,
      displayName : 'Commanditaires',
      roles : ['NIVEAUSUP']
    },
    component: () => import('@/views/admin/commanditaire/CommanditaireIndexView.vue'),
  },
  {
    path: "/admin/application",
    name: "Application",
    meta : {
      allowAnonymous : false,
      displayName : 'Applications',
      roles : ['NIVEAUMOY']
    },
    component: () => import('@/views/admin/application/ApplicationIndexView.vue'),
  },
  {
    path: "/admin/module",
    name: "Module",
    meta : {
      allowAnonymous : false,
      displayName : 'Modules',
      roles : ['NIVEAUINF']
    },
    component: () => import('@/views/admin/module/ModuleIndexView.vue'),
  },
  {
    path: "/admin/recapDetaille",
    name: "admin.recap.detaille",
    meta : {
      allowAnonymous : false,
      displayName : 'Récap détaillé',
      roles : ['STATS']
    },
    component: () => import('@/views/admin/recapitulatifDetaille/RecapDetailleIndexView.vue'),
    // component: RecapIndexView,
  },
  {
    path: "/admin/recap/:date",
    name: "admin.recap",
    meta : {
      allowAnonymous : false,
      displayName : 'Récap',
      roles : ['RECAP']
    },
    component: () => import('@/views/admin/recap/RecapIndexView.vue'),
    // component: RecapIndexView,
  },
  {
    path: "/Account/Index",
    name: "Connexion",
    meta : {
      allowAnonymous : true,
      displayName : 'Connexion',
      roles : []
    },
    component: () => import('@/views/connexion/ConnexionIndexView.vue'),
  },
  {
    path: "/Account/Create",
    name: "Création de compte",
    meta : {
      allowAnonymous : true,
      displayName : 'Création de compte',
      roles : []
    },
    component: () => import('@/views/connexion/AccountCreateView.vue'),
  }
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
    // {
    //   path: "/about",
    //   name: "about",
    //   // route level code-splitting
    //   // this generates a separate chunk (About.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   component: () => import("../views/AboutView.vue"),
    // },
});

router.beforeEach((to, from, next) => {
    if(to.meta.allowAnonymous)
      return next();
  
    const utilisateurStore = useUtilisateurStore();
    
    if(!utilisateurStore.hasRoles)
      router.push({ name: 'Connexion' });

    const requiredRoles = (to.meta?.roles as string[]) ?? [];
    if(requiredRoles.length === 0)
      return next();

    const userRoles = utilisateurStore.roles as string[];
    if(userRoles.some(ur => requiredRoles.includes(ur)))
      return next();

    router.push({ name: 'Connexion' });
});

export default router;
