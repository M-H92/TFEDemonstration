import { defineStore } from "pinia";
import FacturationApi from "@/api/FacturationApi";
import {LigneFacturable} from "@/models/Facturation/LigneFacturable";
import type ExportableLigneFacturableDTO from "@/models/Facturation/ExportableLigneFacturable";

export const useFacturationStore = defineStore("Facturation",{
  state:() => ({
    ligneFacturables : [] as LigneFacturable[],
    loadingFacturables : false,
    loadingFacturableExportation : false
  }),
  getters:{
    loading : (state) => state.loadingFacturables || state.loadingFacturableExportation,
  },
  actions:{
    async charger(from : string, to : string){
      this.loadingFacturables = true;
      try{
        const resp = await FacturationApi.getFacturable(from, to);
        this.ligneFacturables = (resp.map(r => new LigneFacturable(r)));
      }finally{
        this.loadingFacturables = false;
      }
    },
    async exporter(dto : ExportableLigneFacturableDTO ){{
      this.loadingFacturableExportation = true;
      try{
        return await FacturationApi.exportFacturable(dto);
      }finally{
        this.loadingFacturableExportation = false;
      }
    }}
  }
}
);