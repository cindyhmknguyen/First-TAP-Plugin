using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using OpenTap.Metrics;
using OpenTap.Metrics.AssetDiscovery;

namespace CWMeasurementToolkit.Instruments.PowerSensors
{
    public abstract class BaseClassScpiPowerSensor : AssetMetricScpiInstrument, IPowerSensor
    {
        protected BaseClassScpiPowerSensor()
        {
            // No need to pass a visaAddress variable explicitly to this class constructor.
            // BaseClassScpiPowerSensor inherits from the OpenTap ScpiInstrument class, which automatically exposes
            // a user input field for VISA Address in the KS8400 GUI.
        }


        [Metric("Serial Number", group: "Power Sensor Metrics")]
        public string SerialNumberMetric { get; set; }
        public abstract void UpdateSerialNumberMetric(); // Abstract method to enforce metric update in derived classes.This method will update the SerialNumberMetric Auto-property.


        [Metric("Calibration Date", group: "Power Sensor Metrics")]
        public DateTime CalibrationDateMetric { get; set; }
        public abstract void UpdateCalibrationDateMetric(); //Abstract method to enforce metric update in derived classes. This method will update the CalibrationDateMetric Auto-property.  Should convert the scpi string to a C# DateTime type.


        public abstract void Initialize();
        public abstract void SetAveragingAuto();
        public abstract void SetContinuousMeasMode(string measMode);
        public abstract void SetFrequency(double frequency);
        public abstract void SetModePowerAvg();
        public abstract void SetUnits(string units);
        public abstract void DisableCorrections();
        public abstract double MeasurePower();
        public abstract void ZeroPowerSensor();
    }
}
