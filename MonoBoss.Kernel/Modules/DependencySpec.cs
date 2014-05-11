using System;


namespace MonoBoss.Kernel.Modules
{
	/// <summary>
	/// A specifica delle dipendenze di un modulo che rappresenta una singola 
	/// dipendenza di un modulo, ossia nella classe @ModuleSpec ho una lista di DependecySpec
	/// ossia List<DepedencySpec> 
	/// </summary>

	public abstract class DependencySpec
	{

		private PathFilter importFilter { get; set;} 
		private PathFilter exportFilter { get; set;}
		private PathFilter resourceImportFilter {get; set; }
		private PathFilter resourceExportFilter { get; set; }


		public DependencySpec ()
		{
		}
	}
}

