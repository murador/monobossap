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
using MonoBoss.Kernel.Modules;
using System.Configuration;  
using System.Reflection; 

namespace MonoBoss.Kernel.Loaders
{
	/// <summary>
	/// Questo è il boot module loader holder, ossia carica il modulo loader 
	/// stesso. o.O 
	/// </summary>
	public sealed class DefaultBootModuleLoaderHolder
	{
	
		public static ModuleLoader INSTANCE { get; set;}
		static DefaultBootModuleLoaderHolder() {

			string moduleLoaderClass = ConfigurationManager.AppSettings ["boot.module.loader.class"]; 
			string moduleLoaderAssembly = ConfigurationManager.AppSettings ["boot.module.loader.assemby"]; 	
			if (moduleLoaderClass == "") {			
				INSTANCE = new LocalModuloLoader (); 		    	  	
			} else {

				if (moduleLoaderAssembly == "") {
					try {
						Assembly assembly = Assembly.LoadFile (".\\MonoBoss.Kernel.dll"); 
						Type t = assembly.GetType ( moduleLoaderClass);
						INSTANCE = (ModuleLoader)Activator.CreateInstance (t);
						if (INSTANCE == null) {
							throw new ModuleLoaderException ("Cant'load assembly bootloader");
						}
				
					}catch ( ModuleLoaderException ex) {
						throw new ApplicationException (ex.ToString());
					}catch(Exception ex) {
					throw new ApplicationException ( "[Module Loader] " + ex.ToString());
				}

				
				} else {
				
					try {

						Assembly assembly = Assembly.LoadFile (moduleLoaderAssembly); 
						Type t = assembly.GetType(moduleLoaderClass);
						INSTANCE = (ModuleLoader) Activator.CreateInstance(t); 
						if (INSTANCE == null) {
							throw new ModuleLoaderException ("Cant'load assembly bootloader");
						}

					}catch ( ModuleLoaderException ex ) {
						throw new ApplicationException (ex.ToString());
					}catch(Exception ex) {
						throw new ApplicationException ( "[Module Loader] " + ex.ToString());
					}


				
				} 

			} 

		}
		
		private DefaultBootModuleLoaderHolder ()
		{




		}
	}
}

