using System.Collections.Generic;
using System.ComponentModel;

namespace ES.Configurations
{
    public enum CompulsoryTypes
    {
        [DefaultValue("00001")]
        [Description("Compulsory")]
        Compulsory,
        [DefaultValue("00002")]
        [Description("Elective")]
        Elective,
    }
}
