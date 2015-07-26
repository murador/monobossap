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

namespace MonoBoss.As.Server
{
    /// <summary>
    /// Definisce il secondo modulo che viene caricato dopo il servizio MSC. 
    /// Secondo il comportamente predefinito in questo prima fase, vengono 
    /// impostati e correttamente predefiniti 
    /// </summary>
    public class DomainServerMain
	{
		public DomainServerMain ()
		{

		}

		/// <summary>
		/// Entry point of the module
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void main(string[] args) {

		}

	}


	/// <summary>
	/// Avvio del servizio in fase di esecuzione standalone
	/// </summary>
	public class StandAloneMain {

		public StandAloneMain() {
		}


		public static void main(string[] args) {
		
		}

	}

}

