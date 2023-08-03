// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, let's play crups!");

int money = 0;
do
{
    Console.Write("How much money do you have ?>");
    Int32.TryParse(Console.ReadLine(), out money);
}while(money == 0);

var game = new Game(money);
// Game loop
while(true) {
    Console.WriteLine($"now you have {game.money}$");
    int bet = game.ReadBet();
    if(bet > game.money) {
        Console.WriteLine("you can not bet more money than you have");
        continue;
    }
    
    switch(game.ComeOut()) {
        case State.Win:
            game.money += bet;
            if(AskContinue())
                goto Owa;
            break;
        case State.Lose:
            game.money -= bet;
            if(AskContinue())
                goto Owa;
            break;
        case State.Continue:
            break;
    }
}
// Eng Game loop
Owa:
bool AskContinue() {
    string value = "";
    while(true)
    {
        Console.Write("You want to continue ? (y/n)>");
        value = Console.ReadLine();
        if(value.Trim() == "y")
            return false;
        else if(value.Trim() == "n")
            return true;
    }
}
