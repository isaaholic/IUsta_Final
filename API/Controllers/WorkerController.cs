using Application.Models.DTOs;
using Application.Models.DTOs.Worker;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _service;

        public WorkerController(IWorkerService service)
        {
            _service = service;
        }

        [HttpGet("profile")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Worker")]
        public async Task<ActionResult<ProfileDTO>> GetProfile(string email)
        {
            return Ok(await _service.GetWorkerProfile(email));
        }

        [HttpGet("allActiveRequests")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Worker")]
        public ActionResult<IEnumerable<RequestDTO>> GetActiveRequests(string email)
        {
           return Ok(_service.SeeActiveRequests(email));
        }

        [HttpGet("seeInactiveRequests")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Worker")]
        public ActionResult<IEnumerable<RequestDTO>> GetInactiveRequests(string email)
        {
            return Ok(_service.SeeInactiveRequests(email));
        }

        [HttpGet("seeCompletedRequests")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Worker")]
        public ActionResult<IEnumerable<RequestDTO>> GetCompletedRequests(string email)
        {
            return Ok(_service.SeeCompletedTasks(email));
        }

        [HttpPost("completeTask")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Worker")]
        public async Task<ActionResult<bool>> CompleteTask([FromBody] SetWorkDoneRequest request)
        {
            return Ok(await _service.SetWorkDoneAsync(request));
        }

        [HttpPost("acceptTask")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Worker")]
        public async Task<ActionResult<bool>> AcceptTask([FromBody] AcceptWorkRequest request)
        {
            return Ok(await _service.AcceptWorkAsync(request));
        }

        [HttpPost("rejectTask")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Worker")]
        public async Task<ActionResult<bool>> RejectTask([FromBody] RejectWorkRequest request)
        {
            return Ok(await _service.RejectWorkAsync(request));
        }

        [HttpPost("newCategory")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Worker")]
        public async Task<ActionResult<bool>> RegisterInNewCategory([FromBody] CategoryRegisterRequest request)
        {
            return Ok(await _service.RegisterInNewCategory(request));
        }
    }
}
