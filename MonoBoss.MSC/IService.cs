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

/// <summary>
/// Definisce l'anologo del modulo MSC di Jboss, 
/// Definizione del modulo:
/// Provide a way to install ,uninstall, and manage services used by a container.
/// MSC further enables resources injection into services
/// and dependency management between services. 
/// Questo viene fatto prima del caricamenti di qualsiasi altro modulo. 
/// 
/// 
/// 
/// </summary>

namespace MonoBoss.MSC
{

	/// <summary>
	/// Interfaccia principale per la definizioe 
	/// di un nuovo servizio
	/// </summary>
	public interface IService<T> {
	}

}

