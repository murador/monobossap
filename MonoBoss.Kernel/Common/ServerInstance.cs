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

                foreach (XAttribute att in attlist)
                {
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
        ///   <security-realms>
        ///    <security-realm name="ManagementRealm">
        ///        <authentication>
        ///            <properties path="mgmt-users.properties" relative-to="monoboss.server.config.dir"/>
        ///            </authentication
        ///            </security-realm>
        ///            <security-realm name="ApplicationRealm">
        ///       <authentication>
        ///            <properties path="application-users.properties" relative-to="monoboss.server.config.dir"/>
        ///      </authentication>
        ///  </security-realm>
        ///</security-realms>
        /// </summary>
        /// NOTA: per il momento non viene scavato l'intera possibilità di autenticazione e autorizzazione 
        /// in quanto le possibilità sono molte e difficili da gestire
        /// <returns>Ritorna una lista di Realm di Sicurezza</returns>
        public List<securityrealmType> getSecurityRealms()
        {

            List<securityrealmType> listrealms = new List<securityrealmType>();
            IEnumerable<XElement> realms =
                 from rs in serverconfig.Elements("security-realms")
                 select rs;

            foreach (XElement realm in realms)
            {
                // Recupero tutti i realm dentro il i realms
                // Ovvero: 
                IEnumerable<XElement> elem =
                       from e in realm.Descendants("security-realm") select e;

                foreach (XElement re in elem)
                {
                    securityrealmType srealm = new securityrealmType();
                    srealm.name = re.Attribute("name").Value;

                    IEnumerable<XElement> auth =
                               from e in re.Descendants("authentication") select e;

                    foreach (XElement a in auth)
                    {

                        IEnumerable<XElement> auth_attr =
                              from e in re.Descendants("properties") select e;
                        foreach (XElement p in auth_attr)
                        {
                            srealm.authentication.truststore.path = p.Attribute("path").Value;
                            srealm.authentication.truststore.relativeto = p.Attribute("relative-to").Value;
                        }
                    }
                }
            }
            return listrealms;
        }

        /// <summary>
        /// Ritorna le socket da occupare e richieste. 
        ///  - Si specifica correttamente sia la porta che il nome. 
        ///  - Deve essere necessariamente una socket dedicata al servizio di managment
        /// </summary>
        /// <returns></returns>
        public List<serversocketbindingsType> getSocketBindGroup()
        {
            throw new NotImplementedException("Not implemented yet");
        }

        /// <summary>
        /// Qui si fa il binding della porta con un indirizzo IP secondo 
        /// quanto specificato nelle interfacce
        /// </summary>
        /// <returns></returns>
        public List<specifiedinterfaceType> getRequiredInterfaces()
        {
            throw new NotImplementedException("Not implemented yet");
        }

        /// <summary>
        /// Si recuperano tutto il prof
        /// </summary>
        /// <returns></returns>
        public List<standaloneprofileType> getStandAloneProfile()
        {
            throw new NotImplementedException("Not implemeted yet");
        }

        /// <summary>
        /// Si recuperano tutti i profili nel caso in cui sia stato 
        /// caricato in modalità domain
        /// </summary>
        /// <returns></returns>
        public List<domainprofileType> getDomainProfile()
        {
            throw new NotImplementedException("Not implemented yet");
        }
    }
}


