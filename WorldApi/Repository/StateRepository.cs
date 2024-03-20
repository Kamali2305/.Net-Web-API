using Microsoft.EntityFrameworkCore;
using WorldApi.Data;
using WorldApi.Models;
using WorldApi.Repository.IRepository;

namespace WorldApi.Repository
{
    public class StateRepository : GenericRepository<States>, IStateRepository
    {

        private readonly AppDbContext _dbContext;


        public StateRepository(AppDbContext dbContext) :base(dbContext) 
        {
            _dbContext = dbContext;
        }       
 

        public async Task Update(States entity)
        {
            _dbContext.States.Update(entity);
           await _dbContext.SaveChangesAsync();
        }
    }
}
