using Black_Jack.Models;
using System;
using System.Text.RegularExpressions;

namespace Black_Jack
{
    class View
    {
        public System.ConsoleKeyInfo enter;
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Press 'space' to start a new game, e - exit");
                enter = Console.ReadKey();
                if (enter.Key == ConsoleKey.Spacebar)
                {
                    Menu();
                }
                if (enter.Key == ConsoleKey.E)
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(" Not correct answer");
                    continue;
                }
            }
        }

        public void Menu()
        {
            Round round = new Round();
            string informationString = "Total score: \tUser {0} \tComputer {1}";
            Console.Clear();
            round.DeckInitialization();
            OutputСard(round.GetCardForUser());
            OutputСard(round.GetCardForUser());
            Console.WriteLine(informationString, AllScore.TotalScoreForUser, AllScore.TotalScoreForComputer);
            while (true)
            {
                Console.WriteLine("\n Press 'space' to get new card, esc - pass the course to computer ");
                enter = Console.ReadKey();
                Console.Clear();
                round.CardForUserOrComputer(enter);
                Console.WriteLine(informationString, AllScore.TotalScoreForUser, AllScore.TotalScoreForComputer);
            }
        }

        public void GameResult(bool isUserWin)
        {
            if (isUserWin)
            {
                Console.WriteLine(" You win");
            }
            else
            {
                Console.WriteLine(" You lost, Computer win");
                if (AllScore.ComputerScore > 0)
                {
                    Console.WriteLine(" Computer score: {0}", AllScore.ComputerScore);
                }
                AllScore.ComputerScore = 0;
            }
            Start();
        }

        public void OutputСard(Card card)
        {
            Console.WriteLine("{0} {1}  Score: {2}", card.Nominal, card.Lear, AllScore.UserScore);
        }
    }
}