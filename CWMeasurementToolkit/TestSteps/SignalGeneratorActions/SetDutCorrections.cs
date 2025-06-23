//using CWMeasurementToolkit.Instruments.SignalGenerators;
//using OpenTap;
//using System;

//namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

//[Display("Signal Generator --> Set DUT Corrections", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Applies DUT correction file to the signal generator.")]
//public class SetDutCorrections : TestStep
//{
//    [Display("Signal Generator")]
//    public BaseClassScpiSignalGenerator SignalGenerator { get; set; }

//    [Display("Correction File Path")]
//    public string FilePath { get; set; }

//    [Display("RF Channel Number")]
//    public int RfChannelNumber { get; set; } = 1;

//    public override void Run()
//    {
//        if (SignalGenerator == null)
//        {
//            Log.Error("No signal generator selected.");
//            return;
//        }

//        try
//        {
//            Log.Info($"Applying DUT corrections from '{FilePath}' to RF{RfChannelNumber}...");
//            SignalGenerator.SetDutCorrections(FilePath, RfChannelNumber);
//            UpgradeVerdict(Verdict.Pass);
//            Log.Info("DUT corrections applied successfully.");
//        }
//        catch (Exception ex)
//        {
//            UpgradeVerdict(Verdict.Error);
//            Log.Error($"Failed to apply DUT corrections: {ex.Message}");
//        }
//    }
//}
