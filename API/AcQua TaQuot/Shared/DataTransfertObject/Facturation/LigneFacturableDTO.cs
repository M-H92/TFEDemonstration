namespace Shared.DataTransfertObject.Facturation
{
    public class LigneFacturableDTO
    {
        public string Commanditaire { get; set; }
        public string Module { get; set; }
        public string Application { get; set; }
        public string Tache { get; set; }
        public string TypeTache { get; set; }
        public string Statut { get; set; }
        public Guid ModuleId { get; set; }
        public Guid TypeTacheId { get; set; }
        public Guid StatutId { get; set; }
        public Guid CommanditaireId { get; set; }
        public int TimeSpent { get; set; } = 0;

        public LigneFacturableDTO(string commanditaire, string module, string application, string tache, string typeTache, string statut, Guid moduleId, Guid typeTacheId, Guid statutId, Guid commanditaireId)
        {
            this.Commanditaire = commanditaire;
            this.Module = module;
            this.Application = application;
            this.Tache = tache;
            this.TypeTache = typeTache;
            this.Statut = statut;
            this.ModuleId = moduleId;
            this.TypeTacheId = typeTacheId;
            this.StatutId = statutId;
            this.CommanditaireId = commanditaireId;
        }
    }
}
