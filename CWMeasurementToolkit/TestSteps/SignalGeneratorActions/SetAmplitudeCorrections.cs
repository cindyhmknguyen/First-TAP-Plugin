//using CWMeasurementToolkit.Instruments.SignalGenerators;
//using OpenTap;
//using System;

//namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

//[Display("Signal Generator --> Set Amplitude Corrections", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Applies amplitude correction file to the signal generator.")]
//public class SetAmplitudeCorrections : TestStep
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
//            Log.Info($"Applying amplitude corrections from '{FilePath}' to RF{RfChannelNumber}...");
//            SignalGenerator.SetAmplitudeCorrections(FilePath, RfChannelNumber);
//            UpgradeVerdict(Verdict.Pass);
//            Log.Info("Amplitude corrections applied successfully.");
//        }
//        catch (Exception ex)
//        {
//            UpgradeVerdict(Verdict.Error);
//            Log.Error($"Failed to apply amplitude corrections: {ex.Message}");
//        }
//    }
//}
