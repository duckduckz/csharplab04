public class StudentsRepository {
    private const string FilePath = "students.txt";

    public List<Student> GetAllStudents() {
        var students = new List<Student>();

        foreach (var line in File.ReadAllLines(FilePath)) {
            var parts = line.Split(',');
            var student = new Student (
                Convert.ToInt32(parts[0]),
                parts[1],
                parts[2],
                parts[3],
                DateOnly.FromDateTime(DateTime.Now),
                new List<Course>()
            );
            students.Add(student);
        }

        return students;
    }

    public void AddStudent(Student student) {
        var studentLine = $"{student.Id},{student.Name},{student.Email},{student.Class}";
        File.AppendAllText(FilePath, studentLine + Environment.NewLine);
    }
}