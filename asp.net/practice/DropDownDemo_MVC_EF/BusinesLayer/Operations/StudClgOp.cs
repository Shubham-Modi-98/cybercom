using BusinesLayer.Database;
using DropDownDemo_MVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Operations
{
    public class StudClgOp
    {
        public List<College> GetAllCollegeData()
        {
            using(var context = new DbDemoEFEntities())
            {
                var result = context.tblCollege.Select(x => new College()
                {
                    Id = x.Id,
                    CollegeName = x.CollegeName
                }).ToList();
                if(result != null)
                {
                    return result;
                }
                return null;
            }
        }

        public int AddStudent(Student student)
        {
            using (var context = new DbDemoEFEntities())
            {
                tblStudent tblStud = new tblStudent()
                {
                    Name = student.Name,
                    Address = student.Address,
                    CollegeId = student.College.Id
                };
                context.tblStudent.Add(tblStud);
                context.SaveChanges();
                return tblStud.Id;
            }        
        }

        public List<Student> GetAllStudents()
        {
            using (var context = new DbDemoEFEntities())
            {
                var result = context.tblStudent.Select(x => new Student()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    CollegeId = x.CollegeId,
                    College = new College()
                    {
                        Id = x.tblCollege.Id,
                        CollegeName = x.tblCollege.CollegeName
                    }
                }).ToList();
                return result;
            }
        }

        public bool UpdateStudent(int id, Student student)
        {
            using (var context = new DbDemoEFEntities())
            {
                var result = context.tblStudent.FirstOrDefault(x => x.Id == id);
                if(result != null)
                {
                    //result.Id = student.Id;
                    result.Name = student.Name;
                    result.Address = student.Address;
                    result.CollegeId = student.College.Id;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            using (var context = new DbDemoEFEntities())
            {
                var result = context.tblStudent.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    context.tblStudent.Remove(result);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<Student> GetStudentsByClg(int id)
        {
            using (var context = new DbDemoEFEntities())
            {
                var result = context.tblStudent.Where(x => x.tblCollege.Id == id).Select(x => new Student()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    College = new College()
                    {
                        Id = x.tblCollege.Id,
                        CollegeName = x.tblCollege.CollegeName
                    }
                }).ToList();
                return result;
            }
        }
    }
}
