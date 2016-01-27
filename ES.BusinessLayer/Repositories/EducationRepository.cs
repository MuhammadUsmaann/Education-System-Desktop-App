
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class EducationRepository : IRepository<Education>
	{
		private const string SqlTableName = "Education";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( Description, PassYear, score, UserID, Institution) OUTPUT Inserted.EducationID Values(@Description, @PassYear, @score, @UserID, @Institution)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( Description, PassYear, score, UserID, Institution) Values(@Description, @PassYear, @score, @UserID, @Institution);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set Description = @Description, PassYear = @PassYear, score = @score, UserID = @UserID, Institution = @Institution, isActive = @isActive where ( EducationID = @EducationID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( EducationID = @EducationID ) AND isActive = 1 ";

		public override int Insert(Education model)
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
			return Execute(SqlDeleteCommand, new { EducationID = id });
		}
		public override  Education FindByID(int id)
		{
			return Query<Education>(SqlSelectCommand + " AND EducationID = @EducationID ", new { EducationID = id }).FirstOrDefault();
		}
		public override IEnumerable<Education> FindByQuery(string query)
		{
			return Query<Education>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Education> GetAll()
		{
			return Query<Education>(SqlSelectCommand);
		}
		public override IEnumerable<Education> GetTop(int count)
		{
			return Query<Education>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Education item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}