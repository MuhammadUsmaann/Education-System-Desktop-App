using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucSubjectListView.xaml
    /// </summary>
    public partial class ucSubjectListView : BaseUserControl
    {
        private IEnumerable<Subject> _subjects;

        public ucSubjectListView()
        {
            InitializeComponent();
        }


        public IEnumerable<Subject> SubjectList
        {
            get
            {
                return _subjects;
            }
            set
            {
                if(_subjects!= value)
                {
                    _subjects = value;
                    NotifyPropertyChanged("SubjectList");
                }
            }
        }

        private void OpenSubjectDetailWindow(string mode, string title)
        {
            var win = GetSelectedSubject();
            
            if (win == null && mode != FormModes.New)
            {
                Message(MessageTypes.Error, "Please Select to " + mode + " Staff Detail");
                return;
            }
            if(FormModes.New == mode)
            {
                win = new Subject();
            }
            var view = new ucSubjectDetailView(mode, win.SubjectID);
            view.ParentContainer = this;
            OpenPopUp(view, title, 400, 300);
        }

        private Subject GetSelectedSubject()
        {
            return (Subject)gvSubjectListView.SelectedItem;
        }
        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            OpenSubjectDetailWindow(FormModes.New,"Add New Subject");
        }

        private void btnDeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            DeleteSubject();
        }

        private void btnRefreshSubject_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ClearUserControl();
        }

        private void SubjectListUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void btnCMEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenSubjectDetailWindow(FormModes.Edit, "Edit Subject");
        }


        private void btnCMDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSubject();
        }

        private void DeleteSubject()
        {
            var win = GetSelectedSubject();
            if (win == null || win.SubjectID > 0)
            {
                Message(MessageTypes.Error, "Please Select to delete Staff Detail");
                return;
            }
            if (!DeleteMessage())
            {
                return;
            }

            SubjectRepo.Remove(win.SubjectID);
            RefreshList();
        }

        public void RefreshList()
        {
            SubjectTypes.Arts.GetCode();
            SubjectList = SubjectRepo.GetAll();

            foreach (var item in SubjectList)
            {
                item.CompulsoryDescription = Utilities.GetEnumDescriptionFromString<CompulsoryTypes>(item.Compulsory);
                item.TypeDescription = Utilities.GetEnumDescriptionFromString<SubjectTypes>(item.Type);
            }
        }
        public void AddToList(Subject sub)
        {
            SubjectList = SubjectList.Add(sub);
        }
    }
}
