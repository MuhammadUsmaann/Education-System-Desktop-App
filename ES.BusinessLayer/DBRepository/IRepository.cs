using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Data.SQLite;
using System.IO;

namespace ES.BusinessLayer
{
	public abstract class IRepository<T> : IDisposable where T : class
	{
		private IDbConnection _connection;
		private IDbTransaction _transaction;
        public Boolean isSQLite = true;

        protected IRepository()
		{

            //if the database has already password
            try
            {
                if (isSQLite)
                {
                    var path = Directory.GetCurrentDirectory();
                    var constr = System.Configuration.ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString;
                    Connection = new SQLiteConnection(constr);
                    Connection.Open();
                }
                else
                {
                    var ConnectionString = @"Data Source=USMAN;Initial Catalog=EducationSystemDesktop;User ID=admin;Pwd=Netsolpk1;Connect Timeout=15";
                    Connection = new SqlConnection(ConnectionString);
                }
                
            }
            //if it is the first time sets the password in the database
            catch(Exception asasd)
            {
                
            }
		}
		public IDbConnection Connection
		{
			get { return _connection; }
			protected set { _connection = value; }
		}
		/// <summary>
		/// Execute parameterized SQL  
		/// </summary>
		/// <returns>Number of rows affected</returns>
		public int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			if (transaction == null)
				transaction = _transaction;

			OpenConnection();
            try
			{
				return SqlMapper.Execute(_connection, sql, param, transaction, commandTimeout, commandType);
			}
            catch (Exception ee)
            {
                throw ee;
            }
			finally
			{
				CloseConnection();
			}
		}

		/// <summary>
		/// Return a list of dynamic objects, reader is closed after the call
		/// </summary>
		public IEnumerable<dynamic> Query(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
		{
			if (transaction == null)
				transaction = _transaction;

			OpenConnection();
			try
			{
				return SqlMapper.Query(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
			}
            catch (Exception ee)
            {
                throw ee;
            }
			finally
			{
				if (buffered)
					CloseConnection();
			}
		}

		/// <summary>
		/// Executes a query, returning the data typed as per T
		/// </summary>
		/// <remarks>the dynamic param may seem a bit odd, but this works around a major usability issue in vs, if it is Object vs completion gets annoying. Eg type new [space] get new object</remarks>
		/// <returns>A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
		/// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
		/// </returns>
		public IEnumerable<T> Query<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
		{
			if (transaction == null)
				transaction = _transaction;

			OpenConnection();
			try
			{
				return SqlMapper.Query<T>(_connection, sql, param, transaction, buffered, commandTimeout, commandType);
			}
            catch(Exception ee)
            {
                throw ee;
            }
			finally
			{
				if (buffered)
					CloseConnection();
			}
		}

		/// <summary>
		/// Maps a query to objects
		/// </summary>
		public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			if (transaction == null)
				transaction = _transaction;

			OpenConnection();
			try
			{
				return SqlMapper.Query<TFirst, TSecond, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
																 commandTimeout, commandType);
			}
            catch (Exception ee)
            {
                throw ee;
            }
			finally
			{
				if (buffered)
					CloseConnection();
			}
		}

		/// <summary>
		/// Perform a multi mapping query with 5 input parameters
		/// </summary>
		public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			if (transaction == null)
				transaction = _transaction;

			OpenConnection();
			try
			{
				return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
																 commandTimeout, commandType);
			}
            catch (Exception ee)
            {
                throw ee;
            }
			finally
			{
				if (buffered)
					CloseConnection();
			}
		}

		/// <summary>
		/// Perform a multi mapping query with 4 input parameters
		/// </summary>
		public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			if (transaction == null)
				transaction = _transaction;

			OpenConnection();
			try
			{
				return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
																 commandTimeout, commandType);
			}
            catch (Exception ee)
            {
                throw ee;
            }
			finally
			{
				if (buffered)
					CloseConnection();
			}
		}

		/// <summary>
		/// Maps a query to objects
		/// </summary>
		public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			if (transaction == null)
				transaction = _transaction;

			OpenConnection();
			try
			{
				return SqlMapper.Query<TFirst, TSecond, TThird, TReturn>(_connection, sql, map, param, transaction, buffered, splitOn,
																 commandTimeout, commandType);
			}
            catch (Exception ee)
            {
                throw ee;
            }
			finally
			{
				if (buffered)
					CloseConnection();
			}
		}

		/// <summary>
		/// Execute a command that returns multiple result sets, and access each in turn
		/// </summary>
		public SqlMapper.GridReader QueryMultiple(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			if (transaction == null)
				transaction = _transaction;

			OpenConnection();

			return SqlMapper.QueryMultiple(_connection, sql, param, transaction, commandTimeout, commandType);
		}

		protected void OpenConnection()
		{
			if (_connection != null && _connection.State != ConnectionState.Open)
				_connection.Open();
		}

		protected void CloseConnection()
		{
			if (_connection != null)
				_connection.Close();
		}

		public void Dispose()
		{
			if (_transaction != null)
				_transaction.Dispose();

			if (_connection != null)
				_connection.Dispose();

			_transaction = null;
			_connection = null;
		}

        
        protected string LastInsertIDQuerySQLite
        {
            get
            {
                if (isSQLite)
                    return "select last_insert_rowid();";
                else
                    return "";
            }

        }
        public abstract int Insert(T item);
        public abstract int Remove(int id);
        public abstract int Update(T item);
        public abstract T FindByID(int id);
        public abstract IEnumerable<T> FindByQuery(string query);
        public abstract IEnumerable<T> GetAll();
        public abstract IEnumerable<T> GetTop(int count);

	}
}
