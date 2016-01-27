using ES.Entities;

namespace ES.BusinessLayer
{
    public partial class UsersDetailRepository
    {
        public UsersDetail FindByUserID(int id)
        {
            var users  = FindByQuery(" UserID = " + id);
            UsersDetail user = null;
            foreach (var item in users)
            {
                user = item;
            }
            return user;
        }
    }
}
