using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quizard.API.Dtos;
using Quizard.API.Models;

namespace Quizard.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Question, QuestionForDetailedDto>();
            CreateMap<Answer, AnswerForDetailedDto>();
            CreateMap<Answer, AnswerForPostDto>().ReverseMap();
            CreateMap<Question, QuestionForPostDto>()
                .ForMember(dest => dest.Answers, opt =>
                    opt.MapFrom(src => src.Answers.Select(x => new AnswerForPostDto {AnswerText = x.AnswerText, Correct = x.Correct}))).ReverseMap();
        }
    }
}
