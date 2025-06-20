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

        public override void Initialize()
        {
            Log.Info("Starting initialization of E6680A Signal Analyzer...");
            ScpiCommand(":SYSTem:PRESet");
            ScpiCommand(":OUTPut ON");
            ScpiCommand(":OUTPut:MODulation:STATe OFF");
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
                Log.Info($"Setting output modulation to ON...");
                ScpiCommand($":OUTPut:MODulation:STATe ON");
            } else
            {
                Log.Info($"Setting output modulation to OFF...");
                ScpiCommand($":OUTPut:MODulation:STATe OFF");
            }
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Output modulation set successfully.");
        }

    }
}
