using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Infrastructure.Commands;
using FollowMe.Infrastructure.Commands.Category;

namespace FollowMe.Infrastructure.Handlers.Categories
{
    public class ChangeCategoryHandler : ICommandHandler<ChangeCategoryDescription>
    {
        public async Task HandleAsync(ChangeCategoryDescription command)
        {
            await Task.FromResult(command);
        }
    }
}
