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
        private readonly CardDeck cardDeck = new ();

        public Image GetImage(int numberCard)
        {
            if (cardDeck.cards[numberCard].IsOpen)
            {
                return cardDeck.cards[numberCard].FrontSide;

            }
            return cardDeck.cards[numberCard].backSide;
        }

        private readonly Dictionary<int, Button> ButtonsDic = [];

        private void FillButtonsDic(Grid grid)
        {
            int counter = 0;

            foreach (UIElement element in grid.Children)
            {
                if(element is Button button)
                {
                    
                    ButtonsDic.Add(counter, button);
                    counter++;
                }
            }
        }

        public CardDeskHandler(Grid grid)
        {
            FillButtonsDic(grid);
            SubscribeForButton();
            cardDeck.RemoveCard += OnRemoveCard;
        }

        private void OnRemoveCard(object? sender, EventArgs e)
        {
            int? id = this.cardDeck.GetRemoveCardID();
            var cardDeck = sender as CardDeck;
            if(id.HasValue && cardDeck is not null)
            {
                cardDeck.cards.RemoveAll(_ =>  _.Id == id.Value);
            }
           
            
        }

        private void SubscribeForButton()
        {
            for (int i = 0; i < ButtonsDic.Count; i++)
            {
                ButtonsDic[i].Click += OpenCard;
                ButtonsDic[i].Content = GetImage(i);
            }
        }

        private void OpenCard(object sender, RoutedEventArgs e)
        {
            var Button = sender as Button;

            foreach(var button in ButtonsDic)
            {
                if(button.Value == Button)
                {
                    cardDeck.cards[button.Key].IsOpen = true;
                    Button.Content = GetImage(button.Key);
                    MessageBox.Show( cardDeck.cards[button.Key].Id.ToString());
                    break;
                }
            }
            
        }
    }
}
