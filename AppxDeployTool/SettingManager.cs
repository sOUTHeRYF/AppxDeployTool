using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
namespace AppxDeployTool
{
    public class SettingManager
    {
        public static readonly SettingManager Instance = new SettingManager();
        private IsolatedStorageFile innerStorageFile;
        private Dictionary<string, string> innerContent;
        public void Init()
        {
            innerContent = new Dictionary<string, string>();
            innerContent.Add("DeployToolExcutePath", @"C:\Program Files (x86)\Windows Kits\10\bin\x86");
            innerContent.Add("DeployToolExcuteName", @"WinAppDeployCmd.exe");
            innerContent.Add("DefaultIPAddress", @"127.0.0.1");
        }
        public string GetSetting(string index)
        {
            if(null != innerContent)
            {
                string result = "";
                innerContent.TryGetValue(index, out result);
                return result;
            }
            else
            {
                Init();
                return GetSetting(index);
            }
        }
    }
}
