<template>
  <v-container fluid>
    <v-row dense>
      <v-col cols="3" />
      <v-col>
        <v-row class="mt-12">
          <!-- <v-col cols="12">
                    <v-card>
                        <v-card-item>
                            <v-card-title> Encodage rapide </v-card-title>
                            <v-card-text>
                                Tableau d'encodage rapide
                            </v-card-text>
                        </v-card-item>
                    </v-card>
                </v-col>
                <v-col 
                    v-for="card in cards"
                    :key="card.title"
                    >
                    <v-card >
                        <v-img
                        :src="card.src"
                        class="align-end"
                        gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                        height="200px"
                        cover
                        >
                        <v-card-title class="text-white" v-text="card.title"></v-card-title>
                        </v-img>
                    </v-card>
                </v-col> -->
          <v-col cols="12">
            <v-card height="700px" style="overflow-y: scroll">
              <v-card-title>
                <h5 class="text-h5">Notes de mise à jour</h5>
              </v-card-title>
              <v-card-subtitle class="mb-n5">
                Dernière mise à jour 04-08-2023</v-card-subtitle
              >
              <v-card-text>
                <h6 class="text-h6 mt-3">Widget daily wheel</h6>
                <p>
                  Nouveau widget présentant rapidement les heures préstées pour
                  la journée
                </p>
                <p>Si vous êtes dans le vert, tout va bien !</p>
                <p>
                  Passer la souris dessus pour l'agrandir et avoir plus d'info !
                </p>
                <h6 class="text-h6 mt-3">Paramètres de facturation</h6>
                <p>Nouvel écran de paramètres de facturation</p>
                <p>
                  Permet de gérer les status par défaut des lignes de
                  facturation
                </p>
                <h6 class="text-h6 mt-3">Facturation</h6>
                <p>Nouvel écran de facturation</p>
                <p>
                  Permet de trier les différentes prestations et d'en exporter
                  un csv de lignes facturables
                </p>
                <h6 class="text-h6 mt-3">Sprint review</h6>
                <p>
                  Correctif d'un problème concernant la sélection des
                  collaborateurs
                </p>
                <h6 class="text-h6 mt-3">Récapitulatif détaillé</h6>
                <p>
                  Il est maintenant possible de sélectionner le mois analysé
                </p>
                <h6 class="text-h6 mt-3">Récapitulatif détaillé</h6>
                <p>Un nouvel écran de récapitulatif détaillé est disponible</p>
                <p>
                  Il permet d'analyser quels types de tâches ont étés accomplis
                  par les collaborateurs ce mois-ci
                </p>
                <h6 class="text-h6 mt-3">Sprint review</h6>
                <p>
                  Un nouvel écran de gestion de récapitulatif de sprint est
                  disponible
                </p>
                <p>
                  Il permet d'analyser les différentes tâches accomplies par des
                  collaborateurs pendant un laps de temps sélectionné
                </p>
                <h6 class="text-h6 mt-3">Gestion de droits</h6>
                <p>Un nouvel écran de gestion de droits est disponible</p>
                <p>
                  Il permet de voir et gérer les droits par utilisateur ou de
                  voir et gérer les utilisateurs par droits
                </p>
                <h6 class="text-h6 mt-3">Toasts</h6>
                <p>
                  L'application affiche maintenant des toasts en cas de réussite
                  ou d'échec des opérations
                </p>
                <h6 class="text-h6 mt-3">Roles</h6>
                <p>
                  Les différentes pages sont maintenant liées à vos rôles et/ou
                  droits spéciques
                </p>
                <p>
                  Vous pouvez demander de nouveaux rôles à votre administrateur
                </p>
                <h6 class="text-h6 mt-3">Authentification</h6>
                <p>
                  Vous devez maintenant vous authentifier pour modifier vos
                  tâches quotidiennes
                </p>
                <p>
                  Pour cela, vous devrez créer un compte sur l'application
                  d'authentification d'AcQua
                </p>
                <h6 class="text-h6 mt-3">Dupliquer une tâche quotidienne</h6>
                <p>
                  Le bouton de modification de ligne du tableau d'encodage est
                  maintenant remplacé par un bouton de copie de ligne
                </p>
                <p>
                  Vous pouvez néanmoins modifier une tâche quotidienne existante
                  en cliquant directement dessus
                </p>
                <h6 class="text-h6 mt-3">Configuration d'encodage</h6>
                <p>
                  Vous pouvez maintenant personnaliser l'écran d'encodage via un
                  bouton configuration
                </p>
                <h6 class="text-h6 mt-3">Récapitulatif</h6>
                <p>Un écran de récapitulatif est disponible</p>
                <p>
                  Il permet de voir le temps presté pour les différents
                  collaborateurs
                </p>
                <p>
                  Le temps y est indiqué en minute et un cercle de couleur
                  gradué du vert au rouge indique rapidement les heures
                  prestées.
                </p>
                <h6 class="text-h6 mt-3">Encodage</h6>
                <p>
                  Nouvel écran d'encodage permettant de consulter, ajouter,
                  modifier ou supprimer vos tâches quotidiennes
                </p>
              </v-card-text>
            </v-card>
          </v-col>
        </v-row>
      </v-col>

      <v-col cols="3" />
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { onMounted, reactive, ref } from "vue";
</script>
