using System;


/// <summary>
/// Definisce l'anologo del modulo MSC di Jboss, 
/// Definizione del modulo: 
/// 
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

