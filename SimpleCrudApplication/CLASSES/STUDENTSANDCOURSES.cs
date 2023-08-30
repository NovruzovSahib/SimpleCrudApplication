using SimpleCrudApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrudApplication.CLASSES
{
    internal class STUDENTSANDCOURSES
    {
        readonly private RELATIONSHIPEntities relationshipEntities;

        public STUDENTSANDCOURSES()
        {
            relationshipEntities = new RELATIONSHIPEntities();
        }
        public List<STUDENTANDCOURSE> SelectStudentInCourse()
        {
            var studentandcourse = relationshipEntities.STUDENTANDCOURSEs.ToList();
            return studentandcourse;
        }
        public void EnrollStudentInCourse(int studentId, int courseId)
        {
            try
            {
                var existingEnrollment = relationshipEntities.STUDENTANDCOURSEs.FirstOrDefault(e => e.STUDENTID == studentId && e.COURSEID == courseId);

                if (existingEnrollment != null)
                {
                    Console.WriteLine($"Student with ID {studentId} is already enrolled in course with ID {courseId}.");
                }
                else
                {
                    var enrollment = new STUDENTANDCOURSE { STUDENTID = studentId, COURSEID = courseId };
                    relationshipEntities.STUDENTANDCOURSEs.Add(enrollment);
                    relationshipEntities.SaveChanges();
                    Console.WriteLine($"Student with ID {studentId} enrolled in course with ID {courseId}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enrolling student in course: {ex.Message}");
            }
        }

        public void DeleteEnrollStudentInCourse( int studentid, int courseid )
        {
            var enrollment = relationshipEntities.STUDENTANDCOURSEs.FirstOrDefault(s => s.STUDENTID == studentid && s.COURSEID == courseid);
            try
            {
                if (enrollment!=null)
                {
                    relationshipEntities.STUDENTANDCOURSEs.Remove(enrollment);
                    relationshipEntities.SaveChanges();
                    Console.WriteLine($"Student with ID {studentid} removed from course with ID {courseid}.");
                }
                else
                {
                    Console.WriteLine($"Enrollment not found for student ID {studentid} and course ID {courseid}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enrolling student in course: {ex.Message}");
            }
        }
        public void UpdateStudentCourseEnrollment(int studentId, int courseId, int newCourseId)
        {
            try
            {
                var existingEnrollment = relationshipEntities.STUDENTANDCOURSEs.FirstOrDefault(e => e.STUDENTID == studentId && e.COURSEID == courseId);

                if (existingEnrollment != null)
                {
                    var newCourse = relationshipEntities.COURSEs.FirstOrDefault(c => c.ID == newCourseId);

                    if (newCourse != null)
                    {
                        existingEnrollment.COURSEID = newCourseId;
                        relationshipEntities.SaveChanges();
                        Console.WriteLine($"Student with ID {studentId} course enrollment updated to course with ID {newCourseId}.");
                    }
                    else
                    {
                        Console.WriteLine($"Course with ID {newCourseId} not found.");
                    }
                }
                else
                {
                    Console.WriteLine($"Enrollment not found for student ID {studentId} and course ID {courseId}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student course enrollment: {ex.Message}");
            }
        }

    }
}
