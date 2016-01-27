
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class ClassStudentRepository : IRepository<ClassStudent>
	{
		private const string SqlTableName = "ClassStudent";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( ClassID, StudentID, creation_date, updated_date, created_by, updated_by) OUTPUT Inserted.ID Values(@ClassID, @StudentID, @creation_date, @updated_date, @created_by, @updated_by)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( ClassID, StudentID, creation_date, updated_date, created_by, updated_by) Values(@ClassID, @StudentID, @creation_date, @updated_date, @created_by, @updated_by);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set ClassID = @ClassID, StudentID = @StudentID, updated_date = @updated_date, updated_by = @updated_by, isActive = @isActive where ( ID = @ID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ID = @ID ) AND isActive = 1 ";

		public override int Insert(ClassStudent model)
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
		public override  ClassStudent FindByID(int id)
		{
			return Query<ClassStudent>(SqlSelectCommand + " AND ID = @ID ", new { ID = id }).FirstOrDefault();
		}
		public override IEnumerable<ClassStudent> FindByQuery(string query)
		{
			return Query<ClassStudent>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<ClassStudent> GetAll()
		{
			return Query<ClassStudent>(SqlSelectCommand);
		}
		public override IEnumerable<ClassStudent> GetTop(int count)
		{
			return Query<ClassStudent>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(ClassStudent item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}