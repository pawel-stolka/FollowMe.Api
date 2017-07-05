using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;

namespace FollowMe.Infrastructure.DTO
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string Note { get; set; }
        public IEnumerable<PointDto> GpsPoints { get; set; }
    }
}
