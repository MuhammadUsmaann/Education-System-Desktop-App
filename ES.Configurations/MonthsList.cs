using System.ComponentModel;

namespace ES.Configurations
{
    public enum Months
    {
        [DefaultValue("1")]
        [Description("January")]
        January,
        [DefaultValue("2")]
        [Description("February")]
        February,
        [DefaultValue("3")]
        [Description("March")]
        March,
        [DefaultValue("4")]
        [Description("April")]
        April,
        [DefaultValue("5")]
        [Description("May")]
        May,
        [DefaultValue("6")]
        [Description("June")]
        June,
        [DefaultValue("7")]
        [Description("July")]
        JuneJuly,
        [DefaultValue("8")]
        [Description("August")]
        August,
        [DefaultValue("9")]
        [Description("September")]
        September,
        [DefaultValue("10")]
        [Description("October")]
        October,
        [DefaultValue("11")]
        [Description("November")]
        November,
        [DefaultValue("12")]
        [Description("December")]
        December
    }
}
