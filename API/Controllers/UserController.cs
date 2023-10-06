using Application.Models.DTOs;
using Application.Models.DTOs.Category;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IClientService _service;

        public UserController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("getAllWorkers")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetAllWorkers()
        {
            return Ok(await _service.GetAllWorkersAsync());
        }

        [HttpGet("allCategories")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public ActionResult<IEnumerable<CategoryShowDTO>> SeeAllCategories()
        {
            return Ok(_service.SeeAllCategories());
        }

        [HttpGet("getWorkersByRating")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetWorkersByRating(bool Descending)
        {
            return Ok(await _service.GetWorkersByRatingAsync(Descending));
        }
        [HttpGet("getWorkersByCategory")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public ActionResult<IEnumerable<WorkerDTO>> GetWorkersByCategory(string categoryId)
        {
            return Ok(_service.GetWorkersByCategory(categoryId));
        }

        [HttpGet("seeMyRequests")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public ActionResult<UserRequestDTO> GetAllRequests(string userEmail)
        {
            return Ok(_service.GetUsersRequests(userEmail));
        }

        [HttpPost("rateWork")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public async Task<ActionResult<bool>> RateWork([FromBody] RateWorkDTO request)
        {
            var result = await _service.RateWorkDoneAsync(request);

            if (!result)
                return BadRequest(result);

            return result;
        }

        [HttpPost("sendWorkRequest")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User, Admin")]
        public async Task<ActionResult<bool>> SendWorkRequest([FromBody] WorkRequestDTO request)
        {
            var result = await _service.SendWorkRequest(request);

            if (!result)
                return BadRequest(request);

            return result;
        }
    }
}
