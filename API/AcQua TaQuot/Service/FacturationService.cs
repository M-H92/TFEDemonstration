using Contracts.IRepositories;
using Contracts.IRepositories.Constantes;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransfertObject.Facturation;
using System.Text;

namespace Service
{
    internal sealed class FacturationService : IFacturationService
    {
        private readonly IRepositoryManager _repositoryManager;

        public FacturationService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public IEnumerable<LigneFacturableDTO> GetLignesFacturables(DateTime from, DateTime to)
        {
            var facturablePrestations = this._repositoryManager.Prestation.GetFacturable(from, to);
            if (facturablePrestations == null || facturablePrestations.Count is 0)
                return new List<LigneFacturableDTO>();
            return this.AggregateLigneFacturables(facturablePrestations);
        }

        private List<LigneFacturableDTO> AggregateLigneFacturables(List<Prestation> facturablePrestations)
        {
            var returnValue = new List<LigneFacturableDTO>();
            foreach (var prestation in facturablePrestations) prestation.Tache.Libelle = prestation.Tache.Libelle.ToUpper();
            var distinctFacturable = facturablePrestations.DistinctBy(p => new { p.Tache.ModuleId, p.StatutId, p.TypeTacheId, p.Tache.Libelle });
            foreach (var facturable in distinctFacturable)
                returnValue.Add(new(
                    facturable.Tache.Module.Application.Commanditaire.Nom,
                    facturable.Tache.Module.Libelle,
                    facturable.Tache.Module.Application.Libelle,
                    facturable.Tache.Libelle,
                    facturable.TypeTache.Libelle,
                    facturable.Statut.Libelle,
                    facturable.Tache.Module.Id,
                    facturable.TypeTacheId,
                    facturable.StatutId,
                    facturable.Tache.Module.Application.Commanditaire.Id));
            foreach (var facturable in facturablePrestations)
                returnValue.First(p =>
                    p.ModuleId == facturable.Tache.ModuleId
                    && p.StatutId == facturable.StatutId
                    && p.TypeTacheId == facturable.TypeTacheId
                    && p.Tache == facturable.Tache.Libelle).TimeSpent += facturable.Temps;
            foreach (var facturable in returnValue)
            {
                var param = this._repositoryManager.ParametresCommanditaireTypeTacheStatuts.Read(facturable.CommanditaireId, facturable.TypeTacheId, trackChanges: false);
                if (param is not null)
                {
                    facturable.StatutId = param.Statut.Id;
                    facturable.Statut = param.Statut.Libelle;
                }
            }
            return returnValue;
        }

        public byte[] ExportFacturableToCSV(ExportableLigneFacturableDTO dto)
        {
            var facturablePrestations = this._repositoryManager.Prestation.GetFacturable(dto.DateDebut, dto.DateFin);
            this.UpdatePrestationsWithDTO(dto, facturablePrestations);
            var aggregatedLigneFacturable = this.AggregateLigneFacturables(facturablePrestations.Where(p => p.StatutId == StatutConstantes.DefaultFacturedStatut).ToList());
            this.ResetPrestationDependancies(facturablePrestations);
            this._repositoryManager.Prestation.UpdateRange(facturablePrestations);
            this._repositoryManager.Save();
            MemoryStream stream = this.CreateCSV(aggregatedLigneFacturable);

            return stream.ToArray();
        }

        private MemoryStream CreateCSV(List<LigneFacturableDTO> aggregatedLigneFacturable)
        {
            StringBuilder builder = new();
            builder.AppendLine("Commanditaire;Application;Module;Tache;Type de tache; Temps");
            foreach (var ligne in aggregatedLigneFacturable)
                builder.AppendLine($"{ligne.Commanditaire};{ligne.Application};{ligne.Module};{ligne.Tache};{ligne.TypeTache};{ligne.TimeSpent}");

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(builder.ToString());
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private void UpdatePrestationsWithDTO(ExportableLigneFacturableDTO dto, List<Prestation> facturablePrestations)
        {
            foreach (var prestation in facturablePrestations)
            {
                var correspondingDTOLine = dto.ligneFacturableDTOs.FirstOrDefault(l =>
                    l.Tache.ToUpper() == prestation.Tache?.Libelle.ToUpper() &&
                    l.ModuleId == prestation.Tache.ModuleId &&
                    l.TypeTacheId == prestation.TypeTacheId);
                if (correspondingDTOLine is null) throw new Exception("Impossible trouver les prestations correspondantes");
                if (correspondingDTOLine.StatutId == StatutConstantes.DefaultPostpose)
                    continue;
                prestation.StatutId = correspondingDTOLine.StatutId == StatutConstantes.DefaultFacturableStatut ? StatutConstantes.DefaultFacturedStatut : correspondingDTOLine.StatutId;
                prestation.DateFacturation = DateTime.Today.Date;
            }
        }

        private void ResetPrestationDependancies(List<Prestation> facturablePrestations)
        {
            foreach (var prestation in facturablePrestations)
            {
                prestation.Statut = null;
                prestation.TypeTache = null;
                prestation.Tache = null;
                prestation.LignesFacture = null;
            }
        }
    }
}
