
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class ExperienceRepository : IRepository<Experience>
	{
		private const string SqlTableName = "Experience";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( Description, StartDate, EndDate, Institution, UserID) OUTPUT Inserted.ExperienceID Values(@Description, @StartDate, @EndDate, @Institution, @UserID)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( Description, StartDate, EndDate, Institution, UserID) Values(@Description, @StartDate, @EndDate, @Institution, @UserID);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set Description = @Description, StartDate = @StartDate, EndDate = @EndDate, Institution = @Institution, UserID = @UserID, isActive = @isActive where ( ExperienceID = @ExperienceID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ExperienceID = @ExperienceID ) AND isActive = 1 ";

		public override int Insert(Experience model)
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
			return Execute(SqlDeleteCommand, new { ExperienceID = id });
		}
		public override  Experience FindByID(int id)
		{
			return Query<Experience>(SqlSelectCommand + " AND ExperienceID = @ExperienceID ", new { ExperienceID = id }).FirstOrDefault();
		}
		public override IEnumerable<Experience> FindByQuery(string query)
		{
			return Query<Experience>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Experience> GetAll()
		{
			return Query<Experience>(SqlSelectCommand);
		}
		public override IEnumerable<Experience> GetTop(int count)
		{
			return Query<Experience>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Experience item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}