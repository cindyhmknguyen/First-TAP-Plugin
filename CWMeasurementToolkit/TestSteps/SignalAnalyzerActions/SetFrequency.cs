using CWMeasurementToolkit.Instruments.SignalAnalyzers;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalAnalyzerActions;

[Display("Signal Analyzer --> Set Frequency", Group: "CWMeasurementToolkit/TestSteps/SignalAnalyzerActions", Description: "Sets the output frequency.")]
public class SetFrequency : TestStep
{
    [Display("Signal Generator")]
    public BaseClassScpiSignalAnalyzer SignalAnalyzer { get; set; }

    [Display("Frequency (MHz)")]
    public double FrequencyMHz { get; set; } = 1000;

    public override void Run()
    {
        if (SignalAnalyzer == null)
        {
            Log.Error("No signal analyzer selected.");
            return;
        }

        try
        {
            Log.Info($"Setting frequency to {FrequencyMHz} MHz...");
            SignalAnalyzer.SetFrequency(FrequencyMHz);
            Results.Publish("Power Measurement", ["FrequencyMHz"], FrequencyMHz);
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Frequency set successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set frequency: {ex.Message}");
        }
    }
}
