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
    Reset:
    if(game.money <= 0) {
        Console.WriteLine("You bankrupt, See you !");
        break;
    }
    Console.WriteLine($"now you have {game.money}$");
    int bet = game.ReadBet();
    if(bet > game.money) {
        Console.WriteLine("you can not bet more money than you have");
        continue;
    }
    
    switch(game.ComeOut()) {
        case State.Win:
            game.money += bet;
            if(game.AskContinue())
                goto Owa;
            break;
        case State.Lose:
            game.money -= bet;
            if(game.AskContinue())
                goto Owa;
            break;
        case State.Continue:
            bool playerTurn = false;
            while(true) {
                if(playerTurn) {
                    Console.WriteLine("PLAYER ROLL!");
                    switch(game.Come()) {
                        case State.Win:
                            game.money += bet;
                            if(game.AskContinue())
                                goto Owa;
                            goto Reset;
                        case State.Lose:
                            game.money -= bet;
                            if(game.AskContinue())
                                goto Owa;
                            goto Reset;
                        case State.Continue:
                            break;
                    }
                    playerTurn = false;
                }
                else {
                    Console.WriteLine("COM ROLL!");
                    switch(game.Come()) {
                        case State.Win:
                            game.money -= bet;
                            if(game.AskContinue())
                                goto Owa;
                            goto Reset;
                        case State.Lose:
                            game.money += bet;
                            if(game.AskContinue())
                                goto Owa;
                            goto Reset;
                        case State.Continue:
                            break;
                    }
                    playerTurn = true;
                }
            }
            break;
    }
}
// Eng Game loop
Owa:
;
