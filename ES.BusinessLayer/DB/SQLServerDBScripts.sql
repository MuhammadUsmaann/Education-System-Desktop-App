CREATE TABLE [dbo].[AccessRights](
	[AccessRightID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ControlID] [nvarchar](50) NOT NULL,
	[UserID] [int] NOT NULL,
	[CanEdit] [bit] NOT NULL,
	[CanView] [bit] NOT NULL,
	[CanDelete] [bit] NOT NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_AccessRights] PRIMARY KEY CLUSTERED 
(
	[AccessRightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 12/27/2015 5:57:10 PM ******/
CREATE TABLE [dbo].[Attendance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[SessionID] [int] NOT NULL,
	[AttendanceDate] [date] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_by] [int] NOT NULL,
	[created_by] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[isPresent] [bit] NOT NULL,
	[SectionID] [int] NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Class]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](205) NULL,
	[ClassNumber] [int] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[BranchID] [int] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassStudent]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassStudent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[creation_date] [date] NOT NULL,
	[updated_date] [date] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_ClassStudent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassSubject]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassSubject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[creation_date] [date] NOT NULL,
	[updated_date] [date] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_ClassSubject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassTeacher]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTeacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
	[creation_date] [date] NOT NULL,
	[updated_date] [date] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_ClassTeacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Education]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[EducationID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[PassYear] [int] NOT NULL,
	[score] [nvarchar](50) NOT NULL,
	[UserID] [int] NOT NULL,
	[Institution] [nvarchar](250) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[EducationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Exam]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[Type] [bit] NOT NULL,
	[comment] [nvarchar](250) NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Experience]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experience](
	[ExperienceID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[StartDate] [nvarchar](50) NULL,
	[EndDate] [nvarchar](50) NULL,
	[Institution] [nvarchar](250) NULL,
	[UserID] [int] NOT NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Experience] PRIMARY KEY CLUSTERED 
(
	[ExperienceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeeDetail]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeeDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FeeType] [varchar](5) NOT NULL,
	[PaidFee] [int] NOT NULL,
	[PaidDate] [date] NOT NULL,
	[RecievedBy] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[SectionID] [int] NOT NULL,
	[SessionID] [int] NOT NULL,
	[PaidForMonth] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[isAdjusted] [bit] NOT NULL,
	[DecidedFee] [int] NULL,
	[RemainingFee] [int] NULL,
 CONSTRAINT [PK_FeeDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[GradeID] [int] IDENTITY(1,1) NOT NULL,
	[GradeName] [nvarchar](5) NOT NULL,
	[Percentage] [decimal](8, 2) NOT NULL,
	[Comment] [nvarchar](250) NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Grade1] PRIMARY KEY CLUSTERED 
(
	[GradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parent]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[ParentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[MiddleName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[ContactNo1] [nvarchar](250) NULL,
	[ContactNo2] [nvarchar](250) NULL,
	[CNIC] [nvarchar](250) NOT NULL,
	[Income] [int] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[updated_by] [int] NOT NULL,
	[created_by] [int] NOT NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[RoleCode] [nvarchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sections]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[SectionID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[SectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Session]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[Description] [nvarchar](250) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nchar](10) NULL,
	[DateOfBirth] [date] NOT NULL,
	[AdmissionDate] [date] NOT NULL,
	[RegistrationNumber] [nvarchar](50) NOT NULL,
	[Gender] [nchar](50) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[AdminssionFee] [int] NOT NULL,
	[ExaminationFee] [int] NOT NULL,
	[MonthlyFee] [int] NOT NULL,
	[OtherCharges] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[isActive] [bit] NULL,
	[SectionID] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentFee]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentFee](
	[StudentFeeID] [int] IDENTITY(1,1) NOT NULL,
	[FeeType] [varchar](5) NOT NULL,
	[DecidedFee] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[SessionID] [int] NOT NULL,
	[created_by] [int] NOT NULL,
	[creation_date] [date] NOT NULL,
	[updated_by] [int] NOT NULL,
	[updated_date] [date] NOT NULL,
 CONSTRAINT [PK_StudentFee] PRIMARY KEY CLUSTERED 
(
	[StudentFeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentSubjectMarks]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubjectMarks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[ExamID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[SectionID] [int] NOT NULL,
	[ObtainedMarks] [decimal](18, 2) NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[SessionID] [int] NULL,
 CONSTRAINT [PK_StudentSubjectMarks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[Type] [nvarchar](250) NULL,
	[Compulsory] [nvarchar](250) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[RoleID] [nvarchar](250) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersDetail]    Script Date: 12/27/2015 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[MiddleName] [nvarchar](250) NULL,
	[dob] [nvarchar](50) NULL,
	[CNIC] [nvarchar](50) NULL,
	[ContactNo1] [nvarchar](50) NULL,
	[ContactNo2] [nvarchar](50) NULL,
	[EmailID] [nvarchar](250) NULL,
	[Salary] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[creation_date] [date] NOT NULL,
	[updated_date] [date] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_by] [int] NOT NULL,
	[Gender] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[isActive] [bit] NULL,
	[Joining_date] [date] NULL,
	[FatherName] [nvarchar](250) NULL,
 CONSTRAINT [PK_usersDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AccessRights] ADD  CONSTRAINT [DF_AccessRights_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_isPresent]  DEFAULT ((0)) FOR [isPresent]
GO
ALTER TABLE [dbo].[Class] ADD  CONSTRAINT [DF_Class_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[ClassStudent] ADD  CONSTRAINT [DF_ClassStudent_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[ClassSubject] ADD  CONSTRAINT [DF_ClassSubject_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[ClassTeacher] ADD  CONSTRAINT [DF_ClassTeacher_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Education] ADD  CONSTRAINT [DF_Education_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Exam] ADD  CONSTRAINT [DF_Exam_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Experience] ADD  CONSTRAINT [DF_Experience_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[FeeDetail] ADD  CONSTRAINT [DF_FeeDetail_PaidForMonth]  DEFAULT ((0)) FOR [PaidForMonth]
GO
ALTER TABLE [dbo].[FeeDetail] ADD  CONSTRAINT [DF_FeeDetail_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[FeeDetail] ADD  CONSTRAINT [DF_FeeDetail_DecidedFee]  DEFAULT ((0)) FOR [DecidedFee]
GO
ALTER TABLE [dbo].[FeeDetail] ADD  CONSTRAINT [DF_FeeDetail_RemainingFee]  DEFAULT ((0)) FOR [RemainingFee]
GO
ALTER TABLE [dbo].[Grade] ADD  CONSTRAINT [DF_Grade1_Percentage]  DEFAULT ((0)) FOR [Percentage]
GO
ALTER TABLE [dbo].[Grade] ADD  CONSTRAINT [DF_Grade_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Parent] ADD  CONSTRAINT [DF_Parent_Income]  DEFAULT ((0)) FOR [Income]
GO
ALTER TABLE [dbo].[Parent] ADD  CONSTRAINT [DF_Parent_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Sections] ADD  CONSTRAINT [DF_Sections_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [DF_Session_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_AdminssionFee]  DEFAULT ((0)) FOR [AdminssionFee]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_ExaminationFee]  DEFAULT ((0)) FOR [ExaminationFee]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_MonthlyFee]  DEFAULT ((0)) FOR [MonthlyFee]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_OtherCharges]  DEFAULT ((0)) FOR [OtherCharges]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_SectionID]  DEFAULT ((0)) FOR [SectionID]
GO
ALTER TABLE [dbo].[StudentSubjectMarks] ADD  CONSTRAINT [DF_StudentSubjectMarks_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[StudentSubjectMarks] ADD  CONSTRAINT [DF_StudentSubjectMarks_SessionID]  DEFAULT ((0)) FOR [SessionID]
GO
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [DF_Subject_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_users_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[UsersDetail] ADD  CONSTRAINT [DF_usersDetail_Salary]  DEFAULT ((0)) FOR [Salary]
GO
ALTER TABLE [dbo].[UsersDetail] ADD  CONSTRAINT [DF_usersDetail_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[AccessRights]  WITH CHECK ADD  CONSTRAINT [FK_accessright_useraccessright] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[AccessRights] CHECK CONSTRAINT [FK_accessright_useraccessright]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_users_class_created] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_users_class_created]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_users_class_updated] FOREIGN KEY([updated_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_users_class_updated]
GO
ALTER TABLE [dbo].[ClassStudent]  WITH CHECK ADD  CONSTRAINT [FK_users_ClassStudent_created] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ClassStudent] CHECK CONSTRAINT [FK_users_ClassStudent_created]
GO
ALTER TABLE [dbo].[ClassStudent]  WITH CHECK ADD  CONSTRAINT [FK_users_ClassStudent_student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[ClassStudent] CHECK CONSTRAINT [FK_users_ClassStudent_student]
GO
ALTER TABLE [dbo].[ClassStudent]  WITH CHECK ADD  CONSTRAINT [FK_users_ClassStudent_updated] FOREIGN KEY([updated_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ClassStudent] CHECK CONSTRAINT [FK_users_ClassStudent_updated]
GO
ALTER TABLE [dbo].[ClassSubject]  WITH CHECK ADD  CONSTRAINT [FK_users_ClassSSubject_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[ClassSubject] CHECK CONSTRAINT [FK_users_ClassSSubject_Subject]
GO
ALTER TABLE [dbo].[ClassSubject]  WITH CHECK ADD  CONSTRAINT [FK_users_classsubject_created] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ClassSubject] CHECK CONSTRAINT [FK_users_classsubject_created]
GO
ALTER TABLE [dbo].[ClassSubject]  WITH CHECK ADD  CONSTRAINT [FK_users_ClassSubject_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[ClassSubject] CHECK CONSTRAINT [FK_users_ClassSubject_Subject]
GO
ALTER TABLE [dbo].[ClassSubject]  WITH CHECK ADD  CONSTRAINT [FK_users_classsubject_updated] FOREIGN KEY([updated_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ClassSubject] CHECK CONSTRAINT [FK_users_classsubject_updated]
GO
ALTER TABLE [dbo].[ClassTeacher]  WITH CHECK ADD  CONSTRAINT [FK_users_ClassTeacher_created] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ClassTeacher] CHECK CONSTRAINT [FK_users_ClassTeacher_created]
GO
ALTER TABLE [dbo].[ClassTeacher]  WITH CHECK ADD  CONSTRAINT [FK_users_ClassTeacher_teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ClassTeacher] CHECK CONSTRAINT [FK_users_ClassTeacher_teacher]
GO
ALTER TABLE [dbo].[ClassTeacher]  WITH CHECK ADD  CONSTRAINT [FK_users_ClassTeacher_updated] FOREIGN KEY([updated_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ClassTeacher] CHECK CONSTRAINT [FK_users_ClassTeacher_updated]
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD  CONSTRAINT [FK_users_education_id] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Education] CHECK CONSTRAINT [FK_users_education_id]
GO
ALTER TABLE [dbo].[Experience]  WITH CHECK ADD  CONSTRAINT [FK_users_experience_id] FOREIGN KEY([ExperienceID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Experience] CHECK CONSTRAINT [FK_users_experience_id]
GO
ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [FK_users_Parent_created_by] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [FK_users_Parent_created_by]
GO
ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [FK_users_Parent_updated_by] FOREIGN KEY([updated_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [FK_users_Parent_updated_by]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_users_Session_created_by] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_users_Session_created_by]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_users_Session_updated_by] FOREIGN KEY([updated_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_users_Session_updated_by]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_class_student] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_class_student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_parent_student] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Parent] ([ParentID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_parent_student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_users_student_created_by] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_users_student_created_by]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_users_student_updated_by] FOREIGN KEY([updated_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_users_student_updated_by]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_users_Subject_created_by] FOREIGN KEY([created_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_users_Subject_created_by]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_users_Subject_updated_by] FOREIGN KEY([updated_by])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_users_Subject_updated_by]
GO
ALTER TABLE [dbo].[UsersDetail]  WITH CHECK ADD  CONSTRAINT [FK_users_usersDetail] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UsersDetail] CHECK CONSTRAINT [FK_users_usersDetail]
GO
USE [master]
GO
ALTER DATABASE [EducationSystemDesktop] SET  READ_WRITE 
GO
