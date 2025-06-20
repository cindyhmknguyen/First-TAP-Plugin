using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> Set Continuous Measurement Mode", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Sets the continuous measurement mode.")]
public class SetContinuousMeasMode : TestStep
{
    [Display("Power Sensor")]
    public BaseClassScpiPowerSensor PowerSensor { get; set; }

    [Display("Measurement Mode", Description: "ON or OFF")]
    public string MeasMode { get; set; } = "ON";

    public override void Run()
    {
        if (PowerSensor == null)
        {
            Log.Error("No power sensor selected.");
            return;
        }

        try
        {
            Log.Info($"Setting continuous measurement mode to {MeasMode}...");
            PowerSensor.SetContinuousMeasMode(MeasMode);
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Continuous measurement mode set successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set measurement mode: {ex.Message}");
        }
    }
}
