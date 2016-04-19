using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Tools.Deploy.Host.Cmd
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Microsoft.Tools.Deploy.Host.Cmd.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static string CopyrightLine
		{
			get
			{
				return Resources.ResourceManager.GetString("CopyrightLine", Resources.resourceCulture);
			}
		}

		internal static string ExceptionErrorPattern
		{
			get
			{
				return Resources.ResourceManager.GetString("ExceptionErrorPattern", Resources.resourceCulture);
			}
		}

		internal static string ExceptionNeedPin
		{
			get
			{
				return Resources.ResourceManager.GetString("ExceptionNeedPin", Resources.resourceCulture);
			}
		}

		internal static string ExceptionVerbNotImplemented
		{
			get
			{
				return Resources.ResourceManager.GetString("ExceptionVerbNotImplemented", Resources.resourceCulture);
			}
		}

		internal static string HelloMessage
		{
			get
			{
				return Resources.ResourceManager.GetString("HelloMessage", Resources.resourceCulture);
			}
		}

		internal static string SpacerLine
		{
			get
			{
				return Resources.ResourceManager.GetString("SpacerLine", Resources.resourceCulture);
			}
		}

		internal static string StatusOverallComplete
		{
			get
			{
				return Resources.ResourceManager.GetString("StatusOverallComplete", Resources.resourceCulture);
			}
		}

		internal static string UsageInstructions
		{
			get
			{
				return Resources.ResourceManager.GetString("UsageInstructions", Resources.resourceCulture);
			}
		}

		internal static string VersionLine
		{
			get
			{
				return Resources.ResourceManager.GetString("VersionLine", Resources.resourceCulture);
			}
		}

		internal Resources()
		{
		}
	}
}
