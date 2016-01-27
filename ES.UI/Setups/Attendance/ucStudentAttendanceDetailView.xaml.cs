using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucStudentAttendanceDetailView.xaml
    /// </summary>
    public partial class ucStudentAttendanceDetailView : BaseUserControl
    {
        IEnumerable<StudentAttendance> _studentAttendanceList;
        public ucStudentAttendanceDetailView(int stdid , string date)
        {
            InitializeComponent();
            SelectedStudenID = stdid;
            SelectedDate = date;
            //radDatePicker.Culture.DateTimeFormat.ShortDatePattern = DateFormatMonthYear;
        }
        public IEnumerable<StudentAttendance> StudentAttendanceList
        {
            get
            {
                return _studentAttendanceList;
            }
            set
            {
                if(_studentAttendanceList != value)
                {
                    _studentAttendanceList = value;
                    NotifyPropertyChanged("StudentAttendanceList");
                }
            }
        }
        private void CustomeUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (SelectedStudenID > 0 && DateScripts.IsValidDate(SelectedDate))
            {
                var std = StudentRepo.FindByID(SelectedStudenID);
                if (std == null) return;
                SelectedClassID = std.ClassID;
                SetList();
                SetStudentList();
            }
        }
        
        private void SetList()
        {
            string sdate = "", edate = "";
            SelectedDate.GetStartEndDate(ref sdate, ref edate);
            var atnds = AttendanceRepo.GetStudentAttendance(SelectedStudenID, SelectedClassID, sdate, edate);
            int count = SelectedDate.GetDaysInMonth();

            IEnumerable<StudentAttendance> _list = null;
            for (int i = 1; i <= count; i++)
            {
                bool isExisted = false;
                StudentAttendance temp = null;
                foreach (var item in atnds)
                {
                    if(i == item.DayNumber)
                    {
                        item.isExisted = true;
                        temp = item;
                        isExisted = true;
                        break;
                    }
                }
                if(!isExisted)
                {
                    temp = new StudentAttendance() { isPresent = false, DayNumber = i, DayName = sdate.AddDaysInDate(i).GetDayName() };
                }

                _list = _list.Add(temp);
            }
            StudentAttendanceList = _list;
        }
        private void radDatePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            StudentAttendanceList = null;
        }
        private void btnAttendanceSave_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedDate.IsValidDate()&& SelectedClassID > 0)
            {
                foreach (var item in StudentAttendanceList)
                {
                    Attendance atnd = new Attendance { ClassID = SelectedClassID, StudentID = SelectedStudenID, SessionID = SessionID, isPresent = item.isPresent, updated_by = UserID };
                    if (item.isExisted)
                    {
                        AttendanceRepo.Update(atnd);
                    }
                    else
                    {
                        atnd.created_by = UserID;
                        AttendanceRepo.Insert(atnd);
                    }
                }
            }
            else
            {
                Message(MessageTypes.Error, "Please Select the date and Class");
            }
        }
        private void btnAttendanceMark_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }
        private void btnAttendanceView_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
            SetList();
        }
        private void ComboBoxClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
            SetStudentList();
        }
        private void ComboBoxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }
    }
}
