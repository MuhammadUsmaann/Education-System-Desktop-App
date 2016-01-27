using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Configurations
{
    public enum Genders
    {
        [DefaultValue("00001")]
        [Description("Male")]
        Male,
        [DefaultValue("00002")]
        [Description("Female")]
        Female,
    }
}
