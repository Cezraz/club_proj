using FoodOrderingApp.ParserCore;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodOrderingApp
{
    public partial class OrderBox : UserControl, INotifyPropertyChanged
    {
        public string Title { get; set; }

        private int _itemscount;
        public int ItemsCount
        {
            get { return _itemscount; }
            set
            {
                _itemscount = value;
                OnPropertyChanged("ItemsCount");
            }
        }

        private PathFigure ClosedArrow = new PathFigure()
        {
            StartPoint = new Point(1, 1),
            Segments = new PathSegmentCollection()
            {
                new LineSegment() { Point = new Point(15, 15) },
                new LineSegment() { Point = new Point(29, 1) }
            }
        };
        private PathFigure OpenedArrow = new PathFigure()
        {
            StartPoint = new Point(1, 14),
            Segments = new PathSegmentCollection()
            {
                new LineSegment() { Point = new Point(15, 1) },
                new LineSegment() { Point = new Point(29, 14) }
            }
        };

        void OnPropertyChanged(String prop)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public OrderBox()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public OrderBox(string t)
        {
            InitializeComponent();
            this.DataContext = this;
            Title = t;
        }

        public void AddFood(FoodOrderedCard card)
        {
            card.Margin = new Thickness(0, 0, 10, 10);
            ugItems.Children.Add(card);
            ItemsCount = ugItems.Children.Count;
        }

        public void RemoveFood(FoodOrderedCard card)
        {
            ugItems.Children.Remove(card);
            ItemsCount = ugItems.Children.Count;
        }

        public void Clear()
        {
            this.ugItems.Children.Clear();
        }

        private void setArrowState(PathFigure figure)
        {
            var template = btHeader.Template;
            var arrow = (Path)template.FindName("pathArrow", btHeader);
            var geometry = new PathGeometry();
            geometry.Figures.Add(figure);
            arrow.Data = geometry;
        }

        private void btHeader_Click(object sender, RoutedEventArgs e)
        {
            var arrowState = new PathFigure();
            if (Body.Visibility == Visibility.Visible)
            {
                Body.Visibility = Visibility.Collapsed;
                arrowState = ClosedArrow;
            }
            else
            {
                Body.Visibility = Visibility.Visible;
                arrowState = OpenedArrow;
            }
            setArrowState(arrowState);
        }

        public (string, List<(FoodSource, int)>) GetSource()
        {
            var list = new List<(FoodSource, int)>();

            foreach (FoodOrderedCard item in ugItems.Children)
            {
                list.Add(item.GetSource());
            }

            return (Title, list);
        }

    }
}
