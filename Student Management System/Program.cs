using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Student_Management_System
{
    class Student
    {
        public int studentId;
        public string name;
        public int age;
        public List<Course> courses = new List<Course>();

        public Student(int studentId, string name, int age, List<Course> courses)
        {
            this.studentId = studentId;
            this.name = name;
            this.age = age;
            this.courses = courses;
        }

        public bool Enroll(Course course)
        {
            if (courses.Contains(course))
            {
                Console.WriteLine("The course is already registered");
                return false;
            }
            courses.Add(course);
            Console.WriteLine("Registration successful");
            return true;
        }
        public string PrintDetails()
        {
            string information ="the information   " + "  the id  : " + studentId + "   the name : " + name + "  the age : " + age;
            for (int i = 0; i < courses.Count; i++)
            {
                information += courses[i].title;
            }
            return information;
        }
        public void updateinfotmation(string name, int age, List<Course> courses)
        {
            this.name = name;
            Console.Write("the new name : " + name);
            Console.WriteLine("                 ");
            this.age = age;
            Console.WriteLine("the new age : " + age);
            Console.WriteLine("                   ");
            this.courses = courses;
            Console.WriteLine("the new course : " + courses);


        }
    }
    class Instructor
    {
        public int instructorId;
        public string name;
        public string specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            this.instructorId = instructorId;
            this.name = name;
            this.specialization = specialization;
        }
        public string PrintDetails()
        {
            return $"the instructorId is "+ instructorId +" the name is "+ name+ " the specialization is"+ specialization;
        }

    }
    class Course
    {
        public int courseId;
        public string title;
        public Instructor instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            this.courseId = courseId;
            this.title = title;
            this.instructor = instructor;
        }
        public string PrintDetails()
        {
            Instructor I = instructor;
            string information = "the courseId " + courseId + " the title " + title + " the instructor " + I.name;

            return information;
        }
    }
    class StudentManager
    {
        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();
        public List<Instructor> instructors = new List<Instructor>();

        public StudentManager(List<Student> students, List<Course> courses, List<Instructor> instructors)
        {
            this.students = students;
            this.courses = courses;
            this.instructors = instructors;
        }
        public bool AddStudent(Student student)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].studentId == student.studentId)
                {
                    Console.WriteLine("please enter anthoe id");
                    return false;
                }
            }
            students.Add(student);
            Console.WriteLine("Added successfully");
            Console.WriteLine("                  ");
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            if (instructors.Contains(instructor))
            {
                return false;
            }
            instructors.Add(instructor);
            Console.WriteLine("Added successfully");
            Console.WriteLine("                  ");
            return true;
        }
        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].studentId == studentId)
                {
                    Console.WriteLine("the student is found");
                    Console.WriteLine(students[i].PrintDetails());
                    Console.WriteLine("                        ");
                    return students[i];
                }
            }
            Console.WriteLine("the student not found");
            return null;
        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].courseId == courseId)
                {
                    Console.WriteLine("the course is found");
                    return courses[i];
                }
            }
            Console.WriteLine("the course not found");
            return null;
        }
        public bool AddCourse(Course course)
        {
            if (courses.Contains(course))
            {
                Console.WriteLine("the course  already exists");
                return false;
            }
            courses.Add(course);
            Console.WriteLine("Added successfully");
            Console.WriteLine("                  ");
            return true;
        }
        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].instructorId == instructorId)
                {
                    Console.WriteLine("the instructor is found");
                    return instructors[i];
                }
            }
            Console.WriteLine("the instructor not found");
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Course c = FindCourse(courseId);
            Student s = FindStudent(studentId);
            if (s.Enroll(c) == true)
            {
                Console.WriteLine("Added successfully ");
                return true;
            }
            return false;
        }
        public bool check(int courseId , int studentId)
        {
            Course c1 = FindCourse(courseId);
            Student s1 = FindStudent(studentId);
            for(int i = 0;i<s1.courses.Count;i++)
            {
                if(c1==s1.courses[i])
                {
                    Console.WriteLine("the student enrolled");
                    return true;
                }
            }
            return false;
        }
        public string returnname(string title)
        {
            for(int i = 0;i<courses.Count;i++)
            {
                if (courses[i].title == title)
                {
                    return "the instructor name :" + courses[i].instructor.name;
                }
            }
            return null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Instructor> instructors = new List<Instructor>();
            StudentManager m = new StudentManager(students, courses, instructors);
            int studentId;
            int n;
            do
            {
                Console.WriteLine("please choose from the options");
                Console.WriteLine("1-Add a new Student");
                Console.WriteLine("2- View all Students");
                Console.WriteLine("3-Search for a Student by ID");
                Console.WriteLine("4-Update Student Information");
                Console.WriteLine("5-Delete a Student");
                Console.WriteLine("6-Add a new Course");
                Console.WriteLine("7-Add a new Instructor");
                Console.WriteLine("8-Enroll a Student in a Course");
                Console.WriteLine("9-View all Courses");
                Console.WriteLine("10-View all Instructors");
                Console.WriteLine("11-Check if the student enrolled in specific course");
                Console.WriteLine("12-Return the instructor name by course name");
                Console.WriteLine("13-Quit");
                Console.WriteLine("-------------------------------------");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.Write("please enter studentId :");
                        studentId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("please enter the name :");
                        string name = Console.ReadLine();
                        Console.Write("please enter the age :");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("please enter the course :");
                        string course = Console.ReadLine();
                        Student s = new Student(studentId, name, age, courses);
                        m.AddStudent(s);
                        break;
                    case 2:
                        if (students.Count == 0)
                        {
                            Console.WriteLine("the list is empty");
                        }
                        else
                        {
                            for (int i = 0; i < students.Count; i++)
                            {
                                Console.WriteLine(students[i].PrintDetails());
                            }
                        }
                        break;
                    case 3:
                        Console.Write("please enter the id :");
                        studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(m.FindStudent(studentId));
                        break;
                    case 4:
                        Console.Write("please enter the studentId : ");
                        studentId = Convert.ToInt32(Console.ReadLine());
                        s = m.FindStudent(studentId);
                        Console.Write("please enter the name : ");
                        name = Console.ReadLine();
                        Console.Write("please enter the age : ");
                        age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please enter the course : ");
                        course = Console.ReadLine();
                        s.updateinfotmation(name, age, courses);
                        break;
                    case 5:
                        Console.Write("plese entre the student id : ");
                        studentId = Convert.ToInt32(Console.ReadLine());
                        Student ss = m.FindStudent(studentId);
                        students.Remove(ss);
                        break;
                    case 6:
                        Console.WriteLine("please enter the course id : ");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please enter the title : ");
                        string title = Console.ReadLine();
                        Console.WriteLine("please enter the instructor id : ");
                        int instructorId = Convert.ToInt32(Console.ReadLine());
                        Instructor instructor = m.FindInstructor(instructorId);
                        Course c = new Course(courseId, title, instructor);
                        m.AddCourse(c);
                        break;
                    case 7:
                        Console.WriteLine("please enter instructor id : ");
                        instructorId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("plese enter the name : ");
                        name = Console.ReadLine();
                        Console.WriteLine("please enter the specialization : ");
                        string specialization = Console.ReadLine();
                        Instructor instructor1 = new Instructor(instructorId, name, specialization);
                        m.AddInstructor(instructor1);
                        Console.WriteLine("Added successfully");
                        break;
                    case 8:
                        Console.WriteLine("please enter the student id : ");
                        studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please enter the course id : ");
                        courseId = Convert.ToInt32(Console.ReadLine());
                        m.EnrollStudentInCourse(studentId, courseId);
                        break;
                    case 9:
                        if (courses.Count == 0)
                        {
                            Console.WriteLine("the list is empty");
                        }
                        else
                        {
                            for (int i = 0; i < courses.Count; i++)
                            {
                                Console.WriteLine(courses[i].PrintDetails());
                            }
                        }
                        break;
                    case 10:
                        if (instructors.Count == 0)
                        {
                            Console.WriteLine("the list is empty");
                        }
                        else
                        {
                            for (int i = 0; i < instructors.Count; i++)
                            {
                                Console.WriteLine(instructors[i].PrintDetails());
                            }
                        }
                        break;
                        //11.Check if the student enrolled in specific course
                    case 11:
                        Console.WriteLine("please enter the id of student :");
                        studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please enter th id of course :");
                        courseId = Convert.ToInt32(Console.ReadLine());
                        m.check(studentId, courseId);
                        break;
                        //12 Return the instructor name by course namث
                    case 12:
                        Console.WriteLine("please enter the title : ");
                        title = Console.ReadLine();
                        Console.WriteLine("the name of instructor is : "+ m.returnname(title));
                        break;
                    case 13:
                        Console.WriteLine("GOOD BYE");
                        break;
                    default:
                        Console.WriteLine("invaild value");
                    break;
                }
            }
            while (n != 13);
        }
    }
}
