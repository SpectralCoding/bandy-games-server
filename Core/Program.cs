using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BandyServer.Utility;

namespace BandyServer.Core {
	class Program {
		static void Main(String[] args) {
			Config.ParseCommandLineOptions(args);
			Config.LoadServerConfigFile();


			Console.WriteLine("Press ENTER to exit.");
			Console.ReadLine();
		}
	}
}
