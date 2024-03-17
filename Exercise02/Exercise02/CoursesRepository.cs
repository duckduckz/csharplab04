public class CourseRepository {
    private const string FilePath = "courses.txt";

    public List<Course> GetAllCourses() {
        var courses = new List<Course>();

        foreach (var line in File.ReadAllLines(FilePath)) {
            var parts = line.Split(',');
            var course = new Course(
                int.Parse(parts[0]),
                parts[1],
                decimal.Parse(parts[2]),
                new List<Student>()
            );
            courses.Add(course);
        }

        return courses;
    }

    public void AddCourse(Course course) {
        var courseLine = $"{course.Id},{course.Name},{course.Price}";
        File.AppendAllText(FilePath, courseLine + Environment.NewLine);
    }
}