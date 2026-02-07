using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Assessment
{
    //class LogData
    //{
    //    string DirPath = @"D:\college\CAPEGIMINI\assessments\CU-DotNet-Jan26-B4\Assessments\Week 5 Assessment\Shipment\";
    //    string FilePath = "Shipment.txt";

    //    if(!Directory.Exists()){
    //        }

    //}
    internal interface ILoggable
    {
        public void SaveLog(string message);
    }
}
