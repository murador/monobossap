using System;
using MonoBoss.Kernel.Modules; 

namespace MonoBoss.Kernel
{
	/// <summary>
	///  A {@code Module} specification which is used by a {@code ModuleLoader} to define new modules
	/// </summary>
	public abstract class ModuleSpec
	{
		private ModuleIdentifier moduleIdentifier; 

		public ModuleSpec(ModuleIdentifier moduleIdentifier) {
			this.moduleIdentifier = moduleIdentifier; 
		}


		public static Builder build (ModuleIdentifier moduleIdentifier) {
			return null;
		}


		/// <summary>
		/// crea un alias per il modulo, ossia all'interno del sistema posso riferire 
		/// ad uno stesso modulo tramite il suo alias. 
		/// </summary>
		/// <returns>The alias.</returns>
		/// <param name="moduleIdentifier">Module identifier.</param>
		/// <param name="aliasTarget">Alias target, ossia il nome dell'alias </param>
		public static AliasBuilder buildAlias(ModuleIdentifier moduleIdentifier,
		                                      ModuleIdentifier aliasTarget) {
			return null;

		}

		public ModuleIdentifier getModuleIdentifier () {
			return moduleIdentifier; 
		}
	}


	public interface AliasBuilder {


	}

	public interface Builder {



	}


}

