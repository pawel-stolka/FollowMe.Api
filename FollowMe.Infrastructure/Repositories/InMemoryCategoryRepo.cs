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
        private static ISet<Category> _categories = new HashSet<Category>
        {
            new Category("Bieganie", "Treningi i zawody"),
            new Category("Spacer", "Luźnym krokiem..."),
            new Category("Kolarstwo", "Rowerkiem"),
            new Category("Trening siłowy", "Kalistenika"),
            new Category("Inne", "Pozostała aktywność")
        };

        public async Task<Category> GetAsync(Guid id)
            //=> _categories.SingleOrDefault(x => x.Id == id);
            => await Task.FromResult(_categories.SingleOrDefault(x => x.Id == id));

        public async Task<Category> GetAsync(string name)
            => await Task.FromResult(_categories.SingleOrDefault(x => x.Name.ToLower() == name));


        public async Task<IEnumerable<Category>> GetAllAsync()
            => await Task.FromResult(_categories);

        public async Task AddAsync(Category category)
        {
             await Task.FromResult(_categories.Add(category));
        }

        public async Task UpdateAsync(Category category)
        {
            if (_categories.Contains(category))
            {
                var _category = GetAsync(category.Id);

            }
            throw new NotImplementedException("todo...");
        }

        public async Task RemoveAsync(Guid id)
        {
            var category = await GetAsync(id);
            _categories.Remove(category);
        }
    }
}
