using AutoMapper;
using Quizard.API.Dtos;
using Quizard.API.Models;
using System;
using System.Linq;

namespace Quizard.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Answer, CreateAnswerDto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>()
                .ForMember(dest => dest.Answers, opt =>
                    opt.MapFrom(src => src.Answers.Select(x => new CreateAnswerDto { Text = x.Text, IsCorrect = x.IsCorrect })))
                .ForMember(dest => dest.Categories, opt =>
                opt.MapFrom(src => src.QuestionsCategories.Select(x => new CreateQuestionCategoryDto { CategoryID = x.CategoryID, QuestionID = x.QuestionID })))
                .ReverseMap();

            CreateMap<Category, GetCategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id));

            CreateMap<Category, CreateCategoryDto>().ReverseMap();

            CreateMap<Question, GetQuestionForListDto>()
                .ForMember(x => x.Categories, opt => opt.MapFrom(src => src.QuestionsCategories.Select(x => x.Category.Name)));

            CreateMap<DifficultyLevel, GetDifficultyLevelDto>();

            CreateMap<Quiz, CreateQuizDto>()
                .ForMember(dest => dest.QuestionIds, opt =>
                opt.MapFrom(src => src.QuizzesQuestions.Select(x => new QuizQuestion { QuestionId = x.QuestionId, QuizId = x.QuizId })))
                .ReverseMap();

            CreateMap<Quiz, GetQuizDto>()
               .ForMember(dest => dest.Questions, opt =>
               opt.MapFrom(src => src.QuizzesQuestions.Select(x => x.Question))).ReverseMap();


            CreateMap<Session, GetSessionDto>()
                .ForMember(dest => dest.Questions, opt =>
                    opt.MapFrom(src => src.Quiz.QuizzesQuestions.Select(x => x.Question)))
                .ForMember(dest => dest.TimeLeft, opt =>
                    opt.MapFrom(x => (int)x.FinishedAt.Subtract(DateTime.Now).TotalSeconds))
                .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(x=>x.Quiz.Name))
                .ReverseMap();

            CreateMap<Session, CreateSessionDto>().ReverseMap();
            CreateMap<Question, GetQuestionForQuizDto>().ReverseMap();
            CreateMap<Answer, GetAnswerDto>().ReverseMap();
            CreateMap<Session, GetSessionForLeaderboardDto>().ReverseMap();
            CreateMap<Quiz, GetQuizForLeaderboardDto>().ReverseMap();

            CreateMap<Quiz, GetQuizForListDto>()
                .ForMember(dest => dest.NumberOfQuestions, opt => opt.MapFrom(src => src.QuizzesQuestions.Where(x=>x.QuizId == src.Id).Count())).ReverseMap();
            CreateMap<Session, ResponseSessionDto>()
                .ForMember(dest=> dest.Id, opt=> opt.MapFrom(src=>src.Id))
                .ForMember(dest => dest.QuizId, opt => opt.MapFrom(src => src.QuizId)).ReverseMap();


        }
    }
}
