namespace Entities.Exceptions
{
    /// <summary>Applicable quand on tente de supprimer une</summary>
    public class PrestationConstraintException : ConstraintException
    {
        public PrestationConstraintException() : base("Violation de la contrainte pour la prestation") { }
        public PrestationConstraintException(string message) : base(message) { }

        static public PrestationConstraintException ContrainteStatut(Guid? idPrestation = null)
        {
            return new PrestationConstraintException($"Impossible de supprimer la prestation {idPrestation?.ToString() ?? ""} en raison de son statut");
        }

    }
}
