using System;
using System.Linq;
using System.Collections.Generic;
using SimpleCrudApplication.Model;
using SimpleCrudApplication.CLASSES;

class Program
{ 

    static void Main()
    {
        STUDENTS students = new STUDENTS();
        students.CreateStudent(new STUDENT { STUDENTNAME = "CHARLIE" });
        students.DeleteStudent(6);
        students.UpdateStudent(7, new STUDENT { STUDENTNAME = "EMILIANO" });

        COURSES courses = new COURSES();
        courses.CreateCourse(new COURSE { COURSENAME = "FULLSTACK", FEE = 300, COURSESTART = new DateTime(2023, 09, 10, 22, 30, 30) });
        courses.DeleteCourse(5);
        courses.UpdateCourse(4, new COURSE { COURSENAME = "LARAVEL", FEE = 150, COURSESTART = new DateTime(2023, 09, 22, 18, 00, 00) });

        STUDENTSANDCOURSES studentandcourse = new STUDENTSANDCOURSES();
        studentandcourse.EnrollStudentInCourse(2, 3);
        studentandcourse.DeleteEnrollStudentInCourse(2, 3);
        studentandcourse.UpdateStudentCourseEnrollment(2, 2, 3);

        Console.ReadLine();
    }

    
}
