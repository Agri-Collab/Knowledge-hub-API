using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dto;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IServiceManager _service;

        public QuestionController(IServiceManager service)
        {
            _service = service;
        }

        // GET: api/questions
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var questions = await _service.QuestionService.GetAllQuestionsAsync(trackChanges: false);
                return Ok(questions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetAllQuestions: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/questions/{id}
        [HttpGet("{id:int}", Name = "QuestionById")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            try
            {
                var question = await _service.QuestionService.GetQuestionByIdAsync(id, trackChanges: false);

                if (question == null)
                    return NotFound();

                return Ok(question);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetQuestionById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/questions
        [HttpPost("Create")]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionForCreateDto questionDto)
        {
            if (questionDto == null)
                return BadRequest("Question data is missing.");

            try
            {
                var createdQuestion = await _service.QuestionService.CreateQuestionAsync(questionDto);
                return CreatedAtRoute("QuestionById", new { id = createdQuestion.Id }, createdQuestion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in CreateQuestion: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/questions/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionForUpdateDto questionDto)
        {
            if (questionDto == null)
                return BadRequest("Question data is missing.");

            try
            {
                var questionExists = await _service.QuestionService.GetQuestionByIdAsync(id, trackChanges: false);
                if (questionExists == null)
                    return NotFound($"Question with ID {id} not found.");

                await _service.QuestionService.UpdateQuestionAsync(id, questionDto, trackChanges: true);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateQuestion: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/questions/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                var questionExists = await _service.QuestionService.GetQuestionByIdAsync(id, trackChanges: false);
                if (questionExists == null)
                    return NotFound($"Question with ID {id} not found.");

                await _service.QuestionService.DeleteQuestionAsync(id, trackChanges: false);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in DeleteQuestion: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
