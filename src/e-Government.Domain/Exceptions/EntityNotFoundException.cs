namespace e_Government.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName)
            :base($"{entityName} not found")
        {

        }
    }
}
