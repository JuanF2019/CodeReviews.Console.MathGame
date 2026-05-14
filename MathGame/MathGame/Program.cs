using System.Reflection.PortableExecutable;

bool exitGame = false;
string? input;
List<int> scores = new List<int>();
const int NumberOfQuestionsPerGame = 5;
const int ScorePerQuestion = 10;
const int MaximumScore = ScorePerQuestion * NumberOfQuestionsPerGame;

do
{
    Console.WriteLine("Main menu");
    Console.WriteLine("Please select a game mode or type \"exit\" to close the app:");
    Console.WriteLine("1. Sum game");

    bool validSelection;
    do
    {        
        input = Console.ReadLine();
        bool inputNotEmpty = input != null && input.Length > 0;
        validSelection = true;

        if (inputNotEmpty)
        {
            string userSelection = input.ToLower();
            switch (userSelection)
            {
                case "exit":
                    exitGame = true;
                    break;
                case "1":
                    Console.Clear();
                    int score = sumGame();
                    scores.Add(score);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid selection please try again.");
                    validSelection = false;
                    break;
            }
        }
    } while (!validSelection);
} while (!exitGame);

static int sumGame()
{
    int score = 0;
    Random random = new Random();

    int minNumber = 1;
    int maxNumber = 9;

    for(int i = 0; i < NumberOfQuestionsPerGame; i++)
    {
        int number1 = random.Next(minNumber, maxNumber+1);
        int number2 = random.Next(minNumber,maxNumber+1);
        int expectedAnswer = number1 + number2;

        Console.WriteLine($"Question {i+1}/{NumberOfQuestionsPerGame}\nWhat is {number1} + {number2} ?");

        string input = Console.ReadLine();
        int userAnswer;

        while (input == null || input.Length == 0 || !int.TryParse(input, out userAnswer))
        {
            Console.WriteLine("Your answer must be an integer number.");
            input = Console.ReadLine();
        }

        if(userAnswer == expectedAnswer)
        {
            score += ScorePerQuestion;
        }
        Console.Clear();
    }
    Console.WriteLine($"Your score was: {score}/{MaximumScore}");
    return score;
}

enum Operations
{
    ADDITION,SUBSTRACTION,MULTIPLICATION,DIVISION
}
/*
 * Ciclo para la selección de la operación
 * For para las preguntas
 * 
 */