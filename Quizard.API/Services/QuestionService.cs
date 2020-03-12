using AutoMapper;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Helpers;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                throw new Exception("There should be at least 2 answers.");
            }
            if (question.Answers.Where(x => x.IsCorrect).Count() < 1) {
                throw new ValidationException("There should be at least one correct answer.");
            }
            if (questionDto.Categories == null || questionDto.Categories.Length == 0)
            {
                throw new ValidationException("You must enter at least one category.");
            }
            await _repo.AddQuestion(question);

            foreach (var category in questionDto.Categories)
            {
                await _repo.AddQuestionCategory(question.Id, category);
            }
            return question;            
        }

        public async Task<PagedResult<GetQuestionForListDto>> GetQuestions(QuestionParams questionParams)
        {
            var questions = await _repo.GetQuestions(questionParams);
            questions = SearchByName(questions, questionParams.Name);
            questions = FilterByCategory(questions, questionParams.Category, questionParams.Operand);

            var count = questions.Count();
            var data = questions.Skip(questionParams.Offset * questionParams.PageSize).Take(questionParams.PageSize).ToList();

            var pagedQuestion =  new PagedResult<Question>(data, count, questionParams.Offset, questionParams.PageSize);
            var questionDtos = _mapper.Map<IEnumerable<GetQuestionForListDto>>(pagedQuestion.Data);
            var results = new PagedResult<GetQuestionForListDto>
                (
                    questionDtos, 
                    pagedQuestion.Metadata.Total,
                    pagedQuestion.Metadata.Offset,
                    pagedQuestion.Metadata.PageSize
                );
            return results;
        }

        private List<Question> SearchByName(List<Question> questions, string questionName)
        {
            if (string.IsNullOrWhiteSpace(questionName))
            {
                return questions;
            }

            return  questions.Where(o => o.Text.ToLower().Contains(questionName.Trim().ToLower())).ToList();
        }

        private List<Question> FilterByCategory(List<Question> questions, IList<int> categoriesnest, CategoryOperand? operand)
        {
            if (categoriesnest.Count == 0 || !operand.HasValue)
            {
                return questions;
            }


            if (operand == CategoryOperand.Or)
            {
                questions = questions.Where(c => c.QuestionsCategories
                                                    .Any(y => categoriesnest.Contains(y.CategoryID))).ToList();
            }
            else if (operand == CategoryOperand.And)
            {
                questions = questions.Where(q => q.QuestionsCategories.All(qc => categoriesnest.Contains(qc.CategoryID))
                                                  && q.QuestionsCategories.Count == categoriesnest.Count).ToList();
            }

            return questions;
        }
    }
}
