using MonoBoss.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Xml;

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

        private XmlDocument serverconfig;

        // mode
        private string mode;

        /// <summary>
        /// Costruttore di default
        /// </summary>
        public ServerInstance(XmlDocument doc, string mode){
            serverconfig = doc;
            this.mode = mode;
        }
    }
}

