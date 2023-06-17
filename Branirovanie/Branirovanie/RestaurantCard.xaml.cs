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
    /// Логика взаимодействия для RestaurantCard.xaml
    /// </summary>
    public partial class RestaurantCard : UserControl
    {
        public RestaurantCard(string t, string ip, string mos, string dc, string wt, IParser<List<FoodSource>> p, IParserSettings s)
        {
            InitializeComponent();
            this.DataContext = this;
            Title = t;
            ImagePath = ip;
            MinOrderSum = mos;
            DeliveryCost = dc;
            WorkTime = "Время работы: " + wt;
            Parser = p;
            Settings = s;
        }

        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string MinOrderSum { get; set; }
        public string DeliveryCost { get; set; }
        public string WorkTime { get; set; }
        public IParser<List<FoodSource>> Parser { get; set; }
        public IParserSettings Settings { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFood parentWindow = (MainFood)Window.GetWindow(this);
            parentWindow.czHead.Content = Title;
            parentWindow.tcPages.SelectedItem = parentWindow.tiFood;
            parentWindow.parser = new ParserWorker<List<FoodSource>>(Parser);
            parentWindow.parser.Settings = Settings;
            parentWindow.parser.OnNewData += Parser_OnNewData;
            parentWindow.parser.OnSectionsLoaded += Parser_OnSectionsLoaded;
            parentWindow.wpFood.Children.Clear();
            parentWindow.spSections.Children.Clear();
            parentWindow.parser.Start();
        }

        private void Parser_OnSectionsLoaded(object arg1, List<CBSection> arg2)
        {
            MainFood parentWindow = (MainFood)Window.GetWindow(this);
            parentWindow.spSections.Children.Clear();
            foreach (var rb in arg2)
            {
                parentWindow.spSections.Children.Add(rb);
            }
            ((CBSection)parentWindow.spSections.Children[0]).IsChecked = true;
        }

        private void Parser_OnNewData(object arg1, List<FoodSource> arg2)
        {
            MainFood parentWindow = (MainFood)Window.GetWindow(this);
            foreach (var food in arg2)
            {
                parentWindow.wpFood.Children.Add(
                    new FoodCard(food)
                    {
                        Margin = new Thickness(0, 0, 10, 10)
                    }
                );
            }
        }
    }
}
