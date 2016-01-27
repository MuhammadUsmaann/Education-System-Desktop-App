using ES.BusinessLayer;
using ES.Entities;
using System.Collections.Generic;
using System.Windows;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucParentSearchListView.xaml
    /// </summary>
    public partial class ucParentSearchListView : BaseUserControl
    {
        private IEnumerable<Parent> _parents;
        public ucParentSearchListView()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public IEnumerable<Parent> ParentList
        {
            get
            {
                return _parents;
            }
            set
            {
                if (_parents != value)
                {
                    _parents = value;
                    NotifyPropertyChanged("ParentList");
                }
            }
        }
        private void btnSelectParent_Click(object sender, RoutedEventArgs e)
        {
            Parent _p = (Parent)grid.SelectedItem;
            if (this.ParentContainer is ucStudentDetailView)
               (this.ParentContainer as ucStudentDetailView).SetParentDetail(_p);
            else if (this.ParentContainer is ucParentFee)
                (this.ParentContainer as ucParentFee).SetParentDetail(_p);
            
            this.ActualParent.Close();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ParentList = ParentRepo.GetAll();
        }
    }
}
