using System;
using MonoBoss.Kernel.Modules; 
using System.Collections;
using System.Collections.Generic;
using MonoBoss.Kernel.Common;
namespace MonoBoss.Kernel
{

	/// <summary>
	/// Specifica di una classe 
	/// </summary>
	public class ClassSpec {


	}


	/// <summary>
	/// Al posto del packagespec è1 possiible 
	/// usare questa definitzione 
	/// </summary>
	public class NamespaceSpec {


	}




	/// <summary>
	///  A {@code Module} specification which is used by a {@code ModuleLoader} to define new modules
	/// </summary>
	public abstract class ModuleSpec
	{
		private ModuleIdentifier moduleIdentifier; 

		public ModuleSpec() {}

		public ModuleSpec(ModuleIdentifier moduleIdentifier) {
			this.moduleIdentifier = moduleIdentifier; 
		}

		/// <summary>
		/// Costruisce una nuova specifica
		/// </summary>
		/// <param name="moduleIdentifier">Module identifier.</param>
		public static Builder build (ModuleIdentifier moduleIdentifier) {
			if (moduleIdentifier == null) {
				throw new ArgumentException ("ERROR: provide a valid module indentifier"); 
			}
			return new BuilderImpl(moduleIdentifier);
		}


		/// <summary>
		/// crea un alias per il modulo, ossia all'interno del sistema posso riferire 
		/// ad uno stesso modulo tramite il suo alias. 
		/// </summary>
		/// <returns>The alias.</returns>
		/// <param name="moduleIdentifier">Module identifier.</param>
		/// <param name="aliasTarget">Alias target, ossia il nome dell'alias </param>
		public static AliasBuilder buildAlias(ModuleIdentifier moduleIdentifier,
		                                      ModuleIdentifier aliasTarget) {

			if (moduleIdentifier == null) {
				throw new ArgumentException ("[ERROR] - moduleIdentifier is null");
			}

			if (aliasTarget == null) {
				throw new ArgumentException ("[ERROR] - aliasTarget is null"); 
			}

			AliasBuilder aliasBuilder = new AliasBuilderImpl (); 
			aliasBuilder.create (moduleIdentifier, aliasTarget); 
			return aliasBuilder;

		}

		/// <summary>
		/// Ritorna l'identificatore associato alla specifica del modulo 
		/// </summary>
		/// <returns>The module identifier.</returns>
		public ModuleIdentifier getModuleIdentifier () {
			return moduleIdentifier; 
		}
		
	}

	public  class AliasModuleSpec : ModuleSpec {
		private ModuleIdentifier aliasTarget; 
		public AliasModuleSpec(ModuleIdentifier moduleIdentifier, ModuleIdentifier aliasTarget) : base(moduleIdentifier){
			this.aliasTarget = aliasTarget;
		}
		public ModuleIdentifier getAliasTarget () {
			return aliasTarget; 
		}

	}

	/// <summary>
	/// Alias builder
	/// </summary>
	public interface AliasBuilder {
		ModuleSpec create(ModuleIdentifier ident, ModuleIdentifier alias);
		ModuleIdentifier getIdentifier(); 
		ModuleIdentifier getAliasTarget(); 
	
	}

	public class AliasBuilderImpl: AliasBuilder {
		#region AliasBuilder implementation

		private ModuleIdentifier moduleIdentifier; 
		private ModuleIdentifier aliasTarget; 

		public ModuleSpec create (ModuleIdentifier ident, ModuleIdentifier alias)
		{
			moduleIdentifier = ident; 
			aliasTarget = alias;
			return new AliasModuleSpec (ident, alias);	
		}

		public ModuleIdentifier getIdentifier ()
		{
			return moduleIdentifier;
		}

		public ModuleIdentifier getAliasTarget ()
		{
			return aliasTarget;
		}

		#endregion
}


	public interface Builder {

		// deifinisce la classe main del modulo
		// ossia il modul loader prendera: mainClass.Main(string args) come entry point
		Builder setMainClass(string mainClass); 

		// aggiunge una dipendenza al modulo 
		Builder addDependecy(DependencySpec dp);

		Builder addResourceRoot (ResourceLoaderSpec resourceLoader); 

		Builder setAssertionSetting (AssertionSetting assertionSetting); 

		ModuleSpec create ();

		ModuleIdentifier getModuleIdentifier ();

		Builder addProperty (string name, string value); 


	}

	

	public class BuilderImpl: Builder {


		private IDictionary<string,string> properties = new Dictionary<string, string>(); 
		private string mainClass = ""; 
		private AssertionSetting assertionSetting = AssertionSetting.INHERIT;
		private List<ResourceLoaderSpec> resourceLoaders = new List<ResourceLoaderSpec> ();
		private List<DependencySpec> dependencies = new List<DependencySpec> ();
		private ModuleIdentifier modIdent; 


		#region BuilderImplementation

		public Builder setAssertionSetting (AssertionSetting assertionSetting)
		{
			this.assertionSetting = assertionSetting;
			return this;
		}
		

		Builder Builder.addProperty (string name, string value)
		{
			properties.Add (name, value);
			return this;
		}
		
		public ModuleSpec create () { 
			return new ConcreteModuleSpec();
		}

		public ModuleIdentifier getModuleIdentifier ()
		{
			return modIdent;
		}

		public BuilderImpl(){
		}
		public BuilderImpl(ModuleIdentifier id) {
			modIdent = id;
		}

		public  Builder setMainClass(string mainClass) {
			this.mainClass = mainClass;
			return this; 
		}

		public Builder addDependecy(DependencySpec dp ) { 
			dependencies.Add (dp);
			return this; 
		}

		public Builder addResourceRoot (ResourceLoaderSpec resourceLoader)
		{
			resourceLoaders.Add (resourceLoader);
			return this;
		}

		#endregion

	}


	#region ConcreteModuleSpec 

	/// <summary>
	/// Implementation of abstract class ModuleSpec
	/// </summary>
	public class ConcreteModuleSpec: ModuleSpec {
		public ConcreteModuleSpec(){
		
		}
	}
	#endregion 



}


