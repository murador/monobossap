using System;

namespace MonoBoss.Shell.Main
{

    /// <summary>
    /// Questa classe serve per recuperare i dati all'interno del config dell'applicativo
    /// Ossia a livello configurazione del programma shell.
    /// Verificare come devono essere legati
    /// </summary>
    [Serializable]
    public class AppConfiguration
    {

        public string verbs { get; set; }
        public string bootModuleLoader { get; set; }
        public string bootModuleLoaderClass { get; set; }
        public bool bootServiceLoaderOsgi { get; set; }
        public string configurationDir { get; set; }
        public AppConfiguration()
        {

            configurationDir = System.Configuration.ConfigurationManager.AppSettings["configurationDir"];
            verbs = System.Configuration.ConfigurationManager.AppSettings["verbs"];
            bootModuleLoaderClass = System.Configuration.ConfigurationManager.AppSettings["bootModuleLoaderClass"];
            bootServiceLoaderOsgi = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["bootServiceLoaderOsgi"]);

        }
    }
}

