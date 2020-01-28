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
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id));

            CreateMap<Category, CategoryForPostDto>().ReverseMap();

            CreateMap<Question, QuestionForListDto>()
                .ForMember(x => x.Categories, opt=> opt.MapFrom(src => src.QuestionsCategories.Select(x => x.Category.Name)));
            CreateMap<Answer, AnswerForListDto>();
            
            CreateMap<DifficultyLevel, DifficultyLevelForListDto>();

        }
    }
}
