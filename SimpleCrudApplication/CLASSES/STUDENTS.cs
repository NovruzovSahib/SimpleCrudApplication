using SimpleCrudApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrudApplication.CLASSES
{
    internal class STUDENTS
    {
        readonly private RELATIONSHIPEntities relationshipEntities;
        public STUDENTS()
        {
            relationshipEntities = new RELATIONSHIPEntities();
        }
       public void CreateStudent(STUDENT student)
        {
            try
            {
                if (student != null)
                {
                    relationshipEntities.STUDENTs.Add(student);
                    relationshipEntities.SaveChanges();
                    Console.WriteLine($"{student.STUDENTNAME} successfully added to db");
                }
                else
                {
                    Console.WriteLine($"{student.STUDENTNAME} is not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured", ex.Message);
            }
        }
        public void DeleteStudent(int studentid)
        {
            var id = relationshipEntities.STUDENTs.FirstOrDefault(s => s.ID == studentid);
            try
            {
                if (id != null)
                {
                    relationshipEntities.STUDENTs.Remove(id);
                    relationshipEntities.SaveChanges();
                    Console.WriteLine($"N={studentid} id successfully deleted from db");
                }
                else
                {
                    Console.WriteLine($"StudentId is not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured", ex.Message);
            }
        }
        public void UpdateStudent(int studentid,STUDENT newstudent)
        {
            var student = relationshipEntities.STUDENTs.FirstOrDefault(s => s.ID == studentid);
            try
            {
                if (student != null)
                {
                    student.STUDENTNAME = newstudent.STUDENTNAME; 
                    relationshipEntities.SaveChanges();
                    Console.WriteLine($"Student with ID {studentid} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"StudentId is not found");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured", ex.Message);
            }
        }
    }
}
