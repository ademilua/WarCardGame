using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WarGameUpdate
{
    public class Battle
    {
        private List<Card> _bounty;
        private StringBuilder _sb;

        public Battle()
        {
            _bounty = new List<Card>(); // a new list of cards in _bounty
            _sb = new StringBuilder();  // a new list of string built up by stringbuilder in _sb.
        }
        private Card getCard(Player player)
        {
            Card card = player.Cards.ElementAt(0); // Gives a card to each player out of the 26 cards from each
            player.Cards.Remove(card); // removes the card from the losing player's hand
            _bounty.Add(card);   // add the removed card to a _bounty of the type List<Card>
            return card;   // return the card to its caller.
        }
        private void performEvaluation(Card card1, Card card2, Player player1, Player player2)
        {
            displayBattleCards(card1, card2);

            if (card1.CardValue() == card2.CardValue()) war(player1, player2);
            if (card1.CardValue() > card2.CardValue()) awardWinner(player1);
            else awardWinner(player2);

            
        }
        public string performBattle(Player player1, Player player2)
        {
                Card player1Card = getCard(player1);
                Card player2Card = getCard(player2);
                performEvaluation(player1Card, player2Card, player1, player2);
                return _sb.ToString();

        }
        private void war(Player player1, Player player2)
        {
             // supply 3 cards for each player. 
             // we created an handle for the second getCard() method in other to use the handle for comparism
            getCard(player1);
            Card warCard1 = getCard(player1);
            getCard(player1);

            getCard(player2);
            Card warCard2 = getCard(player2);
            getCard(player2);
            // we now called on the performevaluation to compare the second card for each player during war.
            performEvaluation(warCard1, warCard2, player1, player2);

        }
        // Create a helper method to determine which cards are taking place in battle
        private void displayBattleCards(Card card1, Card card2)
        {
            _sb.Append("<br/> Battle begins:");
            _sb.Append(card1.Kind);
            _sb.Append("of");
            _sb.Append(card1.Suit);
            _sb.Append("Versus");
            _sb.Append(card2.Kind);
            _sb.Append("of");
            _sb.Append(card2.Suit);
        }
        private void displayBountyCards()
        {
            _sb.Append("</br>bounty...");
            foreach (var card in _bounty)
            {
                _sb.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;");
                _sb.Append(card.Kind);
               _sb.Append("of");
               _sb.Append(card.Suit);
            }
        }
        private void awardWinner(Player player)
        {
            if (_bounty.Count == 0) return;
            displayBountyCards();
            player.Cards.AddRange(_bounty);
            _bounty.Clear();

            _sb.Append("<br/><strong>");
            _sb.Append(player.Name);
            _sb.Append("wins!</strong><br/>");
        }
    }
}