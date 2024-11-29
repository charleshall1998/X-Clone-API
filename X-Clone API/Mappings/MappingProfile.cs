using AutoMapper;
using X_Clone_API.Data;
using X_Clone_API.Models.Dto;

namespace X_Clone_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserDto>();
        }
    }
}
