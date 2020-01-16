<<<<<<< HEAD
﻿using System.Linq;
using AutoMapper;
using Quizard.API.Dtos;
using Quizard.API.Models;
=======
﻿using AutoMapper;
using Quizard.API.Dtos;
using Quizard.API.Models;
using System.Linq;
>>>>>>> Quizard5-AnesEdiCategory

namespace Quizard.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Question, QuestionForDetailedListDto>();
            CreateMap<Answer, AnswerForDetailedListDto>();
<<<<<<< HEAD

            CreateMap<Question, QuestionForListDto>();
            CreateMap<Answer, AnswerForListDto>();

            CreateMap<Answer, AnswerToPostDto>().ReverseMap();
            CreateMap<Question, QuestionToPostDto>()
                .ForMember(dest => dest.Answers, opt =>
                    opt.MapFrom(src => src.Answers.Select(x => new AnswerToPostDto {Text = x.Text, IsCorrect = x.IsCorrect}))).ReverseMap();
=======
            CreateMap<Answer, AnswerToPostDto>().ReverseMap();
            CreateMap<Question, QuestionToPostDto>()
                .ForMember(dest => dest.Answers, opt =>
                    opt.MapFrom(src => src.Answers.Select(x => new AnswerToPostDto { Text = x.Text, IsCorrect = x.IsCorrect })))
                .ForMember(dest => dest.Categories, opt => 
                opt.MapFrom(src => src.QuestionsCategories.Select(x => new QuestionCategoryForPost { CategoryID = x.CategoryID, QuestionID = x.QuestionID})))
                .ReverseMap();

            CreateMap<Category, CategoryForGet>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Category, CategoryForPost>().ReverseMap();

>>>>>>> Quizard5-AnesEdiCategory
        }
    }
}
