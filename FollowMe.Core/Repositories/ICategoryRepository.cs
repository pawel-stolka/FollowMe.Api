using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;

namespace FollowMe.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<ICategory> GetAsync(Guid id);
        Task<ICategory> GetAsync(string name);
        Task<IEnumerable<ICategory>> GetAllAsync();
        Task AddAsync(ICategory category);
        Task UpdateAsync(ICategory category);
        Task RemoveAsync(Guid id);
    }
}
