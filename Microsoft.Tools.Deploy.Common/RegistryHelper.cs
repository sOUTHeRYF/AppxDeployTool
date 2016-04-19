using Microsoft.DriverKit.Shared;
using Microsoft.Win32;
using System;
using System.IO;

namespace Microsoft.Tools.Deploy.Common
{
	public static class RegistryHelper
	{
		private const string THIRD_PARTY_KITS_SUBFOLDER = "Microsoft SDKs\\Windows Kits\\10";

		public static string GetWindowsKitsRoot()
		{
			return WdkUtilities.GetWdkInstallPath();
		}

		public static string Get3rdPartyKitsRoot()
		{
			Environment.SpecialFolder folder = Environment.Is64BitOperatingSystem ? Environment.SpecialFolder.ProgramFilesX86 : Environment.SpecialFolder.ProgramFiles;
			string folderPath = Environment.GetFolderPath(folder);
			return Path.Combine(folderPath, "Microsoft SDKs\\Windows Kits\\10");
		}

		public static T GetValueFromLocalMachineRegistry32<T>(string keyPath, string valueName)
		{
			return RegistryHelper.GetValueFromLocalMachineRegistry32<T>(keyPath, valueName, default(T));
		}

		public static T GetValueFromLocalMachineRegistry32<T>(string keyPath, string valueName, T defaultValue)
		{
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(keyPath))
				{
					if (registryKey2 != null)
					{
						object value = registryKey2.GetValue(valueName);
						if (value != null)
						{
							return (T)((object)value);
						}
					}
				}
			}
			return defaultValue;
		}
	}
}
