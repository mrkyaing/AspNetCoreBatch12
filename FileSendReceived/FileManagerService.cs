using System.ServiceProcess;
using System.IO;
using System.Timers;
using System;
namespace FileSendReceived
{
    public partial class FileManagerService : ServiceBase
    {
        Timer timeDelay;
        int count;
        public FileManagerService()
        {
            InitializeComponent();
            timeDelay = new Timer();
            timeDelay.Elapsed += new ElapsedEventHandler(WorkProcess);
        }
        public void WorkProcess(object sender, ElapsedEventArgs e)
        {
            string process = "Timer Tick " + count;
            LogService(process);
            count++;
        }
        protected override void OnStart(string[] args)
        {
            System.Diagnostics.Debugger.Launch();
            LogService("Service is Started:"+args.ToString());
            timeDelay.Enabled = true;
        }
        protected override void OnStop()
        {
            LogService("Service Stoped");
            timeDelay.Enabled = false;
        }
        private void LogService(string content)
        {
            FileStream fs = new FileStream(@"d:\TestServiceLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(content);
            sw.Flush();
            sw.Close();
        }
    }
}
