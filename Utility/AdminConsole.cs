using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BandyServer.Core;

namespace BandyServer.Utility {
	public static class AdminConsole {

		/// <summary>
		/// Writes a line to the Admin Console.
		/// </summary>
		/// <param name="LineType">Type of line to write.</param>
		/// <param name="Text">Text to write on the line.</param>
		public static void WriteLine(LogLineType LineType, String Text) {
			String LogString = DateTime.Now.ToString("[hh:mm:ss.f]") + " [";
			if (LineType == LogLineType.Error) { LogString += "ERROR"; } else if (LineType == LogLineType.Warning) { LogString += " WARN"; } else if (LineType == LogLineType.Information) { LogString += " INFO"; } else if (LineType == LogLineType.Debug) { LogString += "DEBUG"; }
			LogString += "] " + Text + "\n";
			Write(LineType, LogString);
		}

		/// <summary>
		/// Writes an chunk of text to the Admin Console.
		/// </summary>
		/// <param name="LineType">Type of line to write.</param>
		/// <param name="Text">Text to write on the line.</param>
		public static void Write(LogLineType LineType, String Text) {
			if (Config.Option["ConsoleLogLevel"] == "DEBUG") {
				Console.Write(Text);
			} else if (Config.Option["ConsoleLogLevel"] == "INFORMATION") {
				if ((LineType == LogLineType.Information) || (LineType == LogLineType.Warning) || (LineType == LogLineType.Error)) {
					Console.Write(Text);
				}
			} else if (Config.Option["ConsoleLogLevel"] == "WARNING") {
				if ((LineType == LogLineType.Warning) || (LineType == LogLineType.Error)) {
					Console.Write(Text);
				}
			} else if (Config.Option["ConsoleLogLevel"] == "ERROR") {
				if (LineType == LogLineType.Error) {
					Console.Write(Text);
				}
			}
		}

	}
}
