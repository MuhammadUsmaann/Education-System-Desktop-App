
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class StudentFeeRepository : IRepository<StudentFee>
	{
		private const string SqlTableName = "StudentFee";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( FeeType, DecidedFee, StudentID, SessionID, created_by, creation_date, updated_by, updated_date) OUTPUT Inserted.StudentFeeID Values(@FeeType, @DecidedFee, @StudentID, @SessionID, @created_by, @creation_date, @updated_by, @updated_date)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( FeeType, DecidedFee, StudentID, SessionID, created_by, creation_date, updated_by, updated_date) Values(@FeeType, @DecidedFee, @StudentID, @SessionID, @created_by, @creation_date, @updated_by, @updated_date);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set FeeType = @FeeType, DecidedFee = @DecidedFee, StudentID = @StudentID, SessionID = @SessionID, updated_by = @updated_by, updated_date = @updated_date where ( StudentFeeID = @StudentFeeID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( StudentFeeID = @StudentFeeID ) AND isActive = 1 ";

		public override int Insert(StudentFee model)
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
			return Execute(SqlDeleteCommand, new { StudentFeeID = id });
		}
		public override  StudentFee FindByID(int id)
		{
			return Query<StudentFee>(SqlSelectCommand + " AND StudentFeeID = @StudentFeeID ", new { StudentFeeID = id }).FirstOrDefault();
		}
		public override IEnumerable<StudentFee> FindByQuery(string query)
		{
			return Query<StudentFee>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<StudentFee> GetAll()
		{
			return Query<StudentFee>(SqlSelectCommand);
		}
		public override IEnumerable<StudentFee> GetTop(int count)
		{
			return Query<StudentFee>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(StudentFee item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}