using System;
/// <summary>
/// Legge in input il file di configurazione 
/// da usare per caricare i moduli richiesti
/// </summary>
namespace MonoBoss.Kernel
{

	/// <summary>
	/// Legge il file standalone.xml o 
	/// un'altro tipo di file simile com domain.xml 
	/// per l'esecuzione in modalità dominio, si dovrà attendere la prossima release. 
	/// </summary>
	public abstract class ConfigurationReader
	{
		public string filePath { get; set; }
		public abstract void load(bool validate); 
		protected abstract void validate (); 

	}


	/// <summary>
	/// M
	/// </summary>
	public class ModuleConfigurationReader: ConfigurationReader  {
		#region implemented abstract members of ConfigurationReader

		public override void load (bool validate)
		{

			if (filePath == null) {
				throw new ArgumentNullException (filePath+ " - filePath is null" );
			}

			throw new NotImplementedException ();
		}

		protected override void validate ()
		{
			throw new NotImplementedException ();
		}

		#endregion

	}

	/// <summary>
	/// standalone or domain .xml :) 
	/// 
	/// </summary>
	public class ServerConfigurationReader: ConfigurationReader {
		#region implemented abstract members of ConfigurationReader

		public override void load (bool validate)
		{
			if (filePath == null) {
				throw new ArgumentNullException (filePath + " is null"); 
			}

			throw new NotImplementedException ();
		}
		protected override void validate ()
		{
			throw new NotImplementedException ();
		}
		#endregion
		
		/// <summary>
		/// crea un istanza del server base ai parametri 
		/// resti
		/// </summary>
		/// <returns>The server instance.</returns>
		public ServerInstance getServerInstance() {

			throw new NotImplementedException ();
		}


	}









}

