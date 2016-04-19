using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AppxDeployTool
{
    public class DeployManager
    {
        public static readonly DeployManager Instance = new DeployManager();
        private List<string> deployFiles;

        public void Clear()
        {
            deployFiles = new List<string>();
        }
        public void SetDeployFile(string[] deployFilesName)
        {
            if(deployFilesName?.Length>0)
            {
                deployFiles = deployFilesName.ToList();
            }
        }
        public void SetDeployFile(string deployFilesName)
        {
            if(!string.IsNullOrWhiteSpace(deployFilesName))
            {
                deployFiles = new List<string>();
                deployFiles.Add(deployFilesName);
            }
        }

        public void StartDeployAppx(Action<bool,string> callback)
        {
            if(deployFiles?.Count>0)
            {
                foreach(string filepath in deployFiles)
                {
                    DeployAppxOnce(filepath);                    
                }
            }
        }

        private bool DeployAppxOnce(string fileWithPath)
        {
            if (!File.Exists(fileWithPath))
            {
                return false;
            }
            else
            {
                CMDInvoker.Instance.AddParam("install ");
                CMDInvoker.Instance.AddParam("-file", fileWithPath);
                CMDInvoker.Instance.AddParam("-ip", "127.0.0.1");
                CMDInvoker.Instance.AddParam("-pin", "r1U8m5");
                CMDInvoker.Instance.Invoke();
                return true;
            }
        }
    }
}
