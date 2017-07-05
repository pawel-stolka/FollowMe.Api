using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.DTO;

namespace FollowMe.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryDto Get(Guid id)
        {
            var category = _categoryRepository.Get(id);
            return Get(category.Name);
        }

        public CategoryDto Get(string name)
        {
            var category = _categoryRepository.Get(name);
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var _categories = _categoryRepository.GetAll();

            var ret = new List<CategoryDto>();
            foreach (var category in _categories)
            {
                ret.Add(
                    new CategoryDto
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Description = category.Description
                    });
            }
            return ret;
        }

        public void Register(string name, string description)
        {
            var category = _categoryRepository.Get(name);
            if (category != null)
            {
                throw new Exception($"Category with name '{name}' already exists.");
            }

            category = new Category(name, description);
            _categoryRepository.Add(category);
        }
    }
}
