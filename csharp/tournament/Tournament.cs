using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Tournament
{
    private record Team
    {
        public string Name { get; set; }
        public int MatchesPlayed { get; set; } = 0;
        public int Wins { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int Loses { get; set; } = 0;
        public int Points => Wins * 3 + Draws;
        public override string ToString()
            => $"{Name.PadRight(31)}| {MatchesPlayed.ToString().PadLeft(2)} | {Wins.ToString().PadLeft(2)} | {Draws.ToString().PadLeft(2)} | {Loses.ToString().PadLeft(2)} | {Points.ToString().PadLeft(2)}";
    }
    public static void Tally(Stream inStream, Stream outStream)
    {
        Dictionary<string, Team> teams = new Dictionary<string, Team>();
        using StreamReader sr = new StreamReader(inStream);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] parts = line.Split(";");
            string team1 = parts[0];
            string team2 = parts[1];
            string matchResult = parts[2];
            if (!teams.ContainsKey(team1))
                teams.Add(team1, new Team() { Name = team1 });
            if (!teams.ContainsKey(team2))
                teams.Add(team2, new Team() { Name = team2 });
            teams[team1].MatchesPlayed++;
            teams[team2].MatchesPlayed++;
            if (matchResult == "win")
            {
                teams[team1].Wins++;
                teams[team2].Loses++;
            }
            else if (matchResult == "loss")
            {
                teams[team1].Loses++;
                teams[team2].Wins++;
            }
            else
            {
                teams[team1].Draws++;
                teams[team2].Draws++;
            }
        }
        var encoding = new UTF8Encoding();
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Team                           | MP |  W |  D |  L |  P");
        var rankedTeams = teams
            .OrderByDescending(k => k.Value.Points)
                .ThenBy(k => k.Value.Name);
        foreach (var kvp in rankedTeams)
        {
            string t = kvp.Value.ToString();
            sb.AppendLine(t);
        }
        var results = sb.ToString().Trim();
        outStream.Write(Encoding.UTF8.GetBytes(results));
    }
}
