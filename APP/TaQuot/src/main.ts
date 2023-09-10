import { createApp } from "vue";
import { createPinia } from "pinia";

import App from "./App.vue";
import router from "./router";
import Toast, { TYPE } from "vue-toastification";
import "vue-toastification/dist/index.css";

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import { aliases, mdi } from 'vuetify/iconsets/mdi'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

import "./assets/main.css";
import axios, { AxiosError } from "axios";
import { useUtilisateurStore } from "./stores/UtilisateurStore/UtilisateurStore";
import { useNotificationStore } from "./stores/Shared/ToastStore";

const themeBiac = {
  dark : false,
  colors:{
    background: '#FFFFFF',
    surface: '#FFFFFF',
    primary: '#428dcb',
    'primary-darken-1': '#3700B3',
    secondary: '#03DAC6',
    'secondary-darken-1': '#018786',
    error: '#B00020',
    info: '#2196F3',
    success: '#4CAF50',
    warning: '#FB8C00',
  }
}

const vuetify = createVuetify({
    components,
    directives,
    theme:{
      defaultTheme:'themeBiac',
      themes:{
        themeBiac
      }
    },
    icons: {
      defaultSet: 'mdi',
      aliases,
      sets: {
        mdi,
      }
    },
  }
);
const options = {
  toastDefaults: {
      // ToastOptions object for each type of toast
      [TYPE.ERROR]: {
          timeout: 3000,
          hideProgressBar: false,
          closeOnClick : true,
          icon: true,
      },
      [TYPE.SUCCESS]: {
          timeout: 3000,
          hideProgressBar: false,
          closeOnClick : true,
          icon: true,
        }    
  }
};

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(vuetify);
app.use(Toast, options);

app.mount("#app");

axios.interceptors.request.use(function (config) {
  let token = useUtilisateurStore().authJWT;
  if(config.headers)
  {
    if(token && token.length > 0)
    config.headers["Authorization"] = `Bearer ${token}`
  }
  return config;
});


const toaster = useNotificationStore();
app.config.errorHandler = (err : any, instance, info) => {
  if(err instanceof AxiosError){
    if(err.code === 'ERR_NETWORK')
      toaster.addError('Erreur de communication avec le serveur');
    else
      toaster.addError(err.message);
  }
  else if(typeof err === 'string'){
    toaster.addError(err);
  }
  else if (err.message){
    toaster.addError(err.message)
  }
  else if (err.Message){
    toaster.addError(err.Message)
  }
}
