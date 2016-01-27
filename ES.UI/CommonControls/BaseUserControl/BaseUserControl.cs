using ES.Configurations;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ES.UI.CommonControls;
using System.Collections.Generic;
using ES.Entities;
using System;
using ES.Controls;

namespace ES.UI
{
    public partial class BaseUserControl : UserControl, INotifyPropertyChanged
    {
        private bool _isEnabled = true;
        
        private string _formMode;
        private string _saveButtonContent;
        private string _selectedDate;
        private string m_title = null;

        #region Dropdown Section

        private List<CustomDropDownValues> _classList = null;
        private List<CustomDropDownValues> _studentList = null;
        private List<CustomDropDownValues> _examList = null;
        private List<CustomDropDownValues> _subjectList = null;
        private List<CustomDropDownValues> _sectionDropDown = null;
 
        public List<CustomDropDownValues> ClassDropDown
        {
            get
            {
                if (_classList == null)
                {
                    List<CustomDropDownValues> _list = new List<CustomDropDownValues>();

                    var classList = ClassRepo.GetAll();

                    foreach (var item in classList)
                    {
                        CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.Description, DisplayID = item.ClassID.ToString() };
                        _list.Add(_temp);
                    }
                    _classList = _list;
                }

                return _classList;
            }
            set
            {
                _classList = value; NotifyPropertyChanged("ClassDropDown");
            }
        }
        public List<CustomDropDownValues> StudentDropDown
        {
            get
            {
                return _studentList;
            }
            set
            {
                _studentList = value;
                NotifyPropertyChanged("StudentDropDown");
            }
        }
        public List<CustomDropDownValues> SubjectDropDown
        {
            get
            {
                return _subjectList;
            }
            set
            {
                _subjectList = value;
                NotifyPropertyChanged("SubjectDropDown");
            }
        }
        public List<CustomDropDownValues> ExamDropDown
        {
            get
            {

                if (_examList == null)
                {
                    List<CustomDropDownValues> _list = new List<CustomDropDownValues>();

                    var examList = ExamRepo.GetManadatoryExams();

                    foreach (var item in examList)
                    {
                        CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.Description, DisplayID = item.ExamID.ToString() };
                        _list.Add(_temp);
                    }
                    _examList = _list;
                }

                return _examList;
            }
            set
            {
                _examList = value;
                NotifyPropertyChanged("ExamDropDown");
            }
        }
        public List<CustomDropDownValues> SectionDropDown
        {
            get
            {

                if (_sectionDropDown == null)
                {
                    List<CustomDropDownValues> _list = new List<CustomDropDownValues>();

                    var list = SectionRepo.GetAll();

                    foreach (var item in list)
                    {
                        CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.Description, DisplayID = item.SectionID.ToString() };
                        _list.Add(_temp);
                    }
                    _sectionDropDown = _list;
                }
                return _sectionDropDown;
            }
            set
            {
                _sectionDropDown = value;
                NotifyPropertyChanged("SectionDropDown");
            }
        }

        public List<CustomDropDownValues> GenderDropDown
        {
            get
            {

                List<CustomDropDownValues> _list = new List<CustomDropDownValues>();

                foreach (Enum item in Enum.GetValues(typeof(Genders)))
                {
                    CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.GetDescription(), DisplayID = item.GetCode() };
                    _list.Add(_temp);
                }
                return _list;
            }
            set
            {
                NotifyPropertyChanged("GenderDropDown");
            }
        }
        public List<CustomDropDownValues> RoleTypeDropDown
        {
            get
            {

                List<CustomDropDownValues> _list = new List<CustomDropDownValues>();

                foreach (Enum item in Enum.GetValues(typeof(RoleTypes)))
                {
                    CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.GetDescription(), DisplayID = item.GetCode() };
                    _list.Add(_temp);
                }
                return _list;
            }
            set
            {
                NotifyPropertyChanged("RoleTypeDropDown");
            }
        }

        public List<CustomDropDownValues> SubjectTypesList
        {
            get
            {

                List<CustomDropDownValues> _list = new List<CustomDropDownValues>();

                foreach (Enum item in Enum.GetValues(typeof(SubjectTypes)))
                {
                    CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.GetDescription(), DisplayID = item.GetCode() };
                    _list.Add(_temp);
                }
                return _list;
            }
            set
            {
                NotifyPropertyChanged("SubjectTypesList");
            }
        }

        public List<CustomDropDownValues> SubjectCompulsoryTypesList
        {
            get
            {

                List<CustomDropDownValues> _list = new List<CustomDropDownValues>();

                foreach (Enum item in Enum.GetValues(typeof(CompulsoryTypes)))
                {
                    CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.GetDescription(), DisplayID = item.GetCode() };
                    _list.Add(_temp);
                }
                return _list;
            }
            set
            {
                NotifyPropertyChanged("SubjectCompulsoryTypesList");
            }
        }
        
        #endregion

        #region Generic Necessory Dropdown Properties


        public string SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                value = DateScripts.GetJustDate(value);
                _selectedDate = value;
                NotifyPropertyChanged("SelectedDate");
            }
        }
        public void SetStudentList(int classid, int sectionid)
        {
            var stds = StudentRepo.FindByQuery(" ClassID = " + classid + " AND SectionID = " + sectionid);

            if (stds != null)
            {
                List<CustomDropDownValues> _list = new List<CustomDropDownValues>();
                foreach (var item in stds)
                {
                    CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.FullName, DisplayID = item.StudentID.ToString() };
                    _list.Add(_temp);
                }
                StudentDropDown = _list;
                SelectedStudenID = SelectedStudenID;
            }
            else { StudentDropDown = null; }

        }
        public void SetSubjectList(int classID)
        {
            var subjects = ClassSubjectRepo.GetSelectedSubjects(classID);

            if (subjects != null)
            {
                List<CustomDropDownValues> _list = new List<CustomDropDownValues>();
                foreach (var item in subjects)
                {
                    CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.Description, DisplayID = item.SubjectID.ToString() };
                    _list.Add(_temp);
                }
                SubjectDropDown = _list;
            }
            else { SubjectDropDown = null; }
        }
        public void SetStudentList()
        {
            var stds = StudentRepo.FindByQuery(" ClassID = " + SelectedClassID);

            if (stds != null)
            {
                List<CustomDropDownValues> _list = new List<CustomDropDownValues>();
                foreach (var item in stds)
                {
                    CustomDropDownValues _temp = new CustomDropDownValues { DisplayName = item.FullName, DisplayID = item.StudentID.ToString() };
                    _list.Add(_temp);
                }
                StudentDropDown = _list;
            }
            else { StudentDropDown = null; }

        }

        #endregion

        #region Generic Selected IDs


        private int _selectedClassID;
        private int _selectedStudentID;
        private int _selectedExamID;
        private int _selectedSubjectID;
        private int _selectedSectionID;
        
        public int SessionID
        {
            get { return Utilities.UserSession.SessionID; }
        }
        public int UserID
        {
            get { return Utilities.UserSession.UserID; }
        }
        public string GetRandomID()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 10000000);
            return "temp_" + randomNumber;
        }
        public int SelectedClassID
        {
            get
            {
                return _selectedClassID;
            }
            set
            {
                if (_selectedClassID != value)
                {
                    _selectedClassID = value;
                    NotifyPropertyChanged("SelectedClassID");
                }
            }
        }
        public int SelectedSubjectID
        {
            get
            {
                return _selectedSubjectID;
            }
            set
            {
                if (_selectedSubjectID != value)
                {
                    _selectedSubjectID = value;
                    NotifyPropertyChanged("SelectedSubjectID");
                }
            }
        }
        public int SelectedStudenID
        {
            get
            {
                return _selectedStudentID;
            }
            set
            {
                _selectedStudentID = value;
                NotifyPropertyChanged("SelectedStudenID");
            }
        }
        public int SelectedExamID
        {
            get
            {
                return _selectedExamID;
            }
            set
            {
                _selectedExamID = value;
                NotifyPropertyChanged("SelectedExamID");
            }
        }

        public int SelectedSectionID
        {
            get
            {
                return _selectedSectionID;
            }
            set
            {
                _selectedSectionID = value;
                NotifyPropertyChanged("SelectedSectionID");
            }
        }
        #endregion

        #region Date Section
        public string DateFormatMonthYear
        {
            get { return DateScripts.DATE_MONTH_YEAR_FORMAT; }
            set { NotifyPropertyChanged("DateFrmateMonthYear"); }
        }

        public string DBDateFormat
        {
            get { return DateScripts.DB_DATE_FORMAT; }
            set { NotifyPropertyChanged("DBDateFormat"); }
        }
        public string DateFormat
        {
            get { return DateScripts.DATE_FORMAT; }
            set { NotifyPropertyChanged("DateFormat"); }
        }

        #endregion


        #region Property Changed Event Section

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        
        #endregion

        public void SetOpenWindowTitle(string title)
        {
            OpenWindowTitle = title;
        }
        public String OpenWindowTitle
        {
            get
            {
                if (string.IsNullOrEmpty(m_title)) m_title = "Main Window Title";

                return m_title;
            }
            set
            {
                m_title = value;
                NotifyPropertyChanged("OpenWindowTitle");
            }
        }
        
        public BaseUserControl()
        {
            this.DataContext = this;
            _formMode = FormModes.New;
        }
        public BaseUserControl ParentContainer { get; set; }
        public Window ActualParent { get; set; }
        public string FormMode
        {
            get
            {
                return _formMode;
            }
            set
            {
                if (_formMode != value)
                {
                    _formMode = value;

                    if(value == FormModes.View)
                    { Enabled = false; }

                    NotifyPropertyChanged("isUpdateMode");
                }
            }
        }
        public bool Enabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    NotifyPropertyChanged("IsEnabled");
                }
            }
        }

        public void Message(string type, string msg)
        {
            CustomMessageBox msgBox = new CustomMessageBox(type, msg);
            msgBox.ShowDialog();
        }
        public bool CanDelete { get; set; }
        public bool DeleteMessage()
        {
            DeleteMessageBox dbox = new DeleteMessageBox();
            dbox.ParentContainer = this;
            dbox.ShowDialog();
            var result = CanDelete;
            CanDelete = false;
            return result;
        }
        public string SaveButtonContent
        {
            get
            {
                return _saveButtonContent;
            }
            set
            {
                if (_saveButtonContent != value)
                {
                    _saveButtonContent = value;
                    NotifyPropertyChanged("SaveButtonContent");
                }
            }
        }
        public void ViewModeGenericWork()
        {

            if (FormMode == FormModes.New)
            {
                SaveButtonContent = "Save";
            }
            else if (FormMode == FormModes.Edit)
            {
                SaveButtonContent = "Update";
            }
            else if (FormMode == FormModes.View)
            {
                SaveButtonContent = "Close";
                Enabled = false;
            }
        }
        public void OpenPopUp(BaseUserControl control, string title = "Testing Window", int width = 300, int height = 300)
        {
            TryCatch.BeginTryCatch(new Action(() => {
                PopUpWindow ne = new PopUpWindow(control, title, width, height);
                ne.ShowDialog();
            }));
            
        }
        public void Close()
        {
            Utilities.ClearUserControl();
        }

        //public static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj == null) return null;

        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //    {
        //        var child = VisualTreeHelper.GetChild(depObj, i);

        //        var result = (child as T) ?? GetChildOfType<T>(child);
        //        if (result != null) return result;
        //    }
        //    return null;
        //}
    }
}
