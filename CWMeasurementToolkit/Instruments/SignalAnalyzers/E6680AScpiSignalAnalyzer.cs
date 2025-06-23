using CWMeasurementToolkit.Instruments.SignalAnalyzers;
using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWMeasurementToolkit.Instruments.SignalAnalyzers
{
    [Display("E6680A Signal Analyzer", Group: "CWMeasurementToolkit/Instruments/SignalAnalyzers", Description: "Keysight E6680A Signal Analyzer")]
    public class E6680AScpiSignalAnalyzer : BaseClassScpiSignalAnalyzer
    {
        public E6680AScpiSignalAnalyzer()
        {
            // Additional initialization for the class constructor, if needed.
            Log.Info("Successfully instantiated E6680AScpiSignalAnalyzer class.");
        }

        protected override void UpdateAssetMetrics()
        {
            //UpdateAttenuatorBypassHistoryMetric();
            UpdatePowerOnHistoryMetric();
            //UpdateReversePowerProtectionHistoryMetric();
            UpdateOnTimeHistoryMetric();

        }

        public override void UpdatePowerOnHistoryMetric()
        {
            Log.Info("Getting Power On History.");
            string response = ScpiQuery(":DIAGnostic:CPU:INFormation:CCOunt:PON?").Trim(); //Gets the cumulative number of times the instrument has been powered on.
            PowerOnHistoryMetric = int.Parse(response);
            Log.Info("Power On History Metric successfully updated.");
        }

        public override void UpdateOnTimeHistoryMetric()
        {
            Log.Info("Getting On-Time History.");
            string response = ScpiQuery(":DIAGnostic:CPU:INFormation:OTIMe?").Trim(); //Gets the cumulative number of hours the sig gen has been turned on.
            OnTimeHistoryMetric = double.Parse(response);
            Log.Info("On-Time History Metric successfully updated.");
        }

        public override void Initialize()
        {
            Log.Info("Starting initialization of E6680A Signal Analyzer...");
            
            // CHP setup
            ScpiCommand(":INST:CONF:NR5G:CHP");
            
            ScpiCommand(":SYSTem:PRESet");
            //ScpiCommand(":OUTPut ON");
            //ScpiCommand(":OUTPut:MODulation:STATe OFF");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Initialization of E6680A Signal Analyzer completed successfully.");
        }

        public override void SetFrequency(double frequencyMHz)
        {
            Log.Info($"Setting output frequency to {frequencyMHz} MHz...");
            ScpiCommand($":SENSe:FREQuency:CENTer {frequencyMHz} MHz");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Output frequency set successfully.");
        }

        public override void SetPower(double powerDbm)
        {
            Log.Info($"Setting output power to {powerDbm} dBm...");
            ScpiCommand($":SENSe:POWer:RF:RANGe {powerDbm} dBm");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Output power set successfully.");
        }

        public override void SetModulation(bool modulation)
        {
            if (modulation)
            {
                Log.Info($"Turning ON the output modulation...");
                ScpiCommand($":OUTPut:MODulation:STATe ON");
            } else
            {
                Log.Info($"Turning OFF the output modulation...");
                ScpiCommand($":OUTPut:MODulation:STATe OFF");
            }
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Output modulation set successfully.");
        }

        public override void MeasureCHP()
        {
            Log.Info($"Measuring channel power...");
            ScpiCommand($":INITiate:CHPower");
            ScpiCommand($":CONFigure:CHPower");
            ScpiQuery($":SYST:ERR?");
            ScpiQuery($":FETCh:CHPower1?");
            ScpiQuery($":MEASure:CHPower1?");
            ScpiQuery($":READ:CHP1?");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Channel power measured successfully.");
        }
    }
}
