using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Microsoft.Tools.Deploy.Common
{
	public static class LocHelper
	{
		public static string FormatCurrentCulture(string format, params object[] args)
		{
			return string.Format(CultureInfo.CurrentCulture, format, args);
		}

		public static void PrintCurrentCulture(string format, params object[] args)
		{
			Console.WriteLine(LocHelper.FormatCurrentCulture(format, args));
		}

		public static string FormatInvariantCulture(string format, params object[] args)
		{
			return string.Format(CultureInfo.InvariantCulture, format, args);
		}

		public static void PrintInvariantCulture(string format, params object[] args)
		{
			Console.WriteLine(LocHelper.FormatInvariantCulture(format, args));
		}

		public static StringBuilder AppendFormatInvariant(this StringBuilder builder, string format, params object[] args)
		{
			return builder.AppendFormat(CultureInfo.InvariantCulture, format, args);
		}

		public static void SetThreadLanguage(params string[] args)
		{
			if (args.Length != 1)
			{
				throw new IndexOutOfRangeException();
			}
			string language = args[0];
			CultureInfo requestedLanguage = LocHelper.GetRequestedLanguage(language);
			Thread.CurrentThread.CurrentUICulture = requestedLanguage;
			CultureInfo.DefaultThreadCurrentUICulture = requestedLanguage;
		}

		private static CultureInfo GetRequestedLanguage(string language)
		{
			if (!string.IsNullOrEmpty(language))
			{
				try
				{
					return LocHelper.ParseLanguage(language);
				}
				catch (Exception)
				{
				}
			}
			return Thread.CurrentThread.CurrentCulture;
		}

		private static CultureInfo ParseLanguage(string language)
		{
			int culture;
			CultureInfo result;
			if (int.TryParse(language, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out culture))
			{
				result = new CultureInfo(culture);
			}
			else
			{
				result = new CultureInfo(language);
			}
			return result;
		}
	}
}
