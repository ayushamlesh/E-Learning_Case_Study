using Admission.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admission.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        // Implement the Services here
        private readonly IAdmissionRepository _admissionRepository;
        public AdmissionController(IAdmissionRepository admissionRepository)
        {
            _admissionRepository = admissionRepository;
        }

        // [Authorize(Roles = "Admin")]
        [HttpGet("Register/{associateId}/{courseId}")]
        public async Task<IActionResult> RegisterAssociateForCourse([FromRoute] int associateId, [FromRoute] int courseId)
        {
            string bearerToken = HttpContext.Request.Headers["Authorization"];
            var result = await _admissionRepository.RegisterAssociateForCourse(associateId, courseId, bearerToken);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to register associate for the course.");
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("CalculateFees/{associateId}")]
        public async Task<IActionResult> CalculateFees([FromRoute] int associateId)
        {

            var result = await _admissionRepository.CalculateFees(associateId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to calculate fees.");
            }
        }

        // [Authorize(Roles = "User")]
        [HttpPost("Feedback/{id}/{feedback}/{feedbackRating}")]
        public async Task<IActionResult> AddFeedback([FromRoute] int admissionId, [FromRoute] string feedback, [FromRoute] float feedbackRating)
        {
            string bearerToken = HttpContext.Request.Headers["Authorization"];
            var result = await _admissionRepository.AddFeedback(admissionId, feedback, feedbackRating, bearerToken);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to add feedback.");
            }
        }

        // [Authorize(Roles = "Admin")]
        [HttpGet("HighestFee/{associateId}")]
        public async Task<IActionResult> HighestFee([FromRoute] int associateId)
        {
            var result = await _admissionRepository.HighestFee(associateId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to get the highest fee.");
            }
        }

        // [Authorize(Roles = "Admin,User")]
        [HttpGet("ViewFeedbackByCourseId/{courseId}")]
        public async Task<IActionResult> ViewFeedbackByCourseId([FromRoute] int courseId)
        {
            var result = await _admissionRepository.ViewFeedbackByCourseId(courseId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to view feedback by course ID.");
            }
        }
        // [Authorize(Roles = "Admin")]
        [HttpDelete("DeactivateAdmission/{courseId}")]
        public async Task<IActionResult> DeactivateAdmission([FromRoute] int courseId)
        {
            string bearerToken = HttpContext.Request.Headers["Authorization"];
            var result = await _admissionRepository.DeactivateAdmission(courseId, bearerToken);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {

                return BadRequest("Failed to deactivate admission.");
            }
        }

        // [Authorize(Roles = "Admin,User")]
        [HttpPost("MakePayment/{admissionId}")]
        public async Task<IActionResult> MakePayment([FromRoute] int admissionId)

        {
            string bearerToken = HttpContext.Request.Headers["Authorization"];
            var result = await _admissionRepository.MakePayment(admissionId, bearerToken);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to make payment.");
            }
        }

    }
}