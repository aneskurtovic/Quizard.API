using AutoMapper;
using Quizard.API.Data;
using Quizard.API.Dtos;
using Quizard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizard.API.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryDto>> GetCategories(string searchTerm)
        {
            if (searchTerm == null)
            {
                return null;
            }
            return  _mapper.Map<List<GetCategoryDto>>(await _categoryRepository.GetCategories(searchTerm));
        }
        public async Task<GetCategoryDto> Post(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var existingCat = await _categoryRepository.CategoryExists(categoryDto.Name);
            if (existingCat != null)
            {
                var existingCategoryForGetDto = _mapper.Map<GetCategoryDto>(existingCat);
                return existingCategoryForGetDto;
            }
            await _categoryRepository.AddCategory(category);
            var categoryForGetDto = _mapper.Map<GetCategoryDto>(category);
            return categoryForGetDto;
        }
    }
}
