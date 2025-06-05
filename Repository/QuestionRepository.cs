using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repository
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void CreateQuestion(Question question)
        {
            Create(question);
        }

        public void UpdateQuestion(Question question)
        {
            Update(question);
        }

        public void DeleteQuestion(Question question)
        {
            Delete(question);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderByDescending(q => q.CreatedAt)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(int id, bool trackChanges)
        {
            var question = await FindByCondition(q => q.Id == id, trackChanges).SingleOrDefaultAsync();

            if (question == null)
                throw new KeyNotFoundException($"Question with id {id} was not found.");

            return question;
        }
    }
}
