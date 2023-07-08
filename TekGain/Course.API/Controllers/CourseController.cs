using Course.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TekGain.DAL.ErrorHandler;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Course.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // Implement the Services here
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost("AddCourse")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCourse([FromBody] TekGain.DAL.Entities.Course course)
        {
            // Call the AddCourse method of the CourseRepository
            bool result = _courseRepository.AddCourse(course);

            if (result)
            {
                return Ok(result);
            }

//            return BadRequest("AddCourse failure");
            return BadRequest(result);

        }

        [HttpGet("GetAllCourse")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAllCourse()
        {
            var result = _courseRepository.GetAllCourse();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("GetAllCourse failure");
            }
        }

        [HttpPut("UpdateCourse/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCourse(int id, [FromBody] int fee)
        {
            var result = _courseRepository.UpdateCourse(id, fee);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
                //return BadRequest("UpdateCourse failure");
            }
        }

        [HttpGet("GetCourseById/{id}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetCourseById(int id)
        {
            try
            {
                var result = _courseRepository.GetCourseById(id);
                return Ok(result);
            }
            catch (ServiceException ex)
            {
                return BadRequest(ex.Message);


            }
        }

        [HttpGet("GetRating/{id}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetRating(int id)
        {
            var result = _courseRepository.GetRating(id);
            if (result!=0)
            { return Ok(result); }
            else
            { return BadRequest(result); }
        }

        [HttpPut("CalculateAverageRating/{id}/{rating}")]
        [Authorize(Roles = "Admin")]
        public IActionResult CalculateAverageRating(int id, double rating)
        {
            var result = _courseRepository.CalculateAverageRating(id, rating);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
                // return BadRequest("CalculateAverageRating failure");
            }
        }
    }
}
