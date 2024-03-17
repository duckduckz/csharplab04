public class Course
{
    public int id;
    public string name;
    public decimal price;
    private List<Student> students;

    public Course()
    {
    }

    public Course(int id, string name, decimal price, List<Student> students)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.students = students;
    }
  
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

     public List<Student> Students
    {
        get { return students; }
        set { students = value; }
    }

}