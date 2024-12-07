using AutoMapper;
using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;

namespace X_Clone_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePostDto, Post>();
            CreateMap<Post, PostDto>();

            CreateMap<CreateCommentDto, Comment>();
            CreateMap<Comment, CommentDto>();

            CreateMap<User, UserDto>();
        }
    }
}
