using Microsoft.AspNetCore.Mvc;
using InspectionAPI.Data.Entities;
using InspectionAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using InspectionAPI.Controllers.Helpers;
using System.Net;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Status>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), 500)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetStatuses()
        {
            try
            {
                var statuses = await _statusService.GetStatuses();

                if (statuses != null)
                {
                    return Ok(statuses);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseMessage { Message = ex.Message});
            }
        }

        [HttpGet("{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(Status), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), 500)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetStatus(int id)
        {
            try
            {
                var status = await _statusService.GetStatusById(id);

                if (status != null)
                {
                    return Ok(status);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpPut("{id}"), AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutStatus(int id, Status status)
        {
            try
            {
                if (status == null || id != status.Id)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect request" });
                }

                var existingStatus = await _statusService.GetStatusById(id);

                if (existingStatus == null)
                {
                    return BadRequest(new ResponseMessage { Message = $"Status with id {id} not found" });
                }

                await _statusService.UpdateStatus(status);

                return Ok(new ResponseMessage { Message = "Status updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpPost, AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostStatus(Status status)
        {
            try
            {
                if (status == null)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect request" });
                }

                await _statusService.CreateStatus(status);

                return Ok(new ResponseMessage { Message = "Status created" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            try
            {
                var status = await _statusService.GetStatusById(id);

                if (status == null)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect id" });
                }

                await _statusService.DeleteStatus(status.Id);

                return Ok(new ResponseMessage { Message = "Status deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }
    }
}
