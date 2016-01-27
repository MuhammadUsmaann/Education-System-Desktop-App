using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace ES.BusinessLayer
{
    public class SQLiteScripts
    {
        public void Install ()
        {
            RunSql();
        }
        private void RunSql(bool newdb = false)
        {
            string myDBName = "ES.sqlite";
            string strConnection = "Data Source=" + myDBName + ";Version=3;New=True;Compress=True;";
            string filePath = "" + myDBName;

            if (newdb == true)
            {

            }
            else
            {
                if (!File.Exists(filePath))
                {
                    //string strCommand = File.ReadAllText("/../DBScripts/DBScripts.sql"); // .sql file path

                    //using (SQLiteConnection objConnection = new SQLiteConnection(strConnection))
                    //{
                    //    using (SQLiteCommand objCommand = objConnection.CreateCommand())
                    //    {
                    //        objConnection.Open();
                    //        objCommand.CommandText = strCommand;
                    //        objCommand.ExecuteNonQuery();
                    //        objConnection.ChangePassword("mypassword");
                    //        objConnection.Close();
                    //    }
                    //}
                }
            }
        }
        private void AccessRights()
        {
            string query = "CREATE TABLE [dbo].[AccessRights]("
	                        +"[AccessRightID] [int] IDENTITY(1,1) NOT NULL,"
	                        +"[Description] [nvarchar](50) NOT NULL,"
	                        +"[ControlID] [nvarchar](50) NOT NULL,"
	                        +"[UserID] [int] NOT NULL,"
	                        +"[CanEdit] [bit] NOT NULL,"
	                        +"[CanView] [bit] NOT NULL,"
	                        +"[CanDelete] [bit] NOT NULL,"
	                        +"[isActive] [bit] NULL,"
                            +"CONSTRAINT [PK_AccessRights] PRIMARY KEY CLUSTERED "
                            +"("
	                            +"[AccessRightID] ASC"
                            +")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                            +") ON [PRIMARY]";          
        }
    }
}
