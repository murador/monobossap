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

namespace MonoBoss.Kernel.Modules
{
	/// <summary>
	/// Definisca una specifica delle dipendenze di un modulo che rappresenta una singola 
	/// dipendenza all'interno di un modulo, ossia nella classe @ModuleSpec ho una lista di DependecySpec
	/// ossia List<DepedencySpec> 
	/// </summary>

	public abstract class DependencySpec
	{

		private PathFilter importFilter { get; set;} 
		private PathFilter exportFilter { get; set;}
		private PathFilter resourceImportFilter {get; set; }
		private PathFilter resourceExportFilter { get; set; }


		public DependencySpec ()
		{
		}
	}
}

