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
    /// TODO: finire l'implementazione 
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
        public List<extension> getRequiredExtention()
        {

            IEnumerable<XElement> extentions =
                 from ext in serverconfig.Elements("extension")
                 select ext;


            List<extension> listext = new List<extension>();

            foreach (XElement xEle in extentions)
            {
                IEnumerable<XAttribute> attlist =
                        from att in xEle.DescendantsAndSelf().Attributes()
                        select att;
                
                int i = 0; 
                foreach (XAttribute att in attlist){
                    extension e = new extension(); 
                    e.module = att.Value;
                    listext.Add(e);
                }
            }
            return listext; 
        }
    }
}

