public class CoursesService
{
    private readonly CourseRepository _repository = new CourseRepository();

    public List<Course> GetAllCourses() => _repository.GetAllCourses();

    public void AddCourse(Course course) => _repository.AddCourse(course);
}