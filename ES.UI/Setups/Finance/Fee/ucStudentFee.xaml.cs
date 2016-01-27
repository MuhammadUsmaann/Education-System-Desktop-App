using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ES.Configurations;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucStudentFee.xaml
    /// </summary>
    public partial class ucStudentFee : BaseUserControl
    {
        public ucStudentFee()

        {
            InitializeComponent();

            var code = FeeType.AdmissionFee.GetCode();
            var asd = FeeType.AdmissionFee.GetDescription();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedClassID > 0 && SelectedSectionID > 0)
            {
                SetStudentList();
            }
        }
        private void Student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        

        private void btnViewClassMarks_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClassID > 0 && SelectedSectionID > 0 && SelectedStudenID > 0)
            {

            }
        }
    }
}
