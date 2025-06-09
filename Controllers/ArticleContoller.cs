using api.Dto;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ArticleController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            try
            {
                Console.WriteLine("GetAllArticles called");
                var articles = await _service.ArticleService.GetAllArticlesAsync(trackChanges: false);
                return Ok(articles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetAllArticles: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}", Name = "ArticleById")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _service.ArticleService.GetArticleByIdAsync(id, trackChanges: false);
            if (article == null)
                return NotFound($"Article with ID {id} not found.");

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleForCreateDto articleDto)
        {
            if (articleDto == null)
                return BadRequest("Article data is missing.");

            try
            {
                var createdArticle = await _service.ArticleService.CreateArticleAsync(articleDto);
                return CreatedAtRoute("ArticleById", new { id = createdArticle.Id }, createdArticle);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateArticle: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] ArticleForUpdateDto articleDto)
        {
            if (articleDto == null)
                return BadRequest("Article data is missing.");

            var existingArticle = await _service.ArticleService.GetArticleByIdAsync(id, trackChanges: false);
            if (existingArticle == null)
                return NotFound($"Article with ID {id} not found.");

            await _service.ArticleService.UpdateArticleAsync(id, articleDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var existingArticle = await _service.ArticleService.GetArticleByIdAsync(id, trackChanges: false);
            if (existingArticle == null)
                return NotFound($"Article with ID {id} not found.");

            await _service.ArticleService.DeleteArticleAsync(id, trackChanges: false);
            return NoContent();
        }
    }
}
