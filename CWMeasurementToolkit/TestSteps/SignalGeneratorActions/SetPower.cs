using CWMeasurementToolkit.Instruments.SignalGenerators;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

[Display("Signal Generator --> Set Power", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Sets the output power.")]
public class SetPower : TestStep
{
    [Display("Signal Generator")]
    public BaseClassScpiSignalGenerator SignalGenerator { get; set; }

    [Display("Power (dBm)")]
    public double PowerDbm { get; set; } = 0;

    public override void Run()
    {
        if (SignalGenerator == null)
        {
            Log.Error("No signal generator selected.");
            return;
        }

        try
        {
            Log.Info($"Setting power to {PowerDbm} dBm...");
            SignalGenerator.SetPower(PowerDbm);
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
