using ES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.BusinessLayer
{
    public partial class StudentRepository
    {
        public IEnumerable<Student> GetStudentsList()
        {
            string query = "Select std.* ,cls.Description as ClassName,  prt.FirstName  as pFirstName, prt.LastName as pLastName, prt.Address"
                            +" From Student std"
                            + " Left Join Parent prt On std.ParentID = prt.ParentID"
                            +" Left Join Class cls On cls.ClassID = std.ClassID"
                            + " Where std.isActive = 1";
            return Query<Student>(query);
        }
        public IEnumerable<Student> GetStudentsList(int classid, int sectionid)
        {
            string query = "Select std.* ,cls.Description as ClassName,  prt.FirstName  as pFirstName, prt.LastName as pLastName, prt.Address"
                            + " From Student std"
                            + " Join Parent prt On std.ParentID = prt.ParentID"
                            + " Join Class cls On cls.ClassID = std.ClassID"
                            + " Join Sections sc On sc.SectionID = std.SectionID "
                            + " Where std.isActive = 1 AND std.ClassID = " + classid + " AND std.SectionID = " + sectionid;

            return Query<Student>(query);
        }
        public IEnumerable<Student> GetChildren(int parentid)
        {
            string query = "Select std.*"
                            + " From Student std"
                            + " Join Parent prt On std.ParentID = prt.ParentID and prt.ParentID = " + parentid
                            + " Join Class cls On cls.ClassID = std.ClassID "
                            + " Join Sections sc On sc.SectionID = std.SectionID "
                            + " Where std.isActive = 1 ";

            return Query<Student>(query);
        }
        
        public Student GetStudentDetail(int id)
        {
            string query = "Select std.* , prt.FirstName  as pFirstName, prt.LastName as pLastName, prt.Address"
                            + " From Student std"
                            + " Left Join Parent prt On std.ParentID = prt.ParentID"
                            + " Where std.isActive = 1 and std.StudentID = " + id;
            return Query<Student>(query).FirstOrDefault();
        }
    }
}
