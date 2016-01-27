
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class UsersDetailRepository : IRepository<UsersDetail>
	{
		private const string SqlTableName = "UsersDetail";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( FirstName, LastName, MiddleName, dob, CNIC, ContactNo1, ContactNo2, EmailID, Salary, UserID, creation_date, updated_date, created_by, updated_by, Gender, Address, Joining_date, FatherName) OUTPUT Inserted.ID Values(@FirstName, @LastName, @MiddleName, @dob, @CNIC, @ContactNo1, @ContactNo2, @EmailID, @Salary, @UserID, @creation_date, @updated_date, @created_by, @updated_by, @Gender, @Address, @Joining_date, @FatherName)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( FirstName, LastName, MiddleName, dob, CNIC, ContactNo1, ContactNo2, EmailID, Salary, UserID, creation_date, updated_date, created_by, updated_by, Gender, Address, Joining_date, FatherName) Values(@FirstName, @LastName, @MiddleName, @dob, @CNIC, @ContactNo1, @ContactNo2, @EmailID, @Salary, @UserID, @creation_date, @updated_date, @created_by, @updated_by, @Gender, @Address, @Joining_date, @FatherName);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, dob = @dob, CNIC = @CNIC, ContactNo1 = @ContactNo1, ContactNo2 = @ContactNo2, EmailID = @EmailID, Salary = @Salary, UserID = @UserID, updated_date = @updated_date, updated_by = @updated_by, Gender = @Gender, Address = @Address, isActive = @isActive, Joining_date = @Joining_date, FatherName = @FatherName where ( ID = @ID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ID = @ID ) AND isActive = 1 ";

		public override int Insert(UsersDetail model)
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
		public override  UsersDetail FindByID(int id)
		{
			return Query<UsersDetail>(SqlSelectCommand + " AND ID = @ID ", new { ID = id }).FirstOrDefault();
		}
		public override IEnumerable<UsersDetail> FindByQuery(string query)
		{
			return Query<UsersDetail>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<UsersDetail> GetAll()
		{
			return Query<UsersDetail>(SqlSelectCommand);
		}
		public override IEnumerable<UsersDetail> GetTop(int count)
		{
			return Query<UsersDetail>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(UsersDetail item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}