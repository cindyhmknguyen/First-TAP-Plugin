using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

[Display("Signal Generator --> Initialize", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Initializes the signal generator.")]
public class InitializeSignalGenerator : TestStep
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
            Log.Info("Initializing signal generator...");
            SignalGenerator.Initialize();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Signal generator initialized successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Initialization failed: {ex.Message}");
        }
    }
}
