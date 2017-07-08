using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Core.Domain;
using FollowMe.Core.Repositories;

namespace FollowMe.Infrastructure.Repositories
{
    public class InMemoryCategoryRepo : ICategoryRepository
    {
        private static ISet<ICategory> _categories = new HashSet<ICategory>
        {
            new Category("Bieganie", "Treningi i zawody"),
            new Category("Spacer", "Luźnym krokiem..."),
            new Category("Kolarstwo", "Rowerkiem"),
            new Category("Trening siłowy", "Kalistenika"),
            new Category("Inne", "Pozostała aktywność")
        };

        public async Task<ICategory> GetAsync(Guid id)
            //=> _categories.SingleOrDefault(x => x.Id == id);
            => await Task.FromResult(_categories.SingleOrDefault(x => x.Id == id));

        public async Task<ICategory> GetAsync(string name)
            => await Task.FromResult(_categories.SingleOrDefault(x => x.Name.ToLower() == name));


        public async Task<IEnumerable<ICategory>> GetAllAsync()
            => await Task.FromResult(_categories);

        public async Task AddAsync(ICategory category)
        {
             await Task.FromResult(_categories.Add(category));
        }

        public async Task UpdateAsync(ICategory category)
        {
            //if (_categories.Contains(category))
            //{
            //    var _category = Get(category.Id);
            //
            //}
            throw new NotImplementedException("todo...");
        }

        public async Task RemoveAsync(Guid id)
        {
            var category = await GetAsync(id);
            _categories.Remove(category);
        }
    }
}
