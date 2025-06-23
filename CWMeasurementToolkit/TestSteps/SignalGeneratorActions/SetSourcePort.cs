//using CWMeasurementToolkit.Instruments.SignalGenerators;
//using OpenTap;
//using System;

//namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

//[Display("Signal Generator --> Set Source Port", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Sets the source port.")]
//public class SetSourcePort : TestStep
//{
//    [Display("Signal Generator")]
//    public BaseClassScpiSignalGenerator SignalGenerator { get; set; }

//    [Display("Port Name")]
//    public string PortName { get; set; }

//    public override void Run()
//    {
//        if (SignalGenerator == null)
//        {
//            Log.Error("No signal generator selected.");
//            return;
//        }

//        try
//        {
//            Log.Info($"Setting source port to '{PortName}'...");
//            SignalGenerator.SetSourcePort(PortName);
//            UpgradeVerdict(Verdict.Pass);
//            Log.Info("Source port set successfully.");
//        }
//        catch (Exception ex)
//        {
//            UpgradeVerdict(Verdict.Error);
//            Log.Error($"Failed to set source port: {ex.Message}");
//        }
//    }
//}
