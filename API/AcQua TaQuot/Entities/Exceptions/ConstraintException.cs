namespace Entities.Exceptions
{
    public abstract class ConstraintException : Exception
    {
        protected ConstraintException(string message) : base(message) { }
    }
}
