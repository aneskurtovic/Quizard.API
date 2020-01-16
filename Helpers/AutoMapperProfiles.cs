using System.Linq;
using AutoMapper;
using Quizard.API.Dtos;
using Quizard.API.Models;

namespace Quizard.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Question, QuestionForDetailedListDto>();
            CreateMap<Answer, AnswerForDetailedListDto>();

            CreateMap<Question, QuestionForListDto>();
            CreateMap<Answer, AnswerForListDto>();

            CreateMap<Answer, AnswerToPostDto>().ReverseMap();
            CreateMap<Question, QuestionToPostDto>()
                .ForMember(dest => dest.Answers, opt =>
                    opt.MapFrom(src => src.Answers.Select(x => new AnswerToPostDto {Text = x.Text, IsCorrect = x.IsCorrect}))).ReverseMap();
        }
    }
}
