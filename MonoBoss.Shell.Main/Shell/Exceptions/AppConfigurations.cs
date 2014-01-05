using System;

namespace MonoBoss.Shell.Main
{
	public class AppConfiguration
	{

		string verbs { get; set;}
		string bootModuleLoader {get; set;}
		string bootModuleLoaderClass { get; set; }
		bool bootServiceLoaderOsgi { get; set; }
		public AppConfiguration (){}
	}
}

