using System;
using System.Collections.Generic;

namespace Microsoft.Tools.Deploy.Common
{
	public class ArgsParser
	{
		public static IEnumerable<ParsedArg> ParseArgs(string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				ParsedArg parsedArg = new ParsedArg();
				string text = args[i];
				if (ArgsParser.IsNamedArg(text))
				{
					parsedArg.Name = text.Substring(1);
				}
				else
				{
					parsedArg.AddValue(text);
				}
				for (int j = i + 1; j < args.Length; j++)
				{
					string text2 = args[j];
					if (ArgsParser.IsNamedArg(text2))
					{
						break;
					}
					parsedArg.AddValue(text2);
					i = j;
				}
				yield return parsedArg;
			}
			yield break;
		}

		private static bool IsNamedArg(string arg)
		{
			char c = arg[0];
			return c == '/' || c == '-';
		}
	}
}
