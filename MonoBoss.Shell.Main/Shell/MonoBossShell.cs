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
using System;
using MonoBoss.Kernel.Common;
using MonoBoss.Kernel; 
using MonoBoss.Kernel.Loaders; 

/// <summary>
/// Define the main shell, using Command parser
/// every parameter
/// </summary>
namespace MonoBoss.Shell.Main
{

	public class MonoBossShell
	{
	
		const string VERSION = "1.0Valpha";
		private string bootModule; 
		private string pathToModuleDir; 
		private string mode = null; 

		/// <summary>
		/// Stampa a video gli use case,
		/// </summary>
		public void printUsage() {

			Console.WriteLine ("Usage:\n"+"\tMonoBoss.Shell.Main -mp [PathToModuleDir] -s bootModule -m [mode] "); 
			Console.WriteLine ("\t-help print this message"); 
			Console.WriteLine ("\t-mp path of module folder");
			Console.WriteLine ("\t-s boostrap module");
			Console.WriteLine ("\t-version version of Mono Module Loader");
			Console.WriteLine ("\t-m Domain or StandAlone (deprecated)");
			Console.WriteLine ("Licence GPL "); 
			Console.WriteLine ("for any suggestions write to murador.gianfranco@gmail.com"); 

		}
	
		/// <summary>
		/// Initializes a new instance of the <see cref="MonoBoss.Shell.Main.MonoBossShell"/> class.
		/// 
		/// </summary>
		public MonoBossShell ()
		{
			// default constructor service 
		}
	

		/// <summary>
		/// Parsa gli argomenti in input, in particolare 
		/// 
		/// </summary>
		/// <param name="args">Arguments.</param>
		public void processCommandLine(string[] args) {
		
			if (args.Length <= 1) {	
				Console.WriteLine ("Error in arguments");
				printUsage ();	
			}

			for (int i = 0; i < args.Length; i ++) {
			
				if (String.Compare (args [i], "-mp") == 0) {

					if (i + 1 > args.Length) {
						Console.WriteLine ("Error, expected PathToModuleDir"); 
						printUsage ();
					} else {
						pathToModuleDir = args [i + 1];
					}
				}

				if (String.Compare (args [i], "-s") == 0) {
					if (i + 1 > args.Length) {
						Console.WriteLine ("Error, expected bootModule namespace");
						printUsage ();
					} else {
						bootModule = args [i + 1];
					}
				}

				/// visualizza il messaggio di help 
				if ( String.Compare(args[i], "-help") == 0 ) {
					printUsage(); 
					System.Environment.Exit(0);
				}

				/// visualizza la versione
				if (String.Compare(args[i], "-version") == 0) {
					Console.WriteLine("Version: " + VERSION);
					System.Environment.Exit(0);
				}

				/// visualizza la versione
				if (String.Compare(args[i], "-mode") == 0) {
					if (i + 1 > args.Length) {
						Console.WriteLine ("Error, expected mode flag");
						printUsage ();
					} else {
						mode = args [i + 1];
					}
				}

			
			} 

		}
	
		/// <summary>
		/// Fa+-* partire l'ambiente, carica 
		/// le configurazioni ed il primo modulo 
		/// </summary>
		public void startEnviroment() {
	
			try {
				/// leggo il file di configurazione in input per la shell 
				string standalone = "standalone.xml"; 
				string domain = "domain.xml"; 

				ConfigurationManager cm = new DefaultConfigurationManager();
				AppConfiguration aConfig  = cm.load();						

				/// Inizilizza un primo module lodaer 
				MonoBossKernel kernel =  MonoBossKernel.getInstance (); 

				/// recupera il module loader 
				ModuleLoader mloader =  kernel.getModuleLoader(); 

				/// recupera l'instanza del server in base ai parametri
				ServerConfigurationReader sr = new ServerConfigurationReader(); 
			    
				if ( mode == null )  {
                    // se non specifico la modalia di esecuzionea allora 
                    // faccio partire il tutto in modalità standalone.
                    mode = "standalone";
                    sr.filePath = aConfig.configurationDir + "StandAlone\\Configuration\\" + standalone;     
				} else {
				 if ( mode == "standalone" ) {
                     sr.filePath = aConfig.configurationDir + "StandAlone\\Configuration\\" + standalone;     
				} else {
						if ( mode == "domain" ) {
                            sr.filePath = aConfig.configurationDir + "Domain\\Configuration\\" + domain;
						} else {  
							throw new ShellException("Mode not recognized"); 
						}	 
					}
				}

                sr.configSchemaPath = aConfig.configurationDir + "\\Docs\\Schema\\";


				 // carica il file e valida se è tutto correttamente
				 // definito in base allo x-schema, in questa 
		         sr.load(true, mode); 
				 
				 // Recupero un oggetto che mantiene le configurazioni 
				 // che sono definite all'interno del file .xml ( standalone o domain) 
                 // 17/05/2015 - TODO, continuare ad implementare in questo punto 
			     ServerInstance serverInstance  = sr.getServerInstance();
                 
				// mloader.initLoader(); 
			 	// mmloader.start(); 

			     
				} catch (Exception ex ) {
					throw new ShellException (ex.ToString ()); 
				}
	
		}

	}
}

