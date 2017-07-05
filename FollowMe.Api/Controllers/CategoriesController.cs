using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FollowMe.Core.Domain;
using FollowMe.Infrastructure.DTO;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;

namespace FollowMe.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private ICategoryService _categoryService;
        
        public CategoriesController()
        {
            var _categoryRepo = new InMemoryCategoryRepo();
            _categoryService = new CategoryService(_categoryRepo);
        }

        //public IEnumerable<CategoryDto> GetAllCategories()
        //    =>_categoryService.GetAll();

        //[HttpGet]
        //public CategoryDto Get(string name)
        //{
        //    var category = GetAllCategories()
        //        .FirstOrDefault(c => c.Name == name);

        //    return category;
        //}


        public async Task<IEnumerable<CategoryDto>> GetAsync()
            //    => GetAllCategories().ToList();
            => await _categoryService.GetAllAsync();//.ToList();

        //[HttpGet]
        //public IEnumerable<CategoryDto> Get()
        //    => GetAllCategories();

        //public IHttpActionResult GetCategory(string name)
        //{
        //    var category = GetAllCategories()
        //        .FirstOrDefault(c => c.Name == name);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(category);
        //}
    }
}
