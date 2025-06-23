using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

[Display("Signal Generator --> Load into ARB Memory", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Load .wfm file into ARB memory.")]
public class LoadARBMemory : TestStep
{
    [Display("Signal Generator")]
    public BaseClassScpiSignalGenerator SignalGenerator { get; set; }

    [Display("File path")]
    public string FPath { get; set; } = "";

    [Display("File name")]
    public string FName { get; set; } = "";

    public override void Run()
    {
        if (SignalGenerator == null)
        {
            Log.Error("No signal generator selected.");
            return;
        }

        try
        {
            Log.Info($"Loading wfm file into ARB memory...");
            SignalGenerator.LoadARBMemory(FPath, FName);
            UpgradeVerdict(Verdict.Pass);
            Log.Info("wfm file successfully loaded into ARB memory.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to load into ARB memory: {ex.Message}");
        }
    }
}
