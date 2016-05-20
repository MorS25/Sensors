using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using SensorBackgroundApplication.Gps;
using SensorBackgroundApplication.Hardware;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace SensorBackgroundApplication
{
    public sealed class StartupTask : IBackgroundTask
    {
        private static BackgroundTaskDeferral _deferral;



        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
            
            //IGps gps = new NavSparkGps(false);
            //gps.Start();

            //var ads1115 = new Ads1115();
            //ads1115.Start(0);



        }
        internal static void Complete()
        {
            _deferral.Complete();
        }
    }
}
