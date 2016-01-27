using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucStudentListView.xaml
    /// </summary>
    public partial class ucStudentListView : BaseUserControl
    {
        private IEnumerable<Student> _students;
        public ucStudentListView()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public IEnumerable<Student> StudentList
        {
            get
            {
                return _students;
            }
            set
            {
                if (_students != value)
                {
                    _students = value;
                    NotifyPropertyChanged("StudentList");
                }
            }
        }
        
        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            OpenStudentDetailWindow(FormModes.New , "Adding New Student");
        }

        private void OpenStudentDetailWindow(string mode, string title)
        {
            var win = (Student)gvStudentListView.SelectedItem;
            if (win == null && FormMode != FormModes.New)
            {
                Message(MessageTypes.Error, "Please Select to edit");
                return;
            }
            ucStudentDetailView view;
            if (mode == FormModes.New)
            {
                view = new ucStudentDetailView(mode);
            }
            else
            {
                view = new ucStudentDetailView(mode, win.StudentID);
            }
            view.ParentContainer = this;
            OpenPopUp(view, title, 650, 500);
        }

        private void btnDeleteStdent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRefreshStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ClearUserControl();
        }

        private void btnCMEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenStudentDetailWindow(FormModes.Edit, "Modify Student Detail");
        }
        private void btnCMView_Click(object sender, RoutedEventArgs e)
        {
            OpenStudentDetailWindow(FormModes.View, "Student Detail");
        }
        private void btnCMDelete_Click(object sender, RoutedEventArgs e)
        {
            var win = (Student)gvStudentListView.SelectedItem;
            if (win == null)
            {
                Message(MessageTypes.Error, "Please Select to Delete record");
                return;
            }
            StudentRepo.Remove(win.StudentID);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            StudentList = StudentRepo.GetStudentsList();
        }
    }
}
