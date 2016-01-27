using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucMarkClassMarksListView.xaml
    /// </summary>
    public partial class ucMarkClassMarksListView : BaseUserControl
    {
        private string _radioMark = CustomVisibility.Collapsed;
        private string _radioView = CustomVisibility.Visible;
        private IEnumerable<StudentSubjectMarks> _studentSubjectMarks = null;
        private int _totalMarks;
        private bool _isViewEnable;
        
        public ucMarkClassMarksListView()
        {
            InitializeComponent();
        }

        #region Helper Properties
        public bool isViewEnable
        {
            get { return _isViewEnable; }
            set
            {
                if(_isViewEnable != value)
                {
                    _isViewEnable = value;
                    NotifyPropertyChanged("isViewEnable");
                }
            }
        }
        public int TotalMarks
        {
            get { return _totalMarks; }
            set
            {
                if (_totalMarks != value)
                {
                    _totalMarks = value;
                    NotifyPropertyChanged("TotalMarks");
                }
            }
        }
        public IEnumerable<StudentSubjectMarks> ClassMarkList
        {
            get { return _studentSubjectMarks; }
            set
            {
                if (_studentSubjectMarks != value)
                {
                    _studentSubjectMarks = value;
                    NotifyPropertyChanged("ClassMarkList");
                }
            }
        }
        public string RadioView
        {
            get { return _radioView; }
            set
            {
                if (_radioView != value)
                {
                    _radioView = value;
                    NotifyPropertyChanged("RadioView");
                }
            }
        }
        public string RadioMark
        {
            get { return _radioMark; }
            set
            {
                if (_radioMark != value)
                {
                    _radioMark = value;
                    NotifyPropertyChanged("RadioMark");
                }
            }
        }


        #endregion

        #region Helper Methods

        private void RefreshList()
        {
            if (SelectedExamID > 0 && SelectedClassID > 0 && SelectedSubjectID > 0)
            {
                SyncStudentList();
            }
            else
            {
                Message(MessageTypes.Error, "Select Required Info");
            }
        }
        private void SyncStudentList()
        {
            ClassMarkList = StudentSubjectMarksRepo.GetStudentsMark(SelectedClassID, SelectedExamID, SelectedSubjectID, SelectedSectionID, SessionID);
            IEnumerable<Student> stdList = ClassStudentRepo.GetStudents(SelectedClassID, SelectedSectionID);

            if (ClassMarkList.Count() != stdList.Count())
            {
                foreach (var item in stdList)
                {
                    bool isExisted = false;
                    foreach (var std in ClassMarkList)
                    {
                        if (std.StudentID == item.StudentID && std.ClassID == item.ClassID)
                        {
                            isExisted = true;
                        }
                    }
                    if (!isExisted)
                    {
                        ClassMarkList = ClassMarkList.Add(new StudentSubjectMarks {SessionID = SessionID, StudentID = item.StudentID, StudentName = item.FullName, StudentRoleNumber = item.RegistrationNumber, isNew = true });
                    }
                }
            }
        }

        #endregion

        #region Events

        private void cmbClassList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassMarkList = null;
            SetSubjectList(SelectedClassID);
        }
        private void cmbSubjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassMarkList = null;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ClearUserControl();
        }
        private void btnRadioView_Click(object sender, RoutedEventArgs e)
        {
            RadioMark = CustomVisibility.Collapsed;
            RadioView = CustomVisibility.Visible;
            isViewEnable = true;
        }
        private void btnRadioMark_Click(object sender, RoutedEventArgs e)
        {
            RadioMark = CustomVisibility.Visible;
            RadioView = CustomVisibility.Collapsed;
            isViewEnable = false;
        }
        private void cmbExamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassMarkList = null;
        }
        private void btnViewClassMarks_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }
        private void btnMarkClassMarks_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }
        private void btnSaveMarks_Click(object sender, RoutedEventArgs e)
        {
            if (ClassMarkList != null)
            {
                if (SelectedExamID > 0 && SelectedClassID > 0 && SelectedSubjectID > 0 && SelectedSectionID > 0)
                {
                    foreach (var item in ClassMarkList)
                    {
                        item.ClassID = SelectedClassID;
                        item.SubjectID = SelectedSubjectID;
                        item.ExamID = SelectedExamID;
                        item.TotalMarks = TotalMarks;
                        item.SectionID = SelectedSectionID;
                        item.created_by = item.updated_by = UserID;
                        if (item.isNew)
                        {
                            StudentSubjectMarksRepo.Insert(item);
                        }
                        else
                        {
                            StudentSubjectMarksRepo.Update(item);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
