using Branirovanie.ParserCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Branirovanie
{
    /// <summary>
    /// Логика взаимодействия для FoodCard.xaml
    /// </summary>
    public partial class FoodCard : UserControl
    {
        public string ImageUrl { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ShopName { get; set; }
        public string ProductId { get; set; }

        public FoodCard()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public FoodCard(FoodSource food)
        {
            InitializeComponent();
            this.DataContext = this;
            ImageUrl = food.ImageUrl;
            FoodName = food.FoodName;
            Description = food.Description.Length == 0 ? FoodName : food.Description;
            Price = food.Price;
            ShopName = food.ShopName;
            ProductId = food.ProductId;
        }

        public FoodSource GetSource()
        {
            return new FoodSource()
            {
                ImageUrl = this.ImageUrl,
                FoodName = this.FoodName,
                Description = this.Description,
                Price = this.Price,
                ShopName = this.ShopName,
                ProductId = this.ProductId
            };
        }

        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            var fc = new FoodOrderedCard(1, this.GetSource());
            MainFood parentWindow = (MainFood)Window.GetWindow(this);
            parentWindow.basket.AddFood(fc);
        }
    }
}
