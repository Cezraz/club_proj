using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
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
using System.Windows.Shapes;
using MessBox;

namespace Branirovanie
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        DataBase db = new DataBase();
        public Authorization()
        {
            InitializeComponent();
        }

        private void Mainindow_Loaded(object sender, RoutedEventArgs e)
        {
            
           
            if (Properties.Settings.Default.IsDark == true)
            {   var ccode = "#FF333337";
                Color clr = (Color)ColorConverter.ConvertFromString(ccode);
                var brush = new SolidColorBrush(clr);
                Theme_tg.IsChecked = true;
                Mainindow.Background = brush;
                Login.Foreground = Brushes.White;
                Password.Foreground = Brushes.White;
            }
           else
           {
                Theme_tg.IsChecked = false;
                var ccode = "#FF673AB7";
                Color clr = (Color)ColorConverter.ConvertFromString(ccode);
                var brush = new SolidColorBrush(clr);
                Login.Foreground = brush;
                Password.Foreground = brush;
                Mainindow.Background = Brushes.White;
           }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DesignFunctions.checkEmpty_aut((StackPanel)MainGrid.Children[2]))
            {
                var list=db.getAutentification(Login.Text, Password.Password);
                if (list!=null)
                {
                    WpfMessageBox.Show("Совершен вход с логином " + list[0] + ", добро пожаловать.", "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);
                    if(int.TryParse(list[1],out int item))
                    {
                        MainWindow mw = new MainWindow(item,this, Properties.Settings.Default.IsDark);
                        Properties.Settings.Default.Curuser = Login.Text;
                        Properties.Settings.Default.Save();
                        this.Close();
                        mw.ShowDialog();
                    }
                }
                else
                {
                    WpfMessageBox.Show("Введены неверные данные, вход невозможен.","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var tb = (ToggleButton)sender;
            ResourceDictionary dictionary = new ResourceDictionary();
            if (tb.IsChecked == true)
            {
                var ccode = "#FF333337";
                Color clr = (Color)ColorConverter.ConvertFromString(ccode);
                var brush = new SolidColorBrush(clr);
                MainGrid.Background = brush;
                Login.Foreground = Brushes.White;
                Password.Foreground = Brushes.White;
                dictionary.Source = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml");
                Properties.Settings.Default.IsDark = true;
             
            }
            else
            {
                var ccode = "#FF673AB7";
                Color clr = (Color)ColorConverter.ConvertFromString(ccode);
                var brush = new SolidColorBrush(clr);
                Login.Foreground = brush;
                Password.Foreground = brush;
                dictionary.Source = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
                Properties.Settings.Default.IsDark = false;
                MainGrid.Background = Brushes.White;
            }
               
            Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[Application.Current.Resources.MergedDictionaries.Count - 1]);
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
            
        }

        private void Mainindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
