using Application.Models;
using Application.Models.DTOs;
using Application.Models.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAdminService
    {
        public Task<bool> AddCategoryAsync(CategoryDTO request);
        public Task<bool> UpdateCategoryAsync(CategoryUpdateDTO requset);
        public Task<bool> AddNewAdmin(LoginRequest request);
        public IEnumerable<CategoryShowDTO> GetAllCategories();
        public Statistics GetStatistics();
    }
}
