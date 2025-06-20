using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> Set Units", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Sets the power measurement units.")]
public class SetUnits : TestStep
{
    [Display("Power Sensor")]
    public BaseClassScpiPowerSensor PowerSensor { get; set; }

    [Display("Units", Description: "e.g., DBM, W")]
    public string Units { get; set; } = "DBM";

    public override void Run()
    {
        if (PowerSensor == null)
        {
            Log.Error("No power sensor selected.");
            return;
        }

        try
        {
            Log.Info($"Setting units to {Units}...");
            PowerSensor.SetUnits(Units);
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Units set successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set units: {ex.Message}");
        }
    }
}
