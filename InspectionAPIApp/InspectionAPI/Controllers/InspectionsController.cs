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
    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionService _inspectionService;

        public InspectionsController(IInspectionService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Inspection>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), 500)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetInspections()
        {
            try
            {
                var inspections = await _inspectionService.GetInspections();

                if (inspections != null)
                {
                    return Ok(inspections);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpGet("{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(Inspection), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), 500)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetInspection(int id)
        {
            try
            {
                var inspection = await _inspectionService.GetInspectionById(id);

                if (inspection != null)
                {
                    return Ok(inspection);
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
        public async Task<IActionResult> PutInspection(int id, Inspection inspection)
        {
            try
            {
                if (inspection == null || id != inspection.Id)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect request" });
                }

                var existingInspection = await _inspectionService.GetInspectionById(id);

                if (existingInspection == null)
                {
                    return BadRequest(new ResponseMessage { Message = $"Inspection with id {id} not found" });
                }

                await _inspectionService.UpdateInspection(inspection);

                return Ok(new ResponseMessage { Message = "Inspection updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpPost, AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostInspection(Inspection inspection)
        {
            try
            {
                if (inspection == null)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect request" });
                }

                await _inspectionService.CreateInspection(inspection);

                return Ok(new ResponseMessage { Message = "Inspection created" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteInspection(int id)
        {
            try
            {
                var inspection = await _inspectionService.GetInspectionById(id);

                if (inspection == null)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect id" });
                }

                await _inspectionService.DeleteInspection(inspection.Id);

                return Ok(new ResponseMessage { Message = "Inspection deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }
    }
}
