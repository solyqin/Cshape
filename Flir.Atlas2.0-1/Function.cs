using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace Flir.Atlas2._0
{
    class Function
    {
        //获取当前电脑所有盘符
        public List<string> GetRemovableDeviceID()
        {
            List<string> deviceIDs = new List<string>();
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT  *  From  Win32_LogicalDisk ");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {

                switch (int.Parse(mo["DriveType"].ToString()))
                {
                    case (int)DriveType.Removable:   //可以移动磁盘     
                        {
                            //MessageBox.Show("可以移动磁盘");
                            deviceIDs.Add(mo["DeviceID"].ToString());
                            break;
                        }
                    case (int)DriveType.Fixed:   //本地磁盘     
                        {
                            //MessageBox.Show("本地磁盘");
                            deviceIDs.Add(mo["DeviceID"].ToString());
                            break;
                        }
                    case (int)DriveType.CDRom:   //CD   rom   drives     
                        {
                            //MessageBox.Show("CD   rom   drives ");
                            break;
                        }
                    case (int)DriveType.Network:   //网络驱动   
                        {
                            //MessageBox.Show("网络驱动器 ");
                            break;
                        }
                    case (int)DriveType.Ram:
                        {
                            //MessageBox.Show("驱动器是一个 RAM 磁盘 ");
                            break;
                        }
                    case (int)DriveType.NoRootDirectory:
                        {
                            //MessageBox.Show("驱动器没有根目录 ");
                            break;
                        }
                    default:   //defalut   to   folder     
                        {
                            //MessageBox.Show("驱动器类型未知 ");
                            break;
                        }
                }

            }
            return deviceIDs;
        }

        //获取不是系统盘分区盘符  value：E:  D:
        private string GetDeviceID()
        {
            string DeviceID = null;
            Function function = new Function();
            List<string> deviceIDs = function.GetRemovableDeviceID();
            foreach (string dev in deviceIDs) //获取一个不是C盘的盘符
            {
                if (System.Environment.GetEnvironmentVariable("windir").Remove(2) == dev)
                {
                    continue;
                }

                if (GetHardDiskSpace(dev) > 100) //盘符剩余空间要大于100MB以上
                {
                    DeviceID = dev;
                    break;
                }
            }
            return DeviceID;
        }
        //获取盘符空间剩余大小
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            long totalSize = 0;
            str_HardDiskName = str_HardDiskName + "\\";
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    //totalSize = drive.TotalFreeSpace * 100 / drive.TotalSize;
                    totalSize = drive.AvailableFreeSpace / (1024*1024);
                    
                }
            }
            return totalSize;
        }
        public string GetOutPutPath_Random() //不确定创建在哪一个盘内，以防不存在默认D盘的情况
        {
            string out_path = null;
            string Dev_id = GetDeviceID();
           
            long freesize = GetHardDiskSpace(Dev_id);
            if (freesize > 100)
                out_path = Dev_id + "Atlas_OutPut";
            Console.WriteLine(Dev_id + ": {0}" ,freesize);

            return out_path;
        }
        public string GetOutPutPath()
        {
            string path;
            if (Directory.Exists(@"D:\"))
                path =  @"D:\Atlas_OutPut";
            else
                path =  GetOutPutPath_Random();

            if (Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("创建out文件夹异常！" + ee);
                }
                
            }
            return path;
        }
    }
}
