using Associate.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Associate.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AssociateController : ControllerBase
    {
        // Implement the Services here
        private readonly IAssociateRepository _associateRepository;
        public AssociateController(IAssociateRepository associateRepository)
        {
            _associateRepository = associateRepository;

        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAssociateById/{id}")]
        public IActionResult GetAssociateById(int id)
        {
            try
            {
                var associate = _associateRepository.GetAssociateById(id);
                if (associate != null)
                {
                    return Ok(associate);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("GetAllAssociate")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllAssociate()
        {
            var result = _associateRepository.GetAllAssociate();
            if (result != null)
            {
                return Ok(result);
            }
            else { return BadRequest("Failed to get Associates."); 
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddAssociate")]
        public IActionResult AddAssociate([FromBody] TekGain.DAL.Entities.Associate associate)
        {
            try
            {
                _associateRepository.AddAssociate(associate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateAssociateAddress/{id}")]
        public IActionResult UpdateAssociateAddress(int id, [FromBody] string addr)
        {
            try
            {
                _associateRepository.UpdateAssociateAddress(id, addr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}