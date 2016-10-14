using Black_Jack.Models;
using System;

namespace Black_Jack
{
    class Round
    {
        Deck deck = new Deck();
        View view = new View();
        public void DeckInitialization()
        {
            deck.DeckInitialization();
        }
        public Card GetCardForUser()
        {
            Card card = deck.PullCard();
            AllScore.UserScore += deck.CardValue(card.Nominal);
            return card;
        }
        public void CardForUserOrComputer(System.ConsoleKeyInfo keyEnter)
        {
            if (keyEnter.Key == ConsoleKey.Spacebar)
            {
                Card card = deck.PullCard();
                AllScore.UserScore += deck.CardValue(card.Nominal);
                view.OutputСard(card);
                ConditionsForUser();
            }
            if (keyEnter.Key == ConsoleKey.Escape)
            {
                while (true)
                {
                    Card card = deck.PullCard();
                    AllScore.ComputerScore += deck.CardValue(card.Nominal);
                    ConditionsForComputer();
                }
            }
        }
        public void ConditionsForUser()
        {
            if (AllScore.UserScore == 21)
            {
                AllScore.TotalScoreForUser += 1;
                AllScore.UserScore = 0;
                view.GameResult(true);
            }
            if (AllScore.UserScore > 21)
            {
                AllScore.TotalScoreForComputer += 1;
                AllScore.UserScore = 0;
                view.GameResult(false);
            }
        }
        public void ConditionsForComputer()
        {
            if (AllScore.ComputerScore > AllScore.UserScore && AllScore.ComputerScore <= 21)
            {
                AllScore.TotalScoreForComputer += 1;
                AllScore.UserScore = 0;
                view.GameResult(false);
            }
            if (AllScore.ComputerScore > 21)
            {
                AllScore.TotalScoreForUser += 1;
                AllScore.UserScore = 0;
                AllScore.ComputerScore = 0;
                view.GameResult(true);
            }
        }
    }
}