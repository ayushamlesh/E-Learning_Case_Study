namespace Course.API.Repository
{
    public interface ICourseRepository
    {
        List<TekGain.DAL.Entities.Course> GetAllCourse();
        TekGain.DAL.Entities.Course? GetCourseById(int id);
        bool AddCourse(TekGain.DAL.Entities.Course course);
        bool UpdateCourse(int id, int fee);
        double GetRating(int id);
        bool CalculateAverageRating(int id, double rating);
    }
}
