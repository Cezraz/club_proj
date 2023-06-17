using Branirovanie.ParserCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для FoodOrderedCard.xaml
    /// </summary>
    public partial class FoodOrderedCard : UserControl, INotifyPropertyChanged
    {
        private int _quantity;
        public int Quantity 
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public string ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ShopName { get; set; }
        private FoodSource Source { get; set; }

        public FoodOrderedCard()
        {
            InitializeComponent();
        }

        public FoodOrderedCard(int q, FoodSource fs)
        {
            InitializeComponent();
            this.DataContext = this;
            Source = fs;
            Price = fs.Price;
            Quantity = q;
            ProductId = fs.ProductId;
            ImageUrl = fs.ImageUrl;
            FoodName = fs.FoodName;
            Description = fs.Description;
            ShopName = fs.ShopName;
        }

        void OnPropertyChanged(String prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btDec_Click(object sender, RoutedEventArgs e)
        {
            if (Quantity > 1) Quantity--;
            var mw = (MainFood)Window.GetWindow(this);
            mw.UpdateTotalPrice();
        }

        private void btInc_Click(object sender, RoutedEventArgs e)
        {
            if (Quantity < 99) Quantity++;
            var mw = (MainFood)Window.GetWindow(this);
            mw.UpdateTotalPrice();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var mw = (MainFood)Window.GetWindow(this);
            var parent = VisualTreeHelper.GetParent(this);
            while (!(parent is OrderBox))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            ((OrderBox)parent).RemoveFood(this);
            mw.UpdateTotalPrice();
        }

        public int GetFullPrice()
        {
            return Quantity * Convert.ToInt32(Price);
        }

        public (FoodSource, int) GetSource()
        {
            return (Source, Quantity);
        }
    }
}
