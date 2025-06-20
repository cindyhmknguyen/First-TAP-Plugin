using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> Set Frequency", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Sets the measurement frequency.")]
public class SetFrequency : TestStep
{
    [Display("Power Sensor")]
    public BaseClassScpiPowerSensor PowerSensor { get; set; }

    [Display("Frequency (MHz)")]
    public double FrequencyMHz { get; set; } = 1000;

    public override void Run()
    {
        if (PowerSensor == null)
        {
            Log.Error("No power sensor selected.");
            return;
        }

        try
        {
            Log.Info($"Setting frequency to {FrequencyMHz} MHz...");
            PowerSensor.SetFrequency(FrequencyMHz);
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Frequency set successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Failed to set frequency: {ex.Message}");
        }
    }
}
