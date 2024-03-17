class Program02
{
    static void Main(string[] args)
    {
        var studentService = Singleton<StudentService>.Instance;
        var courseService = Singleton<CoursesService>.Instance;

        CourseManagement courseManagement = new CourseManagement();
        courseManagement.Menu();
    }
}

