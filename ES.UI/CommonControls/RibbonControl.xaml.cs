using ES.Controls;
using ES.UI.Setups;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ES.UI.CommonControls
{
    /// <summary>
    /// Interaction logic for RibbonControl_Windows.xaml
    /// </summary>
    public partial class RibbonControl : BaseUserControl
    {
        private MainWindowContainer m_MainWinContainer = null;
        public RibbonControl()
        {
            InitializeComponent();
        }
        public MainWindowContainer MainWinContainer { get 
        {
            if (m_MainWinContainer == null) m_MainWinContainer = new MainWindowContainer();
            return m_MainWinContainer;
        }
            set { }
        }
        private void RibbonWin_Loaded(object sender, RoutedEventArgs e)
        {
            Grid child = VisualTreeHelper.GetChild((DependencyObject)sender, 0) as Grid;
            if (child != null)
            {
                child.RowDefinitions[0].Height = new GridLength(0);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Utilities.RibbonViewHieght = this.ActualHeight;
        }

        private bool OpenWindow(string controlName, string title = "Public Window")
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                string namespaceName = "ES.UI.Setups";
                TryCatch.BeginTryCatch(() =>
                {
                    MainWindow main = (MainWindow)Utilities.GetMainWindow();
                    if (main != null && main.MainContainer != null)
                    {
                        var myObj = Activator.CreateInstance(Type.GetType(namespaceName + "." + controlName));

                        if (main.MainContainer.Content == null || MainWinContainer.MainWindowContainerContent.Content == null 
                            || (myObj != null && MainWinContainer.MainWindowContainerContent.Content.GetType().Name != myObj.GetType().Name))
                        {
                            MainWinContainer.WindowTitle.Text = title;
                            MainWinContainer.MainWindowContainerContent.Content = myObj;
                            main.MainContainer.Content = MainWinContainer;
                        }
                    }
                });
            }));

            return true;
        }

        private void btnStaffListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucStaffListView", "Staff List View" );
        }
        private void btnStudentListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucStudentListView", "Student List View");
        }
        private void btnSessionListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucSessionListView", "Session list View");
        }
        private  void btnClassListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucClassListView", "Class List View");
        }
        private void btnSubjectListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucSubjectListView", "Subject List View");
        }
        private void btnClassAttendance_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucClassAttendanceListView", "Class Attendance List View");
        }
        private void btnStudentAttendance_Click(object sender, RoutedEventArgs e)
        {
            var view = new ucStudentAttendanceDetailView(0, null);
            OpenPopUp(view, "Student Attendance", 700, 500);
        }
        public void OpenPopUp(BaseUserControl control, string title = "Pop Up", int width = 300, int height = 300)
        {
            PopUpWindow ne = new PopUpWindow(control, title, width, height);
            ne.ShowDialog();
        }

        private void btnExamsListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucExamsSettingListView","Exam List View");
        }

        private void btnGradesListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucGradeSettingListView", "");
        }

        private void btnEnterClassMarkView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucMarkClassMarksListView","");
        }

        private void te_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("TestGridView","");
        }

        private void btnSectionsListView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucSectionListView", "Sections");
        }

        private void btnMarkClassAtnd_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucMarkClassAttendance", "Mark Class Attendance");
        }

        private void btnEnterStudentMarkView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucStudentResult", "Student Result Card");
        }

        private void btnClassResultView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucClassResult", "Class Result");
        }

        private void btnStudentFee_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucStudentFee", "Student Fee Detail");
        }

        private void btnClassFee_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucClassFee", "Class Fee");
        }

        private void btnFamilyFee_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow("ucParentFee", "Family Fee Detail");
        }
    }
}