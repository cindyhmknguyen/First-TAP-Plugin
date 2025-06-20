using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using OpenTap.Metrics;
using OpenTap.Metrics.AssetDiscovery;

namespace CWMeasurementToolkit.Instruments.SignalGenerators
{
    public abstract class BaseClassScpiSignalGenerator : AssetMetricScpiInstrument, ISignalGenerator
    {
        protected BaseClassScpiSignalGenerator()
        {
            // No need to pass a visaAddress variable explicitly to this class constructor.
            // BaseClassScpiSignalGenerator inherits from the OpenTap ScpiInstrument class, which automatically exposes
            // a user input field for VISA Address in the KS8400 GUI.
        }
        
        //not working right now for MXG N5186A. scpi command doesn't work.
        //private int attenuatorBypassHistoryMetric = 0;
        //[Metric("Attenuator Bypass History", group: "Signal Generator Metrics")]
        //public int AttenuatorBypassHistoryMetric { get; set; }
        //public abstract void UpdateAttenuatorBypassHistoryMetric(); // Abstract method to enforce metric update in derived classes.This method will update the AttenuatorBypassHistoryMetric Auto-property.


        [Metric("Power On History", group: "Signal Generator Metrics")]
        public int PowerOnHistoryMetric { get; set; }
        public abstract void UpdatePowerOnHistoryMetric(); // Abstract method to enforce metric update in derived classes.This method will update the AttenuatorBypassHistoryMetric Auto-property.


        //[Metric("Reverse Power Protection History", group: "Signal Generator Metrics")]
        //public int ReversePowerProtectionHistoryMetric { get; set; }
        //public abstract void UpdateReversePowerProtectionHistoryMetric(); // Abstract method to enforce metric update in derived classes.This method will update the ReversePowerProtectionHistoryMetric Auto-property.


        [Metric("On-Time History", group: "Signal Generator Metrics")]
        public double OnTimeHistoryMetric { get; set; }
        public abstract void UpdateOnTimeHistoryMetric(); // Abstract method to enforce metric update in derived classes.This method will update the OnTimeHistoryMetric Auto-property.


        public abstract void Initialize();
        public abstract void SetAmplitudeCorrections(string amplitudeCorrectionsFilePath, int rfChannelNumber);
        public abstract void SetFixtureCorrections(string fixtureCorrectionsFilePath, int rfChannelNumber);
        public abstract void SetDutCorrections(string dutCorrectionsFilePath, int rfChannelNumber);
        public abstract void SetFrequency(double frequency);
        public abstract void SetPower(double power);
        public abstract void SetSourcePort(string portName);
        public abstract void ClearFlatness();
        public abstract void EnableSourceCw();
        public abstract void DisableSourceCw();
    }
}

