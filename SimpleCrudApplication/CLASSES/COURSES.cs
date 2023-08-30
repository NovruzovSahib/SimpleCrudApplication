using SimpleCrudApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrudApplication.CLASSES
{
    internal class COURSES
    {
        readonly private RELATIONSHIPEntities relationshipEntities ;

        public COURSES()
        {
                relationshipEntities = new RELATIONSHIPEntities();
        }
        public List<COURSE> SelectCourse()
        {
            var courses = relationshipEntities.COURSEs.ToList();
            return courses;
        }
        public void CreateCourse(COURSE course)
        {
            try
            {
                if (course != null)
                {
                    relationshipEntities.COURSEs.Add(course);
                    relationshipEntities.SaveChanges();
                    Console.WriteLine($"{course.COURSENAME} Successfully added to db");
                }
                else
                {
                    Console.WriteLine($"{course.COURSENAME} is not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured", ex.Message);
            }
        }
        public void DeleteCourse(int courseid)
        {
            var id = relationshipEntities.COURSEs.FirstOrDefault(s => s.ID == courseid);
            try
            {
                if (id != null)
                {
                    relationshipEntities.COURSEs.Remove(id);
                    relationshipEntities.SaveChanges();
                    Console.WriteLine($"N={courseid} id successfully deleted from db");
                }
                else
                {
                    Console.WriteLine($"CourseId is not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured",ex.Message);

            }
        }
        public void UpdateCourse(int courseid, COURSE newcourse)
        {
            var course = relationshipEntities.COURSEs.FirstOrDefault(s => s.ID == courseid);
            try
            {
                if (course != null)
                {
                    course.COURSENAME = newcourse.COURSENAME;
                    course.FEE = newcourse.FEE;
                    course.COURSESTART = newcourse.COURSESTART;
                    relationshipEntities.SaveChanges();
                    Console.WriteLine($"Course with ID {courseid} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"CourseId is not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured", ex.Message);
            }
        }


    }
}
