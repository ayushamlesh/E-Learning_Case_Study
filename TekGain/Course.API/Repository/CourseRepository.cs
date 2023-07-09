using TekGain.DAL.ErrorHandler;
using TekGain.DAL;
using TekGain.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Course.API.Repository
{
    public class CourseRepository : ICourseRepository
    {
        // Implement the code here

        private readonly TekGainContext _context;
        private readonly ILogger<CourseRepository> _logger;
        public CourseRepository(
            TekGainContext context,
            ILogger<CourseRepository> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        public List<TekGain.DAL.Entities.Course> GetAllCourse()
        {
            return _context.Courses.ToList();
        }

        public TekGain.DAL.Entities.Course? GetCourseById(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                throw new ServiceException("Invalid Course Id");
            }

            return course;
        }

        public bool AddCourse(TekGain.DAL.Entities.Course course)
        {
            var existingCourse = _context.Courses.FirstOrDefault(c => c.Name == course.Name);

            if (existingCourse != null)
            {
                return false;
            }

            _context.Courses.Add(course);
            _context.SaveChanges();

           // _logger.LogInformation($"{DateTime.Now} INFO: Added course-{course.Name}");
            _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Added course-{course.Name}");
            return true;
        }

        public bool UpdateCourse(int id, int fee)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return false;
            }

            course.Fee = fee;
            _context.SaveChanges();
           // _logger.LogInformation($"{DateTime.Now} INFO: Updated course fee course-{id}");
            _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Updated course fee course-{id}");
            return true;
        }

        public double GetRating(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return 0;
            }
            return course.Rating;
        }

        public bool CalculateAverageRating(int id, double rating)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return false;
            }

            var averageRating = (course.Rating + rating) / 2;

            course.Rating = averageRating;
            _context.SaveChanges();
            //_logger.LogInformation($"{DateTime.Now} INFO: Updated course ratings course-{id}");
            _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Updated course ratings course-{id}");
            return true;
        }
    }
}
