using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FollowMe.Core.Domain;
using FollowMe.Infrastructure.DTO;

namespace FollowMe.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<Point, PointDto>();
                cfg.CreateMap<Session, SessionDto>();
                cfg.CreateMap<IEnumerable<Category>, IEnumerable<CategoryDto>>();
                cfg.CreateMap<IEnumerable<IPoint>, IEnumerable<PointDto>>();
            })
            .CreateMapper();
    }
}
