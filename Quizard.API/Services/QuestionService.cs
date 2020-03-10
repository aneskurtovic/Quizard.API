﻿using AutoMapper;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Helpers;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repo;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Question> AddQuestionAndCategory(CreateQuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            if (question.Answers.Count() < 2)
            {
                throw new Exception("There should be atleast 2 answers.");

            }
            if (question.Answers.Where(x => x.IsCorrect).Count() < 1) { 
                throw new Exception("There should be atleast one correct answer.");
            }

            await _repo.AddQuestion(question);

            foreach (var category in questionDto.Categories)
            {
                await _repo.AddQuestionCategory(question.Id, category);
            }

            if (await _repo.SaveAll())
            {
                return question;
            }
            throw new Exception("You must enter atleast one category.");
        }

        public async Task<PagedResult<GetQuestionForListDto>> GetQuestions(QuestionParams questionParams)
        {
            var questions = await _repo.GetQuestions(questionParams);
            var questionDtos = _mapper.Map<IEnumerable<GetQuestionForListDto>>(questions.Data);
            var results = new PagedResult<GetQuestionForListDto>(questionDtos, questions.Metadata.Total, questions.Metadata.Offset, questions.Metadata.PageSize);
            return results;
        }
    }
}