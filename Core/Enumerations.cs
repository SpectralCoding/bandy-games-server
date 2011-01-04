using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BandyServer.Core {

	public enum CommandLineOptions {
		ServerConfigFile,
		GameConfigFile,
		ListeningPort,
		MaxPlayers,
		Unknown
	}

	public enum ConfigurationOptions {
		ServerConfigFile,
		GameConfigFile,
		ListeningPort,
		MaxPlayers,
		Unknown
	}

	public enum LogLineType {
		Error,
		Warning,
		Information,
		Debug
	}

	public enum ErrorType {
		Fatal,
		Warning
	}

}
