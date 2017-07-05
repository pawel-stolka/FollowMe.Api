using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FollowMe.Infrastructure.Commands.Category;
using FollowMe.Infrastructure.DTO;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;

namespace FollowMe.Api.Controllers
{
    public class TestController : ApiController
    {
        private ICategoryService _categoryService;
        public TestController()
        {
            var _categoryRepo = new InMemoryCategoryRepo();
            _categoryService = new CategoryService(_categoryRepo);
        }

        public IEnumerable<CategoryDto> Get()//int id)
        {
            return _categoryService.GetAll().ToList();
        }

        public object Post([FromBody]CreateCategory request)
        {
            try
            {
                _categoryService.Register(request.Name, request.Description);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
