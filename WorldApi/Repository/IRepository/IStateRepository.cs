using WorldApi.Models;
using WorldApi.Data;

namespace WorldApi.Repository.IRepository
{
    public interface IStateRepository : IGenericRepository<States>
    {

        
        Task Update(States entity);
        


    }
}
