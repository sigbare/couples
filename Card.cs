using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace couples
{
    internal class Card
    {
        public Image FrontImage { get; private set; }

        public int CardID { get; private set; }

        public int ButtonId {  get; set; }

        public Card(int CardID, string imagePathURI)
        {
            this.CardID = CardID;
            AddFrontImage(imagePathURI);
        }

        private void AddFrontImage(string imagePath)
        {
            try
            {
                FrontImage = new Image() { Source = new BitmapImage(new Uri("pack://application:,,,/couples;component/image/" + imagePath)) };
            }
            catch
            {
                MessageBox.Show("AddFrontImage error");
            }
        }

    }

}
