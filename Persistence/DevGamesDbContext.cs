using System.Collections.Generic;
using DevGames.API.Entities;

namespace DevGames.API.Persistence
{
    public class DevGamesDbContext
    {
        public DevGamesDbContext()
        {
            Boards = new List<Board>();
        }

        public List<Board> Boards { get; private set; }
    }
}