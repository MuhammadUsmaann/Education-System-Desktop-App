using ES.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ES.Configurations;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucExamsSettingListView.xaml
    /// </summary>
    public partial class ucExamsSettingListView : BaseUserControl
    {
        private IEnumerable<Exam> _examList;
        public Exam _exam;
        public ucExamsSettingListView()
        {
            InitializeComponent();
        }
        private IEnumerable<Exam> DeletedExamList { get; set; }
        public IEnumerable<Exam> ExamList
        {
            get { return _examList; }
            set
            {
                if (_examList != value)
                {
                    _examList = value;
                    NotifyPropertyChanged("ExamList");
                }
            }
        }
        private void btnSaveExams_Click(object sender, RoutedEventArgs e)
        {

            if (DeletedExamList != null)
            {
                foreach (var item in DeletedExamList)
                {
                    ExamRepo.Remove(item.ExamID);
                }
            }
            if(ExamList != null)
            {
                foreach (var item in ExamList)
                {
                    item.updated_by = item.created_by = UserID;

                    if (item.ExamID == 0)
                    {
                        ExamRepo.Insert(item);
                    }
                    else
                    {
                        ExamRepo.Update(item);
                    }
                }
            }
            RefreshList();
        }

        private void RefreshList()
        {
            ExamList = ExamRepo.GetAll();
        }

        //private void btnAddExamsList_Click(object sender, RoutedEventArgs e)
        //{
        //    ExamList = ExamList.Add(new Exam() { isNew = true, TempID = GetRandomID() });
        //}

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ClearUserControl();
        }
        //private void gvExamsSettingListView_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        //{
        //    if (e.Items != null && e.Items.Count() > 0)
        //    {
        //        foreach (Exam entity in e.Items)
        //        {
        //            IEnumerable<Exam> list = null;
        //            if (entity.TempID != null)
        //            {
        //                foreach (var item in ExamList)
        //                {
        //                    if (item.TempID != entity.TempID)
        //                    {
        //                        list = list.Add(item);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                foreach (var item in ExamList)
        //                {
        //                    if (entity.ExamID != item.ExamID)
        //                    {
        //                        list = list.Add(item);
        //                    }
        //                    if(entity.ExamID == item.ExamID)
        //                    {
        //                        DeletedExamList = DeletedExamList.Add(item);
        //                    }
        //                }
        //            }
        //            ExamList = list;
        //        }
        //    }
        //}

        private void btnCMEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCMDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }
    }
}
