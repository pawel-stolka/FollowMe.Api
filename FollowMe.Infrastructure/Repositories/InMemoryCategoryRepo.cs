using System;
using System.Collections.Generic;
using System.Linq;
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

        public ICategory Get(Guid id)
            => _categories.SingleOrDefault(x => x.Id == id);

        public ICategory Get(string name)
            => _categories.SingleOrDefault(x => x.Name == name);


        public IEnumerable<ICategory> GetAll()
            => _categories;

        public void Add(ICategory category)
        {
            _categories.Add(category);
        }

        public void Update(ICategory category)
        {
            //if (_categories.Contains(category))
            //{
            //    var _category = Get(category.Id);
            //
            //}
            throw new NotImplementedException("todo...");
        }

        public void Remove(Guid id)
        {
            var category = Get(id);
            _categories.Remove(category);
        }
    }
}
