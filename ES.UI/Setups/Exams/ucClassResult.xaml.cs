using ES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ES.UI.Setups
{
    /// <summary>
    /// Interaction logic for ucClassResult.xaml
    /// </summary>
    public partial class ucClassResult : BaseUserControl
    {
        public ucClassResult()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private IEnumerable<Subject> m_subjectList;

        private IEnumerable<Subject> SubjectList
        {
            get { return m_subjectList; }
            set { m_subjectList = value; NotifyPropertyChanged("SubjectList"); }
        }
        public IEnumerable<ClassResult> m_classResultCard;
        public IEnumerable<ClassResult> ClassResultCard
        {
            get { return m_classResultCard; }
            set
            {
                m_classResultCard = value;
                NotifyPropertyChanged("ClassResultCard");
            }
        }
        private void cmbExamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassResultCard = null;
        }
        private void btnViewClassresult_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClassID > 0 && SelectedSectionID > 0 && SelectedExamID >0 )
            {
                ClassResultCard = null;

                SubjectList = ClassSubjectRepo.GetSelectedSubjects(SelectedClassID);
                int count = 2;

                for (int i = count; i < 20; i++)
                {
                    grid.Columns[i].Visibility = System.Windows.Visibility.Collapsed;
                    grid.Columns[i].Header = "";
                }

                foreach (var subject in SubjectList)
                {
                    grid.Columns[count].Visibility = System.Windows.Visibility.Visible;
                    grid.Columns[count].Header = subject.Description;
                    count++;
                }

                IEnumerable<StudentSubjectMarks> results = StudentSubjectMarksRepo.GetClassResult(SelectedExamID, SessionID, SelectedSectionID, SelectedClassID);

                

                IEnumerable<Student> studentsList = StudentRepo.GetAll().Where(p => p.ClassID == SelectedClassID && p.SectionID == SelectedSectionID);


                foreach (var student in studentsList)
                {
                    IEnumerable<StudentSubjectMarks> subjectResult = results.Where(p => p.StudentID == student.StudentID);
                    ClassResult classResult = new ClassResult();

                    classResult.StudentName = student.FullName;
                    classResult.RoleNumber = student.StudentID.ToString();

                    count = 1;
                    foreach (var item in SubjectList)
                    {
                        StudentSubjectMarks rs = subjectResult.Where(p => p.SubjectID == item.SubjectID).FirstOrDefault();

                        PropertyInfo propertyInfo = classResult.GetType().GetProperty("Subject" + count);
                        if (rs != null)
                        {
                            propertyInfo.SetValue(classResult, Convert.ChangeType(rs.ObtainedMarks, propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(classResult, Convert.ChangeType(0, propertyInfo.PropertyType), null);
                        }
                        count++;
                    }

                    ClassResultCard = ClassResultCard.Add(classResult);
                }
            }
        }
    }
}