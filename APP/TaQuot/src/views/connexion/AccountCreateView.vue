<template>
  <v-container class="d-flex align-center" fluid style="height: calc(100vh - 250px);">
    <v-row >
      <v-spacer />
      <v-col cols="12" md="6" lg="3" class="px-2">
        <v-card class="py-3">
          <v-card-title>
            Création de compte
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
                <v-col cols="12">
                  <v-text-field type="password" label="Vérification du mot de passe" v-model="form.passwordValidation" :rules="rules.passwordValidation" ></v-text-field>
                </v-col>
              </v-row>
            </v-form>
          </v-card-text>
          <v-card-actions class="px-4">
            <v-spacer/>
            <v-btn  color="primary" variant="elevated" @click="submit" :loading="saveLoading" :disabled="saveLoading">Valider</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
      <v-spacer />
    </v-row>
  </v-container>
</template>
      
      
<script setup lang="ts">
import ConnexionApi from '@/api/ConnexionApi';
import CreateAccountDTO from '@/models/Connexion/createAccountDTO';
import { useNotificationStore } from '@/stores/Shared/ToastStore';
import { Rule } from '@/utils/Rules';
import { onMounted, reactive, ref } from 'vue';
import { useRouter } from 'vue-router';

const refForm = ref(null as any);
const toaster = useNotificationStore();

const router = useRouter();

const form = reactive({
  identifier: '',
  password: '',
  passwordValidation: '',
  isValid: true
});

const saveLoading = ref(false);

const rules = {
  identifier : new Rule()
    .required()
    .build(),
  password : new Rule()
    .required()
    .build(),
  passwordValidation : new Rule()
    .required()
    .build()
};

onMounted(async () => {
})

async function submit() {
  await refForm.value?.validate();
  if (!form.isValid)
    return;
  
  await create();
}

async function create(){
  saveLoading.value = true;
  try {
    await ConnexionApi.postNewAccount(formToCreateModel())
    refForm.value?.reset();
    toaster.addSuccess('Compte créé');
    router.push({ name: 'Connexion' })
  } finally {
    saveLoading.value = false;
  }
}

function formToCreateModel(): CreateAccountDTO {
  const returnValue = new CreateAccountDTO();

  returnValue.identifier = form.identifier;
  returnValue.password = form.password;
  returnValue.passwordValidation = form.passwordValidation;

  return returnValue;
}

</script>
      