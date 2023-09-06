using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
        => shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 => "center back",
            4 => "center back",
            5 => "right back",
            6 => "midfielder",
            7 => "midfielder",
            8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => throw new ArgumentOutOfRangeException("shirt number is out of range", nameof(shirtNum)),
        };

    private static string formatSupporterReport(int n)
        => $"There are {n} supporters at the match.";

    private static string formatManagerReport(Manager m)
        => m.Club == null
            ? m.Name
            : $"{m.Name} ({m.Club})";
    private static string formatInjuryReport(Injury i)
        => $"Oh no! {i.GetDescription()} Medics are on the field.";

    public static string AnalyzeOffField(object report)
        => report switch
        {
            int => formatSupporterReport((int)report),
            string => (string)report,
            Foul => ((Foul)report).GetDescription(),
            Injury => formatInjuryReport((Injury)report),
            Incident => ((Incident)report).GetDescription(),
            Manager => formatManagerReport((Manager)report),
            _ => throw new ArgumentException("report is unknown type", nameof(report)),

        };
}
