using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> Set Averaging Auto", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Enables automatic averaging.")]
public class SetAveragingAuto : TestStep
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
            Log.Info("Setting averaging to AUTO...");
            PowerSensor.SetAveragingAuto();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Averaging set to AUTO successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set averaging: {ex.Message}");
        }
    }
}
