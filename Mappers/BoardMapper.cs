using AutoMapper;
using DevGames.API.Entities;
using DevGames.API.Models;

namespace DevGames.API.Mappers
{
    public class BoardMapper : Profile
    {
        public BoardMapper()
        {
            // lado esquerdo qual o objeto 
            //para partir para o seguindo destino que quero converter
            CreateMap<AddBoardInputModel, Board>();
        }
    }
}