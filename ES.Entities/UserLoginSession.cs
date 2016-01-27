using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Entities
{
    public class UserLoginSession
    {   
        public string RoleID { get; set; }

        public string DisplayName { get; set; }

        public string UserName { get; set; }

        public int UserID { get; set; }

        public string Password { get; set; }

        public string SchoolName { get; set; }
        public int SessionID { get; set; }
    }
}
