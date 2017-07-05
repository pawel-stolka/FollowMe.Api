using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Core.Domain
{
    public class Category : ICategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(string name, string description="")
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }
    }
}
