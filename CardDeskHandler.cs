using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace couples
{
    internal class CardDeskHandler 
    {
        private CardDeck cardDeck = new CardDeck();

        private int counter;

        


        public Image GetImage(int numberCard)
        {
            if (cardDeck.cards[numberCard].IsOpen)
            {
                return cardDeck.cards[numberCard].frontImage;

            }
            return cardDeck.cards[numberCard].backSide;
        }

        public List<Button> GetButtonsFromGrid(Grid grid)
        {
            List<Button> buttons = new List<Button>();

            foreach (UIElement child in grid.Children)
            {
                if (child is Button button)
                {
                    buttons.Add(button);
                }
            }

            return buttons;
        }

        

       public delegate void InitTakeCardHandler(object sender);

       public event InitTakeCardHandler? InitTakeCard;

    }
}
