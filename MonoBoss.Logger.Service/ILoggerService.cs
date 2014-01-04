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

