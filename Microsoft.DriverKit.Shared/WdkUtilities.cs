using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Microsoft.DriverKit.Shared
{
	internal static class WdkUtilities
	{
		private const string DefaultInstallKey = "Software\\Microsoft\\Windows Kits\\Installed Roots";

		private const string DefaultInstall64Key = "Software\\Wow6432Node\\Microsoft\\Windows Kits\\Installed Roots";

		private const string EnvVarInstallPath = "WDKContentRoot";

		private const string DefaultInstallValueName = "KitsRoot10";

		private const string TaefFolder = "Testing\\Runtimes\\TAEF";

		private const string ToolsChildFolder = "Tools\\x86";

		private const string KitBinaryFolder = "bin";

		private const string X86Folder = "x86";

		private const string AssemblyExtension = ".dll";

		private const string VisualStudioInstallValue = "ShellFolder";

		public static bool IsWdkInstalled()
		{
			string wdkInstallPath = WdkUtilities.GetWdkInstallPath();
			return !string.IsNullOrWhiteSpace(wdkInstallPath) && Directory.Exists(wdkInstallPath);
		}

		public static string GetWdkInstallPath()
		{
			string text = Environment.GetEnvironmentVariable("WDKContentRoot");
			if (text == null || !Directory.Exists(text))
			{
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
				RegistryKey registryKey2 = registryKey.OpenSubKey("Software\\Microsoft\\Windows Kits\\Installed Roots") ?? registryKey.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows Kits\\Installed Roots");
				if (registryKey2 != null)
				{
					string text2 = (string)registryKey2.GetValue("KitsRoot10");
					if (!string.IsNullOrEmpty(text2))
					{
						text = text2;
					}
				}
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}
			return text;
		}

		public static Assembly AssemblyResolveHandler(object sender, ResolveEventArgs args)
		{
			List<string> list = new List<string>();
			int num = args.Name.IndexOf(',');
			string text = (num > -1) ? args.Name.Substring(0, num) : args.Name;
			if (!text.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
			{
				text += ".dll";
			}
			list.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
			string wdkInstallPath = WdkUtilities.GetWdkInstallPath();
			list.Add(Path.Combine(wdkInstallPath, "bin", "x86"));
			list.Add(Path.Combine(wdkInstallPath, "bin"));
			list.Add(Path.Combine(wdkInstallPath, "Tools\\x86"));
			list.Add(Path.Combine(wdkInstallPath, "Testing\\Runtimes\\TAEF", "x86"));
			list.Add(Path.Combine(wdkInstallPath, "Testing\\Runtimes\\TAEF"));
			foreach (string current in list)
			{
				try
				{
					string text2 = Path.Combine(current, text);
					if (File.Exists(text2))
					{
						Assembly assembly = Assembly.LoadFrom(text2);
						if (assembly != null)
						{
							return assembly;
						}
					}
				}
				catch (Exception)
				{
				}
			}
			return null;
		}
	}
}
