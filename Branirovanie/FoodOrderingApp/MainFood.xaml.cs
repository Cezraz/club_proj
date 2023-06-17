using FoodOrderingApp.ParserCore;
using FoodOrderingApp.ParserCore.Presto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodOrderingApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        bool StateClosed = true;
        public ParserWorker<List<FoodSource>> parser;
        public Basket basket;

        private List<RestaurantCard> Restaurants = new List<RestaurantCard>()
        {
            new RestaurantCard(
                "Престо",
                "/Resources/images/restaurants/presto.jpg", 
                "490 руб.", 
                "0 руб.", 
                "09:00 - 01:00", 
                new PrestoParser(), 
                new PrestoSettings()
            ),
            new RestaurantCard(
                "Якида и Фигаро",
                "/Resources/images/restaurants/yakida.png",
                "490 руб.",
                "0 руб.",
                "09:00 - 03:00",
                new YakidaParser(),
                new YakidaSettings()
            ),
            new RestaurantCard(
                "Верона",
                "/Resources/images/restaurants/verona.png",
                "490 руб.",
                "0 руб.",
                "09:00 - 03:00",
                new VeronaParser(),
                new VeronaSettings()
            ),
            new RestaurantCard(
                "Subway",
                "/Resources/images/restaurants/subway.png",
                "500 руб.",
                "0 руб.",
                "10:00 - 22:00",
                new SubwayParser(),
                new SubwaySettings()
            )
        };

        private int _totalPrice = 0;
        public int TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
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

        public MainWindow()
        {
            InitializeComponent();
            InsertRestaurants();
            lvMenu.SelectedItem = lviRestaurants;
            basket.OnBasketUpdate += OnBasketUpdate;
            DataContext = this;
        }

        private void OnBasketUpdate(object arg1, Dictionary<string, List<FoodOrderedCard>> arg2)
        {
            foreach (var rest in arg2)
            {
                var currentBox = (from box in spOrderBoxes.Children.OfType<OrderBox>() 
                                  where box.Title == rest.Key 
                                  select box).First();
                currentBox.Clear();
                foreach (var food in rest.Value)
                {
                    currentBox.AddFood(food);
                }
            }
            UpdateTotalPrice();
        }

        public void UpdateTotalPrice()
        {
            TotalPrice = 0;
            foreach (OrderBox box in spOrderBoxes.Children)
            {
                foreach (FoodOrderedCard item in box.ugItems.Children)
                    TotalPrice += item.GetFullPrice();
            }
        }

        public void InsertRestaurants()
        {
            foreach (var restaurant in Restaurants)
            {
                wpCards.Children.Add(restaurant);
                spOrderBoxes.Children.Add(new OrderBox(restaurant.Title));
            }
                
            basket = new Basket(Restaurants);
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            if (StateClosed)
                sb = FindResource("OpenMenu") as Storyboard;
            else
                sb = FindResource("CloseMenu") as Storyboard;
            sb.Begin();
            StateClosed = !StateClosed;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.GetPosition(this).Y <= 70)
                DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "lviRestaurants":
                    tcPages.SelectedItem = tiRest;
                    break;
                case "lviBasket":
                    tcPages.SelectedItem = tiBasket;
                    break;
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            czHead.Content = "Рестораны";
            tcPages.SelectedItem = tiRest;
        }

        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            var dict = new Dictionary<string, List<(FoodSource, int)>>();
            foreach (OrderBox box in spOrderBoxes.Children)
            {
                var source = box.GetSource();
                dict.Add(source.Item1, source.Item2);
            }
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            MessageBox.Show(json);
        }
    }
}
