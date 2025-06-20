using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

[Display("Signal Generator --> Set Frequency", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Sets the output frequency.")]
public class SetFrequency : TestStep
{
    [Display("Signal Generator")]
    public BaseClassScpiSignalGenerator SignalGenerator { get; set; }

    [Display("Frequency (MHz)")]
    public double FrequencyMHz { get; set; } = 1000;

    public override void Run()
    {
        if (SignalGenerator == null)
        {
            Log.Error("No signal generator selected.");
            return;
        }

        try
        {
            Log.Info($"Setting frequency to {FrequencyMHz} MHz...");
            SignalGenerator.SetFrequency(FrequencyMHz);
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
