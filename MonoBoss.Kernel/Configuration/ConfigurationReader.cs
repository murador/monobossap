using System;
using System.Xml;
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

        public string configSchemaPath {get; set; }

		public abstract void load(bool validate); 
		protected abstract void validate (); 

	}


	/// <summary>
	/// Definisce una classe per poter leggere 
	/// module.xml
	/// </summary>
	public class ModuleConfigurationReader: ConfigurationReader  {
		#region implemented abstract members of ConfigurationReader

		public override void load (bool validate)
		{

			if (filePath == null) {
				throw new ArgumentNullException ("filePath is null" );
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
<<<<<<< HEAD
	/// Definisce una classe per leggere il file di configurazione del server. 
    /// In AP questo viene inserito all'interno del file standalone.xml e domain.xml
=======
	/// define 
>>>>>>> origin/master
	/// </summary>
	public class ServerConfigurationReader: ConfigurationReader {

		#region implemented abstract members of ConfigurationReader
        private XmlTextReader xmlReader = null; 

		public override void load (bool validate)
		{
			if (filePath == null) {
				throw new ArgumentNullException ("file configuration path is null"); 
			}
            if (configSchemaPath == null) {
                throw new ArgumentNullException("Schema configuration path is null");
            }

            loadXSchema(); 
            if ( validate ) 
                this.validate(); 
		}
		
		/// <summary>
		/// Valida il file standalone o domain.xml che 
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		protected override void validate(){
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


        /// <summary>
        /// Questa funzione esegue il caricamento dello schema secondo quest'ordine. 
        /// 
        /// </summary>
		private void loadXSchema() {
            xmlReader = new XmlTextReader(configSchemaPath+"\\prova.xsd"); 
<<<<<<< HEAD
=======
			
>>>>>>> origin/master
		} 




	}









}

