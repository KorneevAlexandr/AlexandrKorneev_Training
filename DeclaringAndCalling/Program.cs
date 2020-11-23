using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBakery;

namespace DeclaringAndCalling
{
	/// <summary>
	/// Begin class
	/// </summary>
	class Program
	{
		/// <summary>
		/// Program entry point
		/// </summary>
		/// <param name="args">Arguments method Main</param>
		static void Main(string[] args)
		{
			Menu menu = new Menu();
			menu.ShowMenu();
		}
	}
}
