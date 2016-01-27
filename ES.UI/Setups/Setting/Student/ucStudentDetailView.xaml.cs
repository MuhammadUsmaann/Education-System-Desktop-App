using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucStudentDetailView.xaml
    /// </summary>
    public partial class ucStudentDetailView : BaseUserControl
    {
        private Student _student;
        private Parent _parents;
        
        public ucStudentDetailView(string mode, int stdID = 0 )
        {
            this.DataContext = this;
            InitializeComponent();
            FormMode = mode;
            SelectedStudenID = stdID;

            InitData();
        }

       

        #region Helper Properties


        public Parent ParentDetail
        {
            get
            {
                if (_parents == null)
                {
                    _parents = new Parent();
                }
                return _parents;
            }
            set
            {
                if (_parents != value)
                {
                    _parents = value;
                    NotifyPropertyChanged("ParentDetail");
                }
            }
        }
        public Student StudentDetail
        {
            get
            {
                if (_student == null)
                {
                    _student = new Student();
                }
                return _student;
            }
            set
            {
                if (_student != value)
                {
                    _student = value;
                    NotifyPropertyChanged("StudentDetail");
                }
            }
        }

       
        #endregion

        #region Helper Methods
        private void InitData()
        {
            if (FormMode == FormModes.New)
            {
                ParentDetail.isNew = true;
            }
        }
        
        internal void SetParentDetail(Parent parent)
        {
            ParentDetail = parent;
            ParentDetail.isNew = false;
        }
        private bool isValidate()
        {
            if (string.IsNullOrEmpty(StudentDetail.FirstName))
            {
                Message(MessageTypes.Error, "Select Student First Name");
                return false;
            }
            if (string.IsNullOrEmpty(StudentDetail.LastName))
            {
                Message(MessageTypes.Error, "Select Student Last Name");
                return false;
            }
            if (StudentDetail.ClassID > 0)
            {
                Message(MessageTypes.Error, "Select Student Class");
                return false;

            }
            if (StudentDetail.SectionID > 0 )
            {
                Message(MessageTypes.Error, "Select Student Class Section");
                return false;
            }
            if (string.IsNullOrEmpty( StudentDetail.AdmissionDate ))
            {
                Message(MessageTypes.Error, "Select Student Adminssion Date");
                return false;
            }
            if (string.IsNullOrEmpty(StudentDetail.AdmissionDate))
            {
                Message(MessageTypes.Error, "Select Student Adminssion Date");
                return false;
            }
            if (string.IsNullOrEmpty(ParentDetail.FirstName))
            {
                Message(MessageTypes.Error, "Select Parent First name");
                return false;
            }
            if (string.IsNullOrEmpty(ParentDetail.LastName))
            {
                Message(MessageTypes.Error, "Select Parent Last Name");
                return false;
            }
            if (string.IsNullOrEmpty(ParentDetail.ContactNo1) && string.IsNullOrEmpty(ParentDetail.ContactNo2))
            {
                Message(MessageTypes.Error, "Provide parent atleast one contact number");
                return false;
            }
            if (string.IsNullOrEmpty(ParentDetail.Address))
            {
                Message(MessageTypes.Error, "Select Parent Address");
                return false;
            }
            
            return true;
        }

        #endregion


        #region Events
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (FormMode == FormModes.Edit || FormMode == FormModes.View)
            {
                StudentDetail = StudentRepo.FindByID(SelectedStudenID);
                ParentDetail = ParentRepo.FindByID(StudentDetail.ParentID);
                var _tempClass = ClassStudentRepo.FindByUserID(StudentDetail.StudentID);
                SelectedClassID = _tempClass != null ? _tempClass.ClassID : 0;
            }
            ViewModeGenericWork();
        }
      
        private void btnStudentSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (FormMode == FormModes.View)
            {
                this.ActualParent.Close();
                return;
            }

            if (isValidate())
            {
                int _studentID = 0;

                if (FormMode == FormModes.New)
                {
                    int parentid = 0;
                    StudentDetail.created_by = StudentDetail.updated_by = ParentDetail.updated_by = ParentDetail.created_by = Utilities.UserSession.UserID;
                    StudentDetail.ClassID = SelectedClassID;
                    if (ParentDetail.isNew)
                    {
                        parentid = ParentRepo.Insert(ParentDetail);
                    }
                    else
                    {
                        ParentRepo.Update(ParentDetail);
                        parentid = ParentDetail.ParentID;
                    }
                    StudentDetail.ParentID = parentid;
                    StudentDetail.RegistrationNumber = "123123";
                    _studentID = StudentRepo.Insert(StudentDetail);
                    ClassStudentRepo.Insert(new ClassStudent { ClassID = SelectedClassID, StudentID = _studentID, created_by = StudentDetail.created_by, updated_by = StudentDetail.updated_by });
                }
                else if (FormMode == FormModes.Edit)
                {
                    StudentDetail.ParentID = ParentDetail.ParentID;
                    StudentDetail.updated_by = ParentDetail.updated_by = Utilities.UserSession.UserID;
                    StudentDetail.ClassID = SelectedClassID;
                    StudentRepo.Update(StudentDetail);
                    ParentRepo.Update(ParentDetail);
                    ClassStudentRepo.Update(new ClassStudent { ClassID = SelectedClassID, StudentID = _studentID, updated_by = StudentDetail.updated_by });
                }
                this.ActualParent.Close();
            }
        }
        private void btnSearchParent_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var view = new ucParentSearchListView();
            view.ParentContainer = this;
            OpenPopUp(view, "Search Parent", 650, 500);
        }
        private void btnAddNewSubject_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnRowSubEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnRowSubView_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnRowSubDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
      
     
    }
}
