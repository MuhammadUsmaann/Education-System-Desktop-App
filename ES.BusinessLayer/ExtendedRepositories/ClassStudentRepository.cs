using ES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.BusinessLayer
{
    public partial class ClassStudentRepository
    {
        public ClassStudent FindByUserID(int p)
        {
            return FindByQuery(" StudentID = " + p).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudents(int classid, int sectionID)
        {
            return new StudentRepository().FindByQuery(" ClassID = " + classid + " AND SectionID = " + sectionID);
        }

    }
}
