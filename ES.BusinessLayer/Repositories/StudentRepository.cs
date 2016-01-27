
using ES.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ES.BusinessLayer
{
	public partial class StudentRepository : IRepository<Student>
	{
		private const string SqlTableName = "Student";
		private const string SqlSelectCommand = " SELECT * FROM " + SqlTableName + " Where isActive = 1 ";
		private const string SqlInsertCommandSQLServer = " INSERT INTO " + SqlTableName + " ( FirstName, LastName, MiddleName, DateOfBirth, AdmissionDate, RegistrationNumber, Gender, Phone, AdminssionFee, ExaminationFee, MonthlyFee, OtherCharges, Discount, ParentID, ClassID, creation_date, updated_date, created_by, updated_by, SectionID) OUTPUT Inserted.StudentID Values(@FirstName, @LastName, @MiddleName, @DateOfBirth, @AdmissionDate, @RegistrationNumber, @Gender, @Phone, @AdminssionFee, @ExaminationFee, @MonthlyFee, @OtherCharges, @Discount, @ParentID, @ClassID, @creation_date, @updated_date, @created_by, @updated_by, @SectionID)";
		private const string SqlInsertCommandSQLite = " INSERT INTO " + SqlTableName + " ( FirstName, LastName, MiddleName, DateOfBirth, AdmissionDate, RegistrationNumber, Gender, Phone, AdminssionFee, ExaminationFee, MonthlyFee, OtherCharges, Discount, ParentID, ClassID, creation_date, updated_date, created_by, updated_by, SectionID) Values(@FirstName, @LastName, @MiddleName, @DateOfBirth, @AdmissionDate, @RegistrationNumber, @Gender, @Phone, @AdminssionFee, @ExaminationFee, @MonthlyFee, @OtherCharges, @Discount, @ParentID, @ClassID, @creation_date, @updated_date, @created_by, @updated_by, @SectionID);select last_insert_rowid();";
		private const string SqlUpdateCommand = " UPDATE " + SqlTableName + " Set FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, DateOfBirth = @DateOfBirth, AdmissionDate = @AdmissionDate, RegistrationNumber = @RegistrationNumber, Gender = @Gender, Phone = @Phone, AdminssionFee = @AdminssionFee, ExaminationFee = @ExaminationFee, MonthlyFee = @MonthlyFee, OtherCharges = @OtherCharges, Discount = @Discount, ParentID = @ParentID, ClassID = @ClassID, updated_date = @updated_date, updated_by = @updated_by, isActive = @isActive, SectionID = @SectionID where ( StudentID = @StudentID ) AND  isActive = 1 ";
		private const string SqlDeleteCommand = " Update " + SqlTableName + " Set isActive = 0 where ( StudentID = @StudentID ) AND isActive = 1 ";

		public override int Insert(Student model)
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
			return Execute(SqlDeleteCommand, new { StudentID = id });
		}
		public override  Student FindByID(int id)
		{
			return Query<Student>(SqlSelectCommand + " AND StudentID = @StudentID ", new { StudentID = id }).FirstOrDefault();
		}
		public override IEnumerable<Student> FindByQuery(string query)
		{
			return Query<Student>(SqlSelectCommand + " AND " + query);
		}
		public override IEnumerable<Student> GetAll()
		{
			return Query<Student>(SqlSelectCommand);
		}
		public override IEnumerable<Student> GetTop(int count)
		{
			return Query<Student>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName)).ToList();
		}
		public override int Update(Student item)
		{
			return Execute(SqlUpdateCommand, item);
		}
	}
}