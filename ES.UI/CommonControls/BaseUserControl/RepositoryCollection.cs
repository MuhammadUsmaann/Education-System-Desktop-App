using ES.BusinessLayer;

namespace ES.UI
{
    public partial class BaseUserControl
    {
        #region Repository Properties

        private StudentRepository _studentRepository;
        private ParentRepository _parentRepository;
        private ClassRepository _classRepository;
        private ClassStudentRepository _classStudentRepository;
        private ExperienceRepository _experienceRepository;
        private EducationRepository _educationRepository;
        private UsersDetailRepository _userDetailRepository;
        private UsersRepository _userRepository;
        private AttendanceRepository _attendanceRepository;
        private SubjectRepository _subjectrepository;
        private ExamRepository _examRepository;
        private GradeRepository _gradeRepository;
        private ClassSubjectRepository _classSubjectRepository;
        private StudentSubjectMarksRepository _studentSubjectMarksRepository;
        private SessionRepository _sessionRepository;
        private SectionsRepository _sectionsRepository;
        private FeeDetailRepository _feeDetailRepository;

        #endregion

        #region Repository Public Properties
        public FeeDetailRepository FeeDetailRepo
        {
            get
            {
                if (_feeDetailRepository == null)
                {
                    _feeDetailRepository = new FeeDetailRepository();
                }
                return _feeDetailRepository;
            }
        }
        public SectionsRepository SectionRepo
        {
            get
            {
                if (_sectionsRepository == null)
                {
                    _sectionsRepository = new SectionsRepository();
                }
                return _sectionsRepository;
            }
        }
        public SessionRepository SessionRepo
        {
            get
            {
                if (_sessionRepository == null)
                {
                    _sessionRepository = new SessionRepository();
                }
                return _sessionRepository;
            }
        }
        public StudentSubjectMarksRepository StudentSubjectMarksRepo
        {
            get
            {
                if (_studentSubjectMarksRepository == null)
                {
                    _studentSubjectMarksRepository = new StudentSubjectMarksRepository();
                }
                return _studentSubjectMarksRepository;
            }
        }
        
        public ClassSubjectRepository ClassSubjectRepo
        {
            get
            {
                if (_classSubjectRepository == null)
                {
                    _classSubjectRepository = new ClassSubjectRepository();
                }
                return _classSubjectRepository;
            }
        }
        public ExamRepository ExamRepo
        {
            get
            {
                if (_examRepository == null)
                {
                    _examRepository = new ExamRepository();
                }
                return _examRepository;
            }
        }
        public GradeRepository GradeRepo
        {
            get
            {
                if (_gradeRepository == null)
                {
                    _gradeRepository = new GradeRepository();
                }
                return _gradeRepository;
            }
        }
        public SubjectRepository SubjectRepo
        {
            get
            {
                if(_subjectrepository == null)
                {
                    _subjectrepository = new SubjectRepository();
                }
                return _subjectrepository;
            }
        }
        public AttendanceRepository AttendanceRepo
        {
            get
            {
                if (_attendanceRepository == null)
                {
                    _attendanceRepository = new AttendanceRepository();
                }
                return _attendanceRepository;
            }
        }
        public UsersDetailRepository UserDetailRepo
        {
            get
            {
                if (_userDetailRepository == null)
                {
                    _userDetailRepository = new UsersDetailRepository();
                }
                return _userDetailRepository;
            }
        }
        public UsersRepository UserRepo
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UsersRepository();
                }
                return _userRepository;
            }
        }
        public EducationRepository EducationRepo
        {
            get
            {
                if (_educationRepository == null)
                {
                    _educationRepository = new EducationRepository();
                }
                return _educationRepository;
            }
        }
        public ExperienceRepository ExperienceRepo
        {
            get
            {
                if (_experienceRepository == null)
                {
                    _experienceRepository = new ExperienceRepository();
                }
                return _experienceRepository;
            }
        }
        public ClassStudentRepository ClassStudentRepo
        {
            get
            {
                if(_classStudentRepository ==  null)
                {
                    _classStudentRepository = new ClassStudentRepository();
                }
                return _classStudentRepository;
            }
        }
        public ClassRepository ClassRepo
        {
            get
            {
                if (_classRepository == null)
                    _classRepository = new ClassRepository();
                return _classRepository;
            }
        }
        public ParentRepository ParentRepo{
            get {
                if (_parentRepository == null)
                    _parentRepository = new ParentRepository();
                return _parentRepository;
            }
        }
        public StudentRepository StudentRepo
        {
            get{
                if(_studentRepository == null)
                {
                    _studentRepository = new StudentRepository();
                }
                return _studentRepository;
            }
        }

        #endregion
    }
}
