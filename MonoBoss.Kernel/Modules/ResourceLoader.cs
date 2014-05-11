using System;

namespace MonoBoss.Kernel
{

	/// <summary>
	/// Defisce l'interfaccia di un singolo ResourceLoader
	/// </summary>
	public interface ResourceLoader
	{
		string rootName {get; set;}



	}; 



	/// <summary>
	/// Definisce una classe per il mantenimento di un insieme di 
	/// ResourceLoaders
	/// </summary>
	public class ResourceLoaders {



	}; 


	// NOTA; TUTTO QUESTO CODICE DEVE ESSERE SPOSTATO IN UN FILE APPOSITO 
	// UNA VOLTA COMPLETATO IL PRIMO RILASCIO. AL MOMENTO c# NON HA UN MECCANISMO 
	// DI GESTIONE DELLE RISORSE SIMILE A QUELLO DI J2EE. 

	/// <summary>
	/// Abstract resource loader.
	/// </summary>
	public abstract class AbstractResourceLoader {



	}; 


	/// <summary>
	/// Native dll loader.
	/// </summary>
	public class NativeDllLoader : AbstractResourceLoader {
	
	}; 


	/// <summary>
	/// All'interno della class ResourcesLoader 
	/// </summary>
	public class FileResourceLoader : NativeDllLoader {


	}; 










}

 