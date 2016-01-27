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
using ES.Configurations;
using ES.Entities;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucStudentFee.xaml
    /// </summary>
    public partial class ucParentFee : BaseUserControl
    {
        private bool isManualEditCommit;
        
        public ucParentFee()
        {
            InitializeComponent();
        }

        #region Helper Properties
        string m_selectedFeeType;
        int m_selectedMonth;
        public string SelectedFeeType
        {
            get
            {
                return m_selectedFeeType;
            }
            set
            {
                m_selectedFeeType = value;
                NotifyPropertyChanged("SelectedFeeType");
            }
        }
        public List<CustomDropDownValues> ParentDropDown
        {
            get
            {
                List<CustomDropDownValues> list = new List<CustomDropDownValues>();

                var parentList = ParentRepo.GetAll();
                foreach (Parent item in parentList)
                {
                    list.Add(new CustomDropDownValues { DisplayID = item.ParentID.ToString(), DisplayName = item.FullName });
                }
                return list;
            }
            set
            {
                NotifyPropertyChanged("FeeTypeDropDown");
            }
        }
        
        private IEnumerable<FeeDetail> m_childrenFeeDetailList;
        public IEnumerable<FeeDetail> ChildrenFeeDetailList
        {
            get
            {
                return m_childrenFeeDetailList;
            }
            set
            {
                m_childrenFeeDetailList = value;
                NotifyPropertyChanged("ChildrenFeeDetailList");
            }


        }
        #endregion


        #region
        private void RefreshList()
        {
            ChildrenFeeDetailList = null;
        }

        internal void SetParentDetail(Parent parent)
        {
            if (parent != null)
            {
                RefreshList();

                var detailsFee = FeeDetailRepo.GetChildrenFeeDetail(parent.ParentID, SessionID);

                var stdList = StudentRepo.GetChildren(parent.ParentID);

                foreach (var item in stdList)
                {
                    var singleStd = detailsFee.LastOrDefault(p => p.StudentID == item.StudentID && p.SectionID == item.SectionID && p.ClassID == item.ClassID);

                    if (singleStd.DecidedFee <= 0)
                    {
                        singleStd.DecidedFee = item.MonthlyFee;
                    }
                    if (singleStd.RemainingFee == 0 && singleStd.DecidedFee > singleStd.PaidFee)
                        singleStd.RemainingFee = singleStd.DecidedFee;

                    
                    ChildrenFeeDetailList = ChildrenFeeDetailList.Add(singleStd);
                }
            }
        }

        #endregion

        #region  Events

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }
        
        private void grid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }

            if (e.EditAction == DataGridEditAction.Commit)
            {
                FeeDetail feeDetail = e.Row.DataContext as FeeDetail;

                var remaingFee = feeDetail.DecidedFee - (feeDetail.PaidFee + feeDetail.RemainingFee);
                if (remaingFee < 0)
                {
                    Message(MessageTypes.Error, "Please Enter Correct Paid");
                    return;
                }

                foreach (var item in ChildrenFeeDetailList)
                {
                    if (item.StudentID == feeDetail.StudentID)
                    {
                        item.RemainingFee = remaingFee;
                        item.isUpdated = true;
                    }
                }
            }
        }

        private void btnSaveFeeDetail_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ChildrenFeeDetailList)
            {
                if (item.ID == 0)
                {
                    FeeDetailRepo.Insert(item);
                }
                else if (item.isUpdated)
                {
                    FeeDetailRepo.Update(item);
                }
            }
        }

        private void btnSearchParent_Click(object sender, RoutedEventArgs e)
        {
            var view = new ucParentSearchListView();
            view.ParentContainer = this;
            OpenPopUp(view, "Search Parent", 650, 500);
        }

        #endregion
    }
}
