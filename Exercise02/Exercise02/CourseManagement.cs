public class CourseManagement
{
    private List<Student> _students;
    private List<Course> _courses;

    public CourseManagement()
    {
        _students = new List<Student>();
        _courses = new List<Course>();
        Init();
    }

    #region Public

    public void Menu()
    {
        int choice = 0;
        Console.WriteLine("Course Management System");

        while (choice != 99)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Add Student to Course");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. List Courses");
            Console.WriteLine("6. List Students in Course");
            Console.WriteLine("7. Total course price student is enrolled in");
            Console.WriteLine("99. Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            ChooseAction(choice);
        }
    }

    #endregion

    #region Private

    private void ChooseAction(int choice)
    {

        switch (choice)
        {
            case 1:
                AddStudent();
                break;
            case 2:
                AddCourse();
                break;
            case 3:
                AddStudentToCourse();
                break;
            case 4:
                ListStudents();
                break;
            case 5:
                ListCourses();
                break;
            case 6:
                ListStudentsInCourse();
                break;
            case 7:
                TotalPriceStudentIsEnrolledIn();
                break;
            case 99:
                Console.WriteLine("Exiting");
                Environment.Exit(0);
                break;
            default:
                break;

        }
    }

    private void TotalPriceStudentIsEnrolledIn()
    {
        Console.WriteLine("Choose a student from the list by its Id");
        _students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        int studentId = Convert.ToInt32(Console.ReadLine());
        Student? student = _students.FirstOrDefault(s => s.Id == studentId);
        decimal totalPrice = 0;
        student?.Courses.ForEach(c => totalPrice += c.Price);
        Console.WriteLine($"Total price of courses: €{totalPrice}");
    }

    private void ListStudentsInCourse()
    {
        _courses.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: {c.Price}"));
        Console.WriteLine("Enter Course Id");
        int courseId = Convert.ToInt32(Console.ReadLine());
        Course? course = _courses.FirstOrDefault(c => c.Id == courseId);
        course?.Students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
    }

    private void ListCourses()
    {
        foreach (Course course in _courses)
        {
            Console.WriteLine($"Id: {course.Id}, Name: {course.Name}, Price: €{course.Price}");
        }
    }

    private void ListStudents()
    {
        foreach (Student student in _students)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Email: {student.Email}");
        }
    }

    private void AddStudentToCourse()
    {

        Console.WriteLine("Choose a student from the list by it's Id");
        _students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        int studentId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Choose a course from the list by it's Id");
        _courses.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: €{c.Price}"));
        int courseId = Convert.ToInt32(Console.ReadLine());

        Student? student = _students.FirstOrDefault(s => s.Id == studentId);
        Course? course = _courses.FirstOrDefault(c => c.Id == courseId);
        if (student != null && course != null)
        {
            student.Courses.Add(course);
            course.Students.Add(student);
            Console.WriteLine("Student added to course");
        }

    }

    private void AddCourse()
    {
        Console.WriteLine("Enter Course Name");
        string name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Course Price");
        string strPrice = Console.ReadLine() ?? "0";
        decimal Price = Convert.ToDecimal(strPrice);
        Course course = new Course() { Id = _courses.Count + 1, Name = name, Price = Price };
        _courses.Add(course);
    }

    private void AddStudent()
    {
        Console.WriteLine("Enter Student Name");
        string name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Student Email");
        string email = Console.ReadLine() ?? string.Empty;
        int id = _students.Count + 1; // Generate a unique id for the new student
        Student student = new Student(id, name, email, "1A", new DateOnly(2000, 1, 1), new List<Course>());
        _students.Add(student);
    }

    private void Init()
    {

        /*
        var s = new Student(3, "Dieter", "dieter.de.preester@howest.be", "1A", new DateOnly(2000, 4, 2), new List<Course>());

        var s1 = new Student()
        {
            Id = 4,
            BirthDate = new DateOnly(2000, 1, 2),
            Class = "1A",
            Courses = new List<Course>(),
            Email = "dieter.de.preester@howest.be",
            Name = "Dieter"
        };
        */


        _students = new List<Student>(){
            new Student(1, "John", "john@doe.com", "A1", new DateOnly(2000,1,1), new List<Course>()),
            new Student(2, "Jane", "jane@doe.com", "B1", new DateOnly(2000,5,4),  new List<Course>()),
        };

        _courses = new List<Course>(){
            new Course(1, "C#", 350M, new List<Student>()),
            new Course(2, "Java", 350M, new List<Student>()),
            new Course(3, "Python", 350M, new List<Student>()),
            new Course(4, "JavaScript", 350M, new List<Student>()),
            new Course(5, "C++", 350M, new List<Student>()),
            new Course(6, "PHP", 350M, new List<Student>()),
            new Course(7, "Ruby", 150M, new List<Student>()),
            new Course(8, "Swift", 250M, new List<Student>()),
        };

        _students[0].Courses.Add(_courses[0]);
        _students[0].Courses.Add(_courses[1]);
        _students[0].Courses.Add(_courses[2]);

    }

    #endregion

}