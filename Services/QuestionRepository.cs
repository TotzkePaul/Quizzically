using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quizzically.Data;

namespace Quizzically.Services
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionListAsync();
        Task<Question> CreateQuestionsAsync(Question question);
        Task<Question> GetQuestionAsync(Guid Id);
        Task<IEnumerable<Question>> GetQuestionByQuizIdAsync(Guid quizId);
        Task<bool> SaveAll();
    }
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Question> CreateQuestionsAsync(Question question)
        {
            await _dbContext.Questions.AddAsync(question);
            await _dbContext.SaveChangesAsync();
            return question;
        }

        public async Task<Question> GetQuestionAsync(Guid Id)
        {
            return await _dbContext.Questions .Where(c => c.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestionByQuizIdAsync(Guid quizId)
        {
            return await _dbContext.Questions .Where(c => c.QuizId == quizId).ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestionListAsync()
        {
             return await _dbContext.Questions.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
             return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}