using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoBoss.Kernel
{
	/// <summary>
	/// Descrive una lista di file sorgente 
	/// e percorsri associati al file sorgente
	/// Più moduli possono avere gli stessi file sorgente 
	/// </summary>
	public class Paths<T,A>
	{

		private A[] sourceList;
		private Dictionary<A,List<T>> allPaths;

		public Paths (A[] sourceList, Dictionary<A,List<T>> allPaths)
		{
	
			this.sourceList = sourceList; 
			this.allPaths = allPaths; 

		}

		public Dictionary<A,List<T>> getAllPaths ()
		{
			return allPaths;
		}

		public A[] getAllSourceList (A[] defVal) {
			A[] sourceList = this.sourceList; 
			return sourceList == null ? defVal : sourceList;  
		}

	}
}

