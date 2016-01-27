
using ES.Entities;
using System.Collections.Generic;
namespace ES.BusinessLayer
{
    public partial class AttendanceRepository
    {
        public IEnumerable<Attendance> GetClassAttendance(int classid, int sessionid , int sectionid , string date = "")
        {
            string query = "Select atnd.* , std.FirstName, std.LastName, std.RegistrationNumber as RoleNumber "
                            + " from Student std"
                            + " Join  Class cls on std.ClassID = cls.ClassID AND cls.isActive = 1"
                            + " Left Join " + SqlTableName + " atnd on std.StudentID = atnd.StudentID "
                            + " Where std.isActive = 1 and  atnd.SessionID = " + sessionid + " AND std.SectionID = " + sectionid +" AND atnd.SectionID = " + sectionid +" AND  std.ClassID = " + classid + " AND atnd.AttendanceDate = '" + date + "'";
            return Query<Attendance>(query);
        }
        public IEnumerable<Attendance> GetStudentsListForAttendance(int classid, int sectionid)
        {
            string query = "Select std.StudentID, std.ClassID, std.FirstName,  std.LastName, std.RegistrationNumber as RoleNumber"
                            + " From Student std , Class cls , Sections sc"
                            + " Where std.ClassID = cls.ClassID AND cls.isActive = 1 and std.isActive = 1 AND sc.isActive = 1  AND std.ClassID = " + classid + " AND std.SectionID = " + sectionid + " AND sc.SectionID = " + sectionid;

            return Query<Attendance>(query);
        }
        public IEnumerable<Attendance> GetClassAttendance(int classid, int sessionid, int sectionid, string sDate = "", string eDate = "")
        {
            string query = "Select atnd.* , std.FirstName, std.LastName, std.RegistrationNumber as RoleNumber "
                            + " from Student std"
                            + " Join  Class cls on std.ClassID = cls.ClassID AND cls.isActive = 1"
                            + " Left Join " + SqlTableName + " atnd on std.StudentID = atnd.StudentID "
                            + " Where std.isActive = 1 and  atnd.SessionID = " + sessionid + " AND std.SectionID = " + sectionid +" AND atnd.SectionID = " + sectionid +" AND std.ClassID = " + classid + " AND atnd.AttendanceDate >= '" + sDate + "' AND atnd.AttendanceDate <= '" + eDate + "'";
            return Query<Attendance>(query);
        }
        public IEnumerable<StudentAttendance> GetStudentAttendance(int std, int cls, string sDate, string eDate)
        {
            string query = "Select datename(dw,atnd.AttendanceDate) as DayName, datename(d,atnd.AttendanceDate) as DayNumber, atnd.isPresent"
                           + " from Student std"
                           + " Join  Class cls on std.ClassID = cls.ClassID AND cls.isActive = 1"
                           + " Left Join " + SqlTableName + " atnd on std.StudentID = atnd.StudentID "
                           + " Where std.isActive = 1 and  std.StudentID = " + std + " AND std.ClassID = " + cls + " AND atnd.AttendanceDate >= '" + sDate + "' AND atnd.AttendanceDate <= '" + eDate + "'";
            return Query<StudentAttendance>(query);
        }
    }
      
}
