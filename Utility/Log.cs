using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BandyServer.Core;

namespace BandyServer.Utility {
	public static class Log {

		private static StreamWriter LogWriter;

		/// <summary>
		/// Writes a line to the log file. Creates a new timestamped log file if none exists.
		/// </summary>
		/// <param name="LineType">The type of line to log,</param>
		/// <param name="Text">The text to be on the line.</param>
		public static void WriteLine(LogLineType LineType, String Text) {
			if (LogWriter == null) {
				if (!Directory.Exists("Logs")) {
					Directory.CreateDirectory("Logs");
				}
				LogWriter = new StreamWriter("Logs\\" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".log");
				LogWriter.AutoFlush = true;
			}
			String LogString = DateTime.Now.ToString("[MM/dd/yy @ hh:mm:ss.f]") + " [";
			if (LineType == LogLineType.Error) { LogString += "ERROR"; } else if (LineType == LogLineType.Warning) { LogString += " WARN"; } else if (LineType == LogLineType.Information) { LogString += " INFO"; } else if (LineType == LogLineType.Debug) { LogString += "DEBUG"; }
			LogString += "] " + Text;
			if (Config.Option["LogLevel"] == "DEBUG") {
				LogWriter.WriteLine(LogString);
			} else if (Config.Option["LogLevel"] == "INFORMATION") {
				if ((LineType == LogLineType.Information) || (LineType == LogLineType.Warning) || (LineType == LogLineType.Error)) {
					LogWriter.WriteLine(LogString);
				}
			} else if (Config.Option["LogLevel"] == "WARNING") {
				if ((LineType == LogLineType.Warning) || (LineType == LogLineType.Error)) {
					LogWriter.WriteLine(LogString);
				}
			} else if (Config.Option["LogLevel"] == "ERROR") {
				if (LineType == LogLineType.Error) {
					LogWriter.WriteLine(LogString);
				}
			}
			AdminConsole.WriteLine(LineType, Text);
		}

	}
}
