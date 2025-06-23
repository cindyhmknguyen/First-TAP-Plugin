using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWMeasurementToolkit.Instruments.SignalGenerators;

namespace CWMeasurementToolkit.Instruments.SignalGenerators
{
    public interface ISignalGenerator
    {
        void Initialize();
        //void SetAmplitudeCorrections(string amplitudeCorrectionsFilePath, int rfChannelNumber);
        //void SetFixtureCorrections(string fixtureCorrectionsFilePath, int rfChannelNumber);
        //void SetDutCorrections(string dutCorrectionsFilePath, int rfChannelNumber);
        void LoadARBMemory(string path, string name);
        void SetARB(bool arb);
        void SetFrequency(double frequency);
        void SetPower(double power);
        //void SetSourcePort(string portName);
        void EnableSourceCw();
        void DisableSourceCw();
    }
}
