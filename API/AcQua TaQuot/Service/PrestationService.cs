using Contracts;
using Contracts.IRepositories;
using Entities.Exceptions;
using Entities.Mapper;
using Entities.Mapper.UserPreferences;
using Service.Contracts;
using Shared.DataTransfertObject;
using Shared.DataTransfertObject.Prestation;

namespace Service
{
    internal sealed class PrestationService : IPrestationService
    {
        #region Ctor + services

        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public PrestationService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }

        #endregion

        #region Create

        public PrestationDTO Create(CreatePrestationDTO dto)
        {
            var statut = this._repositoryManager.Statut.GetDefaultFacturableStatut(trackChanges: false);
            if (statut is null) throw new Exception("Statut introuvable");

            var typeTache = this._repositoryManager.TypeTache.Get(dto.TypeTacheId, trackChanges: false);
            if (typeTache is null) throw new Exception("Type de tache introuvable");

            var module = this._repositoryManager.Module.Get(dto.ModuleId, trackChanges: false);
            if (module is null) throw new Exception("Module introuvable");

            var application = this._repositoryManager.Application.Get(dto.ApplicationId, trackChanges: false);
            if (application is null) throw new Exception("Application introuvable");

            var commanditaire = this._repositoryManager.Commanditaire.Get(dto.CommanditaireId, trackChanges: false);
            if (commanditaire is null) throw new Exception("Commanditaire introuvable");


            var displayNumber = this._repositoryManager.Prestation.GetNextDisplayNumber(dto.Date);

            var entity = dto.ToPrestation(statut.Id, displayNumber);

            this._repositoryManager.Prestation.CreatePrestation(entity);

            var tache = dto.ToTache(entity.Id);

            this._repositoryManager.Tache.CreateTache(tache);
            this._repositoryManager.Save();
            return entity.ToPrestationDTO();
        }


        #endregion

        #region Read

        public DetailPrestationDTO Get(Guid id, bool trackChanges = false)
        {
            var prestation = this._repositoryManager.Prestation.GetDetails(id, trackChanges);
            return new DetailPrestationDTO(
                prestation.Id,
                prestation.Date,
                prestation.Temps,
                prestation.TypeTacheId,
                prestation.Tache.Module.Application.CommanditaireId,
                prestation.Tache.Module.ApplicationId,
                prestation.Tache.ModuleId,
                prestation.Tache.Id,
                prestation.Tache.Libelle,
                prestation.Commentaire);
        }

        public List<PaginatePrestationDTO> GetPaginatedPrestations(int take, int skip, string user)
        => this._repositoryManager.Prestation.GetPrestations(take, skip, user)
                .Select(e => new PaginatePrestationDTO(e.Id,
                                                       e.Date,
                                                       e.Temps,
                                                       e.TypeTache?.Libelle ?? "NA",
                                                       e.Tache?.Module?.Application?.Commanditaire?.Nom ?? "NA",
                                                       e.Tache?.Module?.Application?.Libelle ?? "NA",
                                                       e.Tache?.Module?.Libelle ?? "NA",
                                                       e.Tache?.Libelle ?? "NA",
                                                       e.Commentaire ?? "NA")).ToList();

        public List<PaginatePrestationDTO> GetTodaysPrestations(string user)
        => this._repositoryManager.Prestation.ReadWhere(p => p.Date.Date == DateTime.Today.Date && p.Utilisateur == user, trackChanges: false)
                .ToList()
                .Select(e => new PaginatePrestationDTO(e.Id,
                                                       e.Date,
                                                       e.Temps,
                                                       e.TypeTache?.Libelle ?? "NA",
                                                       e.Tache?.Module?.Application?.Commanditaire?.Nom ?? "NA",
                                                       e.Tache?.Module?.Application?.Libelle ?? "NA",
                                                       e.Tache?.Module?.Libelle ?? "NA",
                                                       e.Tache?.Libelle ?? "NA",
                                                       e.Commentaire ?? "NA")).ToList();

        public GetPreferenceEncodagePrestationDTO GetPreferenceUtilisateur(string user)
        {
            var preference = this._repositoryManager.PreferencesEncodagePrestation.Get(user, tracking: false);
            if (preference is null)
            {
                preference = new() { InitAtLastDate = false, ResetApplication = true, ResetCommanditaire = true, ResetModule = true, ResetTypeTache = true, TempsAsInputTypeTime = false, Utilisateur = user };
                this._repositoryManager.PreferencesEncodagePrestation.AddOrUpdate(preference);
            }

            return preference.ToDTO();
        }

        #endregion

        #region Update

        public void Update(Guid id, UpdatePrestationDTO dto)
        {
            var prestation = this._repositoryManager.Prestation.GetDetails(id, trackChanges: true);
            if (prestation is null)
                throw new PrestationNotFoundException(id);

            if (prestation.Tache is null)
                throw new Exception("tache introuvable");
            else
                prestation.Tache.Libelle = dto.Tache;

            prestation = prestation.Update(dto);
            this._repositoryManager.Save();
        }

        public void UpdateConfigurationPrestation(PutPreferenceEncodagePrestationDTO dto)
        {
            this._repositoryManager.PreferencesEncodagePrestation.AddOrUpdate(dto.ToEntity());
            this._repositoryManager.Save();
        }
        #endregion

        #region Delete

        public void Delete(Guid id)
        {
            var prestation = this._repositoryManager.Prestation.Get(id, trackChanges: false);
            if (prestation is null) throw new PrestationNotFoundException(id);

            var untouchableStatut = this._repositoryManager.Statut.GetDefaultUntouchablesStatuts();
            if (untouchableStatut.Any(s => s.Id.Equals(prestation.StatutId)))
                throw PrestationConstraintException.ContrainteStatut(prestation.Id);

            this._repositoryManager.Prestation.Delete(prestation);
            this._repositoryManager.Save();
        }




        #endregion
    }
}
