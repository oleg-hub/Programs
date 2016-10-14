using System;
using System.Collections.Generic;
using System.Linq;

namespace Black_Jack.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public void DeckInitialization()
        {
            Cards = new List<Card>();
            for (int i = 0; i <= 12; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    Card card = new Card { Nominal = (Nominal)i, Lear = (Lear)j };
                    card.Value = CardValue(card.Nominal);
                    Cards.Add(card);
                }
            }
            MixCards();
        }
        public int CardValue(Nominal nominal)
        {
            switch (nominal)
            {
                case Nominal.Two:
                case Nominal.Jack:
                    return 2;
                case Nominal.Three:
                case Nominal.Queen:
                    return 3;
                case Nominal.Four:
                case Nominal.King:
                    return 4;
                case Nominal.Five:
                    return 5;
                case Nominal.Six:
                    return 6;
                case Nominal.Seven:
                    return 7;
                case Nominal.Eight:
                    return 8;
                case Nominal.Nine:
                    return 9;
                case Nominal.Ten:
                    return 10;
                case Nominal.Ace:
                    return 1;
                default:
                    return 0;
            }
        }
        public void MixCards()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            Cards = Cards.OrderBy(c => random.Next()).ToList();
        }
        public Card PullCard()
        {
            Card firstCard = Cards.FirstOrDefault();
            Cards.Remove(firstCard);
            return firstCard;
        }
    }
}
