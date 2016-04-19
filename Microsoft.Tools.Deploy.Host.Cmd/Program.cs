using Microsoft.Tools.Deploy.Common;
using System;
using System.Reflection;
using System.Globalization;
namespace Microsoft.Tools.Deploy.Host.Cmd
{
	public sealed class Program
	{
        public static readonly Program Instance = new Program();
        private Action<string> logout;

        public static void Init(Action<string> logout)
        {
            Instance.logout = logout;
        }
        public void LogOut(string format, params object[] args)
        {
            string result = string.Format(CultureInfo.CurrentCulture, format, args) + System.Environment.NewLine;
            if(null != logout)
            {
                logout?.Invoke(result);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(result);
            }
        }
		public static int Main(string[] args)
		{
			int result = 0;
			Instance.LogOut(Resources.HelloMessage, new object[0]);
			Instance.LogOut(Resources.VersionLine, new object[]
			{
				Assembly.GetExecutingAssembly().GetName().Version
			});
			Instance.LogOut(Resources.CopyrightLine, new object[0]);
			Instance.LogOut(Resources.SpacerLine, new object[0]);
			ArgsProcessor argsProcessor = new ArgsProcessor();
			try
			{
				argsProcessor.ParseArgs(args);
				if (argsProcessor.ShowUsage || argsProcessor.Verb == Verbs.None)
				{
					argsProcessor.PrintUsage();
					result = -2147024809;
				}
				else
				{
					Deploy deploy = new Deploy();
					switch (argsProcessor.Verb)
					{
					case Verbs.Devices:
						deploy.EnumerateDevices(argsProcessor.DeviceScanTimeout);
						break;
					case Verbs.Install:
						deploy.DoInstallOrUpdate(argsProcessor.ConnectivityOptions, argsProcessor.PackageFile, argsProcessor.DependencyFiles, Deploy.DeployAction.Install, argsProcessor.PackageCertFile);
						break;
					case Verbs.Update:
						deploy.DoInstallOrUpdate(argsProcessor.ConnectivityOptions, argsProcessor.PackageFile, argsProcessor.DependencyFiles, Deploy.DeployAction.Update, argsProcessor.PackageCertFile);
						break;
					case Verbs.Uninstall:
						if (!string.IsNullOrEmpty(argsProcessor.PackageFullName))
						{
							deploy.DoUninstall(argsProcessor.ConnectivityOptions, argsProcessor.PackageFullName);
						}
						else
						{
							deploy.DoUninstall(argsProcessor.ConnectivityOptions, argsProcessor.PackageFile);
						}
						break;
					case Verbs.List:
						deploy.DoList(argsProcessor.ConnectivityOptions);
						break;
					default:
						throw new NotImplementedException(Resources.ExceptionVerbNotImplemented);
					}
					Instance.LogOut(Resources.StatusOverallComplete, new object[0]);
				}
			}
			catch (IndexOutOfRangeException ex)
			{
				argsProcessor.PrintUsage();
				result = ex.HResult;
			}
			catch (NeedPinException ex2)
			{
				Instance.LogOut(Resources.SpacerLine, new object[0]);
				Instance.LogOut(Resources.ExceptionNeedPin, new object[0]);
				result = ex2.HResult;
			}
			catch (Exception innerException)
			{
				Instance.LogOut(Resources.SpacerLine, new object[0]);
				Instance.LogOut(Resources.ExceptionErrorPattern, new object[]
				{
					innerException.HResult,
					innerException.Message
				});
				result = innerException.HResult;
				while (innerException.InnerException != null)
				{
					innerException = innerException.InnerException;
					Instance.LogOut(Resources.ExceptionErrorPattern, new object[]
					{
						innerException.HResult,
						innerException.Message
					});
					result = innerException.HResult;
				}
			}
			return result;
		}
        public static int TestMain(string[] args)
        {
            int result = 0;
            Instance.LogOut(Resources.HelloMessage, new object[0]);
            Instance.LogOut(Resources.VersionLine, new object[]
            {
                Assembly.GetExecutingAssembly().GetName().Version
            });
            Instance.LogOut(Resources.CopyrightLine, new object[0]);
            Instance.LogOut(Resources.SpacerLine, new object[0]);
            ArgsProcessor argsProcessor = new ArgsProcessor();
            try
            {
                argsProcessor.ParseArgs(args);
                if (argsProcessor.ShowUsage || argsProcessor.Verb == Verbs.None)
                {
                    argsProcessor.PrintUsage();
                    result = -2147024809;
                }
                else
                {
                    Deploy deploy = new Deploy();
                    switch (argsProcessor.Verb)
                    {
                        case Verbs.Devices:
                            deploy.EnumerateDevices(argsProcessor.DeviceScanTimeout);
                            break;
                        case Verbs.Install:
                            deploy.DoInstallOrUpdate(argsProcessor.ConnectivityOptions, argsProcessor.PackageFile, argsProcessor.DependencyFiles, Deploy.DeployAction.Install, argsProcessor.PackageCertFile);
                            break;
                        case Verbs.Update:
                            deploy.DoInstallOrUpdate(argsProcessor.ConnectivityOptions, argsProcessor.PackageFile, argsProcessor.DependencyFiles, Deploy.DeployAction.Update, argsProcessor.PackageCertFile);
                            break;
                        case Verbs.Uninstall:
                            if (!string.IsNullOrEmpty(argsProcessor.PackageFullName))
                            {
                                deploy.DoUninstall(argsProcessor.ConnectivityOptions, argsProcessor.PackageFullName);
                            }
                            else
                            {
                                deploy.DoUninstall(argsProcessor.ConnectivityOptions, argsProcessor.PackageFile);
                            }
                            break;
                        case Verbs.List:
                            deploy.DoList(argsProcessor.ConnectivityOptions);
                            break;
                        default:
                            throw new NotImplementedException(Resources.ExceptionVerbNotImplemented);
                    }
                    Instance.LogOut(Resources.StatusOverallComplete, new object[0]);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                argsProcessor.PrintUsage();
                result = ex.HResult;
            }
            catch (NeedPinException ex2)
            {
                Instance.LogOut(Resources.SpacerLine, new object[0]);
                Instance.LogOut(Resources.ExceptionNeedPin, new object[0]);
                result = ex2.HResult;
            }
            catch (Exception innerException)
            {
                Instance.LogOut(Resources.SpacerLine, new object[0]);
                Instance.LogOut(Resources.ExceptionErrorPattern, new object[]
                {
                    innerException.HResult,
                    innerException.Message
                });
                result = innerException.HResult;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                    Instance.LogOut(Resources.ExceptionErrorPattern, new object[]
                    {
                        innerException.HResult,
                        innerException.Message
                    });
                    result = innerException.HResult;
                }
            }
            return result;
        }
    }
}
