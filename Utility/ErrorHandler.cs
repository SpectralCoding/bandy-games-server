using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BandyServer.Core;

namespace BandyServer.Utility {
	public static class ErrorHandler {

		/// <summary>
		/// Handles custom generated error messages.
		/// </summary>
		/// <param name="ErrorType">ErrorType enum indicating the severity of the error.</param>
		/// <param name="Message">Message describing the error.</param>
		public static void Handle(ErrorType ErrorType, String Message) {
			switch (ErrorType) {
				case ErrorType.Fatal:
					Log.WriteLine(LogLineType.Error, Message);
					Environment.Exit(0);
					break;
				case ErrorType.Warning:
					Log.WriteLine(LogLineType.Warning, Message);
					break;
			}
		}

		/// <summary>
		/// Handles automatically generated exceptions.
		/// </summary>
		/// <param name="ErrorType">ErrorType enum indicating the severity of the error.</param>
		/// <param name="Exception">Exception object containing a Message and InnerException.</param>
		public static void Handle(ErrorType ErrorType, Exception Exception) {
			switch (ErrorType) {
				case ErrorType.Fatal:
					if (Exception.InnerException == null) {
						Log.WriteLine(LogLineType.Error, Exception.Message);
					} else {
						Log.WriteLine(LogLineType.Error, Exception.Message + " (" + Exception.InnerException + ")");
					}
					Environment.Exit(0);
					break;
				case ErrorType.Warning:
					if (Exception.InnerException == null) {
						Log.WriteLine(LogLineType.Warning, Exception.Message);
					} else {
						Log.WriteLine(LogLineType.Warning, Exception.Message + " (" + Exception.InnerException + ")");
					}
					break;
			}
		}


	}
}
