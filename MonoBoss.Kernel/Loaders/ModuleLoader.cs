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
namespace MonoBoss.Kernel.Loaders
{

	public abstract class ModuleLoader
	{
		public ModuleLoader()
		{
	

		}

        /// <summary>
        /// Questo è il primo modulo che viene caricato
        /// Diversamente da Wildfly lo standalone.xml come refernce al primo modulo 
        /// caricato. Questo significa che , se è standalone faccio partire un modulo diverso da quello 
        /// per il dominio. 
        /// </summary>
        /// <param name="ist"></param>
		public abstract void bootLoader (ServerInstance ist);
	}

	/// <summary>
	/// Recupera i moduli da un repository locale, tramite NetMX
	/// ossia recupero i moduli tramite delle interfacce di servizi remoti
	/// </summary>
	public class LocalModuloLoader : ModuleLoader {
		#region implemented abstract members of ModuleLoader

		public override void bootLoader (ServerInstance ist)
		{
            // Implementare in questo punto 
			throw new NotImplementedException ();
		}

		#endregion


	}


	/// <summary>
	/// Simile a Jar Module Loader 
	/// </summary>
	public class AssemblyModuleLoader : ModuleLoader {
		#region implemented abstract members of ModuleLoader

		public override void bootLoader (ServerInstance ist)
		{
           


		}

		#endregion
	}

}

