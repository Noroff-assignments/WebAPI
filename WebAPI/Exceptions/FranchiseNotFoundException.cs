namespace WebAPI.Exceptions
{
    public class FranchiseNotFoundException : Exception
    {
        public FranchiseNotFoundException(int id) : base($"Couldn't find franchise with ID: {id}") { }
    }
}
