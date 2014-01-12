using System;

namespace MonoBoss.Shell.Main
{
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

