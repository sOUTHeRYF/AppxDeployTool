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
            innerContent.Add("DeplyToolExcutePath", @"C:\Program Files (x86)\Windows Kits\10\bin\x86");
            innerContent.Add("DeplyToolExcuteName", @"WinAppDeployCmd.exe");
            innerContent.Add("DefaultIPAddress", @"127.0.0.1");
        }
    }
}
