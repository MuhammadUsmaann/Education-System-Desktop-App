
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class GradeRepository : IRepository<Grade>
	{
		private const string SqlTableName = "Grade";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( GradeName, Percentage, Comment, created_by, updated_by, creation_date, updated_date) OUTPUT Inserted.GradeID Values(@GradeName, @Percentage, @Comment, @created_by, @updated_by, @creation_date, @updated_date)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( GradeName, Percentage, Comment, created_by, updated_by, creation_date, updated_date) Values(@GradeName, @Percentage, @Comment, @created_by, @updated_by, @creation_date, @updated_date);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set GradeName = @GradeName, Percentage = @Percentage, Comment = @Comment, updated_by = @updated_by, updated_date = @updated_date, isActive = @isActive where ( GradeID = @GradeID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( GradeID = @GradeID ) AND isActive = 1 ";

		public override int Insert(Grade model)
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
			return Execute(SqlDeleteCommand, new { GradeID = id });
		}
		public override  Grade FindByID(int id)
		{
			return Query<Grade>(SqlSelectCommand + " AND GradeID = @GradeID ", new { GradeID = id }).FirstOrDefault();
		}
		public override IEnumerable<Grade> FindByQuery(string query)
		{
			return Query<Grade>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Grade> GetAll()
		{
			return Query<Grade>(SqlSelectCommand);
		}
		public override IEnumerable<Grade> GetTop(int count)
		{
			return Query<Grade>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Grade item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}