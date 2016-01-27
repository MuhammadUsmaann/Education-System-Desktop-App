
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class SessionRepository : IRepository<Session>
	{
		private const string SqlTableName = "Session";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( StartDate, EndDate, creation_date, updated_date, created_by, updated_by, Description) OUTPUT Inserted.SessionID Values(@StartDate, @EndDate, @creation_date, @updated_date, @created_by, @updated_by, @Description)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( StartDate, EndDate, creation_date, updated_date, created_by, updated_by, Description) Values(@StartDate, @EndDate, @creation_date, @updated_date, @created_by, @updated_by, @Description);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set StartDate = @StartDate, EndDate = @EndDate, updated_date = @updated_date, updated_by = @updated_by, Description = @Description, isActive = @isActive where ( SessionID = @SessionID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( SessionID = @SessionID ) AND isActive = 1 ";

		public override int Insert(Session model)
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
			return Execute(SqlDeleteCommand, new { SessionID = id });
		}
		public override  Session FindByID(int id)
		{
			return Query<Session>(SqlSelectCommand + " AND SessionID = @SessionID ", new { SessionID = id }).FirstOrDefault();
		}
		public override IEnumerable<Session> FindByQuery(string query)
		{
			return Query<Session>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Session> GetAll()
		{
			return Query<Session>(SqlSelectCommand);
		}
		public override IEnumerable<Session> GetTop(int count)
		{
			return Query<Session>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Session item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}