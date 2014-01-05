using System;
using System.Configuration; 
namespace MonoBoss.Shell.Main
{
	/// <summary>
	/// Questa classe legge il file di configurazione in input
	/// alla shell, non viene usato per leggere il file dei moduli 
	/// </summary>
	public abstract class ConfigurationManager
	{
		public ConfigurationManager (){}
		public abstract AppConfiguration load ();
	}


	/// <summary>
	/// Definisce il caricamento del manager 
	/// </summary>
	public class DefaultConfigurationManager : ConfigurationManager {

		/// <summary>
		/// Recupera tutte le chiavi necessarie al boot 
		/// </summary>
	

		public AppConfiguration load() {



			return null; 



		}

	}

}

