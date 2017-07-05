using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;
using FollowMe.Infrastructure.DTO;

namespace FollowMe.Infrastructure.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetAsync(Guid id);
        Task<CategoryDto> GetAsync(string name);
        Task<IEnumerable<CategoryDto>> GetAllAsync(); 
        Task RegisterAsync(string name, string description);
    }
}
