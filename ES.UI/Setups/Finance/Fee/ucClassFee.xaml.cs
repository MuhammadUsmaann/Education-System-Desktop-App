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
    public partial class ucClassFee : BaseUserControl
    {
        private bool isManualEditCommit;
        public ucClassFee()
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
        public int SelectedMonth
        {
            get
            {
                return m_selectedMonth;
            }
            set
            {
                m_selectedMonth = value;
                NotifyPropertyChanged("SelectedMonth");
            }
        }

        public List<CustomDropDownValues> FeeTypeDropDown
        {
            get
            {
                List<CustomDropDownValues> list = new List<CustomDropDownValues>();

                foreach (Enum item in  Enum.GetValues(typeof(FeeType)))
                {
                    list.Add(new CustomDropDownValues { DisplayID = item.GetCode(), DisplayName = item.GetDescription() });
                }
                return list;
            }
            set
            {
                NotifyPropertyChanged("FeeTypeDropDown");
            }
        }
        public List<CustomDropDownValues> MonthsDropDown
        {
            get
            {
                List<CustomDropDownValues> list = new List<CustomDropDownValues>();

                foreach (Enum item in Enum.GetValues(typeof(Months)))
                {
                    list.Add(new CustomDropDownValues { DisplayID = item.GetCode(), DisplayName = item.GetDescription() });
                }
                return list;
            }
            set
            {
                NotifyPropertyChanged("MonthsDropDown");
            }
        }

        private IEnumerable<FeeDetail> m_classFeeDetailList;
        public IEnumerable<FeeDetail> ClassFeeDetailList
        {
            get
            {
                return m_classFeeDetailList;
            }
            set {
                m_classFeeDetailList = value;
                NotifyPropertyChanged("ClassFeeDetailList");
            }

 
        }
        #endregion


        #region
        private void RefreshList()
        {
            ClassFeeDetailList = null;
        }
        #endregion

        #region  Events

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }
        private void btnViewClassMarks_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClassID > 0 && SelectedSectionID > 0 && !string.IsNullOrEmpty(SelectedFeeType))
            {
                RefreshList();

                var detailsFee = FeeDetailRepo.GetClassDetail(SelectedClassID, SelectedSectionID, SessionID);

                var stdList = StudentRepo.GetStudentsList(SelectedClassID,SelectedSectionID);


                foreach (var item in stdList)
                {
                    var singleStd = detailsFee.LastOrDefault(p => p.StudentID == item.StudentID && p.SectionID == item.SectionID && p.ClassID == item.ClassID);

                    if (singleStd.DecidedFee <= 0)
                    {
                        singleStd.DecidedFee = item.MonthlyFee;
                    }

                    if (singleStd.RemainingFee == 0 && singleStd.DecidedFee > singleStd.PaidFee)
                        singleStd.RemainingFee = singleStd.DecidedFee;
            
                    ClassFeeDetailList = ClassFeeDetailList.Add(singleStd);
                }
            }
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
                FeeDetail feeDetail = ((DataGrid)sender).SelectedItem as FeeDetail;

                var remaingFee = feeDetail.DecidedFee - (feeDetail.PaidFee + feeDetail.RemainingFee);
                if (remaingFee < 0)
                {
                    Message(MessageTypes.Error, "Please Enter Correct Paid");
                    return;
                }

                foreach (var item in ClassFeeDetailList)
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
            foreach (var item in ClassFeeDetailList)
            {
                if (item.ID == 0)
                {
                    FeeDetailRepo.Insert(item);
                }
                else if(item.isUpdated){
                    FeeDetailRepo.Update(item);
                }
            }
        }
        #endregion
       

    }
}
