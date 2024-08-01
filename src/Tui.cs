namespace CCTT;

class Tui {
    uint index = 0;
    (string, Action<List<Team>>)[] options =
        [("Start!", Start),
        ("View Times", ViewTimes)];

    static void Start(List<Team> teams) {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;


        for(int i = 0; i < teams.Count; i++) {
            if(teams[i].Completed) {
                continue;
            }
            DateTime now = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current team: {teams[i].Name}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Next team: {teams[i == teams.Count - 1 ? i : i + 1].Name}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press a button to proceed ( Q to quit )");
            ConsoleKey ck = Console.ReadKey().Key;
            if(ck == ConsoleKey.Q) {
                break;
            }
            DateTime after = DateTime.Now;
            teams[i].Completed = true;
            teams[i].Length = after - now;
            Console.Clear();
        }

        (new Tui()).RunMenu(teams);
    }

    static void ViewTimes(List<Team> teams) {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        foreach(var team in teams) {
            if(team.Completed)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            if(team.Length is null || team.Completed is false) {
                Console.WriteLine($"{team.Name} : Not yet completed");
            }

            else Console.WriteLine($"{team.Name} : {Math.Round(team.Length.Value.TotalMinutes, 2)} Minutes");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
        (new Tui()).RunMenu(teams);
    }

    public void RunMenu(List<Team> teams) {
        index = 0;
        ConsoleKey ck = ConsoleKey.None;
        DisplayOptions();

        while(ck != ConsoleKey.Enter) {
            ck = Console.ReadKey(false).Key;
            if(ck == ConsoleKey.UpArrow || ck == ConsoleKey.K) dec_index();
            else if(ck == ConsoleKey.DownArrow || ck == ConsoleKey.J) inc_index();
            DisplayOptions();
        }

        options[index].Item2.Invoke(teams);
    }

    void DisplayOptions() {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Apple Arcade Time Table");
        Console.ForegroundColor = ConsoleColor.White;

        for(int i = 0; i < options.Length; i++) {
            if(options[i].Item1 != options[index].Item1) {
                Console.WriteLine($"{options[i].Item1}");
                continue;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{options[i].Item1}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" <");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }


    void inc_index() {
        if(index >= options.Length - 1)
            return;
        index++;
    }
    void dec_index() {
        if(index == 0)
            return;
        index--;
    }
}
