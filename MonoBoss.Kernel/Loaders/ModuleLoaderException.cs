using System;

namespace MonoBoss.Kernel
{
	public class ModuleLoaderException: Exception {

		private string exceptionMessage; 

		public ModuleLoaderException ()
		{

		}

		public ModuleLoaderException (string moduleLoaderCantlaodAssemblyBootloader)
		{
			exceptionMessage = moduleLoaderCantlaodAssemblyBootloader; 
		}

		public override string ToString ()
		{
			return string.Format ("[ModuleLoaderException] "+ exceptionMessage);
		}	

	}
}

