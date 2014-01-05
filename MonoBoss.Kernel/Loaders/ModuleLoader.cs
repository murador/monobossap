using System;

namespace MonoBoss.Kernel.Loaders
{

	public abstract class ModuleLoader
	{
		public ModuleLoader()
		{
		}

		public abstract void initLoader (ServerInstance ist);
	}

	/// <summary>
	/// Recupera i moduli da un repository locale, tramite NetMX
	/// ossia recupero i moduli tramite delle interfacce di servizi remoti
	/// </summary>
	public class LocalModuloLoader : ModuleLoader {
		#region implemented abstract members of ModuleLoader

		public override void initLoader (ServerInstance ist)
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

		public override void initLoader (ServerInstance ist)
		{
			throw new NotImplementedException ();
		}

		#endregion




	}





}

