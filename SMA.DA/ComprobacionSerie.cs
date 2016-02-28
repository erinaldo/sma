using System;
using System.IO;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.DA
{
   public  class ComprobacionSerie
    {
       public Boolean ValidacionSerie()
       {
           DirectoryInfo currentDir = new DirectoryInfo(Environment.CurrentDirectory);
           string path = string.Format("win32_logicaldisk.deviceid=\"{0}\"",
               currentDir.Root.Name.Replace("\\", ""));
           ManagementObject disk = new ManagementObject(path);
           disk.Get();

           string serial = disk["VolumeSerialNumber"].ToString();

           return false;
       }
    }
}
