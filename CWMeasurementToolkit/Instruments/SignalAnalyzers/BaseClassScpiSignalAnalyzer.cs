using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.SignalAnalyzers;
using OpenTap;
using OpenTap.Metrics;
using OpenTap.Metrics.AssetDiscovery;

namespace CWMeasurementToolkit.Instruments.SignalAnalyzers
{
    public abstract class BaseClassScpiSignalAnalyzer : AssetMetricScpiInstrument, ISignalAnalyzer
    {
        protected BaseClassScpiSignalAnalyzer()
        {
            // No need to pass a visaAddress variable explicitly to this class constructor.
            // BaseClassScpiSignalGenerator inherits from the OpenTap ScpiInstrument class, which automatically exposes
            // a user input field for VISA Address in the KS8400 GUI.
        }

        [Metric("Power On History", group: "Signal Analyzer Metrics")]
        public int PowerOnHistoryMetric { get; set; }
        public abstract void UpdatePowerOnHistoryMetric(); // Abstract method to enforce metric update in derived classes.This method will update the AttenuatorBypassHistoryMetric Auto-property.

        [Metric("On-Time History", group: "Signal Analyzer Metrics")]
        public double OnTimeHistoryMetric { get; set; }
        public abstract void UpdateOnTimeHistoryMetric(); // Abstract method to enforce metric update in derived classes.This method will update the OnTimeHistoryMetric Auto-property.


        public abstract void Initialize();
        public abstract void SetFrequency(double frequency);
        public abstract void SetPower(double power);
        public abstract void SetModulation(bool modulation);

        public abstract void MeasureCHP();
    }
}