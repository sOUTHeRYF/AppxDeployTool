using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AppxDeployTool
{
    public class DeplyManager
    {
        public static readonly DeplyManager Instance = new DeplyManager();
        private List<string> deplyFiles;

        public void Clear()
        {
            deplyFiles = new List<string>();
        }
        public void SetDeplyFile(string[] deplyFilesName)
        {
            if(deplyFilesName?.Length>0)
            {
                deplyFiles = deplyFilesName.ToList();
            }
        }
        public void SetDeplyFile(string deplyFilesName)
        {
            if(!string.IsNullOrWhiteSpace(deplyFilesName))
            {
                deplyFiles = new List<string>();
                deplyFiles.Add(deplyFilesName);
            }
        }
        public void StartDeplyAppx(Action<bool,string> callback)
        {
            if(deplyFiles?.Count>0)
            {
                foreach(string filepath in deplyFiles)
                {
                    if (!File.Exists(filepath))
                    {
                        callback?.Invoke(false, "指定的文件不正确");
                        return;
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
