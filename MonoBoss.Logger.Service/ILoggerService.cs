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

// descrive un servizio di logging usando 
// MBean per .net ? 
namespace MonoBoss.Logger.Service
{

	/// <summary>
	/// Definisce l'interfaccia per un ILogger service
	/// </summary>
	public interface ILoggerService {

		void info(string message, string filesource, int line);
		void info (string message); 
	    void error(string message, Exception ex, int filesource, int line); 
		void error(Exception ex); 
		void warn (string message, string filesource, int line); 
		void warn (string message); 
	
	}
		
}

