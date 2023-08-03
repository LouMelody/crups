internal class Dice {
    private readonly string[,] diceStr = new string[7, 5] {
        { "", "", "", "", "" },
        {
            "-----",
            "|   |",
            "| o |",
            "|   |",
            "-----"
        },
        {
            "-----",
            "|o  |",
            "|   |",
            "|  o|",
            "-----"
        },
        {
            "-----",
            "|o  |",
            "| o |",
            "|  o|",
            "-----"
        },
        {
            "-----",
            "|o o|",
            "|   |",
            "|o o|",
            "-----"
        },
        {
            "-----",
            "|o o|",
            "| o |",
            "|o o|",
            "-----"
        },
        {
            "-----",
            "|o o|",
            "|o o|",
            "|o o|",
            "-----"
        }
    };
    private Random rnd;

    internal Dice()
    {
        rnd = new Random();
    }

    internal int PrintRollAndValue()
    {
        int one = rnd.Next(1, 7);
        int two = rnd.Next(1, 7);
        for(int i = 0; i < 5; i++) {
            Console.WriteLine(diceStr[one, i] + diceStr[two, i]);
        }

        return one + two;
    }
}