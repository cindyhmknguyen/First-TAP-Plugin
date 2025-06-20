using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.SignalAnalyzers;
using OpenTap;
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

        public abstract void Initialize();
    }
}