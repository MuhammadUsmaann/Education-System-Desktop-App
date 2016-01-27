using System.Collections.Generic;
using System.ComponentModel;

namespace ES.Configurations
{
    public enum RoleTypes
    {
        [DefaultValue("00001")]
        [Description("Admin")]
        Admin,
        [DefaultValue("00002")]
        [Description("Teacher")]
        Teacher,
        [DefaultValue("00002")]
        [Description("Accountant")]
        Accountant,
        [DefaultValue("00002")]
        [Description("Peon")]
        Peon
    }
}
