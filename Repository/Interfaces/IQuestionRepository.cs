using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync(bool trackChanges);
        Task<Question> GetQuestionAsync(int id, bool trackChanges);
        void CreateQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(Question question);
    }
}
