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
    public class InspectionTypesController : ControllerBase
    {
        private readonly IInspectionTypeService _inspectionTypeService;

        public InspectionTypesController(IInspectionTypeService inspectionTypeService)
        {
            _inspectionTypeService = inspectionTypeService;
        }

        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<InspectionType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), 500)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetInspectionTypes()
        {
            try
            {
                var inspectionTypes = await _inspectionTypeService.GetInspectionTypes();

                if (inspectionTypes != null)
                {
                    return Ok(inspectionTypes);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpGet("{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(InspectionType), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), 500)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetInspectionType(int id)
        {
            try
            {
                var inspectionType = await _inspectionTypeService.GetInspectionTypeById(id);

                if (inspectionType != null)
                {
                    return Ok(inspectionType);
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
        public async Task<IActionResult> PutInspectionType(int id, InspectionType inspectionType)
        {
            try
            {
                if (inspectionType == null || id != inspectionType.Id)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect request" });
                }

                var existingStatus = await _inspectionTypeService.GetInspectionTypeById(id);

                if (existingStatus == null)
                {
                    return BadRequest(new ResponseMessage { Message = $"InspectionType with id {id} not found" });
                }

                await _inspectionTypeService.UpdateInspectionType(inspectionType);

                return Ok(new ResponseMessage { Message = "InspectionType updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpPost, AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<InspectionType>> PostInspectionType(InspectionType inspectionType)
        {
            try
            {
                if (inspectionType == null)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect request" });
                }

                await _inspectionTypeService.CreateInspectionType(inspectionType);

                return Ok(new ResponseMessage { Message = "InspectionType created" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionType(int id)
        {
            try
            {
                var inspectionType = await _inspectionTypeService.GetInspectionTypeById(id);

                if (inspectionType == null)
                {
                    return BadRequest(new ResponseMessage { Message = "Incorrect id" });
                }

                await _inspectionTypeService.DeleteInspectionType(inspectionType.Id);

                return Ok(new ResponseMessage { Message = "InspectionType deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }
    }
}
