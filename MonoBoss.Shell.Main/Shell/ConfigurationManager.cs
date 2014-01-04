using System;

namespace MonoBoss.Shell.Main
{
	public abstract class ConfigurationManager
	{
		public ConfigurationManager (){}

		public abstract void parseModuleFile(string path); 
	
	}


	/// <summary>
	/// Definisce il caricamento del manager 
	/// </summary>
	public class DefaultConfigurationManager : ConfigurationManager {


		#region implemented abstract members of ConfigurationManager
		public override void parseModuleFile (string path)
		{




		}
		#endregion
	}

}

