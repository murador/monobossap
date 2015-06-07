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
using System.Collections.Generic;

namespace MonoBoss.Kernel.Common
{
	/// <summary>
	/// Generic class to manipulate command
	/// every command has the following structure: 
	///  --verb param1 param2 etc ... 
    ///  Per il momento la shell è stata hardcoded
	/// </summary>
	public class Command
	{

		protected string verb;

		public string getVerb { get { return verb; } }
	
		protected List<string> parameters;

		public List<string> getParameters { get { return parameters; } }


		public Command ()
		{
		}

		public Command (string verb)
		{
			this.verb = verb; 
			parameters = new List<string> ();
		}

		public Command (string verb, List<string> param)
		{
			this.verb = verb; 
			this.parameters = param;
		}

		public void addParameter (string param)
		{
			this.parameters.Add (param);
		}
	}

	/// <summary>
	/// Command line.
	/// </summary>

	public abstract class CommandLine
	{

		protected List<Command> commands = new List<Command> ();

		public void addCommand (Command c)
		{
			commands.Add (c);
		}

		public Command getCommandByVerb (string verb)
		{
			foreach (Command c in commands) {
				if (String.Compare (c.getVerb, verb) == 0) {
					return c;
				}
			}
			return null;
		}

		public List<string> getParametersByVerbs ( string verb) {
	

			foreach (Command c in commands) {
			
				if (String.Compare (c.getVerb, verb )  ==  0) {
					return c.getParameters;
				}
			
			}
	
			return null; 
		}


		public abstract void parseCommands (string[] args, string[] verbs);
	
		public  bool checkVerb (string verb){
			foreach (Command c in commands) {
				if (String.Compare (c.getVerb, verb) == 0) {
					return true; 
				}
			}
			return false; 
		}
	}

	/// <summary>
	/// Questa 
	/// </summary>
	public class MBossServerCommand : CommandLine
	{
		#region implemented abstract members of CommandLine
        public MBossServerCommand() { 
           
        }
	
		public override void parseCommands (string[] args, string[] verbs)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}

	/// <summary>
	/// MShellCommand è una shell di amministrazione 
	/// </summary>
	public class MShellCommand: CommandLine
	{

		public MShellCommand() {
		}

		#region implemented abstract members of CommandLine
		
		public override void parseCommands (string[] args, string[] verbs)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}
