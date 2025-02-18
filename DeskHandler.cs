using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;


namespace couples
{
    internal class DeskHandler
    {
        CardDeck cardDeck;

        public List<Button> buttons;

        public DeskHandler(int numberCards)
        {
            cardDeck = new CardDeck(numberCards);
            buttons = new List<Button>();
        }

        public void FillButtons(Button button)
        {
            if (button is not null)
            {
                buttons.Add(button);
            }

        }

        public void SetImage(int ButtonId)
        {
            
            buttons[ButtonId].Content = cardDeck.Cards[ButtonId].FrontImage;
        }

        public void SetClick()
        {

        }
    }
}
