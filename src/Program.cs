using CCTT;

string[] file = File.ReadAllLines("teams.txt");

List<Team> teams = new();

foreach(var team in file) {
    teams.Add(new(team));
}

foreach(var team in teams) {
    // Console.WriteLine(team.Name);
}


