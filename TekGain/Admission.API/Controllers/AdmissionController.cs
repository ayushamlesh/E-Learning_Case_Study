using Admission.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TekGain.DAL.ErrorHandler;

namespace Admission.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionRepository _admissionRepository;
        private readonly ILogger<AdmissionController> _logger;


        public AdmissionController(IAdmissionRepository admissionRepository, ILogger<AdmissionController> logger)
        {
            _admissionRepository = admissionRepository;
            _logger = logger;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAllRegistration")]
        public async Task<ActionResult<List<TekGain.DAL.Entities.Admission>>> GetAllRegistration()
        {
            var result = await _admissionRepository.GetAllRegistration();

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Register/{associateId}/{courseId}")]
        public async Task<IActionResult> RegisterAssociateForCourse([FromRoute] int associateId, [FromRoute] int courseId)
        {
            try
            {
                string result = await _admissionRepository.RegisterAssociateForCourse(associateId, courseId, Request.Headers["Authorization"]);
                _logger.LogInformation($"{DateTime.UtcNow} INFO : Course registration success Associate-{associateId} course-{courseId}");
                return Ok(result);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("CalculateFees/{associateId}")]
        public async Task<IActionResult> CalculateFees([FromRoute] int associateId)
        {
            double result = await _admissionRepository.CalculateFees(associateId);
            _logger.LogTrace($"{DateTime.UtcNow} TRACE : Fee calculated associate-{associateId}");
            return Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpPost("Feedback/{id}/{feedback}/{feedbackRating}")]
        public async Task<IActionResult> AddFeedback([FromRoute] int id, [FromRoute] string feedback, [FromRoute] float feedbackRating)
        {
            try
            {
                bool success = await _admissionRepository.AddFeedback(id, feedback, feedbackRating, Request.Headers["Authorization"]);
                _logger.LogInformation($"{DateTime.UtcNow} INFO : Added Associate-{id}");
                return Ok(success);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("HighestFee/{associateId}")]
        public async Task<IActionResult> HighestFee([FromRoute] int associateId)
        {
            double result = await _admissionRepository.HighestFee(associateId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("ViewFeedbackByCourseId/{courseId}")]
        public async Task<IActionResult> ViewFeedbackByCourseId([FromRoute] int courseId)
        {
            try
            {
                var result = await _admissionRepository.ViewFeedbackByCourseId(courseId);
                return Ok(result);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeactivateAdmission/{courseId}")]
        public async Task<IActionResult> DeactivateAdmission(int courseId)
        {
            try
            {
                string result = await _admissionRepository.DeactivateAdmission(courseId, Request.Headers["Authorization"]);

                if (result != null)
                {
                    _logger.LogInformation($"{DateTime.UtcNow} INFO: Deactivated course-{courseId}");
                    return Ok(result);
                }

                return NotFound();

            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost("MakePayment/{admissionId}")]
        public async Task<IActionResult> MakePayment([FromRoute] int admissionId)
        {
            try
            {
                string result = await _admissionRepository.MakePayment(admissionId, Request.Headers["Authorization"]);
                return Ok(result);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
