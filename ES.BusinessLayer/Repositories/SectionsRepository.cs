
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class SectionsRepository : IRepository<Sections>
	{
		private const string SqlTableName = "Sections";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( Description) OUTPUT Inserted.SectionID Values(@Description)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( Description) Values(@Description);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set Description = @Description, isActive = @isActive where ( SectionID = @SectionID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( SectionID = @SectionID ) AND isActive = 1 ";

		public override int Insert(Sections model)
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
			return Execute(SqlDeleteCommand, new { SectionID = id });
		}
		public override  Sections FindByID(int id)
		{
			return Query<Sections>(SqlSelectCommand + " AND SectionID = @SectionID ", new { SectionID = id }).FirstOrDefault();
		}
		public override IEnumerable<Sections> FindByQuery(string query)
		{
			return Query<Sections>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Sections> GetAll()
		{
			return Query<Sections>(SqlSelectCommand);
		}
		public override IEnumerable<Sections> GetTop(int count)
		{
			return Query<Sections>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Sections item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}