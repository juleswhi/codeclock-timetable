using CCTT;

var teams = File.ReadAllLines("teams.txt")
    .AsEnumerable()
    .Select(x => new Team(x))
    .ToList();

(new Tui()).RunMenu(teams);
Console.WriteLine();
