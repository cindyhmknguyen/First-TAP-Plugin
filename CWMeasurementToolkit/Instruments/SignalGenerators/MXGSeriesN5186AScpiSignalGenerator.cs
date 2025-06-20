using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;

namespace CWMeasurementToolkit.Instruments.SignalGenerators
{
    [Display("MXG N5186A Signal Generator", Group: "CWMeasurementToolkit/Instruments/SignalGenerators", Description: "Keysight MXG N5186A Vector Signal Generator")]
    public class MXGSeriesN5186AScpiSignalGenerator : BaseClassScpiSignalGenerator
    {
        public MXGSeriesN5186AScpiSignalGenerator()
        {
            // Additional initialization for the class constructor, if needed.
            Log.Info("Successfully instantiated MXGSeriesN5186AScpiSignalGenerator class.");
        }

        protected override void UpdateAssetMetrics()
        {
            //UpdateAttenuatorBypassHistoryMetric();
            UpdatePowerOnHistoryMetric();
            //UpdateReversePowerProtectionHistoryMetric();
            UpdateOnTimeHistoryMetric();

        }

        //not working, even though it's in the help file.
        //public override void UpdateAttenuatorBypassHistoryMetric()
        //{
        //    Log.Info("Getting Attenuator Bypass History.");
        //    string response = ScpiQuery(":DIAGnostic:CPU:INFormation:CCOunt:ATTenuator:BYPass?").Trim();//Gets the cumulative number of times the Attenuator bypass has been switched.
        //    AttenuatorBypassHistoryMetric = int.Parse(response);
        //    Log.Info("Attenuator Bypass History Metric successfully updated.");
        //}

        public override void UpdatePowerOnHistoryMetric()
        {
            Log.Info("Getting Power On History.");
            string response = ScpiQuery(":DIAGnostic:CPU:INFormation:CCOunt:PON?").Trim(); //Gets the cumulative number of times the instrument has been powered on.
            PowerOnHistoryMetric = int.Parse(response);
            Log.Info("Power On History Metric successfully updated.");
        }

        //public override void UpdateReversePowerProtectionHistoryMetric()
        //{
        //    Log.Info("Getting Reverse Power Protection History.");
        //    string response = ScpiQuery(":DIAGnostic:CPU:INFormation:CCOunt:PROTection?").Trim(); //Gets the cumulative number of times the reverse power protection has been engaged.
        //    ReversePowerProtectionHistoryMetric = int.Parse(response);
        //    Log.Info("Reverse Power Protection History Metric successfully updated.");
        //}

        public override void UpdateOnTimeHistoryMetric()
        {
            Log.Info("Getting On-Time History.");
            string response = ScpiQuery(":DIAGnostic:CPU:INFormation:OTIMe?").Trim(); //Gets the cumulative number of hours the sig gen has been turned on.
            OnTimeHistoryMetric = double.Parse(response);
            Log.Info("On-Time History Metric successfully updated.");
        }


        public override void Initialize()
        {
            Log.Info("Starting initialization of MXG Signal Generator...");
            ScpiCommand(":SYSTem:PRESet");
            ScpiCommand(":SOUR:RAD:ARB:TRIG KEY");
            ScpiCommand("SOUR:RAD:ARB:STAT OFF");
            ScpiCommand("OUTPut:MODulation:STATe OFF");
            ScpiCommand(":SOURce:RF1:CORRection:BLOCk1:STATe ON"); // BlockA corrections are enabled by default on preset
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Initialization of MXG Signal Generator completed successfully.");
        }

        public override void SetAmplitudeCorrections(string userCorrectionsFilePath, int rfChannelNumber)
        {
            Log.Info($"Applying user corrections from '{userCorrectionsFilePath}' to RF{rfChannelNumber}...");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk1:STATe OFF");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk1:FILE \"{userCorrectionsFilePath}\"");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk1:APPLy EMBedding");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk1:STATe ON");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:STATe ON");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("User corrections applied successfully.");
        }

        public override void SetFixtureCorrections(string fixtureCorrectionsFilePath, int rfChannelNumber)
        {
            Log.Info($"Applying fixture corrections from '{fixtureCorrectionsFilePath}' to RF{rfChannelNumber}...");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk:CLEar:FIXTure");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk:ADD:FIXTure");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk2:STATe OFF");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk2:FILE \"{fixtureCorrectionsFilePath}\"");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk2:APPLy DEEMbedding");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:BLOCk2:STATe ON");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:STATe ON");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Fixture corrections applied successfully.");
        }

        public override void SetDutCorrections(string dutCorrectionsFilePath, int rfChannelNumber)
        {
            Log.Info($"Applying DUT corrections from '{dutCorrectionsFilePath}' to RF{rfChannelNumber}...");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:RCOefficient:ENABle OFF");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:RCOefficient:FILE \"{dutCorrectionsFilePath}\"");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:RCOefficient:ENABle ON");
            ScpiCommand($":SOURce:RF{rfChannelNumber}:CORRection:STATe ON");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("DUT corrections applied successfully.");
        }

        public override void SetFrequency(double frequencyMHz)
        {
            Log.Info($"Setting frequency to {frequencyMHz} MHz...");
            ScpiCommand(":SOURce:FREQuency:MODE CW");
            ScpiCommand($":SOURce:FREQuency:CW {frequencyMHz}MHz");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Frequency set successfully.");
        }

        public override void SetPower(double powerDbm)
        {
            Log.Info($"Setting output power to {powerDbm} dBm...");
            ScpiCommand($"SOURce:POWer:LEVel {powerDbm}");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Output power set successfully.");
        }

        public override void SetSourcePort(string portName)
        {
            Log.Info($"SetSourcePort called with port '{portName}' — not yet implemented.");
            // TODO: Implement for MXG multi-channel support
        }

        public override void ClearFlatness()
        {
            Log.Info("Clearing all flatness tables...");
            ScpiCommand(":SOURce:CORRection:FLATness:PRESet");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("Flatness tables cleared.");
        }

        public override void EnableSourceCw()
        {
            Log.Info("Enabling CW output...");
            ScpiCommand("OUTPut:STATe ON");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("CW output enabled.");
        }

        public override void DisableSourceCw()
        {
            Log.Info("Disabling CW output...");
            ScpiCommand("OUTPut:STATe OFF");
            ScpiQuery("*OPC?"); // Wait for all operations to complete
            Log.Info("CW output disabled.");
        }
    }
}

