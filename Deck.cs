using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WarGameUpdate
{
    public class Deck
    {
        //private List<Card> _deck;
        
        public List<Card> _deck;
        private Random _random;
        private StringBuilder _sb;
        public Deck()
        {
            _sb = new StringBuilder();
            _random = new Random();
            _deck = new List<Card>();
            string[] suits= new string[] { "Clubs", "Spades", "Hearts", "Diamonds" };
            string[] kinds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            foreach (var suit in suits)
            {
                foreach (var kind in kinds)
                {
                    _deck.Add(new Card { Kind = kind, Suit = suit });
                }
            }
        }
        private void dealCard(Player player)
        {
            Card card = _deck.ElementAt(_random.Next(_deck.Count));
            player.Cards.Add(card);
            _deck.Remove(card);

            _sb.Append("<br/>");
            _sb.Append(player.Name);
            _sb.Append("  is dealt the ");
            _sb.Append(card.Kind);
            _sb.Append(" of ");
            _sb.Append(card.Suit);


        }
        public string Deal(Player player1, Player player2)
        {
            while (_deck.Count > 0)
            {
                // Deal a card to each player randomly
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }
        
    }
    
}