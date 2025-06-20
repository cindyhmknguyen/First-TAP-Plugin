using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;

namespace CWMeasurementToolkit.Instruments.PowerSensors
{
    [Display("U2060 Series Power Sensor", Group: "CWMeasurementToolkit/Instruments/PowerSensors", Description: "Keysight U2060 Series Power Sensor")]
    public class U2060SeriesScpiPowerSensor : BaseClassScpiPowerSensor
    {
        public U2060SeriesScpiPowerSensor()
        {
            // Additional initialization for the class constructor, if needed.
            Log.Info("Successfully instantiated U2060SeriesScpiPowerSensor class.");
        }

        public override void UpdateSerialNumberMetric()
        {
            Log.Info("Getting Power Sensor Serial Number.");
            SerialNumberMetric = ScpiQuery("SERVice:SENSor:SNUMber?").Trim();
            Log.Info("Power Sensor Serial Number Metric successfully updated.");
        }

        public override void UpdateCalibrationDateMetric()
        {
            Log.Info("Getting Power Sensor Calibration Date.");
            string _dateString = ScpiQuery("SERVice:SENSor:CDATe?").Trim();
            CalibrationDateMetric = DateTime.Parse(_dateString);
            Log.Info("Power Sensor Calibration Date Metric successfully udpated.");

        }

        public override void Initialize()
        {
            Log.Info("Starting initialization of U2060 Series Power Sensor...");
            ScpiCommand("*RST");
            ScpiCommand("*CLS");
            ScpiCommand("UNIT:POW DBM");
            DisableCorrections();
            ScpiQuery("*OPC?");
            Log.Info("Initialization of U2060 Series Power Sensor completed successfully.");
        }

        public override void SetAveragingAuto()
        {
            Log.Info("Setting averaging to AUTO...");
            ScpiQuery("SENSe:AVERage:COUNt:AUTO ON;*OPC?");
            Log.Info("Averaging set to AUTO successfully.");
        }

        public override void SetContinuousMeasMode(string measMode)
        {
            Log.Info($"Setting continuous measurement mode to '{measMode}'...");
            ScpiQuery($"INIT:CONT {measMode};*OPC?");
            Log.Info("Continuous measurement mode set successfully.");
        }

        public override void SetFrequency(double frequency)
        {
            Log.Info($"Setting frequency to {frequency} MHz...");
            double frequencyHz = frequency * 1e6;
            ScpiQuery($"SENSe:FREQuency {frequencyHz};*OPC?");
            Log.Info("Frequency set successfully.");
        }

        public override void SetModePowerAvg()
        {
            Log.Info("Setting mode to power average...");
            ScpiCommand("INIT:CONT OFF");
            ScpiQuery("SENSe:AVERage:STATe ON;*OPC?");
            Log.Info("Power average mode set successfully.");
        }

        public override void SetUnits(string units)
        {
            Log.Info($"Setting units to '{units}'...");
            ScpiQuery($"TRACe:UNIT {units};*OPC?");
            Log.Info("Units set successfully.");
        }

        public override void DisableCorrections()
        {
            Log.Info("Disabling correction sets CSET2, CSET3, and CSET4...");
            ScpiCommand("SENSe:CORRection:CSET2:STATe 0");
            ScpiCommand("SENSe:CORRection:CSET3:STATe 0");
            ScpiCommand("SENSe:CORRection:CSET4:STATe 0");
            ScpiQuery("*OPC?"); // Wait for operation to complete
            Log.Info("Correction sets disabled successfully.");
        }

        public override double MeasurePower()
        {
            Log.Info("Starting power measurement...");
            ScpiCommand("INIT:CONT OFF");
            ScpiCommand("TRIGger:SOURce IMMediate");
            ScpiCommand("INIT:IMMediate");
            ScpiCommand("TRIGger:IMMediate");

            string status;
            do
            {
                Thread.Sleep(100);
                status = ScpiQuery<string>("STATus:OPERation:MEASuring:SUMMary?").Trim(); //this decimal value is set to "+2" when the power sensor is measuring.
            } while (status != "+0");

            double result = ScpiQuery<double>("FETCh?");
            Log.Info($"Power measurement completed successfully: {result} dBm");
            return result;
        }

        public override void ZeroPowerSensor()
        {
            Log.Info("Starting zeroing of power sensor...");
            ScpiQuery("CAL:ZERO:AUTO ONCE;*OPC?"); //Performs an automatic calibration and zeroing operation.  USB power sensors can be connected to RF OUTPUT OFF signal generator ports during this operation.
            Log.Info("Zeroing of power sensor completed successfully.");
        }

        protected override void UpdateAssetMetrics()
        {
            UpdateSerialNumberMetric();
            UpdateCalibrationDateMetric();
        }
    }
}

