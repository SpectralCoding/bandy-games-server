using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BandyServer.Utility {
	public static class AdminConsole {

		public static void WriteLine(LogLineType LineType, String Message) {
			switch (LineType) {
				case LogLineType.Error:
					DateTime.Now.ToString("hh:mm:ss.fff [ERROR] " + Message);
					break;
				case LogLineType.Warning:
					DateTime.Now.ToString("hh:mm:ss.fff [WARN] " + Message);
					break;
				case LogLineType.Information:
					DateTime.Now.ToString("hh:mm:ss.fff [INFO] " + Message);
					break;
			}
		}

		public static void Write(String Message) {
			Console.Write(Message);
		}

	}
}
