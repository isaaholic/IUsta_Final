using Application.Models;
using Application.Models.DTOs;
using Application.Models.DTOs.Category;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet("showAll")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public ActionResult<IEnumerable<CategoryShowDTO>> GetAllCategories()
        {
            return Ok(_service.GetAllCategories());
        }

        [HttpGet("getStatistics")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public ActionResult<Statistics> GetStatistics()
        {
            return _service.GetStatistics();
        }

        [HttpPost("addCategory")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult<bool>> AddCategory([FromBody] CategoryDTO request)
        {
            return await _service.AddCategoryAsync(request);
        }

        [HttpPut("updateCategory")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult<bool>> UpdateCategory([FromBody] CategoryUpdateDTO request)
        {
            return await _service.UpdateCategoryAsync(request);
        }

        [HttpPost("addAdmin")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult<bool>> AddAdmin([FromBody] LoginRequest request)
        {
           return await _service.AddNewAdmin(request);
        }

    }
}
