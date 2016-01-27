
using ES.BusinessLayer;
using ES.Entities;
using System.Collections.Generic;
using ES.Configurations;
namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucClassListView.xaml
    /// </summary>
    public partial class ucClassListView : BaseUserControl
    {
        private IEnumerable<Class> _classes;
        private ClassRepository _classRepository;
        public ucClassListView()
        {
            InitializeComponent();
            _classRepository = new ClassRepository();
        }
        public IEnumerable<Class> ClassList
        {
            get
            {
                return _classes;
            }
            set
            {
                if (_classes != value)
                {
                    _classes = value;
                    NotifyPropertyChanged("ClassList");
                }
            }
        }


        public void AddToClassList(Class cls)
        {
            ClassList = ClassList.Add(cls);
        }
        public void Refreshlist()
        {
            ClassList = _classRepository.GetAll();
        }

        private Class GetSelectClass()
        {
            return (Class)gvClassListView.SelectedItem;
        }

        private void ShowClassDetailWindow(string mode, string title, int id = 0)
        {
            var view = new ucClassDetailView(mode, id);
            view.ParentContainer = this;
            OpenPopUp(view, title, 700, 500);
        }
        private void DeleteRecord()
        {
            var win = GetSelectClass();
            if (win == null)
            {
                Message(MessageTypes.Error, "Please Select Class To Delete..");
                return;
            }
            _classRepository.Remove(win.ClassID);
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Refreshlist();
        }

        private void btnAddClass_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ShowClassDetailWindow(FormModes.New,"Add Class Detail");
        }
        private void btnCMEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var win = GetSelectClass();

            if(win == null)
            {
                Message(MessageTypes.Error, "Please Select Class To edit..");
                return;
            }

            ShowClassDetailWindow(FormModes.Edit, "Edit Class Detail",win.ClassID);
        }



        private void btnCMView_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var win = GetSelectClass();
            if (win == null)
            {
                Message(MessageTypes.Error, "Please Select Class To View..");
                return;
            }
            ShowClassDetailWindow(FormModes.View, "Class Detail", win.ClassID);
        }
        private void btnCMDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteRecord();
        }
        private void btnDeleteClass_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteRecord();
        }

        private void btnRefreshClass_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Utilities.ClearUserControl();
        }
    }
}
