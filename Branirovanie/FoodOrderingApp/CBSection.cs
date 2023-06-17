using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FoodOrderingApp
{
    public class CBSection : RadioButton
    {
        private string _sectionCode { get; set; }

        public CBSection(string sc, string sn)
        {
            _sectionCode = sc;
            Content = sn;
            Style = FindResource("SectionStyle") as Style;
        }

        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.wpFood.Children.Clear();
            parentWindow.parser.ParseSection(_sectionCode);
        }
    }
}
