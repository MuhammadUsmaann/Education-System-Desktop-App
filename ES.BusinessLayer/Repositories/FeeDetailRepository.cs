
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class FeeDetailRepository : IRepository<FeeDetail>
	{
		private const string SqlTableName = "FeeDetail";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( FeeType, PaidFee, PaidDate, RecievedBy, StudentID, ClassID, SectionID, SessionID, PaidForMonth, isAdjusted, DecidedFee, RemainingFee) OUTPUT Inserted.ID Values(@FeeType, @PaidFee, @PaidDate, @RecievedBy, @StudentID, @ClassID, @SectionID, @SessionID, @PaidForMonth, @isAdjusted, @DecidedFee, @RemainingFee)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( FeeType, PaidFee, PaidDate, RecievedBy, StudentID, ClassID, SectionID, SessionID, PaidForMonth, isAdjusted, DecidedFee, RemainingFee) Values(@FeeType, @PaidFee, @PaidDate, @RecievedBy, @StudentID, @ClassID, @SectionID, @SessionID, @PaidForMonth, @isAdjusted, @DecidedFee, @RemainingFee);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set FeeType = @FeeType, PaidFee = @PaidFee, PaidDate = @PaidDate, RecievedBy = @RecievedBy, StudentID = @StudentID, ClassID = @ClassID, SectionID = @SectionID, SessionID = @SessionID, PaidForMonth = @PaidForMonth, isActive = @isActive, isAdjusted = @isAdjusted, DecidedFee = @DecidedFee, RemainingFee = @RemainingFee where ( ID = @ID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ID = @ID ) AND isActive = 1 ";

		public override int Insert(FeeDetail model)
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
		public override  FeeDetail FindByID(int id)
		{
			return Query<FeeDetail>(SqlSelectCommand + " AND ID = @ID ", new { ID = id }).FirstOrDefault();
		}
		public override IEnumerable<FeeDetail> FindByQuery(string query)
		{
			return Query<FeeDetail>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<FeeDetail> GetAll()
		{
			return Query<FeeDetail>(SqlSelectCommand);
		}
		public override IEnumerable<FeeDetail> GetTop(int count)
		{
			return Query<FeeDetail>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(FeeDetail item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}