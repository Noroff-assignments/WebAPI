using WebAPI.Models;

namespace WebAPI.Services.FranchiseService
{
    public class FranchiseService : IFranchiseService
    {
        public Task<Franchise> AddFranchise(Franchise franchise)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFranchise(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>> GetAllFranchiseCharacters(int franchiseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllFranchiseMovies(int franchiseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Franchise>> GetAllFranchises()
        {
            throw new NotImplementedException();
        }

        public Task<Franchise> GetFranchiseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFranchiseMovies(int id, List<int> moviesId)
        {
            throw new NotImplementedException();
        }
    }
}
