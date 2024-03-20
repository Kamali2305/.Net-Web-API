using WorldApi.Data;
using WorldApi.Models;

namespace WorldApi.Repository.IRepository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        
        Task Update(Country entity);
        
        
    }
}
