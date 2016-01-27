
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class ExamRepository : IRepository<Exam>
	{
		private const string SqlTableName = "Exam";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( Description, Type, comment, created_by, updated_by, creation_date, updated_date) OUTPUT Inserted.ExamID Values(@Description, @Type, @comment, @created_by, @updated_by, @creation_date, @updated_date)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( Description, Type, comment, created_by, updated_by, creation_date, updated_date) Values(@Description, @Type, @comment, @created_by, @updated_by, @creation_date, @updated_date);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set Description = @Description, Type = @Type, comment = @comment, updated_by = @updated_by, updated_date = @updated_date, isActive = @isActive where ( ExamID = @ExamID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ExamID = @ExamID ) AND isActive = 1 ";

		public override int Insert(Exam model)
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
			return Execute(SqlDeleteCommand, new { ExamID = id });
		}
		public override  Exam FindByID(int id)
		{
			return Query<Exam>(SqlSelectCommand + " AND ExamID = @ExamID ", new { ExamID = id }).FirstOrDefault();
		}
		public override IEnumerable<Exam> FindByQuery(string query)
		{
			return Query<Exam>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Exam> GetAll()
		{
			return Query<Exam>(SqlSelectCommand);
		}
		public override IEnumerable<Exam> GetTop(int count)
		{
			return Query<Exam>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Exam item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}