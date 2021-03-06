﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;
using System.Diagnostics;
using System.IO;

namespace Liquibase.Runner.MSBuild
{
    public class Liquibase : Task
    {
        public string FileName { get; set; }

        public override bool Execute()
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true; //设置为false将会看到程序窗口 
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //启动进程时窗口状态 
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = Path.GetFullPath(this.FileName); //如果a.bat在System32文件夹中，此处只需填写文件名即可
                p.StartInfo.WorkingDirectory = Path.Combine(Environment.CurrentDirectory, Path.GetDirectoryName(this.FileName)); //工作目录
                p.Start();

                Log.LogMessage("FileName:{0}", p.StartInfo.FileName);
                Log.LogMessage("WorkingDirectory:{0}", p.StartInfo.WorkingDirectory);

                var result = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();

                Log.LogMessage(result);
                Log.LogMessage("Bat executed.");

                return result.Contains("Liquibase Update Successful");
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
            }

            return false;
        }
    }
}
