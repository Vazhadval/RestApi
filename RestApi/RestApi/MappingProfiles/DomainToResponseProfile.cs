using AutoMapper;
using RestApi.Contracts.v1.Responses;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Tag, TagResponse>();

            CreateMap<Post, PostResponse>()
                .ForMember(dest => dest.Tags, opt =>
                  opt.MapFrom(src => src.Tags.Select(x => new TagResponse { Name = x.TagName })));
        }
    }
}
