using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Net;
using System.Net.Http;
using TekGain.DAL;
using TekGain.DAL.Entities;
using TekGain.DAL.ErrorHandler;

namespace Admission.API.Repository
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly ILogger<AdmissionRepository> _logger;
        private readonly HttpClient _httpClient;
        private readonly TekGainContext _context;

        public AdmissionRepository(ILogger<AdmissionRepository> logger, HttpClient httpClient, TekGainContext context)
        {
            _logger = logger;
            _httpClient = httpClient;
            _context = context;
        }
        public async Task<List<TekGain.DAL.Entities.Admission>> GetAllRegistration()
        {
            return await _context.Admissions.ToListAsync();
        }

        public async Task<string> RegisterAssociateForCourse(int associateId, int courseId, string bearerToken)
        {
            // Check if the associate exists
            bool associateExists = await CheckAssociateExists(associateId);
            if (!associateExists)
            {
                throw new ServiceException("Admission Invalid Exception");
            }

            // Check if the course exists
            bool courseExists = await CheckCourseExists(courseId);
            if (!courseExists)
            {
                throw new ServiceException("Admission Invalid Exception");
            }

            // Add details to the admission table
         

            TekGain.DAL.Entities.Admission adm = new TekGain.DAL.Entities.Admission
            {
                CourseId = courseId,
                AssociateId = associateId,
                Status = "",
                Feedback = ""
            };

            var addStatus = await _context.Admissions.AddAsync(adm);
            _context.SaveChangesAsync();


            string result = "Registered Successfully!";
            _logger.LogInformation($"{DateTime.UtcNow} INFO : Course registration success Associate-{associateId} course-{courseId}");
            return result;
        }

        public async Task<double> CalculateFees(int associateId)
        {
            // Calculate associate's fees
            // ...

            List<TekGain.DAL.Entities.Admission> admission = _context.Admissions.Where(x => x.AssociateId == associateId).ToList();

            double result = 0.0;

            foreach (TekGain.DAL.Entities.Admission adm in admission)
            {
                TekGain.DAL.Entities.Course course = _context.Courses.Where(x => x.Id == adm.CourseId).FirstOrDefault();
                result += course.Fee;
            }

            _logger.LogTrace($"{DateTime.UtcNow} TRACE : Fee calculated associate-{associateId}");
            return result;
        }

        public async Task<bool> AddFeedback(int id, string feedback, double feedbackRating, string bearerToken)
        {
            // Check if the associate id exists
            bool associateExists = await CheckAssociateExists(id);
            if (!associateExists)
            {
                return false;
            }

            // Update the feedback and return true
            // ...

            TekGain.DAL.Entities.Admission admission = await _context.Admissions.FirstOrDefaultAsync(x => x.Id == id);

            if (admission != null)
            {
                admission.Feedback = feedback;
                _context.SaveChangesAsync();

                _logger.LogInformation($"{DateTime.UtcNow} INFO : Added Associate-{id}");
                return true;
            }

            return false;
        }

        public async Task<double> HighestFee(int associateId)
        {
            // Get the highest course fee of the associate
            // ...

            List<TekGain.DAL.Entities.Admission> admissionAssociateList = AdmissionAssociateList(associateId);

            double result = 0.0;

            List<Double> FeeList = new List<Double>();

            foreach (TekGain.DAL.Entities.Admission Entry in admissionAssociateList)
            {
                TekGain.DAL.Entities.Course CourseByAssociate = await _context.Courses.FirstOrDefaultAsync(x => x.Id == Entry.CourseId);
                FeeList.Add(CourseByAssociate.Fee);
            }

            result = FeeList.Max();

            return result;
        }

        public List<TekGain.DAL.Entities.Admission> AdmissionAssociateList(int associateId)
        {
            return _context.Admissions.Where(x => x.AssociateId == associateId).ToList();
        }

        public async Task<List<string>> ViewFeedbackByCourseId(int courseId)
        {
            // View feedback of the course
            // ...

            List<TekGain.DAL.Entities.Admission> listAdmission = _context.Admissions.Where(x => x.CourseId == courseId).ToList();
            List<string> result = new List<string>();

            foreach (TekGain.DAL.Entities.Admission admission in listAdmission)
            {
                result.Add(admission.Feedback);
            }

            return result;
        }

        public async Task<string> DeactivateAdmission(int courseId, string bearerToken)
        {
            // Deactivate the given course in the database
            // ...
            string result = "false";

            TekGain.DAL.Entities.Admission admission = await _context.Admissions.FirstOrDefaultAsync(x => x.CourseId == courseId);

            if (admission != null)
            {
                admission.Status = "Deactivated";
                _context.SaveChangesAsync();
                result = "true";
            }

            //_logger.LogInformation($"{DateTime.UtcNow} INFO: Deactivated course-{courseId}");
            return result;
        }

        public async Task<string> MakePayment(int admissionId, string bearerToken)
        {
            // Make the payment
            string result = "Payment Successful!";
            return result;
        }

        private async Task<bool> CheckAssociateExists(int associateId)
        {
            var associate = await _context.Associates.FirstOrDefaultAsync(c => c.Id == associateId);

            if (associate != null)
            {
                return true;
            }

            return false; // Placeholder
        }

        private async Task<bool> CheckCourseExists(int courseId)
        {
            // Make a request to the Course service to check if the course exists
            // ...

            var associate = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

            if (associate != null)
            {
                return true;
            }

            return false; // Placeholder
        }
    }
}
