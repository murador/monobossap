/*
This file is part of MonoBoss Application Server.
     MonoBoss Application Server is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
     MonoBoss Application Server is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with Nome-Programma.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoBoss.Logger.Service
{

    /// <summary>
    /// We define the implementation of the ILoggerService interface. 
	/// We're using NLog for logging and Nancy for provide the interface
    /// </summary>
	class NancyLoggerService: ILoggerService
    {
		#region ILoggerService implementation
		public void info (string message, string filesource, int line)
		{
			throw new NotImplementedException ();
		}
		public void info (string message)
		{
			throw new NotImplementedException ();
		}
		public void error (string message, Exception ex, int filesource, int line)
		{
			throw new NotImplementedException ();
		}
		public void error (Exception ex)
		{
			throw new NotImplementedException ();
		}
		public void warn (string message, string filesource, int line)
		{
			throw new NotImplementedException ();
		}
		public void warn (string message)
		{
			throw new NotImplementedException ();
		}
		public bool isDebugEnable ()
		{
			throw new NotImplementedException ();
		}
		public void setLevel (LogLevel level)
		{
			throw new NotImplementedException ();
		}
		public LogLevel getLevel ()
		{
			throw new NotImplementedException ();
		}
		#endregion
		

    }
}
