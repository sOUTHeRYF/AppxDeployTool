using Microsoft.Tools.Deploy.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Microsoft.Tools.Deploy.Host.Cmd
{
	public sealed class ArgsProcessor
	{
		public ConnectivityOptions ConnectivityOptions
		{
			get;
			private set;
		}

		public TimeSpan DeviceScanTimeout
		{
			get;
			private set;
		}

		public FileInfo PackageFile
		{
			get;
			private set;
		}

		public string PackageFullName
		{
			get;
			private set;
		}

		public FileInfo PackageCertFile
		{
			get;
			private set;
		}

		public List<FileInfo> DependencyFiles
		{
			get;
			private set;
		}

		public Verbs Verb
		{
			get;
			private set;
		}
		public bool ShowUsage
		{
            get;
            private set;
		}

		public ArgsProcessor()
		{
			this.Verb = Verbs.None;
			this.DependencyFiles = new List<FileInfo>();
			this.ConnectivityOptions = new ConnectivityOptions();
		}

		public void PrintUsage()
		{
			Program.Instance.LogOut(Resources.UsageInstructions, new object[0]);
		}

		public void ParseArgs(string[] args)
		{
			foreach (ParsedArg current in ArgsParser.ParseArgs(args))
			{
				if (string.IsNullOrEmpty(current.Name))
				{
					if (current.Values.Count < 1 || this.Verb != Verbs.None)
					{
						this.ShowUsage = true;
						break;
					}
					string a = current.Values[0].ToUpperInvariant();
					string[] array = current.Values.Skip(1).ToArray<string>();
					if (a == "DEVICES")
					{
						if (this.Verb != Verbs.None || array.Length > 1)
						{
							this.ShowUsage = true;
						}
						else if (array.Length == 1)
						{
							int num;
							if (!int.TryParse(array[0], out num))
							{
								this.ShowUsage = true;
							}
							else if (num < 1)
							{
								this.ShowUsage = true;
							}
							else
							{
								this.DeviceScanTimeout = new TimeSpan(0, 0, num);
							}
						}
						else
						{
							this.DeviceScanTimeout = new TimeSpan(0, 0, 10);
						}
						if (!this.ShowUsage)
						{
							this.Verb = Verbs.Devices;
						}
					}
					else if (a == "INSTALL")
					{
						this.CheckAndSetVerb(Verbs.Install, array);
					}
					else if (a == "UPDATE")
					{
						this.CheckAndSetVerb(Verbs.Update, array);
					}
					else if (a == "UNINSTALL")
					{
						this.CheckAndSetVerb(Verbs.Uninstall, array);
					}
					else
					{
						if (!(a == "LIST"))
						{
							this.ShowUsage = true;
							break;
						}
						if (this.Verb != Verbs.None || array.Length > 0)
						{
							this.ShowUsage = true;
						}
						else
						{
							this.Verb = Verbs.List;
						}
					}
				}
				else
				{
					string a2 = current.Name.ToUpperInvariant();
					if (a2 == "FILE" || a2 == "F")
					{
						if (current.Values.Count != 1 || !ArgsProcessor.IsValidFileExtension(current.Values[0]) || this.PackageFile != null)
						{
							this.ShowUsage = true;
						}
						else
						{
							this.PackageFile = new FileInfo(current.Values[0]);
						}
					}
					else if (a2 == "CERT" || a2 == "C")
					{
						if (current.Values.Count != 1 || this.PackageCertFile != null)
						{
							this.ShowUsage = true;
						}
						else
						{
							this.PackageCertFile = new FileInfo(current.Values[0]);
						}
					}
					else if (a2 == "DEPENDENCY" || a2 == "D")
					{
						if (current.Values.Count >= 1)
						{
							if (!current.Values.Any((string val) => !ArgsProcessor.IsValidFileExtension(val)))
							{
								this.DependencyFiles.AddRange(from val in current.Values
								select new FileInfo(val));
								goto IL_52A;
							}
						}
						this.ShowUsage = true;
					}
					else if (a2 == "IP")
					{
						IPAddress iPAddress;
						if (current.Values.Count != 1)
						{
							this.ShowUsage = true;
						}
						else if (!IPAddress.TryParse(current.Values[0], out iPAddress))
						{
							this.ShowUsage = true;
						}
						else
						{
							this.ConnectivityOptions.IPAddress = iPAddress;
						}
					}
					else if (a2 == "GUID" || a2 == "G")
					{
						Guid guid;
						if (current.Values.Count != 1)
						{
							this.ShowUsage = true;
						}
						else if (!Guid.TryParse(current.Values[0], out guid))
						{
							this.ShowUsage = true;
						}
						else
						{
							this.ConnectivityOptions.Guid = guid;
						}
					}
					else if (a2 == "PIN")
					{
						if (current.Values.Count != 1)
						{
							this.ShowUsage = true;
						}
						else
						{
							this.ConnectivityOptions.Password = current.Values[0];
						}
					}
					else if (a2 == "ARCH")
					{
						if (current.Values.Count != 1)
						{
							this.ShowUsage = true;
						}
						else if (!string.IsNullOrEmpty(this.ConnectivityOptions.ArchitectureOverride))
						{
							this.ShowUsage = true;
						}
						else
						{
							this.ConnectivityOptions.ArchitectureOverride = current.Values[0];
						}
					}
					else if (a2 == "PACKAGE" || a2 == "P")
					{
						if (current.Values.Count != 1)
						{
							this.ShowUsage = true;
						}
						else if (!string.IsNullOrEmpty(this.PackageFullName))
						{
							this.ShowUsage = true;
						}
						else
						{
							this.PackageFullName = current.Values[0];
						}
					}
					else if (a2 == "LANGUAGE")
					{
						if (current.Values.Count != 1)
						{
							this.ShowUsage = true;
						}
						else
						{
							LocHelper.SetThreadLanguage(new string[]
							{
								current.Values[0]
							});
						}
					}
					else if (a2 == "HELP" || a2 == "H")
					{
						this.ShowUsage = true;
					}
					else
					{
						this.ShowUsage = true;
					}
				}
				IL_52A:
				if (this.ShowUsage)
				{
					break;
				}
			}
			if (!this.ShowUsage)
			{
				this.Validate();
			}
		}

		private void Validate()
		{
			if (this.Verb != Verbs.Devices && !this.ConnectivityOptions.IsValid())
			{
				this.ShowUsage = true;
				return;
			}
			if ((this.Verb == Verbs.Install || this.Verb == Verbs.Update) && this.PackageFile == null)
			{
				this.ShowUsage = true;
				return;
			}
			if (this.Verb == Verbs.Uninstall && this.PackageFile == null && string.IsNullOrEmpty(this.PackageFullName))
			{
				this.ShowUsage = true;
				return;
			}
			if (this.Verb == Verbs.None)
			{
				this.ShowUsage = true;
			}
		}

		private static bool IsValidFileExtension(string filePath)
		{
			string value = Path.GetExtension(filePath).ToUpperInvariant();
			string[] source = new string[]
			{
				".APPX",
				".APPXBUNDLE"
			};
			return source.Contains(value);
		}

		private void CheckAndSetVerb(Verbs verb, string[] argValues)
		{
			if (argValues.Length != 0)
			{
				this.ShowUsage = true;
				return;
			}
			if (this.Verb != Verbs.None)
			{
				this.ShowUsage = true;
				return;
			}
			this.Verb = verb;
		}
	}
}
