using CWMeasurementToolkit.Instruments.PowerSensors;
using OpenTap;
using System;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> Initialize", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Initializes the power sensor.")]
public class InitializePowerSensor : TestStep
{
    [Display("Power Sensor")]
    public BaseClassScpiPowerSensor PowerSensor { get; set; }
    public override void PrePlanRun()
    {
        base.PrePlanRun();
    }
    public override void Run()
    {
        if (PowerSensor == null)
        {
            Log.Error("No power sensor selected.");
            return;
        }

        try
        {
            Log.Info("Initializing power sensor...");
            PowerSensor.Initialize();
            UpgradeVerdict(Verdict.Pass);
            Log.Info("Power sensor initialized successfully.");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Initialization failed: {ex.Message}");
        }
    }
}
