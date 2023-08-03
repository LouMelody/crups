internal class Game {
    Dice dice;
    int point;
    internal int money;

    internal Game(int money) {
        dice = new();
        this.money = money;
    }
    internal State ComeOut() {
        RollPrompt();
        var value = dice.PrintRollAndValue();
        
        if(value == 7 || value == 11) {
            return State.Win;
        }
        else if(value == 2 || value == 3 || value == 12) {
            return State.Lose;
        }
        else {
            point = value;
            return State.Continue;
        }
    }
    internal State Come() {
        RollPrompt();
        var value = dice.PrintRollAndValue();

        if(value == 7) {
            return State.Lose;
        }
        if(value == point) {
            return State.Win;
        }
        return State.Continue;
    }

    internal void RollPrompt() {
        Console.WriteLine("please hit Enter to roll dice");
        Console.ReadKey(true);
    }

    internal bool AskContinue() {
        string value = "";
        while(true)
        {
            Console.WriteLine($"remain {money}$");
            Console.Write("You want to continue ? (y/n)>");
            value = Console.ReadLine();
            if(value.Trim() == "y")
                return false;
            else if(value.Trim() == "n")
                return true;
        }
}
    internal int ReadBet() {
        int bet = 0;
        do
        {
            Console.Write("How much money do you bet ?>");
            Int32.TryParse(Console.ReadLine(), out bet);
        }while(bet == 0);

        return bet;
    }
}