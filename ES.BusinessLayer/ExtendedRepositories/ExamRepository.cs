using ES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.BusinessLayer
{
    public partial class ExamRepository
    {
        public IEnumerable<Exam> GetManadatoryExams()
        {
            return GetAll().Where(p => p.Type == true);
        }
    }
}
