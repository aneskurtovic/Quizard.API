using AutoMapper;
using Quizard.API.Dtos;
using Quizard.API.Models;
using System.Linq;

namespace Quizard.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Question, QuestionForDetailedListDto>();
            CreateMap<Answer, AnswerForDetailedListDto>();
            CreateMap<Answer, AnswerToPostDto>().ReverseMap();
            CreateMap<Question, QuestionToPostDto>()
                .ForMember(dest => dest.Answers, opt =>
                    opt.MapFrom(src => src.Answers.Select(x => new AnswerToPostDto { Text = x.Text, IsCorrect = x.IsCorrect })))
                .ForMember(dest => dest.Categories, opt =>
                opt.MapFrom(src => src.QuestionsCategories.Select(x => new QuestionCategoryForPostDto { CategoryID = x.CategoryID, QuestionID = x.QuestionID })))
                .ReverseMap();

            CreateMap<Category, CategoryForGetDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID));

            CreateMap<Category, CategoryForPostDto>().ReverseMap();

        }
    }
}
