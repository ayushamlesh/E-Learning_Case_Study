using Associate.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TekGain.DAL.ErrorHandler;

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


        [HttpGet("GetAllAssociate")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllAssociate()
        {

            var result = _associateRepository.GetAllAssociate();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("GetAllAssociate failure");
            }
        }


        [HttpGet("GetAssociateById/{id}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetAssociateById(int id)
        {
            try
            {
                var asot = _associateRepository.GetAssociateById(id);
            
                return Ok(asot);

            }
            catch (ServiceException ex)
            {
                return BadRequest("Invalid associate id");

            }
        }

        [HttpPost("AddAssociate")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAssociate([FromBody] TekGain.DAL.Entities.Associate associate)
        {
            try
            {
                var result = _associateRepository.AddAssociate(associate);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateAssociateAddress/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateAssociateAddress(int id, [FromBody] string address)
        {
            try
            {
                var result = _associateRepository.UpdateAssociateAddress(id, address);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
