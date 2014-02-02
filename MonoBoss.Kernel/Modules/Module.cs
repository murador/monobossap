using System;

namespace MonoBoss.Kernel.Modules
{
	/// <summary>
	/// Definisce un classe per la generazione del modulo 
	/// Vedere la classe Module all'interno del file JBossModule.jar 
	/// </summary>

	public sealed class Module {
		void run(string[] args) {}
	}


	/// <summary>
	/// Definisce l'identificatore del modulo 
	/// ossia un oggetto serializabile per descrivere il comportamento 
	/// dell'oggetto
	/// </summary>
	[Serializable]
	public class ModuleIdentifier {

		public string mainClass { get; set; }
		public static long serialVersionUID = 118533026624827995L; 

		/**    
		 * Creates a new module identifier using the specified name and slot.
		 * A slot allows for multiple modules to exist with the same name.
		 * The main usage pattern for this is to differentiate between
		 * two incompatible release streams of a module.
		 * Normally all module definitions wind up in the "main" slot.
		 * An unspecified or null slot will result in placement in the "main" slot. 
		 **/

		private string MODULE_NAME_PATTERN = ""; 
		/// <summary>
		/// 
		/// </summary>
		private string SLOT_PATTERN = ""; 
		private static string DEFAULT_SLOT = "main"; 
		private string name { get; set;} 
		private string slot { get; set; }
		
		// Identificatore del CLASSPATH, ossia un modulo 
		// virtule per il caricamento di una singola DLL
		public static ModuleIdentifier CLASSPATH = new ModuleIdentifier("Classpath",DEFAULT_SLOT); 

		private ModuleIdentifier(string name, string slot) {
			this.name = name; 
			this.slot = slot; 
		}


		public static ModuleIdentifier create ( string name, string slot) {
			return null; 
		}

	}


	/// <summary>
	/// Momorizza le specifiche del modulo, 
	/// come rappresentante nel file del modulo
	/// </summary>
	public class ModuleSpec {



	} 


}

