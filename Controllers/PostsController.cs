using System.Linq;
using AutoMapper;
using DevGames.API.Entities;
using DevGames.API.Models;
using DevGames.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.API.Controllers
{
    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DevGamesDbContext context;
        public PostsController(DevGamesDbContext context)
        {
            this.context = context;

        }
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            var board = context.Boards.SingleOrDefault(b => b.Id == id);
            
            if(board == null)
                return NotFound();

            return Ok(board.Posts);
        }

        [HttpGet("{postId}")]
        public IActionResult GetById(int id, int postId)
        {
            var board = context.Boards.SingleOrDefault(b => b.Id == id);
            
            if(board == null)
                return NotFound();
            
            var post = board.Posts.SingleOrDefault(p => p.Id == postId);

            if(post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post([FromServices] IMapper mapper, int id, AddPostInputModel inputModel)
        {
            var board = context.Boards.SingleOrDefault(b => b.Id == id);

            if(board == null)
                return NotFound();

            //var post = mapper.Map<Post>(inputModel);
            
            var post = new Post(inputModel.Title, inputModel.Description, board.Id);
            
            board.Posts.Add(post);

            return CreatedAtAction("GetById", new { id = id, postId = inputModel.Id }, inputModel);
        }

        [HttpPost("{postId}/comments")]
        public IActionResult PostComment(int id, int postId, AddCommentInputModel inputModel)
        {
            var board = context.Boards.SingleOrDefault(b => b.Id == id);

            if(board == null)
            {
                return NotFound();
            }

            var post = board.Posts.SingleOrDefault(p => p.Id == postId);

            if(post == null)
            {
                return NotFound();
            }

            var comment = new Comment(inputModel.Title, inputModel.Description, inputModel.User, postId);

            post.AddComment(comment);

            return NoContent();
        }
    }
}