using CWMeasurementToolkit.Instruments.SignalAnalyzers;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalAnalyzerActions;

[Display("Signal Analyzer --> Initialize", Group: "CWMeasurementToolkit/TestSteps/SignalAnalyzerActions", Description: "Initializes the signal analyzer.")]
public class InitializeSignalAnalyzer : TestStep
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
            Log.Info("Initializing signal analyzer...");
            SignalAnalyzer.Initialize();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Signal analyzer initialized successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Initialization failed: {ex.Message}");
        }
    }
}
