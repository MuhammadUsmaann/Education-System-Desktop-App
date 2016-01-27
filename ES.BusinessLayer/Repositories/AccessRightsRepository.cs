
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class AccessRightsRepository : IRepository<AccessRights>
	{
		private const string SqlTableName = "AccessRights";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( Description, ControlID, UserID, CanEdit, CanView, CanDelete) OUTPUT Inserted.AccessRightID Values(@Description, @ControlID, @UserID, @CanEdit, @CanView, @CanDelete)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( Description, ControlID, UserID, CanEdit, CanView, CanDelete) Values(@Description, @ControlID, @UserID, @CanEdit, @CanView, @CanDelete);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set Description = @Description, ControlID = @ControlID, UserID = @UserID, CanEdit = @CanEdit, CanView = @CanView, CanDelete = @CanDelete, isActive = @isActive where ( AccessRightID = @AccessRightID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( AccessRightID = @AccessRightID ) AND isActive = 1 ";

		public override int Insert(AccessRights model)
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
			return Execute(SqlDeleteCommand, new { AccessRightID = id });
		}
		public override  AccessRights FindByID(int id)
		{
			return Query<AccessRights>(SqlSelectCommand + " AND AccessRightID = @AccessRightID ", new { AccessRightID = id }).FirstOrDefault();
		}
		public override IEnumerable<AccessRights> FindByQuery(string query)
		{
			return Query<AccessRights>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<AccessRights> GetAll()
		{
			return Query<AccessRights>(SqlSelectCommand);
		}
		public override IEnumerable<AccessRights> GetTop(int count)
		{
			return Query<AccessRights>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(AccessRights item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}