namespace Admission.API.Repository
{
    public interface IAdmissionRepository
    {
        Task<List<TekGain.DAL.Entities.Admission>> GetAllRegistration();
        Task<string> RegisterAssociateForCourse(int associateId, int courseId, string bearerToken);
        Task<double> CalculateFees(int associateId);
        Task<bool> AddFeedback(int admissionId, string feedback, double feedbackRating, string bearerToken);
        Task<double> HighestFee(int associateId);
        Task<List<String>> ViewFeedbackByCourseId(int courseId);
        Task<string> DeactivateAdmission(int courseId, string bearerToken);
        Task<string> MakePayment(int regNo, string bearerToken);
    }
}
