using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> firstDeck = new List<string>();
            List<string> secondDeck = new List<string>();

            string[] array = new[] { "Six Hearts", "Six Diamonds ", "Six Clubs ", "Six Spades", "Seven Hearts", "Seven Diamonds ", "Seven Clubs ", "Seven Spades", "Eight Hearts", "Eight Diamonds ", "Eight Clubs ", "Eight Spades", "Nine Hearts", "Nine Diamonds ", "Nine Clubs ", "Nine Spades", "Ten Hearts", "Ten Diamonds ", "Ten Clubs ", "Ten Spades", "Jack Hearts", "Jack Diamonds ", "Jack Clubs ", "Jack Spades", "Queen Hearts", "Queen Diamonds ", "Queen Clubs ", "Queen Spades", "King Hearts", "King Diamonds ", "King Clubs ", "King Spades", "Ace Hearts", "Ace Diamonds ", "Ace Clubs ", "Ace Spades" };

            foreach (string cards in array)
            {
                firstDeck.Add(cards);
                secondDeck.Add(cards);
            }

            Random random = new Random();
            firstDeck.RemoveAt(random.Next(0, 35));
            var result = secondDeck.Except(firstDeck);
            foreach (string removedNumber in result)
            {
                Console.WriteLine("Stretched out " + removedNumber); // цикл, так же дает возможность находжения более одной вытянутой карты
            }
            Console.ReadKey();
        }
    }
}

