using CWMeasurementToolkit.Instruments.SignalAnalyzers;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalAnalyzerActions;

[Display("Signal Analyzer --> Set Modulation", Group: "CWMeasurementToolkit/TestSteps/SignalAnalyzerActions", Description: "Sets the modulation.")]
public class SetModulation : TestStep
{
    [Display("Signal Analyzer")]
    public BaseClassScpiSignalAnalyzer SignalAnalyzer { get; set; }

    [Display("Modulation")]
    public bool Modulation { get; set; } = false;

    public override void Run()
    {
        if (SignalAnalyzer == null)
        {
            Log.Error("No signal analyzer selected.");
            return;
        }

        try
        {
            Log.Info($"Setting modulation to {Modulation}...");
            SignalAnalyzer.SetModulation(Modulation);
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Modulation set successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set modulation: {ex.Message}");
        }
    }
}
