using System;
using System.Text.RegularExpressions;
namespace MonoBoss.Kernel.Modules
{
	/// <summary>
	/// A module is a unit of classes and other resources, along with the specification of what is imported and exporte
	/// by this module from and to other modules.  Modules are created by {@link ModuleLoader}s which build modules from
	/// various configuration information and resource roots.
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
		 * 
		 * Example: org.monoboss.AS.Sever:1.0 ,dove  MODULE_NAME_PATTERN:SLOT
		 **/

		private static string MODULE_NAME_PATTERN = "[a-zA-Z]+?((\\.[a-zA-Z])*)"; 
		/// <summary>
		/// 
		/// </summary>
		private static string SLOT_PATTERN = "[0-9]+\\.[0-9]+"; 
		private static string DEFAULT_SLOT = "main";
		private static string ENTRY = DEFAULT_SLOT;
		private string name { get; set;} 
		private string slot { get; set; }

		private int hashCode; 
		
		// Identificatore del CLASSPATH, ossia un modulo 
		// virtule per il caricamento di una singola DLL
		public static ModuleIdentifier CLASSPATH = new ModuleIdentifier("Classpath",DEFAULT_SLOT); 

		private ModuleIdentifier(string name, string slot) {
			this.name = name; 
			this.slot = slot;
			hashCode = calculateHashCode (name, slot);
		}


		public void setEntry (string entry) {
			ENTRY = entry; 
		}

		public static ModuleIdentifier create ( string name, string slot) {
			if (name == null) {
				throw new ModuleLoaderException ("ModuleIdentifier create() : module name can't be null");
			} 
			if (slot == null) {
				slot = "1.0"; 
			}
			return new ModuleIdentifier (name, slot); 
		}


		/// <summary>
		/// Calcola l'hashcode tra il nome e lo slot
		/// per generare un string univoca per identificare la stima 
		/// </summary>
		/// <returns>The hash code.</returns>
		/// <param name="name">Name.</param>
		/// <param name="slot">Slot.</param>
		private static int calculateHashCode ( string name, string slot ) {
			int h = 17; 
			h = 37 * h + name.GetHashCode(); 
			h = 37 * h + slot.GetHashCode (); 
			return h; 
		}

		public static ModuleIdentifier create(string name) {
			return create(name, null);
		}


		/// <summary>
		//  Recupera uno specifica specifica del modulo e ne recupera l'identificatore
		// La specifica di un modulo 
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="moduleSpec">Module spec. e' una stringa contentente il nome del modulo e la versione separata da :
		/// ossia org.monoboss.As.Server.StandAlone:1.0</param>
		public static ModuleIdentifier fromString(string moduleSpec) {

			string name; 
			string slot; 

			if (moduleSpec == null) {
				throw new ArgumentNullException ("Module specs not found!"); 
			}
			if (moduleSpec.Length == 0) {
				throw new ArgumentException ("Module spec name not found");
			}

			int cl = moduleSpec.LastIndexOf (':'); 

			if (cl < 0) {
				throw new ModuleLoaderException ("ModuleIdentifier: fromString , error SLOT not found"); 
			} 

			// controllo se il pattern è giusto per il nome e per lo slot
			slot = moduleSpec.Substring (cl, moduleSpec.Length);
			name = moduleSpec.Substring (0, cl); 
			Regex r = new Regex(ModuleIdentifier.MODULE_NAME_PATTERN, RegexOptions.IgnoreCase);
			Match m = r.Match (name);
			if (!m.Success) {
				throw new ModuleLoaderException ("ModuleIdentifier: fromString, error module name not formatted "); 
			}
			r = new Regex(ModuleIdentifier.SLOT_PATTERN, RegexOptions.IgnoreCase);
		    m = r.Match (name);
			if (!m.Success) {
				throw new ModuleLoaderException ("ModuleIdentifier: fromString, error slot version not formatted "); 
			}
			return new ModuleIdentifier (name, slot); 
		}


	}





}

