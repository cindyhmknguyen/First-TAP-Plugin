using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

[Display("Signal Generator --> Set ARB", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Turn the ARB on or off.")]
public class SetARB : TestStep
{
    [Display("Signal Generator")]
    public BaseClassScpiSignalGenerator SignalGenerator { get; set; }

    [Display("ARB State")]
    public bool arb { get; set; } = false;

    public override void Run()
    {
        if (SignalGenerator == null)
        {
            Log.Error("No signal generator selected.");
            return;
        }

        try
        {
            Log.Info($"Setting the ARB...");
            SignalGenerator.SetARB(arb);
            UpgradeVerdict(Verdict.Pass);
            Log.Info("ARB set successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set the ARB: {ex.Message}");
        }
    }
}
