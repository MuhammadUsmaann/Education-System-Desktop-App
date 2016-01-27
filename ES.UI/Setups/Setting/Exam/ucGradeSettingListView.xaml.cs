using ES.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ES.Configurations;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucGradeSettingListView.xaml
    /// </summary>
    public partial class ucGradeSettingListView : BaseUserControl
    {
        private IEnumerable<Grade> _gradeList = null;
        public ucGradeSettingListView()
        {
            this.DataContext = this;
            InitializeComponent();
            RefreshList();
        }
        private IEnumerable<Grade> DeletedGradeList { get; set; }
        public IEnumerable<Grade> GradeList
        {
            get { return _gradeList; }
            set
            {
                if (_gradeList != value)
                {
                    _gradeList = value;
                    NotifyPropertyChanged("GradeList");
                }
            }
        }
        private void btnSaveGrade_Click(object sender, RoutedEventArgs e)
        {
            if (DeletedGradeList != null)
            {
                foreach (var item in DeletedGradeList)
                {
                    GradeRepo.Remove(item.GradeID);
                }
            }
            if (GradeList != null)
            {
                foreach (var item in GradeList)
                {
                    item.updated_by = item.created_by = UserID;

                    if (item.isNew)
                    {
                        GradeRepo.Insert(item);
                    }
                    else
                    {
                        GradeRepo.Update(item);
                    }
                }
            }
            RefreshList();
        }

        private void btnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            GradeList = GradeList.Add(new Grade() { isNew = true, TempID = GetRandomID() });
        }
        private void RefreshList()
        {
            GradeList = GradeRepo.GetAll();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Utilities.ClearUserControl();
        }

        //private void gvGradeSettingListView_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        //{
        //    if (e.Items != null && e.Items.Count() > 0)
        //    {
        //        foreach (Grade entity in e.Items)
        //        {
        //            IEnumerable<Grade> list = null;
        //            if (entity.TempID != null)
        //            {
        //                foreach (var item in GradeList)
        //                {
        //                    if (item.TempID != entity.TempID)
        //                    {
        //                        list = list.Add(item);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                foreach (var item in GradeList)
        //                {
        //                    if (entity.GradeID != item.GradeID)
        //                    {
        //                        list = list.Add(item);
        //                    }
        //                    if (entity.GradeID == item.GradeID)
        //                    {
        //                        DeletedGradeList = DeletedGradeList.Add(item);
        //                    }
        //                }
        //            }
        //            GradeList = list;
        //        }
        //    }
        
        //}

        private void btnCMDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
