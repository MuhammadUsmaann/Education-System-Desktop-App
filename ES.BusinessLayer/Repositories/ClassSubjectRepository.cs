
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class ClassSubjectRepository : IRepository<ClassSubject>
	{
		private const string SqlTableName = "ClassSubject";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( ClassID, SubjectID, creation_date, updated_date, created_by, updated_by) OUTPUT Inserted.ID Values(@ClassID, @SubjectID, @creation_date, @updated_date, @created_by, @updated_by)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( ClassID, SubjectID, creation_date, updated_date, created_by, updated_by) Values(@ClassID, @SubjectID, @creation_date, @updated_date, @created_by, @updated_by);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set ClassID = @ClassID, SubjectID = @SubjectID, updated_date = @updated_date, updated_by = @updated_by, isActive = @isActive where ( ID = @ID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ID = @ID ) AND isActive = 1 ";

		public override int Insert(ClassSubject model)
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
		public override  ClassSubject FindByID(int id)
		{
			return Query<ClassSubject>(SqlSelectCommand + " AND ID = @ID ", new { ID = id }).FirstOrDefault();
		}
		public override IEnumerable<ClassSubject> FindByQuery(string query)
		{
			return Query<ClassSubject>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<ClassSubject> GetAll()
		{
			return Query<ClassSubject>(SqlSelectCommand);
		}
		public override IEnumerable<ClassSubject> GetTop(int count)
		{
			return Query<ClassSubject>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(ClassSubject item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}