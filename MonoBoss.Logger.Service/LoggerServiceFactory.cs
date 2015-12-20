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
using System.Runtime.CompilerServices;

namespace MonoBoss.Logger.Service
{
    public abstract class LoggerServiceFactory
	{
        public abstract ILoggerService getLogger();
        public static LoggerServiceFactory instance;


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void setInstance(LoggerServiceFactory inst)
        {
            if (LoggerServiceFactory.instance == null)
            {
                LoggerServiceFactory.instance = inst;
            }
        }
        public static LoggerServiceFactory getInstance() { 
            if ( LoggerServiceFactory.instance != null) {
              return LoggerServiceFactory.instance; 
            } else {
               throw new NullReferenceException("The logger instance is not setted"); 
            }
        }
			
	

    }

    public class NLoggerServiceFactory : LoggerServiceFactory
    {


        public override ILoggerService getLogger()
        {
            return new NancyLoggerService();
        }
    }
}
