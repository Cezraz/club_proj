using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using MessBox;
using System.Data;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;

namespace Branirovanie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        DataGridColumn part_column = new DataGridTextColumn();
        DataBase db = new DataBase();
        List<Border> borders = DesignFunctions.addGlobalBorder();
        ContextMenu cm = new ContextMenu();
        Authorization aut = new Authorization();
        
        
        bool isAdmin = false;
        bool check_pc_field = true;
        bool check_width_property = true;
        bool check_load_programm = true;
        public string pb_str { get; set; }
        

        public MainWindow()
        {

            InitializeComponent();

            
            foreach (TabItem ti in tabcon.Items)
            {
                ti.Width = 0;

            }
            end_pick.Text = String.Empty;
            start_pick.Text = String.Empty;
            MenuItem mi = new MenuItem();
            mi.Header = "Удалить заказ";
            cm.Items.Add(mi);
            mi.Click += DeleteMI_Click;

            MenuItem mipc = new MenuItem();
            mipc.Header = "Удалить ПК";
            cm.Items.Add(mipc);
            mipc.Click += DeletePc_Click;

        

        }

        

        public MainWindow(int item, Authorization au, bool dark)
        {
            InitializeComponent();
            aut = au;
            load.Visibility = Visibility.Collapsed;
            Theme_tg.IsChecked = dark;

            table_date_pick.SelectedDateChanged += Table_date_pick_SelectedDateChanged;
            Key_word.Text += "\nДля обозначения компьютерна используется сокращение \"pc\"\nПример:\" pc1-pc5,pc14,vip1\"";
         
            if (item == 1)
            {
                isAdmin = true;

                MenuItem updatemi = new MenuItem();
                updatemi.Header = "Изменить заказ";
               

                MenuItem mi = new MenuItem();
                mi.Header = "Удалить заказ";
                cm.Items.Add(mi);
                mi.Click += DeleteMI_Click;

                MenuItem mipc = new MenuItem();
                mipc.Header = "Удалить ПК";
                cm.Items.Add(mipc);
                mipc.Click += DeletePc_Click;

                food_item.Visibility = Visibility.Collapsed;

            }
            else
            {
                about_item.Visibility = Visibility.Collapsed;
            }
           
            foreach (TabItem ti in tabcon.Items)
            {
                ti.Width = 0;

            }

            end_pick.Text = String.Empty;
            start_pick.Text = String.Empty;
            //tabl_grid.Loaded += Tabl_grid_Loaded; ;

        }

        //private void Tabl_grid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Grid gr = sender as Grid;
        //    if(gr.Children.Count!=0)
        //    {
        //        for (int i = 47; i < 900; i++)
        //        {
        //            if(gr.Children[i].Uid!=string.Empty)
        //            {
        //                WpfMessageBox.Show(gr.Children[i].Uid);
        //            }
                   
        //        }
        //    }
           
        //}

        private void DeletePc_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, (ThreadStart)delegate ()
            {

              
                MenuItem mi = (MenuItem)sender;
                ContextMenu cm = mi.Parent as ContextMenu;
               // WpfMessageBox.Show(mi.);
                if (cm != null)
                {
                     UIElement ui = cm.PlacementTarget;
                   
                    
                    if (ui != null)
                    {
                        var dataItem = (Border)ui;

                        var list = new List<Border>();
                        var th = new Thickness(1);


                        var pc = 0;
                        var orId = 0;
                        foreach (var item in tabl_grid.Children)
                        {
                            try
                            {
                                Border br = (Border)item;
                               
                                if (br.Uid == string.Empty)
                                {
                                    continue;
                                }
                                else
                                {
                                     //WpfMessageBox.Show(br.Uid.ToString());
                                    if (br.Uid.Split('_')[3] == dataItem.Uid.Split('_')[3] && br.Uid.Split('_')[0] == dataItem.Uid.Split('_')[0])
                                    {

                                        if (pc == 0)
                                        {
                                            pc = Convert.ToInt32(dataItem.Uid.Split('_')[0]);
                                        }

                                        if (orId == 0)
                                        {
                                            orId = Convert.ToInt32(dataItem.Uid.Split('_')[3]);
                                        }
                                        list.Add(br);
                                    }
                                }

                            }
                            catch
                            {
                                continue;
                            }
                        }
                        List<int> num = DesignFunctions.calcPcRange(db.getPcRange(orId));
                        num = DesignFunctions.calcSimplePcChange(num);
                        var cur_str = DesignFunctions.createChangeString(pc, num);
                        if (!string.IsNullOrEmpty(cur_str))
                        {
                            var res = WpfMessageBox.Show("Вы уверены что хотите удалить данный компьютер из заказа?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                            if (res == MessageBoxResult.Yes)
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    list[i].ClearValue(BackgroundProperty);
                                    list[i].ClearValue(ToolTipProperty);
                                    list[i].SetValue(BorderBrushProperty, Brushes.Purple);
                                    list[i].SetValue(BorderThicknessProperty, th);
                                }
                                db.setPcRange(cur_str, orId);
                                WpfMessageBox.Show("Заказ изменен, Пк удален", "Упех", MessageBoxButton.OK, MessageBoxImage.Information);
                            }

                        }
                        else
                        {
                            var res = WpfMessageBox.Show("Заказ состоит из одного компьютера, вы уверены что хотите удалить заказ?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                            if (res == MessageBoxResult.Yes)
                            {

                                for (int i = 0; i < list.Count; i++)
                                {
                                    list[i].ClearValue(BackgroundProperty);
                                    list[i].ClearValue(ToolTipProperty);
                                    list[i].SetValue(BorderBrushProperty, Brushes.Purple);
                                    list[i].SetValue(BorderThicknessProperty, th);
                                }

                                db.deleteOrder(Convert.ToInt32(dataItem.Uid.Split('_')[3]),"cluborder");
                                WpfMessageBox.Show("Заказ удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            }

                        }


                    }
                }
            });

            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, (ThreadStart)delegate ()
            {
                load.Visibility = Visibility.Collapsed;
            });
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, (ThreadStart)delegate ()
            {
                //отображение экрана загрузки
                load.Visibility = Visibility.Visible;
                //var frameworkElement = e.OriginalSource as FrameworkElement;

                //var _item = frameworkElement.DataContext as Grid;

                //if (null == _item)
                //{
                //    return;
                //}
                MenuItem mi = (MenuItem)sender;
                ContextMenu cm = mi.Parent as ContextMenu;
                if (cm != null)
                {
                    UIElement ui = cm.PlacementTarget;
                    if (ui != null)
                    {
                        var dataItem = (Border)ui;

                        var list = new List<Border>();
                        var th = new Thickness(1);


                        foreach (var item in tabl_grid.Children)
                        {
                            try
                            {
                                Border br = (Border)item;
                                if (br.Uid == string.Empty)
                                {
                                    continue;
                                }
                                else
                                {
                                    //определение всех ячеек относящихся к заказу
                                    if (br.Uid.Split('_')[3] == dataItem.Uid.Split('_')[3])
                                    {

                                        list.Add(br);

                                    }
                                }

                            }
                            catch
                            {
                                continue;
                            }
                        }
                        var res = WpfMessageBox.Show("Вы уверены что хотите удалить заказ?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        if (res == MessageBoxResult.Yes)
                        {
                            //сброс параметров выбранных ячеек
                            for (int i = 0; i < list.Count; i++)
                            {
                                list[i].ClearValue(BackgroundProperty);
                                list[i].ClearValue(ToolTipProperty);
                                list[i].SetValue(BorderBrushProperty, Brushes.Purple);
                                list[i].SetValue(BorderThicknessProperty, th);
                            }
                            //функция удаления заказа из базы данных, принимающая идентификатор в виде входных данных
                            db.deleteOrder(Convert.ToInt32(dataItem.Uid.Split('_')[3]),"cluborder");
                            WpfMessageBox.Show("Заказ удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                    }
                }
            });

            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, (ThreadStart)delegate ()
            {
                //отключение экрана загрузки
                load.Visibility = Visibility.Collapsed;
            });
        }

        private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            if (date_pick.SelectedDate.HasValue && !string.IsNullOrEmpty(start_pick.Text) && !string.IsNullOrEmpty(end_pick.Text))
            {
                Club club = new Club(this, date_pick.SelectedDate.Value, Convert.ToDateTime(start_pick.Text).Hour, Convert.ToDateTime(end_pick.Text).Hour);
                pb_str = club.pb_str;
                club.Closing += Club_Closing;
                club.ShowDialog();

            }
            else
            {
                WpfMessageBox.Show("Введите время и дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Club_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pc_field.Text = pb_str;
            if(pb_str!=string.Empty)
            {
                pc_field.Foreground = Brushes.Green;
            }
           
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Border> local_borders = new List<Border>();
            if (!DesignFunctions.checkEmpty(ti1_grid))
            {

                if (check_pc_field)
                {
                    var list = DesignFunctions.convertTime(Convert.ToDateTime(start_pick.Text).Hour, Convert.ToDateTime(end_pick.Text).Hour);

                    if (list[0] > 0 && list[1] > 0)
                    {
                        var res = DesignFunctions.checkInputString(pc_field.Text);
                        List<int> num = DesignFunctions.calcPcRange(res);
                        var simp = DesignFunctions.calcSimplePcChange(num);
                        var start = Convert.ToDateTime(start_pick.Text).Hour;
                        var end = Convert.ToDateTime(end_pick.Text).Hour;
                        for (int i = 0; i < num.Count; i++)
                        {
                            local_borders.AddRange(getLocalBorderList(date_pick.SelectedDate.Value, start,end, simp[i]));

                        }
                        if (!checkBusy(local_borders))
                        {
                            if (isAdmin)
                            {
                                if (db.checkClient(Name.Text, Phone.Text) == false)
                                {
                                    db.addClient(Name.Text, Phone.Text);
                                }

                                if (MaterialDesignOutlinedTextBoxEnabledComboBox.IsChecked == true)
                                {
                                    db.addOrder((DateTime)date_pick.SelectedDate, start_pick.Text, end_pick.Text, db.getIdClient(Name.Text, Phone.Text), res, Comment.Text);
                                }
                                else
                                {
                                    db.addOrder((DateTime)date_pick.SelectedDate, start_pick.Text, end_pick.Text, db.getIdClient(Name.Text, Phone.Text), res);
                                }
                                if (date_pick.SelectedDate.Value == table_date_pick.SelectedDate.Value)
                                {
                                    check_load_programm = true;

                                    string str = "";
                                    int or = 0, cl = 0;
                                    var l_simp = DesignFunctions.calcSimplePcChange(num);
                                    var st = Convert.ToDateTime(start_pick.Text).Hour;
                                    var ed = Convert.ToDateTime(end_pick.Text).Hour;
                                    for (int i = 0; i < db.getPcCount(num); i++)
                                    {
                                       
                                        if(i==0)
                                        {
                                            colorCell(date_pick.SelectedDate.Value,st,ed , l_simp[i],out or,out cl, out str);
                                            colorCell(date_pick.SelectedDate.Value, st, ed, l_simp[i], or, cl, str);
                                        }
                                        else
                                        {
                                            colorCell(date_pick.SelectedDate.Value,st, ed, l_simp[i],or,cl,str);
                                        }

                                    }
                                   
                                }
                                WpfMessageBox.Show("Заказ успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            else
                            {
                                if (MaterialDesignOutlinedTextBoxEnabledComboBox.IsChecked == true)
                                {
                                    db.addClientOrder((DateTime)date_pick.SelectedDate, start_pick.Text, end_pick.Text, db.getIdClient(Name.Text, Phone.Text), res, Comment.Text);
                                }
                                else
                                {
                                    db.addClientOrder((DateTime)date_pick.SelectedDate, start_pick.Text, end_pick.Text, db.getIdClient(Name.Text, Phone.Text), res);
                                }
                                WpfMessageBox.Show("Ваш заказ отправлен на рассмотрение администратора.\nС вами свяжутся по указанным данным для подтверждения вашего заказа, ожидайте.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                            }




                        }
                    }
                    else
                    {
                        WpfMessageBox.Show("Непододящее время\nКомпьютерный клуб работает с 12:00-8:00", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {
                    WpfMessageBox.Show("Введены некорректные данные в одно из обязательных полей", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }

        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Style s = new Style();
            s.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Hidden));
            tabcon.ItemContainerStyle = s;
            date_pick.Text = DateTime.Today.ToString();
            db.closeConnection();
            ResourceDictionary dictionary = new ResourceDictionary();

            if (Theme_tg.IsChecked == true)
            {
                dictionary.Source = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml");
                Properties.Settings.Default.IsDark = true;

            }
            else
            {
                dictionary.Source = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
                Properties.Settings.Default.IsDark = false;
            }
            Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[Application.Current.Resources.MergedDictionaries.Count - 1]);
            Application.Current.Resources.MergedDictionaries.Add(dictionary);

        }

        private void menuTogle_Click(object sender, RoutedEventArgs e)
        {
            if (menuTogle.IsChecked == true)
            {
                foreach (TabItem ti in tabcon.Items)
                {
                    DoubleAnimation buttonAnimation = new DoubleAnimation();
                    buttonAnimation.From = 0;
                    buttonAnimation.To = 73;
                    buttonAnimation.Duration = TimeSpan.FromMilliseconds(300);
                    ti.BeginAnimation(TabItem.WidthProperty, buttonAnimation);

                }


                part_column.Width = part_column.ActualWidth - 33;
                check_width_property = true;


            }
            else
            {
                foreach (TabItem ti in tabcon.Items)
                {
                    DoubleAnimation buttonAnimation = new DoubleAnimation();
                    buttonAnimation.From = 73;
                    buttonAnimation.To = 0;
                    buttonAnimation.Duration = TimeSpan.FromMilliseconds(300);
                    ti.BeginAnimation(TabItem.WidthProperty, buttonAnimation);


                }
                part_column.Width = part_column.ActualWidth + 33;
                check_width_property = false;
            }
        }

        private void start_pick_LostFocus(object sender, RoutedEventArgs e)
        {
            var s = DesignFunctions.updateTime(start_pick.Text);
            if (!string.IsNullOrEmpty(s))
            {
                start_pick.Text = s;
            }
            Pack_box.SelectedIndex = DesignFunctions.testForPack(start_pick.Text, end_pick.Text);
        }

        private void end_pick_LostFocus(object sender, RoutedEventArgs e)
        {
            var s = DesignFunctions.updateTime(end_pick.Text);
            if (!string.IsNullOrEmpty(s))
            {
                end_pick.Text = s;
            }
            Pack_box.SelectedIndex = DesignFunctions.testForPack(start_pick.Text, end_pick.Text);
        }

        private void Pack_box_DropDownClosed(object sender, EventArgs e)
        {
            switch (Pack_box.SelectedIndex)
            {
                case 0:
                    start_pick.Text = "12:00";
                    end_pick.Text = "16:00";
                    break;
                case 1:
                    start_pick.Text = "16:00";
                    end_pick.Text = "21:00";
                    break;
                case 2:
                    start_pick.Text = "21:00";
                    end_pick.Text = "8:00";
                    break;


            }

        }

        private void pc_field_KeyUp(object sender, KeyEventArgs e)
        {
            if (!DesignFunctions.testRegex_Pc(pc_field.Text,pc_field.Name))
            {
                pc_field.Foreground = Brushes.Red;
                check_pc_field = false;
            }
            else
            {
                pc_field.Foreground = Brushes.Green;
                check_pc_field = true;
            }
        }


        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                scroll.LineDown();
            }
            else
            {
                scroll.LineUp();
            }
        }

        private void colorCell(DateTime dt,int _start, int _end, int pcNum, out int _orId, out int _clId, out string _strToolTip)
        {
           
            int orId = 0, clId = 0;
            bool today = false;
            List<string> strings = new List<string>();
            int true_start = _start, true_end = _end;
            string str_tooltip = "";
            _strToolTip = "";
            _orId = 0;
            _clId = 0;

            var g_list = DesignFunctions.convertTime(_start, _end);
            _start = g_list[0];
            _end = g_list[1];
            if (_start >= 0 && _end >= 0)
            {
                if(dt==DateTime.Today)
                {
                    today = true;
                }
                int index = 0;
                List<string> dt_list = new List<string>();
                if(today)
                {
                    dt_list = db.getIdWithPcRangeToday();
                    for (int j = 0; j < dt_list.Count; j++)
                    {
                        string key = dt_list[j].Split('_')[1];

                        orId = db.getOrderIdToday(true_start, true_end, key);

                        List<int> list = DesignFunctions.calcSimplePcChange(DesignFunctions.calcPcRange(key));
                        index = list.FindIndex(x => x == pcNum);
                        if (index >= 0)
                        {
                            if (orId > 0)
                            {
                                clId = db.getIdClientToday(orId);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    dt_list = db.getIdWithPcRange(dt);
                    for (int j = 0; j < dt_list.Count; j++)
                    {
                        string key = dt_list[j].Split('_')[1];

                        orId = db.getOrderId(dt, true_start, true_end, key);

                        List<int> list = DesignFunctions.calcSimplePcChange(DesignFunctions.calcPcRange(key));
                        index = list.FindIndex(x => x == pcNum);
                        if (index >= 0)
                        {
                            if (orId > 0)
                            {
                                clId = db.getIdClient(orId);
                                break;
                            }
                        }
                    }

                }
                 
                _orId = orId;
                _clId = clId;
                    
                if (index >= 0)
                {
                    strings = db.getTooltipData(clId, orId);
                }

                 

                if (strings.Count > 2)
                {  
                    str_tooltip = strings[0] + "\n" + strings[1] + "\n" + strings[2];
                        
                }
                else if (strings.Count <= 2 && strings.Count > 0)
                { 
                    str_tooltip = strings[0] + "\n" + strings[1];
                       
                }

                _strToolTip = str_tooltip;

                   
                     
            }
                else
                {
                    WpfMessageBox.Show("Что то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
          
          


        }
        private void colorCell(DateTime dt, int _start, int _end, int pcNum, int _orId,  int _clId, string _strToolTip)
        {
            
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
               
                List<string> strings = new List<string>();
                int true_start = _start, true_end = _end;
             

                var g_list = DesignFunctions.convertTime(_start, _end);
                _start = g_list[0];
                _end = g_list[1];
                if (_start >= 0 && _end >= 0)
                {
                    bool f = false;
                  


                    if (_start < _end && (_start > 0 && _end > 0))
                    {


                        
                        if (!f)
                        {

                            for (int i = _start; i < _end; i++)
                            {

                                var new_bor = new Border()
                                {
                                    BorderBrush = Brushes.Black,
                                    BorderThickness = new Thickness(2),
                                    Background = Brushes.BlueViolet,
                                    Uid = pcNum.ToString() + "_" + i.ToString() + "_" + dt.ToString() + "_" + _orId.ToString(),
                                    ContextMenu = cm
                                    
                                };
                                new_bor.MouseRightButtonUp += New_bor_MouseRightButtonUp;
                               // cm.Placement = new_bor;
                                if (isAdmin)
                                {
                                    new_bor.ToolTip = _strToolTip + "\nId:" + _orId.ToString(); ;
                                }
                                Grid.SetRow(new_bor, pcNum);
                                Grid.SetColumn(new_bor, i);
                                //WpfMessageBox.Show(new_bor.Uid.ToString());




                                tabl_grid.Children.Add(new_bor);

                                borders.Add(new_bor);


                            }

                        }
                    }
                }
                else
                {
                    WpfMessageBox.Show("Что то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            



        }

        private void New_bor_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            cm.PlacementTarget = sender as UIElement;
        }

        private void createTable()
        {
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                tabl_grid.Children.Clear();
                tabl_grid.RowDefinitions.Clear();
                tabl_grid.ColumnDefinitions.Clear();
                tabl_grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1) });
                handle_grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30) });
                for (int i = 0; i < 20; i++)
                {
                    TextBlock def_tb = new TextBlock();
                    if (i < 12)
                    {
                        def_tb = new TextBlock() { Text = (i + 12).ToString(), HorizontalAlignment = HorizontalAlignment.Center };
                    }
                    else
                    {
                        def_tb = new TextBlock() { Text = (i - 12).ToString(), HorizontalAlignment = HorizontalAlignment.Center };
                    }
                    tabl_grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
                    Grid.SetRow(def_tb, 0);
                    Grid.SetColumn(def_tb, i + 1);

                    handle_grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
                    Grid.SetRow(def_tb, 0);
                    Grid.SetColumn(def_tb, i + 1);
                    handle_grid.Children.Add(def_tb);
                }


                tabl_grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
                handle_grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
                TextBlock main_tb = new TextBlock() { Text = "PC-All", HorizontalAlignment = HorizontalAlignment.Center };
                Grid.SetRow(main_tb, 0);
                Grid.SetColumn(main_tb, 0);
                handle_grid.Children.Add(main_tb);

                for (int i = 1; i <= 41; i++)
                {
                    TextBlock def_tb = new TextBlock() { Text = "Pc" + i.ToString(), HorizontalAlignment = HorizontalAlignment.Center };
                    tabl_grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30) });
                    Grid.SetRow(def_tb, i);
                    Grid.SetColumn(def_tb, 0);
                    tabl_grid.Children.Add(def_tb);
                }

                for (int j = 1; j <= 41; j++)
                {

                    for (int i = 1; i <= 21; i++)
                    {

                        var th = new Thickness(1);

                        var def_tb = new Border() { BorderBrush = Brushes.Purple, BorderThickness = th };
                        Grid.SetRow(def_tb, j);
                        Grid.SetColumn(def_tb, i);
                        if (i == 1)
                        {
                            th.Left += 1;
                        }
                        if (j == 1)
                        {
                            th.Top += 1;
                        }
                        if (i == 21)
                        {
                            th.Right += 1;
                        }
                        if (j == 41)
                        {
                            th.Bottom += 1;
                        }
                        def_tb.BorderThickness = th;
                        tabl_grid.Children.Add(def_tb);
                    }
                }

            });
        }

        private void Table_date_pick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int orId = 0;
            bool today = false;
            int true_start = 0, true_end = 0;
            if (table_date_pick.SelectedDate.HasValue)
            {
                for (int i = 0; i < borders.Count; i++)
                {

                    if (borders[i].Uid.Split('_')[2] == table_date_pick.SelectedDate.Value.ToString())
                    {
                        borders.RemoveAt(i);
                        i--;
                    }
                }
                Thread thread = new Thread(createTable);
                thread.Start();




                if (table_date_pick.SelectedDate.HasValue == true)
                {
                    if(table_date_pick.SelectedDate==DateTime.Today)
                    {
                        today = true;
                    }
                    if (db.haveOrder((DateTime)table_date_pick.SelectedDate))
                    {
                        List<string> list = new List<string>();
                        List<int> num = new List<int>();
                        if (today)
                        {
                            list = db.getIdWithPcRangeToday();
                        }
                        else
                        {
                            list = db.getIdWithPcRange((DateTime)table_date_pick.SelectedDate);
                        }
                        
                        
                        for (int j = 0; j < list.Count; j++)
                        {
                            string key = list[j].Split('_')[1];
                            if (today)
                            {
                                true_start = Convert.ToDateTime(db.getStartOrderToday()[j]).Hour;
                                true_end = Convert.ToDateTime(db.getEndOrderToday()[j]).Hour;
                                orId = db.getOrderIdToday(true_start, true_end, key);
                                num = DesignFunctions.calcPcRange(db.getPcRangeToday(orId));
                            }
                            else
                            {
                                true_start = Convert.ToDateTime(db.getStartOrder(table_date_pick.SelectedDate.Value)[j]).Hour;
                                true_end = Convert.ToDateTime(db.getEndOrder(table_date_pick.SelectedDate.Value)[j]).Hour;
                                orId = db.getOrderId((DateTime)table_date_pick.SelectedDate, true_start, true_end, key);
                                num = DesignFunctions.calcPcRange(db.getPcRange(orId));
                            }
                           

                          

                           
                            var pcCount = db.getPcCount(num);
                            string st = "";
                            int or = 0, cl = 0;

                            for (int i = 0; i <pcCount; i++)
                            {
                                if(i==0)
                                {
                                    colorCell(table_date_pick.SelectedDate.Value,true_start, true_end, DesignFunctions.calcSimplePcChange(num)[i], out or, out cl, out st); //сделать выборку по сегодняшнему дню 
                                    colorCell(table_date_pick.SelectedDate.Value, true_start, true_end, DesignFunctions.calcSimplePcChange(num)[i], or, cl, st);
                                }
                                else
                                {
                                    colorCell(table_date_pick.SelectedDate.Value,true_start, true_end, DesignFunctions.calcSimplePcChange(num)[i],or,cl,st);

                                }
                            }
                            
                        }
                    }

                }
                check_load_programm = false;
                thread.Abort();
            }


        }

        private List<Border> getLocalBorderList(DateTime dt, int _start, int _end, int pcNum)
        {
            List<Border> loc = new List<Border>();
            int orId = 0, clId = 0;
            List<string> strings = new List<string>();
            int true_start = _start, true_end = _end;

            var datelist = DesignFunctions.convertTime(_start, _end);
            _start = datelist[0];
            _end = datelist[1];
            
                if (_start >= 0 && _end >= 0)
                {
                   
                    int index = 0;
                var temp = 0;
                if (db.getIdWithPcRange()!=null)
                {
                    temp = db.getIdWithPcRange().Count;
                }
                
                    for (int j = 0; j < temp; j++)
                    {
                        string key = db.getIdWithPcRange()[j].Split('_')[1];

                        orId = db.getOrderId(dt, true_start, true_end, key);

                        List<int> list = DesignFunctions.calcSimplePcChange(DesignFunctions.calcPcRange(key));
                        index = list.FindIndex(x => x == pcNum);
                        if (index >= 0)
                        {
                            if (orId > 0)
                            {
                                clId = db.getIdClient(orId);
                                break;
                            }
                        }
                    }
                
                  
                for (int i = _start; i <= _end; i++)
                {
                    var new_bor = new Border()
                    {

                        Uid = pcNum.ToString() + "_" + i.ToString() + "_" + date_pick.SelectedDate.ToString() + "_" + orId.ToString()
                    };
                    Grid.SetRow(new_bor, pcNum);
                    Grid.SetColumn(new_bor, i);
                    loc.Add(new_bor);

                }

            }
            db.closeConnection();
            return loc;
        }

        private bool checkBusy(List<Border> _borders)
        {
            bool f = false;
            for (int i = 0; i < _borders.Count; i++)
            {

                if (f == false)
                {
                    for (int j = 0; j < borders.Count; j++)
                    {


                        if ((borders[j].Uid.Split('_')[1] == _borders[i].Uid.Split('_')[1])&& borders[j].Uid.Split('_')[0] == _borders[i].Uid.Split('_')[0])
                        {
                            int k = Convert.ToInt32(_borders[i].Uid.Split('_')[1]);
                            if (k <= 12)
                            {
                                k += 11;

                            }
                            else
                            {
                                k -= 11;
                            }
                            WpfMessageBox.Show("ПК" + _borders[i].Uid.Split('_')[0] + "   уже занят на время: " + k + " часов\nПожалуйста, зарегестрируйте другой заказ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            f = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return f;
        }

        

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {

            }
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            table_date_pick.Text = DateTime.Today.ToString();
        }

        

        private void change_acc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Authorization au = new Authorization();
            au.ShowDialog();

        }


        private void clientOrder_item_Loaded(object sender, RoutedEventArgs e)
        {
            client_dgv.ItemsSource = db.getSource();
            // client_dgv.Items.Refresh();
        }


        private void Refresh_clientOrder_buttton_Click(object sender, RoutedEventArgs e)
        {
            client_dgv.ItemsSource = db.getSource();
        }

        private void Add_clientOrder_button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Items> cur_items = (ObservableCollection<Items>)client_dgv.ItemsSource;
            List<Border> local_borders = new List<Border>();
           // client_dgv.Columns[0].GetCellContent()
            for (int i = 0; i < cur_items.Count; i++)
            {
                if (cur_items[i].selected)
                {
                  
                    List<int> num = DesignFunctions.calcPcRange(cur_items[i].pcRange);
                    for (int j = 0; j < num.Count; j++)
                    {
                        local_borders.AddRange(getLocalBorderList(Convert.ToDateTime(cur_items[i].date), Convert.ToDateTime(cur_items[i].start_time).Hour, Convert.ToDateTime(cur_items[i].end_time).Hour, DesignFunctions.calcSimplePcChange(num)[j]));

                    }
                   
                    if(!checkBusy(local_borders))
                    {
                        if (cur_items[i].comment != string.Empty)
                        {
                            db.addOrder(Convert.ToDateTime(cur_items[i].date), cur_items[i].start_time, cur_items[i].end_time, Convert.ToInt32(cur_items[i].idClient), cur_items[i].pcRange,  cur_items[i].comment);
                        }
                        else
                        {
                            db.addOrder(Convert.ToDateTime(cur_items[i].date), cur_items[i].start_time, cur_items[i].end_time, Convert.ToInt32(cur_items[i].idClient), cur_items[i].pcRange);
                        }
                        if (Convert.ToDateTime(cur_items[i].date) == table_date_pick.SelectedDate.Value)
                        {
                            check_load_programm = true;

                            string st = "";
                            int or = 0, cl = 0;
                            var pc = DesignFunctions.calcSimplePcChange(num);
                            for (int j = 0; j < db.getPcCount(num); j++)
                            {
                               
                                if (j == 0)
                                {
                                    colorCell(Convert.ToDateTime(cur_items[i].date),Convert.ToDateTime(cur_items[i].start_time).Hour, Convert.ToDateTime(cur_items[i].end_time).Hour, pc[j],out or,out cl,out st);
                                    colorCell(Convert.ToDateTime(cur_items[i].date), Convert.ToDateTime(cur_items[i].start_time).Hour, Convert.ToDateTime(cur_items[i].end_time).Hour, pc[j], or, cl, st);
                                }
                                else
                                {
                                    colorCell(Convert.ToDateTime(cur_items[i].date), Convert.ToDateTime(cur_items[i].start_time).Hour, Convert.ToDateTime(cur_items[i].end_time).Hour, pc[j], or, cl, st);
                                }

                            }
                        }

                        db.deleteOrder(cur_items[i].id,"ClientOrder");
                        WpfMessageBox.Show("Заказ пользователя успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    
                }
            }
            client_dgv.ItemsSource = db.getSource();
        }

       

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var tb = (ToggleButton)sender;
            ResourceDictionary dictionary = new ResourceDictionary();

            if (tb.IsChecked==true)
            {
                dictionary.Source = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml");
                Properties.Settings.Default.IsDark = true;
               
            }
            else
            {
                dictionary.Source = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
                Properties.Settings.Default.IsDark = false;
            }
            Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[Application.Current.Resources.MergedDictionaries.Count - 1]);
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFood mf = new MainFood();
            mf.ShowDialog();
        }

        private void Delete_clientOrder_button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Items> cur_items = (ObservableCollection<Items>)client_dgv.ItemsSource;
            List<Border> local_borders = new List<Border>();
            // client_dgv.Columns[0].GetCellContent()
            for (int i = 0; i < cur_items.Count; i++)
            {
                if (cur_items[i].selected)
                {
                    db.deleteOrder(cur_items[i].id, "ClientOrder");
                }
            }
            client_dgv.ItemsSource = db.getSource();
        }

        private void TabControl_Loaded(object sender, RoutedEventArgs e)
        {
            FoodOrder.ItemsSource = db.getSourceFoodOrder();
            Presto.ItemsSource = db.getSource("Presto");
            Verona.ItemsSource = db.getSource("Verona");
            Subway.ItemsSource = db.getSource("Subway");
            Yakida.ItemsSource = db.getSource("Yakida");

        }

        private void Refresh_foodOrder_buttton_Click(object sender, RoutedEventArgs e)
        {
            FoodOrder.ItemsSource = db.getSourceFoodOrder();
            Presto.ItemsSource = db.getSource("Presto");
            Verona.ItemsSource = db.getSource("Verona");
            Subway.ItemsSource = db.getSource("Subway");
            Yakida.ItemsSource = db.getSource("Yakida");
        }

        private void Delete_foodOrder_button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<FoodOrderClass> cur_items = (ObservableCollection<FoodOrderClass>)FoodOrder.ItemsSource;
            //List<Border> local_borders = new List<Border>();
            // client_dgv.Columns[0].GetCellContent()
            for (int i = 0; i < cur_items.Count; i++)
            {
                if (cur_items[i].selected)
                {
                    db.deleteOrder(cur_items[i].id, "FoodOrder");
                }
            }
            FoodOrder.ItemsSource = db.getSourceFoodOrder();
            Presto.ItemsSource = db.getSource("Presto");
            Verona.ItemsSource = db.getSource("Verona");
            Subway.ItemsSource = db.getSource("Subway"); 
            Yakida.ItemsSource = db.getSource("Yakida");
        }

        private void Restoraunts_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch(Restoraunts.SelectedIndex)
            {
                case 0:
                    rest_header.Text = "Рестораны";
                    break;
                case 1:
                    rest_header.Text = "Престо";
                    break;
                case 2:
                    rest_header.Text = "Верона";
                    break;
                case 3:
                    rest_header.Text = "Subway";
                    break;
                case 4:
                    rest_header.Text = "Якида";
                    break;
            }
        }

        private void Name_KeyUp(object sender, KeyEventArgs e)
        {
            if (!DesignFunctions.testRegex_Pc(Name.Text,"Name"))
            {
                Name.Foreground = Brushes.Red;
                check_pc_field = false;
            }
            else
            {
                Name.Foreground = Brushes.Green;
                check_pc_field = true;
            }
        }

        private void Phone_KeyUp(object sender, KeyEventArgs e)
        {
            if (!DesignFunctions.testRegex_Pc(Phone.Text, "Phone"))
            {
                Phone.Foreground = Brushes.Red;
                check_pc_field = false;
            }
            else
            {
                Phone.Foreground = Brushes.Green;
                check_pc_field = true;
            }
        }
    }



    
}
