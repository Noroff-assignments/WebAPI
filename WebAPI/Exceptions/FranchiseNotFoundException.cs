namespace WebAPI.Exceptions
{
    public class FranchiseNotFoundException : Exception
    {
        // Exception used in case of not finding a specific franchise.
        public FranchiseNotFoundException(int id) : base($"Couldn't find franchise with ID: {id}") { }
    }
}
