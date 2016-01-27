using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System.Collections.Generic;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucClassDetailView.xaml
    /// </summary>
    public partial class ucClassDetailView : BaseUserControl
    {
        private int _classid= 0 ;
        private Class _class;
        private IEnumerable<Subject> _selectedSubjects;
        private IEnumerable<Subject> _unselectedSubjects;
        public ucClassDetailView(string mode, int classid = 0)
        {
            this.DataContext = this;
            InitializeComponent();
            FormMode = mode;
            _classid = classid;
            ViewModeGenericWork();
        }
        public Class ClassDetail
        {
            get
            {
                if(_class == null)
                {
                    _class = new Class();
                }
                return _class;
            }
            set
            {
                if(_class != value)
                {
                    _class = value;
                    NotifyPropertyChanged("ClassDetail");
                }
            }
        }
        public IEnumerable<Subject> SelectedSubjectList
        {
            get {
                return _selectedSubjects;
            }
            set
            {
                if(_selectedSubjects != value)
                {
                    _selectedSubjects = value;
                    NotifyPropertyChanged("SelectedSubjectList");
                }
            }
        }
        public IEnumerable<Subject> UnSelectedSubjectList
        {
            get
            {
                return _unselectedSubjects;
            }
            set
            {
                if (_unselectedSubjects != value)
                {
                    _unselectedSubjects = value;
                    NotifyPropertyChanged("UnSelectedSubjectList");
                }
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (FormMode == FormModes.Edit || FormMode == FormModes.View)
            {
                ClassDetail = ClassRepo.FindByID(_classid);
                SelectedSubjectList = ClassSubjectRepo.GetSelectedSubjects(_classid);
                UnSelectedSubjectList = ClassSubjectRepo.GetUnSelectedSubjects(_classid);
            }
            if(FormMode == FormModes.New)
            {
                UnSelectedSubjectList = SubjectRepo.GetAll();
            }
        }
        private void btnClassSave_Click(object sender, RoutedEventArgs e)
        {
            if(FormMode == FormModes.View)
            {
                this.ActualParent.Close();
                return;
            }

            var parent = (ucClassListView)this.ParentContainer;
            ClassDetail.created_by = ClassDetail.updated_by = Utilities.UserSession.UserID; 

            if (FormMode == FormModes.New)
            {
                _classid = ClassRepo.Insert(ClassDetail);
                parent.AddToClassList(ClassDetail);
            }
            else
            {
                ClassRepo.Update(ClassDetail);
                parent.Refreshlist();
            }
            ClassSubjectRepo.SaveSubjects(SelectedSubjectList, _classid, Utilities.UserSession.UserID);
            this.ActualParent.Close();
        }
        private void btnAddSelectedSignleSubject_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = gvClassSubjectListed.SelectedItems;

            if (selectedItems == null) return;

            for (int i = 0; i < selectedItems.Count; i++)
            {
                Subject item = (Subject)selectedItems[i];
                SelectedSubjectList = SelectedSubjectList.Add(item);
                UnSelectedSubjectList = UnSelectedSubjectList.Remove(item);   
            }
        }
        private void btnRemoveSelectedSingleSubject_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = gvClassSubjectSelected.SelectedItems;

            if (selectedItems == null) return;

            for (int i = 0; i < selectedItems.Count; i++)
            {
                Subject item = (Subject)selectedItems[i];
                UnSelectedSubjectList = UnSelectedSubjectList.Add(item);
                SelectedSubjectList = SelectedSubjectList.Remove(item);
            }
        }
        private void btnAddAllSubject_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in UnSelectedSubjectList)
            {
                SelectedSubjectList = SelectedSubjectList.Add(item);
                UnSelectedSubjectList = UnSelectedSubjectList.Remove(item);
            }
        }
        private void btnRemoveAllSubject_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in SelectedSubjectList)
            {
                UnSelectedSubjectList = UnSelectedSubjectList.Add(item);
                SelectedSubjectList = SelectedSubjectList.Remove(item);
            }
        }
    }
}
