﻿using Quizard.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface ICategoryRepository
    {
        Task AddCategory<T>(T entity) where T : class;
        Task<List<Category>> GetCategories(string searchTerm);
        Task<bool> SaveAll();
        Task<Category> CategoryExists(string name);
    }
}