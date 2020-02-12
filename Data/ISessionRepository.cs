﻿using Quizard.API.Models;
using System.Threading.Tasks;

namespace Quizard.API.Data
{
    public interface ISessionRepository
    {
        Task AddSession(Session session);
    }
}