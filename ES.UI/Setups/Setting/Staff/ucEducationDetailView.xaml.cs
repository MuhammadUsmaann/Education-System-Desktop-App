using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System.Threading.Tasks;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucEducationDetailView.xaml
    /// </summary>
    public partial class ucEducationDetailView : BaseUserControl
    {
        private Education _education;
        private int _educationID = 0;
        public ucEducationDetailView(string mode,int educationID , Education edu = null)
        {
            InitializeComponent();
            FormMode = mode;
            _educationID = educationID;
            UserEducation = edu;
            ViewModeGenericWork();
        }
        public Education UserEducation
        {
            get
            {
                if(_education == null)
                {
                    _education = new Education();
                }
                return _education;
            }
            set
            {
                if (_education != null)
                {
                    _education = value;
                    NotifyPropertyChanged("UserEducation");
                }
            }
        }
        private void btnEducationSave_Click(object sender, RoutedEventArgs e)
        {
            if(FormMode == FormModes.View)
            {
                this.ActualParent.Close();
                return;
            }
            var parent = (ucStaffDetailView)this.ParentContainer;
            
            if(FormMode == FormModes.New)
            {
                UserEducation.isNew = true;
                parent.AddToEducationList(UserEducation);
            }
            else
            {
                parent.UpdateEducationList(UserEducation);
            }
            this.ActualParent.Close();
        }
        private void EducationDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            if (UserEducation != null && FormMode == FormModes.New)
                return;
            if(FormMode != FormModes.New)
            {
                UserEducation = EducationRepo.FindByID(_educationID);
            }
        }
    }
}
