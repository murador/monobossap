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
	/// Module configuration reader.
	/// </summary>
	public class ModuleConfigurationReader: ConfigurationReader  {
		#region implemented abstract members of ConfigurationReader

		public override void load (bool validate)
		{
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
			throw new NotImplementedException ();
		}

		protected override void validate ()
		{
			throw new NotImplementedException ();
		}

		#endregion


		public ServerInstance getServerInstance() {

			throw new NotImplementedException ();



		}


	}









}

