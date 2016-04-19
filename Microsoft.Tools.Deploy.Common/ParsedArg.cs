using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Tools.Deploy.Common
{
	public class ParsedArg
	{
		private List<string> values = new List<string>();

		public string Name
		{
			get;
			set;
		}

		public ReadOnlyCollection<string> Values
		{
			get
			{
				return this.values.AsReadOnly();
			}
		}

		public void AddValue(string value)
		{
			this.values.Add(value);
		}
	}
}
