import { defineStore } from 'pinia';
import { useToast } from 'vue-toastification';
// import type { CustomError } from '@/utils/ErrorMethods';

export const useNotificationStore = defineStore('notification', {
  state:() => ({
    toast : useToast(),
  }),
  actions:{
    addError(error: string) {
      this.toast.error(error);
    },
    addCustomError(errorMessage: string, error: any | null = null) {
      this.toast.error(errorMessage);
    },
    addSuccess(msg: string) {
      this.toast.success(msg);
    },
    addWarning(msg: string){
      this.toast.warning(msg);
    }
  }
}
);