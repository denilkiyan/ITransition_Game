using Game;
using System.Text;

if (!ArgsValidator.Validate(args))
{
    return;
}

var numberOfIndex = new Random().Next(0, args.Length);
var computerMove = args[numberOfIndex];
var key = HMACGenerator.GetRandomKey();
var hmacHash = HMACGenerator.GetHMAC(key, computerMove);
int userInputNumber;

Console.WriteLine($"HMAC: {hmacHash}\nAvailable moves: ");
ShowMenu();

while (true)
{
    string userInput = Console.ReadLine();

    if (userInput == "?") { HelpTable.GenerateTable(args);ShowMenu(); }

    else
    {
        bool parseInput = Int32.TryParse(userInput, out userInputNumber);
        if (parseInput)
        {
            if (userInputNumber == 0) return;
            if (userInputNumber < 0 || userInputNumber > args.Length)
            {
                ShowMenu();
                continue;
            }
            else break;
        }
        else ShowMenu();
    }
}

Console.WriteLine();
Console.WriteLine($"Your move: {args[userInputNumber - 1]}");
Console.WriteLine($"Computer move: {computerMove}");

string winIndex = Rules.GetWinner(userInputNumber - 1, numberOfIndex, args.Length);
Console.WriteLine(winIndex);
Console.WriteLine($"HMAC key: {HMACGenerator.GetKeyToString(key)}");


void ShowMenu()
{
    for (int i = 0; i < args.Length; i++)
    {
        Console.WriteLine($"{i + 1} - {args[i]}");
    }
    Console.WriteLine("0 - exit\n? - help");
    Console.Write("Enter your move: ");
}


