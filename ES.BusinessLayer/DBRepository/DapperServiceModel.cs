using System;
using System.Collections;

namespace ES.BusinessLayer
{
	public partial class DapperServiceModel : IDisposable
	{
		#region variables
		private Hashtable _Items;
		#endregion

		#region properties
		public object this[string name]
		{
			get
			{
				if (_Items == null)
					return null;

				return _Items[name];
			}
			set
			{
				if (_Items == null)
					_Items = new Hashtable();
				_Items[name] = value;
			}
		}
		#endregion

		#region public methods
		public void Dispose()
		{
		}
		#endregion
	}
}
