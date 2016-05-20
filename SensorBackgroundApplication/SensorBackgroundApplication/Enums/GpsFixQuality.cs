using System;
// ReSharper disable InconsistentNaming

namespace SensorBackgroundApplication.Enums
{
    [Flags]
    internal enum GpsFixQuality
    {
        NoFix,
        StandardGps,
        DiffGps,
        PPS,
        RTK,
        FloatRTK,
        Estimated,
        Manual,
        Simulation
    }
}