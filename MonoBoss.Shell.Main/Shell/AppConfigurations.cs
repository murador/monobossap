using System;

namespace MonoBoss.Shell.Main
{

	/// <summary>
	/// Questa classe serve per recuperare i dati all'interno del config dell'applicativo
	/// Ossia a livello configurazione del programma shell.
	/// </summary>
	[Serializable]
	public class AppConfiguration
	{

		public string verbs { get; set;}
		public string bootModuleLoader {get; set;}
		public string bootModuleLoaderClass { get; set; }
		public bool bootServiceLoaderOsgi { get; set; }
		public string configurationDir { get; set; }
		public AppConfiguration (){}
	}
}

