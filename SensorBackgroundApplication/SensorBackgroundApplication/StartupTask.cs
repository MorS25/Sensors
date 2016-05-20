using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;
using Windows.Devices.Gpio.Provider;
using SensorBackgroundApplication.Gps;
using SensorBackgroundApplication.Hardware;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace SensorBackgroundApplication
{
    public sealed class StartupTask : IBackgroundTask
    {
        private static BackgroundTaskDeferral _deferral;

        private GpioController _gpioController;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();

            _gpioController = GpioController.GetDefault();
            if (_gpioController != null)
            {
                //PI 2/3 pinout diagram
                //https://az835927.vo.msecnd.net/sites/iot/Resources/images/PinMappings/RP2_Pinout.png

                var inputPin = _gpioController.OpenPin(12);
                inputPin.SetDriveMode(GpioPinDriveMode.Input);
                inputPin.ValueChanged += InputPin_ValueChanged;

                var outputPin = _gpioController.OpenPin(36);
                outputPin.SetDriveMode(GpioPinDriveMode.Output);
                //Turn on an LED!
                outputPin.Write(GpioPinValue.High);
                //Turn off 
                outputPin.Write(GpioPinValue.Low);
            }

            //IGps gps = new NavSparkGps(false);
            //gps.Start();

            //var ads1115 = new Ads1115();
            //ads1115.Start(0);

            //var xboxController = new XboxController();
            //xboxController.Start();

            //var gyroscopeAccelerometer = new Mpu9150();

            //var capacitiveTouchSensor = new Ads1115();
            //capacitiveTouchSensor.Start(0);

            //var cellModemDataText = new AdafruitFona();
            //cellModemDataText.Start();
            
        }

        private void InputPin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            //Check on the edge, rising = just pushed, falling = released
            var edge = args.Edge;

        }

        internal static void Complete()
        {
            _deferral.Complete();
        }
    }
}
