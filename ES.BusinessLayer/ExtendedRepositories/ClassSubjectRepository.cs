using ES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.BusinessLayer
{
    public partial class ClassSubjectRepository
    {
        public void SaveSubjects(IEnumerable<Subject> list,int classId, int userId)
        {
            Query("Delete from ClassSubject where ClassID = " + classId);

            foreach (var item in list)
            {
                ClassSubject newObj = new ClassSubject() { SubjectID = item.SubjectID, ClassID = classId, created_by = userId, updated_by = userId };
                Insert(newObj);
            }
        }
        public IEnumerable<Subject> GetSelectedSubjects(int classid)
        {
            string query = "Select sub.*, clsSub.* from ClassSubject clsSub, Subject sub "
                            + " Where sub.SubjectID = clsSub.SubjectID AND clsSub.ClassID = " + classid 
                            +" AND clsSub.isActive = 1 and sub.isActive = 1";

            return Query<Subject>(query);
        }

        public IEnumerable<Subject> GetUnSelectedSubjects(int classid)
        {
            string query = "Select sub.* from Subject sub "
                            + " Where sub.SubjectID not in (select SubjectID from ClassSubject where ClassID = " + classid + ")"
                            + " AND sub.isActive = 1";

            return Query<Subject>(query);
        }
    }
}
