using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System.Threading.Tasks;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucExperienceDetailView.xaml
    /// </summary>
    public partial class ucExperienceDetailView : BaseUserControl
    {   
        int _experienceID = 0;
        private Experience _experience;

        public ucExperienceDetailView(string mode, int experienceid = 0, Experience exp = null)
        {
            this.DataContext = this;
            InitializeComponent();
            FormMode = mode;
            _experienceID = experienceid;
            UserExperience = exp;
        }

        public Experience UserExperience
        {
            get
            {
                if (_experience == null)
                {
                    _experience = new Experience();
                }
                return _experience;
            }
            set
            {
                if (_experience != value)
                {
                    _experience = value;
                    NotifyPropertyChanged("UserExperience");
                }
            }
        }
        private void btnExperienceSave_Click(object sender, RoutedEventArgs e)
        {
            if (FormMode == FormModes.New)
            {
                var parent = (ucStaffDetailView)(this.ParentContainer);
                UserExperience.isNew = true;
                parent.AddToExperienceList(UserExperience);
            }
            else if (FormMode == FormModes.Edit)
            {
                ExperienceRepo.Update(UserExperience);
            }

            this.ActualParent.Close();
        }
        private async void ExperienceDetailView_Loaded(object sender, RoutedEventArgs e)
        {

            if (UserExperience != null && FormMode == FormModes.New)
                return;
            if (FormMode == FormModes.Edit)
            {
                await Task.Run(() =>
                {
                    UserExperience = ExperienceRepo.FindByID(_experienceID);
                });
            }
        }
    }
}
