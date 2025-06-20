using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> Set Mode Power Average", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Sets the sensor to power average mode.")]
public class SetModePowerAvg : TestStep
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
            Log.Info("Setting mode to power average...");
            PowerSensor.SetModePowerAvg();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Power average mode set successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set power average mode: {ex.Message}");
        }
    }
}
