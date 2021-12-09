using System.Linq;
using AutoMapper;
using DevGames.API.Entities;
using DevGames.API.Models;
using DevGames.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly DevGamesDbContext _context;
        private readonly IMapper mapper;

        public BoardsController(DevGamesDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Boards);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var board = _context.Boards.SingleOrDefault(b => b.Id == id);

            if (board == null)
            {
                return NotFound();
            }

            return Ok(_context.Boards);
        }

        [HttpPost]
        public IActionResult Post(AddBoardInputModel inputModel)
        {
            var board =  mapper.Map<Board>(inputModel);

            _context.Boards.Add(board);

            return CreatedAtAction("GetById", new { id = inputModel.Id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBoardInputModel inputModel)
        {
            var board = _context.Boards.SingleOrDefault(b => b.Id == id);

            if (board == null)
                return NotFound();

            board.Update(inputModel.Description, inputModel.Rules);
            return NoContent();
        }
    }
}