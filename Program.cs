using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BandyServer.Utility;

namespace BandyServer {
	class Program {
		static void Main(String[] args) {
			Config.SetDefaultOptions();
			Config.ParseCommandLineOptions(args);
			Config.LoadServerConfigFile();


			Console.WriteLine("Press ENTER to exit.");
			Console.ReadLine();
		}
	}
}
