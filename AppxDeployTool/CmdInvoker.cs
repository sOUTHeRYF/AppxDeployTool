using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MSDeploy = Microsoft.Tools.Deploy.Host.Cmd;
namespace AppxDeployTool
{
    public class CMDInvoker
    {
        public static readonly CMDInvoker Instance = new CMDInvoker();
        private List<string> paramsStr = new List<string>();
        private string exeToInvokePath = "";
        private string exeToInvokeName = "";
        public bool SetExePath(string exePath)
        {
            if(true == new DirectoryInfo(exePath).Exists)
            {
                exeToInvokePath = exePath;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetExeName(string exeName)
        {
            if (true == new DirectoryInfo(exeToInvokePath+@"\"+exeName).Exists)
            {
                exeToInvokeName = exeName;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddParam(string paramName,string paramValue = "")
        {
            paramsStr?.Add(paramName);
            if(!string.IsNullOrWhiteSpace(paramValue))
            paramsStr?.Add(paramValue);
        }
        public void Invoke()
        {
            Thread my = new Thread(()=> {
                MSDeploy.Program.TestMain(paramsStr?.ToArray());
            });
            my.Start();

        }
    }
}
