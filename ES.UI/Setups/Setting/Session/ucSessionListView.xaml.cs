using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucSessionListView.xaml
    /// </summary>
    public partial class ucSessionListView : BaseUserControl
    {
        IEnumerable<Session> _sessions;
        bool isManualEditCommit = false;
        public ucSessionListView()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        
        public IEnumerable<Session> AllSessions
        {
            get { return _sessions; }
            set
            {
                _sessions = value;
                NotifyPropertyChanged("AllSessions");
            }
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            AllSessions = SessionRepo.GetAll();
           // ResetDataPager(gvSessionListView, radDataPager);
        }

        public void AddToList(Session ss)
        {
            AllSessions = AllSessions.Add(ss);

        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ClearUserControl();
        }

        private void btnAddSession_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowSession(FormModes.New, "New Session");
        }


        private Session getSelectedValue()
        {
            return (Session)gvSessionListView.SelectedItem;
        }

        private void OpenWindowSession(string mode, string title)
        {
            var win = getSelectedValue();

            if (win == null && mode != FormModes.New)
            {
                Message(MessageTypes.Error, "Please Select to " + mode + " Staff Detail");
                return;
            }

            if (mode == FormModes.New)
            {
                win = new Session();
            }
            var view = new ucSessionView(mode, win.SessionID);
            view.ParentContainer = this;
            OpenPopUp(view, title, 500, 300);
        }
        private void btnDeleteSession_Click(object sender, RoutedEventArgs e)
        {
            DeleteSessionRecord();
        }

        private void btnCMEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowSession(FormModes.Edit, "Edit Session");
        }

        private void btnCMView_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowSession(FormModes.View, "Session Detail");
        }

        private void btnCMDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSessionRecord();
        }
        private void DeleteSessionRecord()
        {
            var win = getSelectedValue();
            if (win == null || win.SessionID == 0)
            {
                Message(MessageTypes.Error, "Please Select to delete Session Detail");
                return;
            }
            if (!DeleteMessage())
            {
                return;
            }

            SessionRepo.Remove(win.SessionID);
            RefreshList();
        }

        private bool isSessionActive()
        {
            bool isExited = false;
            foreach (var item in AllSessions)
            {
                if (item.isActive == true)
                {
                    isExited = true;
                }
            }

            if (!isExited)
            {
                Message(MessageTypes.Error, "Atleast one Session Must be active");
            }

            return isExited;
        }
        private void btnRefreshSession_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void gvSessionListView_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }

            isSessionActive();
        }


    }
}
