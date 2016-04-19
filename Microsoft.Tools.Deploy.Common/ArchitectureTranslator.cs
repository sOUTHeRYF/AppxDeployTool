using System;

namespace Microsoft.Tools.Deploy.Common
{
	public static class ArchitectureTranslator
	{
		public static string TranslateArchitecture(string inputArch)
		{
			inputArch = inputArch.ToLowerInvariant();
			string a;
			if ((a = inputArch) != null)
			{
				if (a == "x86")
				{
					return "x86";
				}
				if (a == "amd64" || a == "x64")
				{
					return "x64";
				}
				if (a == "arm")
				{
					return "arm";
				}
				if (a == "arm64")
				{
					return "arm64";
				}
			}
			return inputArch;
		}
	}
}
