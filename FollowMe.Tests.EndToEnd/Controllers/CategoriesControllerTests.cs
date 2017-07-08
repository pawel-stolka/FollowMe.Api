using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FollowMe.Api.Models;
using FollowMe.Infrastructure.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace FollowMe.Tests.EndToEnd.Controllers
{
    public class CategoriesControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public CategoriesControllerTests()
        {
            _server = new TestServer(new WebHostBuilder());
                //.UseStartup<Global>()
                
                //.UseStartup<StartupBase>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Given_valid_email_category_should_exist()
        {
            // Act
            var name = "bieganie";
            var response = await _client.GetAsync($"categories/get/{name}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content
                .ReadAsStringAsync();

            var category = JsonConvert.DeserializeObject<CategoryDto>(responseString);

            // Assert
            category.Name.ShouldBeEquivalentTo(name);
            //Assert.Equal("Hello", responseString);
        }
    }
}
