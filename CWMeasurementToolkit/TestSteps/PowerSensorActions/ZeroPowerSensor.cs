using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> Zero Sensor", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Performs a zeroing operation on the power sensor.")]
public class ZeroPowerSensor : TestStep
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
            Log.Info("Zeroing power sensor...");
            PowerSensor.ZeroPowerSensor();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Power sensor zeroed successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to zero power sensor: {ex.Message}");
        }
    }
}
