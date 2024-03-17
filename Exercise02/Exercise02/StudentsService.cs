public class StudentService {
    private readonly StudentsRepository _repository = new StudentsRepository();

    public List<Student> GetAllStudents() => _repository.GetAllStudents();

    public void AddStudent(Student student) => _repository.AddStudent(student);

}