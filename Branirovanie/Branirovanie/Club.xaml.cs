using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MessBox;

namespace Branirovanie
{
    /// <summary>
    /// Логика взаимодействия для Club.xaml
    /// </summary>
    public partial class Club : Window
    {
        DataBase db = new DataBase();
        MainWindow mw =  new MainWindow();
        public string pb_str=string.Empty;
        List<string> res = new List<string>();
        List<int> int_res = new List<int>();
        //List<int> id_view = new List<int>();
        int or_start, or_end;
        public Club()
        {
            InitializeComponent();
            
        }
        //string name = string.Empty, phone = string.Empty, comment = string.Empty;
        public Club(MainWindow _mw, DateTime dt, int _start, int _end)
        {
            InitializeComponent();
            mw = _mw;
            or_start = _start;
            or_end = _end;
            

            if (db.haveOrder(dt))
            {   
                if (_start > _end && _end <= 8)
                {
                    _start -= 11;
                    _end += 13;
                }
                else
                {
                    if (_start <= 8)
                        _start += 12;
                    else if (_start >= 12)
                        _start -= 11;


                    if (_end <= 8)
                        _end += 12;
                    else if (_end >= 12)
                        _end -= 11;
                }

                if (_start > _end)
                {
                    int c = _start;
                    _start = _end;
                    _end = c;

                }
                var id_view = db.getIdWithPcRange(dt);
                var start_time = db.getStartOrder(dt);
                var end_time = db.getEndOrder(dt);
                for (int i=0; i<id_view.Count;i++)
                {
                    var st = Convert.ToDateTime( start_time[i]).Hour;
                    var ed = Convert.ToDateTime(end_time[i]).Hour;
                    var pcRange = id_view[i].Split('_')[1];

                    if (st> ed&& ed <= 8)
                    {
                        st-= 11;
                        ed += 13;
                    }
                    else
                    {
                        if (st<= 8)
                            st+= 12;
                        else if (st>= 12)
                            st-= 11;


                        if (ed <= 8)
                            ed += 12;
                        else if (ed >= 12)
                            ed -= 11;
                    }

                    if (st > ed)
                    {
                        int c = st;
                        st = ed;
                        ed = c;

                    }

                    if (( _start<=st && _end<=st) || (_start>=ed && _end>=ed))
                    { 
                    }
                    else
                    {

                        List<int> list = DesignFunctions.calcSimplePcChange(DesignFunctions.calcPcRange(pcRange));
                        for (int j = 0; j < list.Count; j++)
                        {
                            foreach (var tg in mainGrid.Children)
                            {
                                try
                                {
                                    ToggleButton _tg = (ToggleButton)tg;
                                    int item;
                                    if (int.TryParse(_tg.Content.ToString(), out item))
                                    {
                                        if (_tg.Uid == string.Empty)
                                        {
                                            if (list[j] == item)
                                            {
                                                _tg.Foreground = Brushes.Red;
                                                _tg.Uid = "1";
                                                _tg.FontWeight = FontWeights.Bold;
                                                _tg.IsEnabled = false;
                                            }
                                        }
                                        
                                    }

                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }




            }
          
        }
        
        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void club_add_btn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var tg in mainGrid.Children)
            {
                try
                {
                    ToggleButton _tg = (ToggleButton)tg;
                    if(_tg.IsChecked==true)
                    {
                        int item=0;
                        if(int.TryParse(_tg.Content.ToString(),out item))
                        {
                            int_res.Add(Convert.ToInt32(_tg.Content));
                        }
                      
                    }
                }
                catch
                {
                    continue;
                }
            }

            if(int_res!=null)
                int_res.Sort();

            int l =-1,k=-1;
            bool cur = false;
            List<int> after = int_res;
            for (int i = 0; i < int_res.Count - 1; i++)
            {
                if (!cur)
                {
                    if (int_res[i + 1] - int_res[i] == 1)
                    {
                        if (k == -1)
                        {
                            k = i;
                        }
                        l = i + 1;
                        if (i == int_res.Count - 2)
                        {
                            if (k != -1 && l != -1)
                            {
                                pb_str += "pc" + int_res[k].ToString() + "-pc" + int_res[l].ToString() + ",";
                                after.RemoveRange(k, l - k + 1);
                                k = -1;
                                l = -1;
                                cur = true;

                            }
                        }
                    }
                    else if (int_res[i + 1] - int_res[i] != 1)
                    {

                        if (k != -1 && l != -1)
                        {
                            pb_str += "pc" + int_res[k].ToString() + "-pc" + int_res[l].ToString() + ",";
                            after.RemoveRange(k, l - k + 1);
                            k = -1;
                            l = -1;
                            cur = true;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            int_res = null;

           for(int i=0; i<after.Count;i++)
           {
                pb_str += "pc"+after[i].ToString()+",";
           }
            if (!string.IsNullOrEmpty(pb_str))
            {
                mw.pb_str = pb_str.Remove(pb_str.Length - 1);
                WpfMessageBox.Show("ПК успешно добавлены","Успех",MessageBoxButton.OK,MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                WpfMessageBox.Show("Не выбрано ни одного ПК","Ошибка добовления ПК",MessageBoxButton.OK,MessageBoxImage.Error);
            }

                
        }
    }
}
