
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class ClassRepository : IRepository<Class>
	{
		private const string SqlTableName = "Class";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( Description, ClassNumber, creation_date, updated_date, created_by, updated_by, BranchID) OUTPUT Inserted.ClassID Values(@Description, @ClassNumber, @creation_date, @updated_date, @created_by, @updated_by, @BranchID)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( Description, ClassNumber, creation_date, updated_date, created_by, updated_by, BranchID) Values(@Description, @ClassNumber, @creation_date, @updated_date, @created_by, @updated_by, @BranchID);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set Description = @Description, ClassNumber = @ClassNumber, updated_date = @updated_date, updated_by = @updated_by, BranchID = @BranchID, isActive = @isActive where ( ClassID = @ClassID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ClassID = @ClassID ) AND isActive = 1 ";

		public override int Insert(Class model)
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
			return Execute(SqlDeleteCommand, new { ClassID = id });
		}
		public override  Class FindByID(int id)
		{
			return Query<Class>(SqlSelectCommand + " AND ClassID = @ClassID ", new { ClassID = id }).FirstOrDefault();
		}
		public override IEnumerable<Class> FindByQuery(string query)
		{
			return Query<Class>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Class> GetAll()
		{
			return Query<Class>(SqlSelectCommand);
		}
		public override IEnumerable<Class> GetTop(int count)
		{
			return Query<Class>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Class item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}