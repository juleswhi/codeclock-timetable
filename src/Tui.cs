namespace CCTT;

class Tui {
    uint index = 0;
    (string, Action)[] options = [("Start!", () => {

    })];

    public void RunMenu() {
        index = 0;
        ConsoleKey ck = ConsoleKey.None;
        DisplayOptions();

        while(ck != ConsoleKey.Enter) {
            ck = Console.ReadKey(false).Key;
            if(ck== ConsoleKey.UpArrow) dec_index();
            else if(ck== ConsoleKey.DownArrow) inc_index();
            DisplayOptions();
        }
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
        }
    }


    void inc_index() {
        if ( index < options.Length - 1 ) {
            index--;
        }
    }
    void dec_index() {
        if ( index > 0 ) {
            index++;
        }
    }
}
