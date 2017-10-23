using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarGameUpdate
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PlayButton_Click(object sender, EventArgs e)
        {
            Game game = new Game("Player1" , "Player2");
            //Player player = new Player();
            /* Deck deck = new Deck();
             foreach (var card in deck._deck)
             {
                 resultLabel.Text += string.Format("{0} of {1}</br>", card.Kind, card.Suit);
             }*/
            resultLabel.Text = game.Play();
        }
    }
} 