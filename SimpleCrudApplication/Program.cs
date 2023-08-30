using System;
using System.Linq;
using System.Collections.Generic;
using SimpleCrudApplication.Model;
using SimpleCrudApplication.CLASSES;
using System.Globalization;

class Program
{

    static void Main()
    {
        STUDENTS students = new STUDENTS();
        COURSES courses = new COURSES();
        STUDENTSANDCOURSES studentandcourse = new STUDENTSANDCOURSES();

       
        Console.WriteLine("WELCOME TO MODIFY DATABASE");
        Console.WriteLine("SELECT CLASS TO MODIFY: ");
        Console.WriteLine("1:STUDENT 2:COURSE 3:STUDENTANDCOURSE");
        int a = int.Parse(Console.ReadLine());
        switch (a)
        {
            case 1:
                Console.WriteLine("STUDENT");
                Console.WriteLine("SELECT OPERATION TO MODIFY: ");
                Console.WriteLine("1:CREATE 2:DELETE 3:UPDATE 4:SELECT");
                int b = int.Parse(Console.ReadLine());
                switch (b)
                {
                    case 1:
                        Console.Write("CREATE STUDENT: ");
                        students.CreateStudent(new STUDENT { STUDENTNAME = Console.ReadLine() });
                        break;
                    case 2:
                        Console.Write("DELETE STUDENTID: ");
                        students.DeleteStudent(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.Write("UPDATE STUDENTID: ");
                        int stuid = int.Parse(Console.ReadLine());
                        Console.Write("ENTER NEW NAME: ");
                        string stuname = Console.ReadLine();
                        students.UpdateStudent(stuid, new STUDENT { STUDENTNAME = stuname });
                        break;
                    case 4:
                        Console.WriteLine("SELECT STUDENT");
                        List<STUDENT> studentlist = students.SelectStudent();
                        foreach (var student in studentlist)
                        {
                            Console.WriteLine($"Student ID: {student.ID}, Student Name: {student.STUDENTNAME}");
                        }
                        break;
                    default:
                        Console.WriteLine("SELECT VALID OPERATION");
                        break;
                }
                break;
            case 2:
                Console.WriteLine("COURSE");
                Console.WriteLine("SELECT OPERATION TO MODIFY: ");
                Console.WriteLine("1:CREATE 2:DELETE 3:UPDATE 4:SELECT");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.WriteLine("CREATE COURSE:");
                        Console.Write("NAME: ");
                        string name = Console.ReadLine();
                        Console.Write("FEE: ");
                        int fee = int.Parse(Console.ReadLine());
                        Console.Write("START TIME (yyyy-MM-dd HH:mm:ss): ");
                        string startTimeString = Console.ReadLine();
                        if (DateTime.TryParseExact(startTimeString, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime startTime))
                        {
                            courses.CreateCourse(new COURSE { COURSENAME = name, FEE = fee, COURSESTART = startTime });
                            Console.WriteLine("Course created successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Course creation failed.");
                        }
                        break;
                    case 2:
                        Console.Write("DELETE COURSEID: ");
                        courses.DeleteCourse(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.Write("UPDATE COURSEID: ");
                        int courseid = int.Parse(Console.ReadLine());
                        Console.Write("COURSENAME: ");
                        string coursename = Console.ReadLine();
                        Console.Write("FEE: ");
                        int coursefee = int.Parse(Console.ReadLine());
                        Console.Write("START TIME: ");
                        string startTimeString2 = Console.ReadLine();
                        if (DateTime.TryParseExact(startTimeString2, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime2))
                        {
                            courses.UpdateCourse(courseid, new COURSE { COURSENAME = coursename, FEE = coursefee, COURSESTART = startTime2 });
                        }
                        else
                        {
                            Console.WriteLine("Invalid date and time format. Please enter the date and time in the format 'yyyy-MM-dd HH:mm:ss'.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("SELECT COURSE:");
                        List<COURSE> courselist = courses.SelectCourse();
                        foreach (var course in courselist)
                        {
                            Console.WriteLine($"Course ID: {course.ID}  Course Name: {course.COURSENAME}  FEE: {course.FEE}  START TIME:{course.COURSESTART}");
                        }
                        break;
                    default:
                        Console.WriteLine("SELECT VALID OPERATION");
                        break;
                }
                break;

            case 3:
                Console.WriteLine("STUDENTANDCOURSE");
                Console.WriteLine("SELECT OPERATION TO MODIFY: ");
                Console.WriteLine("1:CREATE 2:DELETE 3:UPDATE 4:SELECT");
                int d = int.Parse(Console.ReadLine());
                switch (d)
                {
                    case 1:
                        Console.WriteLine("CREATE STUDENT COURSE ENROLLMENT:");
                        Console.Write("STUDENTID: ");
                        int stuid = int.Parse(Console.ReadLine());
                        Console.Write("COURSEID: ");
                        int courseid = int.Parse(Console.ReadLine());
                        studentandcourse.EnrollStudentInCourse(stuid, courseid);
                        break;
                    case 2:
                        Console.WriteLine("DELETE STUDENT COURSE ENROLLMENT: ");
                        Console.Write("STUDENTID: ");
                        stuid = int.Parse(Console.ReadLine());
                        Console.Write("COURSEID: ");
                        courseid = int.Parse(Console.ReadLine());
                        studentandcourse.DeleteEnrollStudentInCourse(stuid, courseid);
                        break;
                    case 3:
                        Console.WriteLine("UPDATE STUDENT COURSE ENROLLMENT: ");
                        Console.Write("STUDENTID: ");
                        stuid = int.Parse(Console.ReadLine());
                        Console.Write("COURSEID: ");
                        courseid = int.Parse(Console.ReadLine());
                        Console.Write("NEW COURSEID: ");
                        int newcourseid = int.Parse(Console.ReadLine());
                        studentandcourse.UpdateStudentCourseEnrollment(stuid, courseid, newcourseid);
                        break;
                    case 4:
                        Console.WriteLine("SELECT STUDENT COURSE ENROLLMENT: ");
                        List<STUDENTANDCOURSE> studentandourselist = studentandcourse.SelectStudentInCourse();
                        foreach (var stuandcourse in studentandourselist)
                        {
                            Console.WriteLine($"STUDENT ID: {stuandcourse.ID} COURSE ID: {stuandcourse.ID}");
                        }
                        break;
                    default:
                        Console.WriteLine("SELECT VALID OPERATION");
                        break;
                }
                break;
            default:
                Console.WriteLine("SELECT VALID OPERATION");
                break;
        }
        Console.ReadLine();
    }
}
