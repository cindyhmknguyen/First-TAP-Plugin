using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTap;
using System;
using CWMeasurementToolkit.Instruments.PowerSensors;

namespace CWMeasurementToolkit.TestSteps.PowerSensorActions;

[Display("Power Sensor --> MeasurePower", Group: "CWMeasurementToolkit/TestSteps/PowerSensorActions", Description: "Triggers an immediate single capture power measurement.")]
public class MeasurePower : TestStep
{
    [Display("Power Sensor", Description: "Select the power sensor to use.")]
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
            Log.Info("Power Sensor measuring power...");
            double power = PowerSensor.MeasurePower();
            //Results.Publish("Power Measurement", new { Power = power });
            Results.Publish("Power Measurement", ["Power"], power);
            UpgradeVerdict(Verdict.Pass);
            Log.Info($"Measured Power: {power} dBm");
        }
        catch (Exception ex)
        {
            UpgradeVerdict(Verdict.Error);
            Log.Error($"Measurement failed: {ex.Message}");
        }
    }
}
