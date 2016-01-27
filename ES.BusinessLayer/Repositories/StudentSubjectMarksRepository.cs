
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class StudentSubjectMarksRepository : IRepository<StudentSubjectMarks>
	{
		private const string SqlTableName = "StudentSubjectMarks";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( ClassID, StudentID, ExamID, SubjectID, SectionID, ObtainedMarks, TotalMarks, created_by, updated_by, creation_date, updated_date, SessionID) OUTPUT Inserted.ID Values(@ClassID, @StudentID, @ExamID, @SubjectID, @SectionID, @ObtainedMarks, @TotalMarks, @created_by, @updated_by, @creation_date, @updated_date, @SessionID)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( ClassID, StudentID, ExamID, SubjectID, SectionID, ObtainedMarks, TotalMarks, created_by, updated_by, creation_date, updated_date, SessionID) Values(@ClassID, @StudentID, @ExamID, @SubjectID, @SectionID, @ObtainedMarks, @TotalMarks, @created_by, @updated_by, @creation_date, @updated_date, @SessionID);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set ClassID = @ClassID, StudentID = @StudentID, ExamID = @ExamID, SubjectID = @SubjectID, SectionID = @SectionID, ObtainedMarks = @ObtainedMarks, TotalMarks = @TotalMarks, isActive = @isActive, updated_by = @updated_by, updated_date = @updated_date, SessionID = @SessionID where ( ID = @ID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ID = @ID ) AND isActive = 1 ";

		public override int Insert(StudentSubjectMarks model)
		{
			string SqlInsertCommand = SqlInsertCommandSQLServer;
			if(isSQLite)
			{
				SqlInsertCommand=SqlInsertCommandSQLite;
			}
			return Query<int>(SqlInsertCommand, model).Single();
		}
		public override int Remove(int id)
		{
			return Execute(SqlDeleteCommand, new { ID = id });
		}
		public override  StudentSubjectMarks FindByID(int id)
		{
			return Query<StudentSubjectMarks>(SqlSelectCommand + " AND ID = @ID ", new { ID = id }).FirstOrDefault();
		}
		public override IEnumerable<StudentSubjectMarks> FindByQuery(string query)
		{
			return Query<StudentSubjectMarks>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<StudentSubjectMarks> GetAll()
		{
			return Query<StudentSubjectMarks>(SqlSelectCommand);
		}
		public override IEnumerable<StudentSubjectMarks> GetTop(int count)
		{
			return Query<StudentSubjectMarks>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(StudentSubjectMarks item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}