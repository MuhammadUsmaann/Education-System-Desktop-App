 using System;

 namespace ES.Entities
 {
	public partial class FeeDetail : IBaseEntity
	{
		private int m_id;
		private string m_feetype;
		private int m_paidfee;
		private string m_paiddate;
		private int m_recievedby;
		private int m_studentid;
		private int m_classid;
		private int m_sectionid;
		private int m_sessionid;
		private int m_paidformonth;
		private bool m_isactive;
		private bool m_isadjusted;
		private int m_decidedfee;
		private int m_remainingfee;

		public int ID
		{
			get { return  m_id; } 
			set{ m_id = value; NotifyPropertyChanged("ID"); }
		}

		public string FeeType
		{
			get { return  m_feetype; } 
			set{ m_feetype = value; NotifyPropertyChanged("FeeType"); }
		}

		public int PaidFee
		{
			get { return  m_paidfee; } 
			set{ m_paidfee = value; NotifyPropertyChanged("PaidFee"); }
		}

		public string PaidDate
		{
			get { return  m_paiddate; } 
			set{ m_paiddate = value; NotifyPropertyChanged("PaidDate"); }
		}

		public int RecievedBy
		{
			get { return  m_recievedby; } 
			set{ m_recievedby = value; NotifyPropertyChanged("RecievedBy"); }
		}

		public int StudentID
		{
			get { return  m_studentid; } 
			set{ m_studentid = value; NotifyPropertyChanged("StudentID"); }
		}

		public int ClassID
		{
			get { return  m_classid; } 
			set{ m_classid = value; NotifyPropertyChanged("ClassID"); }
		}

		public int SectionID
		{
			get { return  m_sectionid; } 
			set{ m_sectionid = value; NotifyPropertyChanged("SectionID"); }
		}

		public int SessionID
		{
			get { return  m_sessionid; } 
			set{ m_sessionid = value; NotifyPropertyChanged("SessionID"); }
		}

		public int PaidForMonth
		{
			get { return  m_paidformonth; } 
			set{ m_paidformonth = value; NotifyPropertyChanged("PaidForMonth"); }
		}

		public bool isActive
		{
			get { return  m_isactive; } 
			set{ m_isactive = value; NotifyPropertyChanged("isActive"); }
		}

		public bool isAdjusted
		{
			get { return  m_isadjusted; } 
			set{ m_isadjusted = value; NotifyPropertyChanged("isAdjusted"); }
		}

		public int DecidedFee
		{
			get { return  m_decidedfee; } 
			set{ m_decidedfee = value; NotifyPropertyChanged("DecidedFee"); }
		}

		public int RemainingFee
		{
			get { return  m_remainingfee; } 
			set{ m_remainingfee = value; NotifyPropertyChanged("RemainingFee"); }
		}

	}
}