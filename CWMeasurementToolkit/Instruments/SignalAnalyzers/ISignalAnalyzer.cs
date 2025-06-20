using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.SignalAnalyzers;

namespace CWMeasurementToolkit.Instruments.SignalAnalyzers
{
    public interface ISignalAnalyzer
    {
        void Initialize();
        void SetFrequency(double frequency);
        void SetPower(double power);
        void SetModulation(bool modulation);
    }
}
