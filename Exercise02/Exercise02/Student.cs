public class Student
{
     private int id;
    private string name;
    private string email;
    private string _class;

    private DateOnly birthDate;
    private List<Course> courses;

    public int Id
    {
        get { return id; }
        set { this.id = value; }
    }

    public string Name
    {
        get { return name; }
        set { this.name = value; }
    }

    public string Email
    {
        get { return email; }
        set { this.email = value; }
    }

    public string Class
    {
        get { return _class; }
        set { _class = value; }
    }

    public DateOnly BirthDate
    {
        get { return this.birthDate; }
        set { this.birthDate = value; }
    }

    public List<Course> Courses
    {
        get { return this.courses; }
        set { this.courses = value; }
    }


    public Student(int id, string name, string email, string cls, DateOnly birthDate, List<Course> courses)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        _class = cls;
        this.birthDate = birthDate;
        this.courses = courses;
    }
}