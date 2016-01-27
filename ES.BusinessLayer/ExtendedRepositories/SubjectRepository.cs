
namespace ES.BusinessLayer
{
    public partial class SubjectRepository
    {
        public int GetClassCount(int id)
        {
            var sub = FindByID(id);
            return 10;
        }

        public int GetStudentCount(int id)
        {
            return 20;
        }
    }
}
