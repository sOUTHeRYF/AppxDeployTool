using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppxDeployTool
{
    public class CMDInvoker
    {
        public static readonly CMDInvoker Instance = new CMDInvoker();
        private List<string> paramsStr;
        private string exeToInvokeWithPath;
        
        public void SetExe(string exeNameWithPath)
        {
            if(true == exeNameWithPath?.EndsWith(".exe"))
            {
                exeToInvokeWithPath = exeNameWithPath;
            }
        }
        public void AddParam(string paramName,string paramValue = "")
        {

        }
        public void Invoke()
        {

        }
    }
}
