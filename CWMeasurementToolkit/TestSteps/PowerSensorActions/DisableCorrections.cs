using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> Disable Corrections", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Disables all correction sets.")]
public class DisableCorrections : TestStep
{
    [Display("Power Sensor")]
    public BaseClassScpiPowerSensor PowerSensor { get; set; }

    public override void Run()
    {
        if (PowerSensor == null)
        {
            Log.Error("No power sensor selected.");
            return;
        }

        try
        {
            Log.Info("Disabling corrections...");
            PowerSensor.DisableCorrections();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Corrections disabled successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to disable corrections: {ex.Message}");
        }
    }
}
