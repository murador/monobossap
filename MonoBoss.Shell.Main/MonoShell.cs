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
using System.Configuration;  
using MonoBoss.Kernel;
using MonoBoss.Logger.Service; 
namespace MonoBoss.Shell.Main
{
	/// <summary>
	/// Da linea di comando sono necessari 
	/// i seguenti parametri , ossia il percorso dove risiedono 
	/// i moduli , la modalità di esecuzione 
	///             ::> in standalone   la sola possibile esecuzioen per ora 
	///             ::> domain,         gestione su dominio di un cluster di server
	/// Copyright(C) - Gianfranco Murador (C) 2015 
    /// Microservice applications for Mono and MS .net Framework
	/// </summary>
	class MonoBossShellMain
	{
		public static void Main (string[] args)
		{

			// Inizialize the kernel  
			// prompt the shell and execute the action request
			// 
			// trovare un meccanismo per caricare la classe in modo dinamico per il momento  
			// carico l'implementazione di default
			// Deinisce la versione di default del kernel in base 
			// ai parametri 
			MonoBossKernel.setInstance (new DefaultMonoBossKernel ());

            // Fa partire ed inizializzare il logger, per questa prima versione 
            // usiamo solamente ed unicamente  NLog, per come è stato implementato 
            // possiamo usare un nuovo logger 
            LoggerServiceFactory.setInstance(new NLoggerServiceFactory());
            

			// Fa partire la shell
			MonoBossShell shell = new MonoBossShell (); 

			// processa la linea di comando 
			shell.processCommandLine(args); 

			// fa partire l'ambiente 
			// in questa fase vengono letti i parametri di instanza 
			// del server
			shell.startEnviroment(); 

		}
	}
}
