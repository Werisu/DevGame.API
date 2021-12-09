using AutoMapper;
using DevGames.API.Entities;
using DevGames.API.Models;

namespace DevGames.API.Mappers
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<AddPostInputModel, Post>();
        }
    }
}