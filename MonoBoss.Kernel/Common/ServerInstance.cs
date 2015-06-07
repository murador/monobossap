using MonoBoss.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace MonoBoss.Kernel
{
    /// <summary>
    /// Contiene le informazioni di instanza 
    /// del server che si sta facendo partire
    /// </summary>
    [Serializable]
    public class ServerInstance
    {

        // Root del documento 
        private Server standalone;

        // Root del documento 
        private Domain domain;

        private XDocument serverconfig;

        // mode
        private string mode;

        /// <summary>
        /// Costruttore di default
        /// </summary>
        public ServerInstance(XDocument doc, string mode)
        {
            serverconfig = doc;
            this.mode = mode;
        }


        /// <summary>
        /// Get alla extentions module required 
        /// </summary>
        /// <returns>returns a list of module required by the instance</returns>
        public List<Extension> getRequiredExtention()
        {

            IEnumerable<XElement> extentions =
                 from ext in serverconfig.Elements("extension")
                 select ext;


            List<Extension> listext = new List<Extension>();

            foreach (XElement xEle in extentions)
            {
                IEnumerable<XAttribute> attlist =
                        from att in xEle.DescendantsAndSelf().Attributes()
                        select att;
                
                foreach (XAttribute att in attlist){
                    Extension e = new Extension(); 
                    e.module = att.Value;
                    listext.Add(e);
                }
            }
            return listext; 
        }



        /// <summary>
        /// Ritorna i servizi di managment richiesti quali: 
        ///  - Autenticazione  ( securty-realm) 
        ///  - audit-log ( ossia log abilitati per le perfomance) 
        ///  - e le interfacce di gestione che devono essere definiti da dei socket bind 
        /// </summary>
        /// <returns>Ritorna una lista di Managment per il server</returns>
        public List<domainmanagementType> getRequiredManagment() {
            throw new NotImplementedException("Not implemented yet"); 
        }


        /// <summary>
        /// Ritorna le socket da occupare e richieste. 
        ///  - Si specifica correttamente sia la porta che il nome. 
        ///  - Deve essere necessariamente una socket dedicata al servizio di managment
        /// </summary>
        /// <returns></returns>
        public List<socketbindinggroupType> getSocketBindGroup() {
            throw new NotImplementedException("Not implemented yet"); 
        }

        /// <summary>
        /// Qui si fa il binding della porta con un indirizzo IP secondo 
        /// quanto specificato nelle interfacce
        /// </summary>
        /// <returns></returns>
        public List<specifiedinterfaceType> getRequiredInterfaces() {
            throw new NotImplementedException("Not implemented yet"); 
        }

        /// <summary>
        /// Si recuperano tutti nel caso la modalità di start sia stata 
        /// standalone 
        /// </summary>
        /// <returns></returns>
        public List<standaloneprofileType> getStandAloneProfile() {
            throw new NotImplementedException("Not implemeted yet"); 
        }

        /// <summary>
        /// Si recuperano tutti i profili nel caso in cui sia stato 
        /// caricato in modalità domain
        /// </summary>
        /// <returns></returns>
        public List<domainprofileType> getDomainProfile() {
            throw new NotImplementedException("Not implemented yet"); 
        }
    }
}

