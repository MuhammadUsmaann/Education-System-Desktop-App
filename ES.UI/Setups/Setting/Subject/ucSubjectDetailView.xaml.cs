using ES.BusinessLayer;
using ES.Configurations;
using ES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucSubjectDetailView.xaml
    /// </summary>
    public partial class ucSubjectDetailView : BaseUserControl
    {
        private Subject _subject;
        private int _subjectID;
        private SubjectRepository _subjectRepository;
        public ucSubjectDetailView(string mode, int id = 0)
        {
            InitializeComponent();
            FormMode = mode;
            _subjectID = id;
            _subjectRepository = new SubjectRepository();

            ViewModeGenericWork();
        }
        public Subject SubjectDetail
        {
            get
            {
                if(_subject==null)
                {
                    _subject = new Subject();
                }
                return _subject;
            }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    NotifyPropertyChanged("SubjectDetail");
                }
            }
        }
        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            SubjectDetail.created_by = SubjectDetail.updated_by = Utilities.UserSession.UserID;
            var parent = (ucSubjectListView)this.ParentContainer;

            if (FormMode == FormModes.New)
            {
                _subjectID = _subjectRepository.Insert(SubjectDetail);

                SubjectDetail.SubjectID = _subjectID;
                parent.AddToList(SubjectDetail);
            }
            else
            {
                _subjectRepository.Update(SubjectDetail);
                parent.RefreshList();
            }
            this.ActualParent.Close();
        }
        private void SubjectDetailUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(FormMode != FormModes.New)
            {
                 SubjectDetail = _subjectRepository.FindByID(_subjectID);
            }
        }
    }
}
