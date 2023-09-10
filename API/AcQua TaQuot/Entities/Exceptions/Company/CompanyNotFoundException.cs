namespace Entities.Exceptions
{
    public class CommanditaireNotFoundException : NotFoundException
    {
        public CommanditaireNotFoundException(Guid id)
            : base($"Le commanditaire avec l'id : {id} n'a pas été trouvé dans la base de donnée")
        { }
        public CommanditaireNotFoundException()
            : base($"Commanditaire(s) introuvable(s)")
        { }
    }
}
