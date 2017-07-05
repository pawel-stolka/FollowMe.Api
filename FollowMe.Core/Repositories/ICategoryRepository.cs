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
        ICategory Get(Guid id);
        ICategory Get(string name);
        IEnumerable<ICategory> GetAll();
        void Add(ICategory category);
        void Update(ICategory category);
        void Remove(Guid id);
    }
}
