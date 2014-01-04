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
using System.Threading;
using MonoBoss.Kernel.Service; 
using MonoBoss.Kernel.Loaders; 

/// <summary>
/// Fornisce l'analo per JbossModule, ossia gestisce il class loading 
/// di risorse nel container, è possibile pensare al kernel come ad un leggero 
/// bootstrap wrapper per eseguire un applicazione in un ambiente modulare.  
/// </summary>


namespace MonoBoss.Kernel
{
	#region specification on kernel main module
	/// <summary>
	/// il kernel è unico,ossia non ne possono esistere più di uno per instanza d
	/// del server
	/// </summary>
	public abstract class  MonoBossKernel {

		protected static MonoBossKernel instance = null; 

		public abstract void initialize ();

		public abstract ModuleLoader getModuleLoader ();

		// recupera un servizio tramite il modulo MSC
		public abstract IMBossServer getService(string serviceName); 


		[MethodImpl(MethodImplOptions.Synchronized)]
		public static MonoBossKernel getInstance(){

			if (MonoBossKernel.instance != null) {
				return instance;
			}else {
				throw new NullReferenceException ("Set up the instance of Kernel"); 
			} 
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void setInstance(MonoBossKernel instance) {
			if (MonoBossKernel.instance == null) {
				MonoBossKernel.instance = instance; 
			}
		}
		
	}

	#endregion

	#region implemented abstract members of MonoBossKernel

	/// <summary>
	///  Implementazione di default 
	/// </summary>
	public class DefaultMonoBossKernel : MonoBossKernel {

		private ModuleLoader currentModuleLoader; 


		/// <summary>
		/// Fa riferimento al servizio per il caricamento
		/// </summary>
		/// <returns>The service.</returns>
		/// <param name="serviceName">Service name.</param>
		public override IMBossServer getService (string serviceName)
		{
			return null; 
		}

		public override void initialize ()
		{
			currentModuleLoader = DefaultBootModuleLoaderHolder.INSTANCE;

			// Carica il modulo MSC


		}
		/// <summary>
		/// Definisce un ModuleLoader di default
		/// </summary>
		/// <returns>The module loader.</returns>
		public override ModuleLoader getModuleLoader ()
		{
			return currentModuleLoader; 
		}
	
	}
	#endregion

}

