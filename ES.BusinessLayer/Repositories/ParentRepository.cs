
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class ParentRepository : IRepository<Parent>
	{
		private const string SqlTableName = "Parent";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( FirstName, MiddleName, LastName, Address, Email, ContactNo1, ContactNo2, CNIC, Income, creation_date, updated_date, updated_by, created_by) OUTPUT Inserted.ParentID Values(@FirstName, @MiddleName, @LastName, @Address, @Email, @ContactNo1, @ContactNo2, @CNIC, @Income, @creation_date, @updated_date, @updated_by, @created_by)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( FirstName, MiddleName, LastName, Address, Email, ContactNo1, ContactNo2, CNIC, Income, creation_date, updated_date, updated_by, created_by) Values(@FirstName, @MiddleName, @LastName, @Address, @Email, @ContactNo1, @ContactNo2, @CNIC, @Income, @creation_date, @updated_date, @updated_by, @created_by);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Address = @Address, Email = @Email, ContactNo1 = @ContactNo1, ContactNo2 = @ContactNo2, CNIC = @CNIC, Income = @Income, updated_date = @updated_date, updated_by = @updated_by, isActive = @isActive where ( ParentID = @ParentID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ParentID = @ParentID ) AND isActive = 1 ";

		public override int Insert(Parent model)
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
			return Execute(SqlDeleteCommand, new { ParentID = id });
		}
		public override  Parent FindByID(int id)
		{
			return Query<Parent>(SqlSelectCommand + " AND ParentID = @ParentID ", new { ParentID = id }).FirstOrDefault();
		}
		public override IEnumerable<Parent> FindByQuery(string query)
		{
			return Query<Parent>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Parent> GetAll()
		{
			return Query<Parent>(SqlSelectCommand);
		}
		public override IEnumerable<Parent> GetTop(int count)
		{
			return Query<Parent>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Parent item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}