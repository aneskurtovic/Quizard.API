<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
﻿using System.Threading.Tasks;
>>>>>>> Quizard5-AnesEdiCategory
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizard.API.Data;
using Quizard.API.Dtos;
<<<<<<< HEAD
using Quizard.API.Helpers;
=======
>>>>>>> Quizard5-AnesEdiCategory
using Quizard.API.Models;

namespace Quizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _repo;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<IActionResult> GetQuestions([FromQuery]QuestionParams questionParams)
        {
            var questions = await _repo.GetQuestions(questionParams);

            var questionsToReturn = _mapper.Map<IEnumerable<QuestionForListDto>>(questions);

            Response.AddPagination(questions.CurrentPage, questions.PageSize, 
                questions.TotalCount, questions.TotalPages);

            return Ok(questionsToReturn);
=======
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _repo.GetQuestions();

            return Ok(questions);
>>>>>>> Quizard5-AnesEdiCategory
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _repo.GetQuestion(id);

            var questionToReturn = _mapper.Map<QuestionForDetailedListDto>(question);

            return Ok(questionToReturn);
        }

        [HttpPost]        
        public async Task<IActionResult> Post([FromBody]QuestionToPostDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto); //maping object from QuestionForPostDto into question

            await _repo.AddQuestion(question);

<<<<<<< HEAD
            if (await _repo.SaveAll())
            {
                return Ok(question);
            }

            return BadRequest();
=======
            await _repo.SaveAll();

            var questionId = _repo.GetQuestionIDByText(question.Text);

            foreach (var cat in questionDto.Categories)
            {
                _repo.AddQuestionCategory(questionId, cat);
            }


            await _repo.SaveAll();

            return Ok(question);
>>>>>>> Quizard5-AnesEdiCategory
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuestionToPostDto model)
        {
            var question = _repo.GetQuestion(id);
            if (question == null)
            {
                return NotFound();
            }
            
            await _mapper.Map(model, question);

            if (await _repo.SaveAll())
            {
                return Ok(_mapper.Map<QuestionToPostDto>(question));
            }

            return BadRequest();
        }
    }
}