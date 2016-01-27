
using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucStaffDetailView.xaml
    /// </summary>
    public partial class ucStaffDetailView : BaseUserControl
    {
        private UsersDetail _userDetail;
        private Users _user;
        private IEnumerable<Experience> _experiences;
        private IEnumerable<Education> _educations;
        
        private int _userID;

        public ucStaffDetailView(string formMode, int id = 0)
        {
            this.DataContext = this;
            InitializeComponent();
           
            initData();
            _userID = id;
            FormMode = formMode;
        }

      
        
        #region Properties

        public IEnumerable<Experience> ExperienceList
        {
            get
            {
                return _experiences;
            }
            set
            {
                if (_experiences != value)
                {
                    _experiences = value;
                    NotifyPropertyChanged("ExperienceList");
                }
            }
        }
        public IEnumerable<Education> EducationList
        {
            get
            {
                return _educations;
            }
            set
            {
                if (_educations != value)
                {
                    _educations = value;
                    NotifyPropertyChanged("EducationList");
                }
            }
        }
        public Users User
        {
            get
            {
                if (_user == null) _user = new Users();
                return _user;
            }
            set
            {
                if (_user != null)
                {
                    _user = value;
                    NotifyPropertyChanged("User");
                }
            }
        }
        public UsersDetail UserDetail
        {
            get
            {
                if (_userDetail == null) _userDetail = new UsersDetail();
                return _userDetail;
            }
            set
            {
                if (_userDetail != null)
                {
                    _userDetail = value;
                    NotifyPropertyChanged("UserDetail");
                }
            }
        }

        #endregion

       
        #region Events
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_userID > 0)
            {
                await Task.Run(() =>
                {
                    User = UserRepo.FindByID(_userID);
                });
                await Task.Run(() =>
                {
                    UserDetail = UserDetailRepo.FindByUserID(_userID);
                });
                await Task.Run(() =>
                {
                    ExperienceList = ExperienceRepo.FindByUserID(_userID);
                });
                await Task.Run(() =>
                {
                    EducationList = EducationRepo.FindByUserID(_userID);
                });
            }
        }
        private void btnAddNewEducation_Click(object sender, RoutedEventArgs e)
        {
            OpenEducationDetailWindow(FormModes.New , "Add Education Detail");
        }
        private void btnAddNewExperience_Click(object sender, RoutedEventArgs e)
        {
            OpenExperienceDetailWindow(FormModes.New,"Experience Detail");
        }
        private void btnRowExpEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenExperienceDetailWindow(FormModes.Edit, "Experience Detail");
        }
        private void btnRowExpDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnRowEduEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenEducationDetailWindow(FormModes.Edit, "Edit Education");
        }
        private void btnStaffSave_Click(object sender, RoutedEventArgs e)
        {
            if (FormMode == FormModes.View)
            {
                this.ActualParent.Close();
                return;
            }
            if (FormMode == FormModes.New)
            {
                int _newUserID = UserRepo.Insert(User);
                UserDetail.UserID = _newUserID;
                UserDetail.created_by = Utilities.UserSession.UserID;
                UserDetail.updated_by = Utilities.UserSession.UserID;

                UserDetailRepo.Insert(UserDetail);

                foreach (var exp in ExperienceList)
                {
                    exp.UserID = _newUserID;
                    ExperienceRepo.Insert(exp);
                }
                foreach (var edu in EducationList)
                {
                    edu.UserID = _newUserID;
                    EducationRepo.Insert(edu);
                }
            }
            else
            {
                UserDetailRepo.Update(UserDetail);
                UserRepo.Update(User);
                foreach (var exp in ExperienceList)
                {
                    if (exp.isNew)
                    {
                        exp.UserID = User.UserID;
                        ExperienceRepo.Insert(exp);
                    }
                    else
                    {
                        ExperienceRepo.Update(exp);
                    }
                }
                foreach (var edu in EducationList)
                {
                    if (edu.isNew)
                    {
                        edu.UserID = User.UserID;
                        EducationRepo.Insert(edu);
                    }
                    else
                    {
                        EducationRepo.Update(edu);
                    }
                }
            }
            this.ActualParent.Close();
        }


        #endregion

       
        #region Methods
        private void initData()
        {
            if (FormMode == FormModes.View)
            {
                btnAddNewExperience.Visibility = btnAddNewEducation.Visibility = System.Windows.Visibility.Collapsed;
            }
            ViewModeGenericWork();
        }

        internal void AddToExperienceList(Experience exp)
        {
            ExperienceList = ExperienceList.Add(exp);
        }
        private Experience getSelectedEnity()
        {
            return (Experience)gvStaffExpListView.SelectedItem;
        }
        internal void AddToEducationList(Education edu)
        {
            EducationList = EducationList.Add(edu);
        }
        internal void UpdateExperienceList(Experience exp)
        {
            List<Experience> expList = new List<Experience>();
            foreach (Experience e in ExperienceList)
            {
                if (e.ExperienceID == exp.ExperienceID)
                {
                    expList.Add(exp);
                }
                else
                {
                    expList.Add(e);
                }
            }
            ExperienceList = expList as IEnumerable<Experience>;

        }
        internal void UpdateEducationList(Education edu)
        {
            List<Education> eduList = new List<Education>();
            foreach (Education e in EducationList)
            {
                if (e.EducationID == edu.EducationID)
                {
                    eduList.Add(edu);
                }
                else
                {
                    eduList.Add(e);
                }
            }
            EducationList = eduList as IEnumerable<Education>;

        }
        private void OpenEducationDetailWindow(string mode, string title)
        {
            var win = (Education)gvEducationListView.SelectedItem;
            if (win == null && mode != FormModes.New)
            {
                Message(MessageTypes.Error, "Please Select to edit");
                return;
            }
            ucEducationDetailView view;
            if (win != null && win.EducationID == 0)
            {
                view = new ucEducationDetailView(FormModes.New, win.EducationID, win);
            }
            else
            {
                if (win == null)
                {
                    win = new Education();
                }
                view = new ucEducationDetailView(FormModes.New, win.EducationID);
            }
            view.ParentContainer = this;
            OpenPopUp(view, title, 500, 260);
        }
        private void OpenExperienceDetailWindow(string mode, string title)
        {
            var win = (Experience)gvStaffExpListView.SelectedItem;
            if (win == null && mode != FormModes.New)
            {
                Message(MessageTypes.Error, "Please Select to edit");
                return;
            }
            ucExperienceDetailView view;
            if (win != null && win.ExperienceID == 0)
            {
                view = new ucExperienceDetailView(FormModes.New, win.ExperienceID, win);
            }
            else
            {
                if (win == null)
                {
                    win = new Experience();
                }
                view = new ucExperienceDetailView(FormModes.New, win.ExperienceID);
            }
            view.ParentContainer = this;
            OpenPopUp(view, title, 500, 260);
        }

        #endregion

        private void btnRowEduDelete_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}