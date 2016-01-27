using ES.Configurations;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using ES.Entities;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucClassAttendanceListView.xaml
    /// </summary>
    public partial class ucClassAttendanceListView : BaseUserControl
    {
        private IEnumerable<ClassAttendanceList> _attendaceList;
        public ucClassAttendanceListView()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        #region Helper Methods
        private void RefreshList()
        {
            AttendanceList = null;
        }
        private IEnumerable<ClassAttendanceList> GetList()
        {
            int days = SelectedDate.GetDaysInMonth();
            string sData = "", eDate = "";

            SelectedDate.GetStartEndDate(ref sData, ref eDate);

            var atndList = AttendanceRepo.GetClassAttendance(SelectedClassID, SessionID,SelectedSectionID, sData, eDate);
            var stdList = AttendanceRepo.GetStudentsListForAttendance(SelectedClassID, SelectedSectionID);

            IEnumerable<ClassAttendanceList> newList = null;

            foreach (var item in stdList)
            {
                var atnds = from atnd in atndList
                            where atnd.StudentID == item.StudentID
                            select atnd;

                var atdStd = new ClassAttendanceList() { StudentName = item.StudentName, StudentID = item.StudentID };

                foreach (var atnd in atnds)
                {
                    int day = atnd.AttendanceDate.GetDayOfMonth();
                    string isPresent = atnd.isPresent ? "p" : "A";
                    switch (day)
                    {
                        case 1:
                            atdStd.Day01 = isPresent;
                            break;
                        case 2:
                            atdStd.Day02 = isPresent;
                            break;
                        case 3:
                            atdStd.Day03 = isPresent;
                            break;
                        case 4:
                            atdStd.Day04 = isPresent;
                            break;
                        case 5:
                            atdStd.Day05 = isPresent;
                            break;
                        case 6:
                            atdStd.Day06 = isPresent;
                            break;
                        case 7:
                            atdStd.Day07 = isPresent;
                            break;
                        case 8:
                            atdStd.Day08 = isPresent;
                            break;
                        case 9:
                            atdStd.Day09 = isPresent;
                            break;
                        case 10:
                            atdStd.Day10 = isPresent;
                            break;
                        case 11:
                            atdStd.Day11 = isPresent;
                            break;
                        case 12:
                            atdStd.Day12 = isPresent;
                            break;
                        case 13:
                            atdStd.Day14 = isPresent;
                            break;
                        case 14:
                            atdStd.Day14 = isPresent;
                            break;
                        case 15:
                            atdStd.Day15 = isPresent;
                            break;
                        case 16:
                            atdStd.Day16 = isPresent;
                            break;
                        case 17:
                            atdStd.Day17 = isPresent;
                            break;
                        case 18:
                            atdStd.Day18 = isPresent;
                            break;
                        case 19:
                            atdStd.Day19 = isPresent;
                            break;
                        case 20:
                            atdStd.Day20 = isPresent;
                            break;
                        case 21:
                            atdStd.Day21 = isPresent;
                            break;
                        case 22:
                            atdStd.Day22 = isPresent;
                            break;
                        case 23:
                            atdStd.Day23 = isPresent;
                            break;
                        case 24:
                            atdStd.Day24 = isPresent;
                            break;
                        case 25:
                            atdStd.Day25 = isPresent;
                            break;
                        case 26:
                            atdStd.Day26 = isPresent;
                            break;
                        case 27:
                            atdStd.Day27 = isPresent;
                            break;
                        case 28:
                            atdStd.Day28 = isPresent;
                            break;
                        case 29:
                            atdStd.Day29 = isPresent;
                            break;
                        case 30:
                            atdStd.Day30 = isPresent;
                            break;
                        case 31:
                            atdStd.Day31 = isPresent;
                            break;
                    }
                }
                newList = newList.Add(atdStd);
            }
            return newList;
        }

        #endregion


        #region Properties

        public IEnumerable<ClassAttendanceList> AttendanceList
        {
            get
            {
                return _attendaceList;
            }
            set
            {
                if (_attendaceList != value)
                {
                    _attendaceList = value;
                    NotifyPropertyChanged("AttendanceList");
                }
            }
        }
        

        #endregion


        #region Events

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMarkAttendance_Click(object sender, RoutedEventArgs e)
        {
            OpenPopUp(new ucMarkClassAttendance(), "Mark Class Attendance", 800, 600);
        }

        private void ClassAttendanceUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void cmbClassList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }



        private void btnViewAttendance_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
            if (SelectedClassID > 0 && !string.IsNullOrEmpty(SelectedDate) && DateScripts.IsValidDate(SelectedDate))
            {
                AttendanceList = GetList();
            }
            else
            {
                Message(MessageTypes.Error, "Please select date and class");
            }
        }

        private void btnCMEdit_Click(object sender, RoutedEventArgs e)
        {
            var atndStd = (ClassAttendanceList)gvClassAttendanceListView.SelectedItem;
            if (atndStd == null)
            {
                Message(MessageTypes.Error, "Please select date and class");
                return;
            }

            var view = new ucStudentAttendanceDetailView(atndStd.StudentID, SelectedDate);
            OpenPopUp(view, "Student Attendance", 700, 500);
        }

        #endregion
        
        
    }
}
