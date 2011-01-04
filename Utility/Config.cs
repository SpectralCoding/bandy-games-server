using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace BandyServer.Utility {
	public static class Config {

		private static Dictionary<String, String> StartupOptions = new Dictionary<String, String>();
		private static Dictionary<String, String> ServerConfigFileOptions = new Dictionary<String, String>();
		public static Dictionary<String, String> ConfigurationOptions = new Dictionary<String, String>();

		/// <summary>
		/// Parses the command line options as passed into the executable as args.
		/// </summary>
		/// <param name="CommandLineArguments">Space delimited String array of command line arguments</param>
		public static void ParseCommandLineOptions(String[] CommandLineArguments) {
			int i = 0;
			String LastArg = String.Empty;
			foreach (String CurrentArg in CommandLineArguments) {
				if (CurrentArg.Substring(0, 2) == "--") {
					if ((LastArg.Length > 2) && (LastArg.Substring(0, 2) == "--")) {
						StartupOptions.Add(LastArg.Substring(2, LastArg.Length - 2), "ENABLED");
					}
				} else {
					StartupOptions.Add(LastArg.Substring(2, LastArg.Length - 2).ToLower(), CurrentArg);
				}
				LastArg = CurrentArg;
			}
		}

		/// <summary>
		/// Loads confirguation settings from the server's configuration file.
		/// </summary>
		public static void LoadServerConfigFile() {
			StreamReader ConfigReader;
			if (StartupOptions.ContainsKey("config")) {
				ConfigReader = new StreamReader(StartupOptions["config"]);
			} else {
				ConfigReader = new StreamReader("server.cfg");
			}
			String CurrentLine;
			while ((CurrentLine = ConfigReader.ReadLine()) != null) {
				if (CurrentLine.Length > 3) {
					if (CurrentLine.Substring(0, 1) != "#") {
						ServerConfigFileOptions.Add(CurrentLine.Substring(0, CurrentLine.IndexOf(' ')), CurrentLine.Substring(CurrentLine.IndexOf(' ') + 1, CurrentLine.Length - CurrentLine.IndexOf(' ') - 1));
					}
				}
			}
			ConfigReader.Close();
			CombineOptions();

		}

		/// <summary>
		/// Takes information from StartupOptions and ServerConfigFileOptions and combines them into ConfigurationOptions with StartupOptions having priority.
		/// </summary>
		private static void CombineOptions() {
			Dictionary<String, String> ParamaterToOption = new Dictionary<String, String>();
			#region Command Line Options
			ParamaterToOption.Add("listening-port", "ListeningPort");				// The port for the server to listen on. [1-65535]
			ParamaterToOption.Add("config", "ServerConfig");						// The configuration file for the server to use. [Any valid path]
			ParamaterToOption.Add("max-players", "MaxPlayers");						// The maximum number of players allowed on the server. [1-???]
			ParamaterToOption.Add("max-games", "MaxGames");							// The maximum number of games allowed to be concurrently played [1-???]
			ParamaterToOption.Add("chess", "Chess");								// Whether or not chess games are enabled [ENABLED|DISABLED]
			ParamaterToOption.Add("chess-max-spectators", "ChessMaxSpectators");	// The maximum number of spectators for a chess game. [1-???]
			#endregion
			foreach (KeyValuePair<String, String> KVPair in ServerConfigFileOptions) {
				ConfigurationOptions.Add(KVPair.Key, KVPair.Value);
			}
			foreach (KeyValuePair<String, String> KVPair in StartupOptions) {
				if (ConfigurationOptions.ContainsKey(ParamaterToOption[KVPair.Key])) {
					ConfigurationOptions[ParamaterToOption[KVPair.Key]] = KVPair.Value;
				} else {
					ConfigurationOptions.Add(ParamaterToOption[KVPair.Key], KVPair.Value);
				}
			}
		}

	}
}
