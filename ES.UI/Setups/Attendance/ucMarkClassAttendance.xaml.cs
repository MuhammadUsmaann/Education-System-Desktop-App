using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucMarkClassAttendance.xaml
    /// </summary>
    public partial class ucMarkClassAttendance : BaseUserControl
    {
        private IEnumerable<Attendance> _classAttendance;
        public ucMarkClassAttendance()
        {
            this.DataContext = this;
            InitializeComponent();
            ViewModeGenericWork();
        }

        public IEnumerable<Attendance> ClassAttendanceList
        {
            get
            {
                return _classAttendance;
            }
            set
            {
                if (_classAttendance != value)
                {
                    _classAttendance = value;
                    NotifyPropertyChanged("ClassAttendanceList");
                }
            }
        }

        #region Events
        private void btnAttendanceSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ClassAttendanceList)
            {
                item.created_by = item.updated_by = UserID;
                if (item.isNew)
                {
                    item.SessionID = SessionID;
                    item.AttendanceDate = SelectedDate;
                    item.SectionID = SelectedSectionID;
                    AttendanceRepo.Insert(item);
                }
                else
                {
                    AttendanceRepo.Update(item);
                }
            }
            ReloadList();
        }
        private void USERCONTROL_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void btnAttendanceMark_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
            if(SelectedClassID > 0 && !string.IsNullOrEmpty(SelectedDate) )
            {
                ReloadList();
            }
            else
            {
                Message(MessageTypes.Error, "Please select date and class");
            }

        }
        private void cmbClassList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            RefreshList();
        }

        #endregion

        #region Helper Methods

        private void ReloadList()
        {
            RefreshList();

            if (SelectedClassID > 0 && !string.IsNullOrEmpty(SelectedDate))
            {

                var atndList = AttendanceRepo.GetClassAttendance(SelectedClassID, SessionID, SelectedSectionID, SelectedDate);
                var stdlist = AttendanceRepo.GetStudentsListForAttendance(SelectedClassID, SelectedSectionID);
                ClassAttendanceList = MergeLists(atndList, stdlist);

                FormMode = FormModes.Edit;
                if (ClassAttendanceList.Count() == 0)
                {
                    FormMode = FormModes.New;
                    ClassAttendanceList = null;
                }
            }
        }
        private void RefreshList()
        {
            ClassAttendanceList = null;
        }
        private IEnumerable<Attendance> MergeLists(IEnumerable<Attendance> atndList, IEnumerable<Attendance> stdlist)
        {
            if (atndList.Count() == stdlist.Count())
            {
                return atndList;
            }
            IEnumerable<Attendance> newList = null;

            foreach (var atd in atndList)
            {
                newList = newList.Add(atd);
            }
            foreach (var std in stdlist)
            {
                bool isExisted = false;
                foreach (var atd in atndList)
                {
                    if(atd.StudentID == std.StudentID)
                    {
                        isExisted = true; 
                    }
                }
                if(!isExisted)
                {
                    std.isNew = true;
                    newList = newList.Add(std);
                }
            }
            return newList;
        }

        #endregion
    }
}