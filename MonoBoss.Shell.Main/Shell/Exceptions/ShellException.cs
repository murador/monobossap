using System;

namespace MonoBoss.Shell.Main
{
	/// <summary>
	/// Crea una classe per gestire le 
	/// eccezioni 
	/// </summary>
	public class ShellException: Exception 
	{
		public ShellException ()
		{
		}

		public ShellException(string message) : base(message) {
			Console.WriteLine (message); 
		}
	}
}

