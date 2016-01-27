using ES.Entities;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Data;
using System.Windows;
using ES.Configurations;
using System.Reflection;
using System;

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucStudentResult.xaml 
    /// </summary>
    /// 
    public partial class ucStudentResult : BaseUserControl
    {
        public ucStudentResult()
        {
            this.DataContext = this;
            InitializeComponent();

            ExamList = ExamRepo.GetManadatoryExams();
            int count = 1;
            foreach (var exam in ExamList)
            {
                grid.Columns[count].Visibility = System.Windows.Visibility.Visible;
                grid.Columns[count].Header = exam.Description;
                count++;
            }
        }
        private IEnumerable<Exam> ExamList { get; set; }
        
        private IEnumerable<StudentResultCard> m_resultCardList;
        public IEnumerable<StudentResultCard> ResultCardList
        {
            get { return m_resultCardList; }
            set
            {
                m_resultCardList = value;
                NotifyPropertyChanged("ResultCardList");
            }
        }

        #region Helper Methods

        private void SetStudent()
        {
            if (SelectedClassID > 0 && SelectedSectionID > 0)
            {
                SetStudentList(SelectedClassID, SelectedSectionID);
            } 
        }

        #endregion

        #region Events


        private void cmbSectionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetStudent();
        }

        private void cmbStudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbClassList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetStudent();
        }
        private void btnViewClassMarks_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClassID > 0 && SelectedSectionID > 0 && SelectedStudenID > 0 )
            {
                IEnumerable<StudentSubjectMarks> results = StudentSubjectMarksRepo.GetSingleStudentResult(SelectedStudenID, SessionID, SelectedSectionID, SelectedClassID);
                
                IEnumerable<Subject> subjectList = ClassSubjectRepo.GetSelectedSubjects(SelectedClassID);

                
                foreach (var subject in subjectList)
                {
                    IEnumerable<StudentSubjectMarks> subjectResult = results.Where(p => p.SubjectID == subject.SubjectID);

                    StudentResultCard resultCard = new StudentResultCard();

                    int count = 1;
                    foreach (var item in ExamList )
                    {
                        StudentSubjectMarks rs = subjectResult.Where(p => p.ExamID == item.ExamID).FirstOrDefault();
                        resultCard.SubjectName = rs.SubjectName;

                        PropertyInfo propertyInfo = resultCard.GetType().GetProperty("Exam" + count);
                        if (rs != null)
                        {
                            propertyInfo.SetValue(resultCard, Convert.ChangeType(rs.ObtainedMarks, propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(resultCard, Convert.ChangeType(0, propertyInfo.PropertyType), null);
                        }
                        count++;
                    }

                    ResultCardList = ResultCardList.Add(resultCard);
                }
            }
        }
        #endregion

        
    }
}
