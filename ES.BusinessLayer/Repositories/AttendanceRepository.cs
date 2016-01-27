
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class AttendanceRepository : IRepository<Attendance>
	{
		private const string SqlTableName = "Attendance";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( ClassID, StudentID, SessionID, AttendanceDate, updated_date, creation_date, updated_by, created_by, isPresent, SectionID) OUTPUT Inserted.ID Values(@ClassID, @StudentID, @SessionID, @AttendanceDate, @updated_date, @creation_date, @updated_by, @created_by, @isPresent, @SectionID)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( ClassID, StudentID, SessionID, AttendanceDate, updated_date, creation_date, updated_by, created_by, isPresent, SectionID) Values(@ClassID, @StudentID, @SessionID, @AttendanceDate, @updated_date, @creation_date, @updated_by, @created_by, @isPresent, @SectionID);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set ClassID = @ClassID, StudentID = @StudentID, SessionID = @SessionID, AttendanceDate = @AttendanceDate, updated_date = @updated_date, updated_by = @updated_by, isActive = @isActive, isPresent = @isPresent, SectionID = @SectionID where ( ID = @ID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ID = @ID ) AND isActive = 1 ";

		public override int Insert(Attendance model)
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
		public override  Attendance FindByID(int id)
		{
			return Query<Attendance>(SqlSelectCommand + " AND ID = @ID ", new { ID = id }).FirstOrDefault();
		}
		public override IEnumerable<Attendance> FindByQuery(string query)
		{
			return Query<Attendance>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Attendance> GetAll()
		{
			return Query<Attendance>(SqlSelectCommand);
		}
		public override IEnumerable<Attendance> GetTop(int count)
		{
			return Query<Attendance>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Attendance item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}