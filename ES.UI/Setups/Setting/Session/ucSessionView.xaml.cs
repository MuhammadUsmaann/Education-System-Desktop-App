using ES.Configurations;
using ES.Entities;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucSessionView.xaml
    /// </summary>
    public partial class ucSessionView : BaseUserControl
    {
        
        private Session _session;
        private int _sessionID;
        public ucSessionView(string mode,int id = 0)
        {
            this.DataContext = this;
            InitializeComponent();
            FormMode = mode;
            _sessionID = id;
            ViewModeGenericWork();
        }

        public Session SessionEntity
        {
            get
            {
                if(_session == null)
                {
                    _session = new Session();
                }
                return _session;
            }
            set
            {
                if (_session != value)
                {
                    _session = value;
                    NotifyPropertyChanged("SessionEntity");
                }
            }
        }

        private void popBtnAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FormMode == FormModes.View)
            {
                this.ActualParent.Close();
                return;
            }

            SessionEntity.created_by = SessionEntity.updated_by = Utilities.UserSession.UserID;

            if (FormMode == FormModes.New)
            {
                SessionEntity.created_by = Utilities.UserSession.UserID;
                SessionRepo.Insert(SessionEntity);
            }
            else if(FormMode == FormModes.Edit)
            {
                SessionRepo.Update(SessionEntity);
            }

            var parent = (ucSessionListView)this.ParentContainer;
            parent.RefreshList();

            this.ActualParent.Close();
        }

        private void SessionViewDetail_Loaded(object sender, RoutedEventArgs e)
        {
            if(FormMode != FormModes.New)
            {
                SessionEntity = SessionRepo.FindByID(_sessionID);
            }
        }
    }
}
