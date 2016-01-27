using ES.Entities;
using System.Collections.Generic;

namespace ES.BusinessLayer
{
    public partial class StudentSubjectMarksRepository
    {
        public IEnumerable<StudentSubjectMarks> GetStudentsMark(int classid, int examid, int subjectid, int sectionid, int sessionid)
        {
            string query = " Select ssm.*, st.FirstName , st.LastName , st.RegistrationNumber as StudentRoleNumber, st.StudentID as StudentID, cls.Description as ClassName,  ex.Description as ExamName, sb.Description as SubjectName, ssm.ObtainedMarks , ssm.TotalMarks"
                       + " from Student st "
                       + " Left join StudentSubjectMarks ssm on ssm.StudentID = st.StudentID AND ssm.isActive = 1 AND ssm.SessionID = " + sessionid
                       + " Left Join Class cls on cls.ClassID = st.ClassID and cls.ClassID = " + classid + " AND cls.isActive = 1 "
                       //+ " join ClassSubject cs on cs.ClassID = cls.ClassID and cs.SubjectID = ssm.SubjectID "
                       + " join Sections sct on sct.SectionID = st.SectionID and sct.isActive = 1 AND sct.SectionID = " + sectionid
                       + " join Exam ex on ex.ExamID = " + examid + " AND ex.isActive = 1 and ex.ExamID = ssm.ExamID "
                       + " join Subject sb on sb.SubjectID = ssm.SubjectID and sb.SubjectID = " + subjectid + " AND sb.isActive = 1 "
                       + " Where st.isActive = 1";
            return Query<StudentSubjectMarks>(query);
        }

        public IEnumerable<StudentSubjectMarks> GetSingleStudentResult(int studentid, int sessionid, int sectionid, int classid)
        {
            string query = " Select ssm.*, st.FirstName ,st.LastName , st.RegistrationNumber as StudentRoleNumber, st.StudentID as StudentID, cls.Description as ClassName,  ex.Description as ExamName, sb.Description as SubjectName, ssm.ObtainedMarks , ssm.TotalMarks"
                       + " from Student st "
                       + " Left join StudentSubjectMarks ssm on ssm.StudentID = st.StudentID AND ssm.isActive = 1 AND ssm.SessionID = " + sessionid
                       + " Left Join Class cls on cls.ClassID = st.ClassID and cls.ClassID = " + classid + " AND cls.isActive = 1 "
                       + " join Sections sct on sct.SectionID = st.SectionID and sct.isActive = 1 AND sct.SectionID = " + sectionid
                       + " join Exam ex on ex.isActive = 1 and ex.ExamID = ssm.ExamID "
                       + " join Subject sb on sb.SubjectID = ssm.SubjectID  AND sb.isActive = 1 "
                       + " Where st.isActive = 1 and st.StudentID = " + studentid;

            return Query<StudentSubjectMarks>(query);
        }
        public IEnumerable<StudentSubjectMarks> GetClassResult(int examid, int sessionid, int sectionid, int classid)
        {
            string query = " Select ssm.*, st.FirstName , st.LastName, st.RegistrationNumber as StudentRoleNumber, st.StudentID as StudentID, cls.Description as ClassName,  ex.Description as ExamName, sb.Description as SubjectName, ssm.ObtainedMarks , ssm.TotalMarks"
                                  + " from Student st "
                                  + " Left join StudentSubjectMarks ssm on ssm.StudentID = st.StudentID AND ssm.isActive = 1 AND ssm.SessionID = " + sessionid
                                  + " Left Join Class cls on cls.ClassID = st.ClassID and cls.ClassID = " + classid + " AND cls.isActive = 1 "
                                  + " join Sections sct on sct.SectionID = st.SectionID and sct.isActive = 1 AND sct.SectionID = " + sectionid
                                  + " join Exam ex on ex.isActive = 1 and ex.ExamID = ssm.ExamID AND ex.ExamID = " + examid
                                  + " join Subject sb on sb.SubjectID = ssm.SubjectID  AND sb.isActive = 1 "
                                  + " Where st.isActive = 1 ";

            return Query<StudentSubjectMarks>(query);
        }
    }
}
