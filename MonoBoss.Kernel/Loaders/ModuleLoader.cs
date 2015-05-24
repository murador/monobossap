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
			throw new NotImplementedException ();
		}

		#endregion




	}





}

