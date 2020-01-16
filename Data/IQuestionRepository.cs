﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Quizard.API.Helpers;
using Quizard.API.Models;

namespace Quizard.API.Data
{
    public interface IQuestionRepository
    {
        Task AddQuestion<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<Question>> GetQuestions(QuestionParams questionParams);
        Task<Question> GetQuestion(int id);

    }
}