
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class ClassTeacherRepository : IRepository<ClassTeacher>
	{
		private const string SqlTableName = "ClassTeacher";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( ClassID, TeacherID, creation_date, updated_date, created_by, updated_by) OUTPUT Inserted.ID Values(@ClassID, @TeacherID, @creation_date, @updated_date, @created_by, @updated_by)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( ClassID, TeacherID, creation_date, updated_date, created_by, updated_by) Values(@ClassID, @TeacherID, @creation_date, @updated_date, @created_by, @updated_by);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set ClassID = @ClassID, TeacherID = @TeacherID, updated_date = @updated_date, updated_by = @updated_by, isActive = @isActive where ( ID = @ID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( ID = @ID ) AND isActive = 1 ";

		public override int Insert(ClassTeacher model)
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
		public override  ClassTeacher FindByID(int id)
		{
			return Query<ClassTeacher>(SqlSelectCommand + " AND ID = @ID ", new { ID = id }).FirstOrDefault();
		}
		public override IEnumerable<ClassTeacher> FindByQuery(string query)
		{
			return Query<ClassTeacher>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<ClassTeacher> GetAll()
		{
			return Query<ClassTeacher>(SqlSelectCommand);
		}
		public override IEnumerable<ClassTeacher> GetTop(int count)
		{
			return Query<ClassTeacher>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(ClassTeacher item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}