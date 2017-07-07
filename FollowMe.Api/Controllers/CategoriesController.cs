using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FollowMe.Core.Domain;
using FollowMe.Infrastructure.Commands;
using FollowMe.Infrastructure.DTO;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;
using FollowMe.Infrastructure.Commands.Category;

namespace FollowMe.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommandDispatcher _commandDispatcher;

        public CategoriesController(ICategoryService categoryService, ICommandDispatcher commandDispatcher)
        {
            _categoryService = categoryService;
            _commandDispatcher = commandDispatcher;
            // this is registered in autofac configuration in Global.asax
            //var _categoryRepo = new InMemoryCategoryRepo();
            //_categoryService = new CategoryService(_categoryRepo);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
            => await _categoryService.GetAllAsync();

        public async Task Post([FromBody]CreateCategory command)
        {
            await _commandDispatcher.DispatchAsync(command);
            //await _categoryService.RegisterAsync(command.Name, command.Description);
        }
    }
}
