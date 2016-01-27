using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Configurations
{
    public enum FeeType
    {
        [DefaultValue("00001")]
        [Description("Admission Fee")]
        AdmissionFee,
        [DefaultValue("00002")]
        [Description("Examination Fee")]
        ExaminationFee,
        [DefaultValue("00003")]
        [Description("Monthly Fee")]
        MonthlyFee,
        [DefaultValue("00004")]
        [Description("Other Charges")]
        OtherFee,
        [DefaultValue("00005")]
        [Description("Fine")]
        FineFee
    }
}
