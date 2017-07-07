using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Infrastructure.Commands;
using FollowMe.Infrastructure.Commands.Category;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;
using System.Web.Http;

namespace FollowMe.Infrastructure.Handlers.Categories
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategory>
    {
        private ICategoryService _categoryService;

        public CreateCategoryHandler(ICategoryService categoryService)
        {
            //var _categoryRepo = new InMemoryCategoryRepo();
            //_categoryService = new CategoryService(_categoryRepo);
            _categoryService = categoryService;

        }

        public async Task HandleAsync(CreateCategory command)
        {
            await _categoryService
                .RegisterAsync(command.Name, command.Description);
        }
    }
}
