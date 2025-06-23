using CWMeasurementToolkit.Instruments.SignalAnalyzers;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalAnalyzerActions;

[Display("Signal Analyzer --> Set Power", Group: "CWMeasurementToolkit/TestSteps/SignalAnalyzerActions", Description: "Sets the output power.")]
public class SetPower : TestStep
{
    [Display("Signal Analyzer")]
    public BaseClassScpiSignalAnalyzer SignalAnalyzer { get; set; }

    [Display("Power (dBm)")]
    public double PowerDbm { get; set; } = 0;

    public override void Run()
    {
        if (SignalAnalyzer == null)
        {
            Log.Error("No signal analyzer selected.");
            return;
        }

        try
        {
            Log.Info($"Setting power to {PowerDbm} dBm...");
            SignalAnalyzer.SetPower(PowerDbm);
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Power set successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set power: {ex.Message}");
        }
    }
}
