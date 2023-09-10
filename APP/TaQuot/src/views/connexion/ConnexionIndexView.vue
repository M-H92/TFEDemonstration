<template>
    <v-container class="d-flex align-center" fluid style="height: calc(100vh - 250px);">
      <v-row >
        <v-spacer />
        <v-col cols="12" md="6" lg="3" class="px-2">
          <v-card class="py-3">
            <v-card-title>
              Connexion
            </v-card-title>
            <v-card-text>
              <v-form v-model="form.isValid" ref="refForm">
                <v-row>
                  <v-col cols="12">
                    <v-text-field label="Identifiant" v-model="form.identifier" :rules="rules.identifier"></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field type="password" label="Mot de passe" v-model="form.password" :rules="rules.password"></v-text-field>
                  </v-col>
                </v-row>
              </v-form>
            </v-card-text>
            <v-card-actions class="px-4">
              <v-spacer/>
              <v-btn  color="primary" variant="elevated" @click="submit" :disabled="loading" :loading="loading">Connexion</v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
        <v-spacer />
      </v-row>
    </v-container>
  </template>
        
        
  <script setup lang="ts">
  import ConnexionApi from '@/api/ConnexionApi';
  import ConnexionDTO from '@/models/Connexion/connexionDTO';
  import { Rule } from '@/utils/Rules';
  import { onMounted, reactive, ref } from 'vue';
  import { useUtilisateurStore } from '@/stores/UtilisateurStore/UtilisateurStore';
  import {  useRouter } from 'vue-router';
  
  const refForm = ref(null as any);
  const router = useRouter();

  const utilisateurStore = useUtilisateurStore();

  const form = reactive({
    identifier: '',
    password: '',
    isValid: true
  });
  
  const loading = ref(false);
  
  const rules = {
    identifier : new Rule()
      .required()
      .build(),
    password : new Rule()
      .required()
      .build(),
  };
  
  onMounted(async () => {
  })
  
  async function submit() {
    await refForm.value?.validate();
    if (!form.isValid)
      return;
    
    await authenticate();
  }
  
  async function authenticate(){
    loading.value = true;
    try {
      await utilisateurStore.reset();
      const authToken = await ConnexionApi.authenticate(formToCreateModel())
      await utilisateurStore.setAuthJWT(authToken);
      if(!utilisateurStore.authJWT || utilisateurStore.authJWT === '')
        throw `Erreur lors de la connexion`;
      const rolesToken = await ConnexionApi.getRoles(utilisateurStore.authJWT);
      await utilisateurStore.setAuthJWT(rolesToken);
      refForm.value.reset();
      router.push({ name: 'Home' });
    } finally {
      loading.value = false;
    }
  }
  
  function formToCreateModel(): ConnexionDTO {
    const returnValue = new ConnexionDTO();
  
    returnValue.identifier = form.identifier;
    returnValue.password = form.password;
  
    return returnValue;
  }
  
  </script>
        