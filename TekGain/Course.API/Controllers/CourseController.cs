using Course.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var result = _courseRepository.AddCourse(course);
            if (result != null)
            {
                return Ok(result);
            }
            else { return BadRequest("Failed to add course."); }
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
            else { return BadRequest("Failed to get courses."); }
        }
        [HttpPut("UpdateCourse/{id}")]
       [Authorize(Roles = "Admin")]
        public IActionResult UpdateCourse(int id, [FromBody] int fee)
        {
            var result = _courseRepository.UpdateCourse(id, fee);
            if (result != null)
            {
                return Ok(result);
            }
            else { return BadRequest("Failed to update course."); }
        }
        [HttpGet("GetCourseById/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetCourseById(int id)
        {
            var result = _courseRepository.GetCourseById(id);
            if (result != null)
            { return Ok(result); }
            else { return BadRequest("Failed to get course by id."); }
        }

        [HttpGet]
        [Route("GetRating/{id}")]

        [Authorize(Roles = "Admin")]
        public IActionResult GetRaiting(int id)
        {
            var result = _courseRepository.GetRating(id);
            if (result != null)
            { return Ok(result); }
            else { return BadRequest("Failed to get course raiting by  id."); }
        }


        [HttpPut("CalculateAverageRating/{id}/{rating}")]
        [Authorize(Roles = "Admin")]
        public IActionResult CalculateAverageRating(int id, double rating)
        {
            var result = _courseRepository.CalculateAverageRating(id, rating);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to calculate average rating.");
            }
        }

    



    }
}