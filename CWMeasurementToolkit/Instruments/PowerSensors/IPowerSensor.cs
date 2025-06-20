using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.PowerSensors;

namespace CWMeasurementToolkit.Instruments.PowerSensors
{
    public interface IPowerSensor
    {
        void Initialize();
        void SetAveragingAuto();
        void SetContinuousMeasMode(string measMode);
        void SetFrequency(double frequency);
        void SetModePowerAvg();
        void SetUnits(string units);
        void DisableCorrections();
        double MeasurePower();
        void ZeroPowerSensor();
    }
}

