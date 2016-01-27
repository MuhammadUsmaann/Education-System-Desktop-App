
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class SubjectRepository : IRepository<Subject>
	{
		private const string SqlTableName = "Subject";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( Description, creation_date, updated_date, created_by, updated_by, Type, Compulsory) OUTPUT Inserted.SubjectID Values(@Description, @creation_date, @updated_date, @created_by, @updated_by, @Type, @Compulsory)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( Description, creation_date, updated_date, created_by, updated_by, Type, Compulsory) Values(@Description, @creation_date, @updated_date, @created_by, @updated_by, @Type, @Compulsory);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set Description = @Description, updated_date = @updated_date, updated_by = @updated_by, Type = @Type, Compulsory = @Compulsory, isActive = @isActive where ( SubjectID = @SubjectID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( SubjectID = @SubjectID ) AND isActive = 1 ";

		public override int Insert(Subject model)
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
			return Execute(SqlDeleteCommand, new { SubjectID = id });
		}
		public override  Subject FindByID(int id)
		{
			return Query<Subject>(SqlSelectCommand + " AND SubjectID = @SubjectID ", new { SubjectID = id }).FirstOrDefault();
		}
		public override IEnumerable<Subject> FindByQuery(string query)
		{
			return Query<Subject>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Subject> GetAll()
		{
			return Query<Subject>(SqlSelectCommand);
		}
		public override IEnumerable<Subject> GetTop(int count)
		{
			return Query<Subject>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Subject item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}