using Microsoft.EntityFrameworkCore;
using WorldApi.Data;
using WorldApi.Models;
using WorldApi.Repository.IRepository;

namespace WorldApi.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {

        private readonly AppDbContext _dbContext;

        public CountryRepository(AppDbContext dbContext)  : base(dbContext)
        {
            _dbContext = dbContext;
        }

        

        public async Task Update(Country entity)
        {
            _dbContext.Countries.Update(entity);
            await _dbContext.SaveChangesAsync();   
        }
    }
}
