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
        CategoryDto Get(Guid id);
        CategoryDto Get(string name);
        IEnumerable<CategoryDto> GetAll(); 
        void Register(string name, string description);
    }
}
