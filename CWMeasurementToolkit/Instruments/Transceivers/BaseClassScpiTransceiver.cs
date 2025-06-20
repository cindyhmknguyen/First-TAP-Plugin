using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.Transceivers;
using OpenTap;
using OpenTap.Metrics.AssetDiscovery;

namespace CWMeasurementToolkit.Instruments.Transceivers
{
    public abstract class BaseClassScpiTransceiver : AssetMetricScpiInstrument, ITransceiver
    {
        protected BaseClassScpiTransceiver()
        {
            // No need to pass a visaAddress variable explicitly to this class constructor.
            // BaseClassScpiSignalGenerator inherits from the OpenTap ScpiInstrument class, which automatically exposes
            // a user input field for VISA Address in the KS8400 GUI.
        }

        public abstract void Initialize();
    }
}