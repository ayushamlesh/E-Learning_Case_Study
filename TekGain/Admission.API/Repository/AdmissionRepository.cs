using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Net;
using TekGain.DAL;
using TekGain.DAL.Entities;
using TekGain.DAL.ErrorHandler;

namespace Admission.API.Repository
{
    public class AdmissionRepository : IAdmissionRepository
    {
        // Implement the code here
        private readonly TekGainContext _context;
        private readonly ILogger<AdmissionRepository> _logger;
        public AdmissionRepository(TekGainContext context, ILogger<AdmissionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddFeedback(int admissionId, string feedback, double feedbackRating, string bearerToken)
        {
            TekGain.DAL.Entities.Admission admission = await _context.Admissions.FindAsync(admissionId);
            if (admission == null)
            {
                return false;
            }

            admission.Feedback = feedback;


            await _context.SaveChangesAsync();

            _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO : Added feedback for admission-{admissionId}");

            return true;
        }

        public async Task<double> CalculateFees(int associateId)
        {
            double totalFees = 0;

            List<int> courseIds = await _context.Admissions
                .Where(a => a.AssociateId == associateId)
                .Select(a => a.CourseId)
                .ToListAsync();

            foreach (int courseId in courseIds)
            {
                Course course = await _context.Courses.FindAsync(courseId);
                if (course != null)
                {
                    totalFees += course.Fee;
                }
            }
            _logger.LogTrace($"{DateTimeOffset.UtcNow} TRACE : Fee calculated associate-{associateId}");

            return totalFees;
        }

        public async Task<string> DeactivateAdmission(int courseId, string bearerToken)
        {
            Course course = await _context.Courses.FindAsync(courseId);
            if (course == null)
            {
                return "Course not found";
            }

            List<TekGain.DAL.Entities.Admission> admissions = await _context.Admissions
                .Where(a => a.CourseId == courseId)
                .ToListAsync();

            _context.Admissions.RemoveRange(admissions);


            await _context.SaveChangesAsync();

            _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Deactivated admission for course-{courseId}");

            return "Deactivated Successfully";
        }

        public async Task<List<TekGain.DAL.Entities.Admission>> GetAllRegistration()
        {
            List<TekGain.DAL.Entities.Admission> admissions = await _context.Admissions.ToListAsync();

            return admissions;
        }

        public async Task<double> HighestFee(int associateId)
        {
            double highestFee = 0;

            List<int> courseIds = await _context.Admissions
                .Where(a => a.AssociateId == associateId)
                .Select(a => a.CourseId)
                .ToListAsync();

            foreach (int courseId in courseIds)
            {
                Course course = await _context.Courses.FindAsync(courseId);
                if (course != null && course.Fee > highestFee)
                {
                    highestFee = course.Fee;
                }
            }

            return highestFee;
        }

        public async Task<string> MakePayment(int regNo, string bearerToken)
        {
            TekGain.DAL.Entities.Admission admission = await _context.Admissions.FindAsync(regNo);
            if (admission == null)
            {
                return "Admission not found.";
            }

            // Make the payment for the admission using RestSharp or other payment service integration
            // ...
            // Example RestSharp implementation:
            var client = new RestClient("https://localhost:8087/api/Payment/initialize");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            request.AddParameter("application/json", regNo, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            return response.Content;

        }

        public async Task<string> RegisterAssociateForCourse(int associateId, int courseId, string bearerToken)
        {
            bool associateExists = await CheckAssociateExists(associateId, bearerToken);
            if (!associateExists)
            {
                throw new ServiceException("Admission Invalid Exception");
            }

            bool courseExists = await CheckCourseExists(courseId, bearerToken);
            if (!courseExists)
            {
                throw new ServiceException("Admission Invalid Exception");
            }
            TekGain.DAL.Entities.Admission admission = new TekGain.DAL.Entities.Admission
            {
                AssociateId = associateId,
                CourseId = courseId,
                // Add other relevant properties to the admission object
            };
            _context.Admissions.Add(admission);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO : Course registration success Associate-{associateId} course-{courseId}");

            return "Registered Successfully!";
        }

        public async Task<List<string>> ViewFeedbackByCourseId(int courseId)
        {
            List<string> feedbackList = await _context.Admissions
           .Where(a => a.CourseId == courseId && !string.IsNullOrEmpty(a.Feedback))
           .Select(a => a.Feedback)
           .ToListAsync();

            return feedbackList;
        }

        private async Task<bool> CheckAssociateExists(int associateId, string bearerToken)
        {
            // Call the Associate service to check if the associate exists
            var client = new RestClient($"https://localhost:8087/api/Associate/GetAssociateById/{associateId}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            IRestResponse response = await client.ExecuteAsync(request);

            return response.StatusCode == HttpStatusCode.OK;
        }

        private async Task<bool> CheckCourseExists(int courseId, string bearerToken)
        {
            // Call the Course service to check if the course exists
            var client = new RestClient($"https://localhost:8087/api/Course/GetCourseById/{courseId}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            IRestResponse response = await client.ExecuteAsync(request);

            return response.StatusCode == HttpStatusCode.OK;
        }
    }

}