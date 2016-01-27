using ES.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ES.Configurations;
using System.Windows.Controls;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucGradListView.xaml
    /// </summary>
    public partial class ucSectionListView : BaseUserControl
    {
        public ucSectionListView()
        {
            this.DataContext = this;
            InitializeComponent();
            RefreshList();
        }

         private IEnumerable<Sections> _sectionsList = null;

         private IEnumerable<Sections> DeletedGradeList { get; set; }
        public IEnumerable<Sections> SectionsList
        {
            get { return _sectionsList; }
            set
            {
                if (_sectionsList != value)
                {
                    _sectionsList = value;
                    NotifyPropertyChanged("SectionsList");
                }
            }
        }
        private void btnSaveSection_Click(object sender, RoutedEventArgs e)
        {
            if (DeletedGradeList != null)
            {
                foreach (var item in DeletedGradeList)
                {
                    GradeRepo.Remove(item.SectionID);
                }
            }
            if (SectionsList != null)
            {
                foreach (var item in SectionsList)
                {
                    if (item.isNew)
                    {
                        SectionRepo.Insert(item);
                    }
                    else
                    {
                        SectionRepo.Update(item);
                    }
                }
            }
            RefreshList();
        }

        private void btnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            SectionsList = SectionsList.Add(new Sections() { isNew = true, TempID = GetRandomID() });
        }
        private void RefreshList()
        {
            SectionsList = SectionRepo.GetAll();
        }

        //private void gvGradeSettingListView_Deleting(object sender, Telerik.Windows.Controls.GridViewDeletingEventArgs e)
        //{
        //    if (e.Items != null && e.Items.Count() > 0)
        //    {
        //        foreach (Grade entity in e.Items)
        //        {
        //            IEnumerable<Sections> list = null;
        //            if (entity.TempID != null)
        //            {
        //                foreach (var item in SectionsList)
        //                {
        //                    if (item.TempID != entity.TempID)
        //                    {
        //                        list = list.Add(item);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                foreach (var item in SectionsList)
        //                {
        //                    if (entity.GradeID != item.SectionID)
        //                    {
        //                        list = list.Add(item);
        //                    }
        //                    if (entity.GradeID == item.SectionID)
        //                    {
        //                        DeletedGradeList = DeletedGradeList.Add(item);
        //                    }
        //                }
        //            }
        //            SectionsList = list;
        //        }
        //    }
        
        //}

        private void btnCMDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gvSectionListView_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                Sections section = e.Row.DataContext as Sections;

                foreach (var item in SectionsList)
                {
                    if (item.SectionID <= 0)
                        item.isNew = true;
                }
            }
        }
    }


}
