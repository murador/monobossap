/*
This file is part of MonoBoss Application Server.
    MonoBoss Application Server is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    MonoBoss Application Server is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with Nome-Programma.  If not, see <http://www.gnu.org/licenses/>.
*/

using MonoBoss.Kernel.Common;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;


namespace MonoBoss.Kernel
{
	/// <summary>
	/// Contiene le informazioni di instanza del server.
	/// Vedere la classe Server all'interno del ServerInstanceDomainModel.cs
	/// <b> NOTE: The implementation is inevitably incomplete for this first version. </b>
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
		public ServerInstance (XDocument doc, string mode)
		{
			serverconfig = doc;
			this.mode = mode;
		}


		/// <summary>
		/// Get alla extentions module required 
		/// </summary>
		/// <returns>returns a list of module required by the instance</returns>
		public List<Extension> getRequiredExtention ()
		{

			IEnumerable<XElement> extentions =
				from ext in serverconfig.Elements ("extension")
				select ext;


			List<Extension> listext = new List<Extension> ();

			foreach (XElement xEle in extentions) {
				IEnumerable<XAttribute> attlist =
					from att in xEle.DescendantsAndSelf ().Attributes ()
					select att;

				foreach (XAttribute att in attlist) {
					Extension e = new Extension ();
					e.module = att.Value;
					listext.Add (e);
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
		public List<securityrealmType> getSecurityRealms ()
		{

			List<securityrealmType> listrealms = new List<securityrealmType> ();
			IEnumerable<XElement> realms =
				from rs in serverconfig.Elements ("security-realms")
				select rs;

			foreach (XElement realm in realms) {
				// Recupero tutti i realm dentro il i realms
				// Ovvero: 
				IEnumerable<XElement> elem =
					from e in realm.Descendants ("security-realm")
					select e;

				foreach (XElement re in elem) {
					securityrealmType srealm = new securityrealmType ();
					srealm.name = re.Attribute ("name").Value;

					IEnumerable<XElement> auth =
						from e in re.Descendants ("authentication")
						select e;

					foreach (XElement a in auth) {

						IEnumerable<XElement> auth_attr =
							from e in re.Descendants ("properties")
							select e;
						foreach (XElement p in auth_attr) {
							srealm.authentication.truststore.path = p.Attribute ("path").Value;
							srealm.authentication.truststore.relativeto = p.Attribute ("relative-to").Value;
						}
					}
				}
			}
			return listrealms;
		}

		/// <summary>
		/// Ritorna le socket da occupare e richieste. 
		///  - Si specifica correttamente sia la porta che il nome. 
		///  - Deve essere necessariamente una socket dedicata al servizio di managment. 
		///  
		/// </summary>
		/// <returns></returns>
		public List<standalonesocketbindinggroupType> getSocketBindGroup ()
		{

			List<standalonesocketbindinggroupType> socketTypes = new List<standalonesocketbindinggroupType> (); 
			IEnumerable<XElement> elem =
				from e in serverconfig.Descendants ("socket-binding-group")
				select e;

			foreach (XElement s in elem) {
				standalonesocketbindinggroupType selem = new standalonesocketbindinggroupType (); 
				// this is the name of socket-bind-group
				selem.name = s.Attribute ("name").Value; 
				selem.portoffset = Int32.Parse (s.Attribute ("port-offset").Value);
				selem.defaultinterface = s.Attribute ("default-interface").Value;
				IEnumerable<XElement> sockets =
					from e in s.Descendants ("socket-binding")
					select e;
				List<socketbindingType> sb = new List<socketbindingType> (); 
				foreach (XElement so in sockets) {
					socketbindingType sb_elem = new socketbindingType (); 
					sb_elem.name = so.Attribute ("name").Value; 
					sb_elem.port = Convert.ToUInt16 (so.Attribute ("port").Value); 
					sb.Add (sb_elem); 
				}

				// reference here 
				selem.socketbinding = sb.ToArray (); 


				// Now we get the outbopud socket  
				IEnumerable<XElement> outbound_socket =
					from e in s.Descendants ("outbound-socket-binding")
					select e;
				// the outbound socket , are socket the send output request from server
				// such as, smtp email 
				List<outboundsocketbindingType> ob = new List<outboundsocketbindingType> (); 
				foreach (XElement o in outbound_socket) {
					outboundsocketbindingType out_sock = new outboundsocketbindingType (); 
					out_sock.name = o.Attribute ("name").Value;
					IEnumerable<XElement> re_des =
						from e in o.Descendants ("remote-destination")
						select e;

					// List<remotedestinationType> rems = new List<remotedestinationType> (); 
					foreach (XElement r  in re_des) {
						remotedestinationType res_des = new remotedestinationType (); 
						res_des.host = r.Attribute ("host").Value; 
						res_des.port = r.Attribute ("port").Value; 
						// possiamo avere al massimo una destinazione remota
						// altrimenti abbia 
						out_sock.Item = (remotedestinationType)res_des;  
					}
					ob.Add (out_sock); 
				}
				selem.outboundsocketbinding = ob.ToArray (); 
				socketTypes.Add (selem); 					
			}
			return socketTypes; 
		}

		/// <summary>
		/// Qui si fa il binding della porta con un indirizzo IP secondo 
		/// quanto specificato nelle interfacce
		/// </summary>
		/// <returns></returns>
		public List<specifiedinterfaceType> getRequiredInterfaces ()
		{
			throw new NotImplementedException ("Not implemented yet");
		}

		/// <summary>
		/// Get all profile in standalone mode. Note. 
		///
		/// </summary>
		/// <returns></returns>
		public List<standaloneprofileType> getStandAloneProfile ()
		{
			throw new NotImplementedException ("Not implemeted yet");
		}

		/// <summary>
		/// Si recuperano tutti i profili nel caso in cui sia stato 
		/// caricato in modalità domain
		/// </summary>
		/// <returns></returns>
		public List<domainprofileType> getDomainProfile ()
		{
			throw new NotImplementedException ("Not implemented yet");
		}
	}
}


