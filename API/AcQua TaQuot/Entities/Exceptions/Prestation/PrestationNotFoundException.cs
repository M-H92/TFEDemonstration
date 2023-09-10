namespace Entities.Exceptions
{
    public class PrestationNotFoundException : NotFoundException
    {
        public PrestationNotFoundException(Guid id)
            : base($"La prestation avec l'id : {id} n'a pas été trouvé dans la base de donnée")
        { }
        public PrestationNotFoundException()
            : base($"Prestation(s) introuvable(s)")
        { }
    }
}
