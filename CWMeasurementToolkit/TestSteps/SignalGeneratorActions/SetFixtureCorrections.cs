//using CWMeasurementToolkit.Instruments.SignalGenerators;
//using OpenTap;
//using System;

//namespace CWMeasurementToolkit.TestSteps.SignalGeneratorActions;

//[Display("Signal Generator --> Set Fixture Corrections", Group: "CWMeasurementToolkit/TestSteps/SignalGeneratorActions", Description: "Applies fixture correction file to the signal generator.")]
//public class SetFixtureCorrections : TestStep
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
//            Log.Info($"Applying fixture corrections from '{FilePath}' to RF{RfChannelNumber}...");
//            SignalGenerator.SetFixtureCorrections(FilePath, RfChannelNumber);
//            UpgradeVerdict(Verdict.Pass);
//            Log.Info("Fixture corrections applied successfully.");
//        }
//        catch (Exception ex)
//        {
//            UpgradeVerdict(Verdict.Error);
//            Log.Error($"Failed to apply fixture corrections: {ex.Message}");
//        }
//    }
//}
