using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

[Display("Signal Generator --> Enable CW Output", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Enables continuous wave output.")]
public class EnableSourceCw : TestStep
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
            Log.Info("Enabling CW output...");
            SignalGenerator.EnableSourceCw();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("CW output enabled successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to enable CW output: {ex.Message}");
        }
    }
}
