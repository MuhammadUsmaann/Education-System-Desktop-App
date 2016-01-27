
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class UsersRepository : IRepository<Users>
	{
		private const string SqlTableName = "Users";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( UserName, Password, RoleID) OUTPUT Inserted.UserID Values(@UserName, @Password, @RoleID)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( UserName, Password, RoleID) Values(@UserName, @Password, @RoleID);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set UserName = @UserName, Password = @Password, RoleID = @RoleID, isActive = @isActive where ( UserID = @UserID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( UserID = @UserID ) AND isActive = 1 ";

		public override int Insert(Users model)
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
			return Execute(SqlDeleteCommand, new { UserID = id });
		}
		public override  Users FindByID(int id)
		{
			return Query<Users>(SqlSelectCommand + " AND UserID = @UserID ", new { UserID = id }).FirstOrDefault();
		}
		public override IEnumerable<Users> FindByQuery(string query)
		{
			return Query<Users>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Users> GetAll()
		{
			return Query<Users>(SqlSelectCommand);
		}
		public override IEnumerable<Users> GetTop(int count)
		{
			return Query<Users>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Users item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}