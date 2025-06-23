using CWMeasurementToolkit.Instruments.SignalAnalyzers;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalAnalyzerActions;

[Display("Signal Analyzer --> Measure CHP", Group: "CWMeasurementToolkit/TestSteps/SignalAnalyzerActions", Description: "Measures the channel power.")]
public class MeasureCHP : TestStep
{
    [Display("Signal Analyzer")]
    public BaseClassScpiSignalAnalyzer SignalAnalyzer { get; set; }

    public override void Run()
    {
        if (SignalAnalyzer == null)
        {
            Log.Error("No signal analyzer selected.");
            return;
        }

        try
        {
            Log.Info($"Measuring channel power...");
            SignalAnalyzer.MeasureCHP();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Channel power measured successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to measure channel power: {ex.Message}");
        }
    }
}
