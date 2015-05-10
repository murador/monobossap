using System;
using System.Xml;
using System.Xml.Schema;
using System.Configuration;
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

        public string configSchemaPath { get; set; }

        public abstract void load(bool validate, string mode);
        protected abstract void validate(object sender, ValidationEventArgs e);

    }


    /// <summary>
    /// Definisce una classe per poter leggere 
    /// module.xml
    /// </summary>
    public class ModuleConfigurationReader : ConfigurationReader
    {
        #region implemented abstract members of ConfigurationReader

        public override void load(bool validate, string mode)
        {

            if (filePath == null)
            {
                throw new ArgumentNullException("filePath is null");
            }

            throw new NotImplementedException();
        }

        protected override void validate(object sender, ValidationEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    /// <summary>
    /// Definisce una classe per leggere il file di configurazione del server. 
    /// In AP questo viene inserito all'interno del file standalone.xml e domain.xml
    /// define 
    /// </summary>
    public class ServerConfigurationReader : ConfigurationReader
    {

        #region implemented abstract members of ConfigurationReader
        private XmlReaderSettings xmlSchemaSettings = null;
        private XmlReader serverConfigFile = null;
        private string fileschema_name = null;




        /// <summary>
        /// 15/3/2015 - viene aggiunto la modalità di caricamento 
        /// per distringuere tra il caricamento in modalità domino e il caricamento 
        /// in modalità standalone. 
        /// Per il primo rilascio si definisce solo la modalità in standalone. 
        /// </summary>
        /// <param name="validate"></param>
        /// <param name="mode"></param>
        public override void load(bool validate, string mode)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("file configuration path is null");
            }
            if (configSchemaPath == null)
            {
                throw new ArgumentNullException("Schema configuration path is null");
            }


            fileschema_name = ConfigurationManager.AppSettings["serverConfSchema"];
            if (fileschema_name == null)
                throw new ConfigurationErrorsException("Error, serverConfSchema key is not found");
            try
            {
                loadXSchema(mode);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in loading schema: " + ex.Message);
            }

        }

        /// <summary>
        /// Valida il file standalone o domain.xml in base allo schema 
        /// che è stato caricato
        /// </summary>
        protected override void validate(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                // TODO Rimuovere fa sputare questi tipi di messaggi 
                // tramite NLog 
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        /// <summary>
        /// crea un istanza del server base ai parametri 
        /// resti
        /// </summary>
        /// <returns>The server instance.</returns>
        public ServerInstance getServerInstance()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Questa funzione esegue il caricamento dello schema secondo quest'ordine
        /// </summary>
        private void loadXSchema(string mode)
        {
            try
            {
                if (mode.Equals("standalone"))
                {

                    // xmlReader = new XmlTextReader(configSchemaPath + "\\" + fileschema_name);
                    xmlSchemaSettings = new XmlReaderSettings();
                    xmlSchemaSettings.Schemas.Add("http://org.monoboss.config.org/serverschema", configSchemaPath + "\\" + fileschema_name);
                    xmlSchemaSettings.ValidationType = ValidationType.Schema;
                    xmlSchemaSettings.ValidationEventHandler += new ValidationEventHandler(this.validate);
                    serverConfigFile = XmlReader.Create(filePath);

                }
                else
                {
                    // carichiamo lo stesso file ma è bene separare le due modalità 
                    // la cosa potrebbe cambiare in futuro , rispetto alla specifiche
                    xmlSchemaSettings = new XmlReaderSettings();
                    xmlSchemaSettings.Schemas.Add("http://org.monoboss.config.org/serverschema", configSchemaPath + "\\" + fileschema_name);
                    xmlSchemaSettings.ValidationType = ValidationType.Schema;
                    xmlSchemaSettings.ValidationEventHandler += new ValidationEventHandler(this.validate);
                    serverConfigFile = XmlReader.Create(filePath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }









}

