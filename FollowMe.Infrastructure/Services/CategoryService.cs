using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.DTO;
using NLog;

namespace FollowMe.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return await GetAsync(category.Name);
        }

        public async Task<CategoryDto> GetAsync(string name)
        {
            var category = await _categoryRepository.GetAsync(name);
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var _categories = await _categoryRepository.GetAllAsync();

            //foreach (var category in _categories)
            //{
            //    ret.Add(
            //        new CategoryDto
            //        {
            //            Id = category.Id,
            //            Name = category.Name,
            //            Description = category.Description
            //        });
            //}
            //return ret;

            return _categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            }).ToList();
        }

        public async Task RegisterAsync(string name, string description)
        {
            var category = await _categoryRepository.GetAsync(name);
            if (category != null)
            {
                throw new Exception($"Category with name '{name}' already exists.");
            }

            category = new Category(name, description);
            //logger.Log(LogLevel.Info, "RegisterAsync =>    Category:");
            //logger.Log(LogLevel.Info, "RegisterAsync =>      - Id: " + category.Id);
            //logger.Log(LogLevel.Info, "RegisterAsync =>      - Name: " + category.Name);
            //logger.Log(LogLevel.Info, "RegisterAsync =>      - Description: " + category.Description);
            await  _categoryRepository.AddAsync(category);
        }
    }
}
