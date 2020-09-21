using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quizzically.Data;

namespace Quizzically.Services
{
    public interface IQuizAppRepository
    {
        Task<IEnumerable<Quiz>> GetQuizListAsync();
        Task<Quiz> CreateQuizAsync(Quiz quiz);
        Task<Quiz> GetQuizAsync(Guid quizId);
    }

    public class QuizRepository : IQuizAppRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuizRepository(ApplicationDbContext quizAppDbContext)
        {
            _dbContext = quizAppDbContext;
        }

        public async Task<Quiz> CreateQuizAsync(Quiz quiz)
        {
            await _dbContext.Quizzes.AddAsync(quiz);
            await _dbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<IEnumerable<Quiz>> GetQuizListAsync()
        {
             return await _dbContext.Quizzes.ToListAsync();
        }

        public async Task<Quiz> GetQuizAsync(Guid quizId)
        {
            return await _dbContext.Quizzes .Where(c => c.Id == quizId).FirstOrDefaultAsync();
        }
    }
}