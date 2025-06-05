using api.Dto;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CommentController(IServiceManager service)
        {
            _service = service;
        }

        // GET: api/comments
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                Console.WriteLine("GetAllComments called");
                var comments = await _service.CommentService.GetAllCommentsAsync(trackChanges: false);
                Console.WriteLine($"Retrieved {comments?.Count() ?? 0} comments");
                return Ok(comments);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetAllComments: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }


        // GET: api/comments/question/{questionId}
        [HttpGet("question/{questionId:int}")]
        public async Task<IActionResult> GetCommentsForQuestion(int questionId)
        {
            var comments = await _service.CommentService.GetCommentsForQuestionAsync(questionId, trackChanges: false);
            return Ok(comments);
        }

        // GET: api/comments/{id}
        [HttpGet("{id:int}", Name = "CommentById")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _service.CommentService.GetCommentByIdAsync(id, trackChanges: false);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        // POST: api/comments
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentForCreateDto commentDto)
        {
            if (commentDto == null)
                return BadRequest("Comment data is missing.");

            var createdComment = await _service.CommentService.CreateCommentAsync(commentDto);
            return CreatedAtRoute("CommentById", new { id = createdComment.Id }, createdComment);
        }

        // PUT: api/comments/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentForUpdateDto commentDto)
        {
            if (commentDto == null)
                return BadRequest("Comment data is missing.");

            var existingComment = await _service.CommentService.GetCommentByIdAsync(id, trackChanges: false);
            if (existingComment == null)
                return NotFound($"Comment with ID {id} not found.");

            await _service.CommentService.UpdateCommentAsync(id, commentDto, trackChanges: true);
            return NoContent();
        }

        // DELETE: api/comments/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var existingComment = await _service.CommentService.GetCommentByIdAsync(id, trackChanges: false);
            if (existingComment == null)
                return NotFound($"Comment with ID {id} not found.");

            await _service.CommentService.DeleteCommentAsync(id, trackChanges: false);
            return NoContent();
        }
    }
}
