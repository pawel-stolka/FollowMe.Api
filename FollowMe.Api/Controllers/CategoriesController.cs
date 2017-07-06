﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FollowMe.Infrastructure.DTO;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;
using FollowMe.Infrastructure.Commands.Category;

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

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
            => await _categoryService.GetAllAsync();

        public async Task Post([FromBody]CreateCategory request)
        {
            try
            {
                await _categoryService.RegisterAsync(request.Name, request.Description);
            }
            catch (Exception ex)
            {
                Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
