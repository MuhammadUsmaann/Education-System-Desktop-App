using System.Collections.Generic;
using System.ComponentModel;

namespace ES.Configurations
{
    public enum SubjectTypes
    {
        [DefaultValue("00001")]
        [Description("Science")]
        Science,
        [DefaultValue("00002")]
        [Description("Arts")]
        Arts,
    }
}
