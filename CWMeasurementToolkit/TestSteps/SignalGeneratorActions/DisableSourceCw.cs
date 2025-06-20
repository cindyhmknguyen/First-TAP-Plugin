using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

[Display("Signal Generator --> Disable CW Output", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Disables continuous wave output.")]
public class DisableSourceCw : TestStep
{
    [Display("Signal Generator")]
    public BaseClassScpiSignalGenerator SignalGenerator { get; set; }

    public override void Run()
    {
        if (SignalGenerator == null)
        {
            Log.Error("No signal generator selected.");
            return;
        }

        try
        {
            Log.Info("Disabling CW output...");
            SignalGenerator.DisableSourceCw();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("CW output disabled successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to disable CW output: {ex.Message}");
        }
    }
}
