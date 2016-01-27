using ES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.BusinessLayer
{
    public partial class FeeDetailRepository
    {
        public IEnumerable<FeeDetail> GetClassDetail(int classid, int sectionid, int sessionid)
        {
            string query = " Select  st.FirstName , st.LastName , st.MonthlyFee,st.StudentID,st.AdmissionDate as JoiningDate,"
                            + " st.RegistrationNumber as StudentRoleNumber,"
                            + " cls.Description as ClassName,pr.FirstName as pFirstName , pr.LastName as pLastName ,fd.* "
                            + " from Student st  "
                            + " join Sections sct on sct.SectionID = st.SectionID and sct.isActive = 1 AND sct.SectionID = " + sectionid
                            + " join session ss on ss.isActive = 1 AND ss.SessionID = " + sessionid
                            + " Join Class cls on cls.ClassID = st.ClassID  AND cls.isActive = 1  and cls.ClassID = " + classid
                            + " Join Parent pr on pr.ParentID = st.ParentID and pr.isActive = 1 "
                            + " Left Join FeeDetail fd on fd.isActive = 1  AND fd.SectionID = sct.SectionID "
                            + " AND fd.ClassID = cls.ClassID AND fd.SessionID = ss.SessionID AND fd.StudentID = st.StudentID"
                            + " Where st.isActive = 1";
            return Query<FeeDetail>(query);
        }

        public IEnumerable<FeeDetail> GetChildrenFeeDetail(int parentid, int sessionid)
        {
            string query = " Select  st.FirstName , st.LastName , st.MonthlyFee,st.StudentID,st.AdmissionDate as JoiningDate,"
                            + " st.RegistrationNumber as StudentRoleNumber,"
                            + " cls.Description as ClassName, sct.Description as SectionName ,pr.FirstName as pFirstName , pr.LastName as pLastName ,fd.* "
                            + " from Student st  "
                            + " join Sections sct on sct.SectionID = st.SectionID and sct.isActive = 1"
                            + " join session ss on ss.isActive = 1 AND ss.SessionID = " + sessionid
                            + " Join Class cls on cls.ClassID = st.ClassID  AND cls.isActive = 1 "
                            + " Join Parent pr on pr.ParentID = st.ParentID and pr.isActive = 1 AND pr.ParentID = " + parentid
                            + " Left Join FeeDetail fd on fd.isActive = 1  AND fd.SectionID = sct.SectionID "
                            + " AND fd.ClassID = cls.ClassID AND fd.SessionID = ss.SessionID AND fd.StudentID = st.StudentID"
                            + " Where st.isActive = 1";
            return Query<FeeDetail>(query);
        }
        
    }
}
