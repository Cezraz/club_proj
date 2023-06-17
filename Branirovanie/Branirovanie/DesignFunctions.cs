using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MessBox;


namespace Branirovanie
{
    class DesignFunctions
    {
        protected static readonly Regex regex = new Regex(@"(((^((?i)(pc))+([1-9]|[1-3][\d]|4[0-1]){1}((\,{1}|\-{1}){1}((?i)(pc))+([1-9]|[1-3][\d]|4[0-1]){1})*$)+)|(^((?i)(vip))+(([1-2]{1})){1}((\,{1}|\-{1}){1}((?i)(vip))+(([1-2]{1})){1})*$)+)");
        protected static readonly Regex nameRegex = new Regex(@"^[А-ЯЁа-яёa-zA-z0-9]+[А-ЯЁа-яёa-zA-z0-9 ]*[А-ЯЁа-яёa-zA-z0-9]$");
        protected static readonly Regex phoneRegex = new Regex(@"^[А-ЯЁа-яёa-zA-z0-9+\.\\\/\- \:\[\]\,]{1,200}$");
        protected static DataBase db = new DataBase();
        public static int testForPack(string _start, string _end)
        {
            if (_start != String.Empty && _end != String.Empty)
            {
                if (Convert.ToDateTime(_start).Hour == 12 && Convert.ToDateTime(_end).Hour == 16)
                    return 0;
                if (Convert.ToDateTime(_start).Hour == 16 && Convert.ToDateTime(_end).Hour == 21)
                    return 1;
                if (Convert.ToDateTime(_start).Hour == 21 && Convert.ToDateTime(_end).Hour == 8)
                    return 2;
            }
            return -1;
        }

        public static bool testRegex_Pc(string str,string name)
        {
            Regex reg= new Regex("");
            switch(name)
            {
                case "pc_field":
                    reg = regex;
                    break;
                case "Name":
                    reg = nameRegex;
                    break;
                case "Phone":
                    reg = phoneRegex;
                    break;
            }
            if (reg.IsMatch(str))
                return true;
            return false;
        }


        public static List<int> calcPcRange(string _pcRange)
        {
            
            List<string> split_s = _pcRange.Split(',').ToList();
         
            List<int> numbers = new List<int>();
            foreach (string str in split_s)
            {
                if (str.Length < 3)
                {

                    return numbers;
                }


                else if ((str[0] == 'p' || str[0] == 'P') && (str[1] == 'c' || str[1] == 'C') && (str.Length == 3 || str.Length == 4))
                {
                    if (str.Length == 3)
                    {
                        try
                        {
                            numbers.Add(-1 * int.Parse(str[2].ToString()));
                            continue;
                        }
                        catch (Exception ex)
                        {
                            WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            continue;
                        }
                    }
                    if (str.Length == 4)
                    {
                        try
                        {
                            numbers.Add(-1 * int.Parse((str[2].ToString() + str[3].ToString()).ToString()));
                            continue;
                        }
                        catch (Exception ex)
                        {
                            WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            continue;
                        }
                    }
                }


                else if ((str[0] == 'p' || str[0] == 'P') && (str[1] == 'c' || str[1] == 'C') && (str.Length > 4))
                {
                    string[] super_split = str.Split('-');
                    foreach (string str_new in super_split)
                    {


                        if (str_new.Length == 3)
                        {
                            try
                            {
                                numbers.Add(int.Parse(str_new[2].ToString()));
                            }
                            catch (Exception ex)
                            {
                                WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        if (str_new.Length == 4)
                        {
                            try
                            {
                                numbers.Add(int.Parse((str_new[2].ToString() + str_new[3].ToString()).ToString()));
                            }
                            catch (Exception ex)
                            {
                                WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }

                    }
                }

                else if ((str[0] == 'p' || str[0] == 'P') && (str[1] == 's' || str[1] == 'S') && (str.Length == 3 || str.Length == 4))
                {
                    if (str.Length == 3)
                    {
                        try
                        {
                            numbers.Add(-1 * (50 + int.Parse(str[2].ToString())));
                            continue;
                        }
                        catch (Exception ex)
                        {
                            WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            continue;
                        }
                    }
                    if (str.Length == 4)
                    {
                        try
                        {
                            numbers.Add(-1 * (50 + int.Parse((str[2].ToString() + str[3].ToString()).ToString())));
                            continue;
                        }
                        catch (Exception ex)
                        {
                            WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            continue;
                        }
                    }
                }

                else if ((str[0] == 'p' || str[0] == 'P') && (str[1] == 's' || str[1] == 'S') && (str.Length > 4))
                {
                    string[] super_split = str.Split('-');
                    foreach (string str_new in super_split)
                    {
                        if (str_new.Length == 3)
                        {
                            try
                            {
                                numbers.Add((50 + int.Parse(str_new[2].ToString())));
                                continue;
                            }
                            catch (Exception ex)
                            {
                                WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                continue;
                            }
                        }
                        if (str_new.Length == 4)
                        {
                            try
                            {
                                numbers.Add((50 + int.Parse((str_new[2].ToString() + str_new[3].ToString()).ToString())));
                                continue;
                            }
                            catch (Exception ex)
                            {
                                WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                continue;
                            }
                        }
                    }
                }

                else if (str == "vip1")
                {
                    numbers.Add(32);
                    numbers.Add(36);
                }
                else if (str == "vip2")
                {
                    numbers.Add(37);
                    numbers.Add(41);
                }


            }


            var num = numbers.Distinct();
            numbers = num.ToList();

            return numbers;
        }

        public static List<int> calcSimplePcChange(List<int> _num)
        {
            List<int> res = new List<int>();
            int pc, ps, vip;
            pc = ps = vip = 0;
            _num.Sort();

        


            for (int i = 0; i < _num.Count; i++)
            { 
                if (_num[i] < 0)
                {
                    if (_num[i] < -50)
                    {
                        ps += 1;
                    }

                    else
                    {
                        res.Add(Math.Abs(_num[i]));
                    }
                }
                else
                {
                    if (i != _num.Count - 1)
                    {
                        if (_num[i + 1] > 0)
                        {
                            if (_num[i] > 50 && _num[i + 1] > 50)
                            {
                                ps += Math.Abs(_num[i] - _num[i + 1]) + 1;
                                i++;
                            }

                            else
                            {
                                for (int j = _num[i]; j <= _num[i + 1]; j++)
                                {
                                    res.Add(j);
                                }

                                i++;
                            }
                        }
                    }
                }
            }

            return res;
        }

        public static bool checkEmpty(Grid _grid)
        {
            bool f = false;
            string str_res = "";
            for (int i = 0; i < _grid.Children.Count; i++)
            {
                try
                {
                    TextBox tb = (TextBox)_grid.Children[i];
                    if (tb.Text == String.Empty && tb.IsEnabled == true)
                    {
                        f = true;
                        switch (tb.Name)
                        {
                            case "Name":
                                str_res += "Имя,";
                                break;
                            case "Phone":
                                str_res += "Средство связи,";
                                break;

                            case "pc_field":
                                str_res += "Перечень занимаемых компьютеров,";
                                break;

                             
                        }
                    }
                }
                catch
                {
                    try
                    {
                        DatePicker dp = (DatePicker)_grid.Children[i];
                        if (dp.Text == String.Empty)
                        {
                            str_res += "Дата заказа,";
                            f = true;
                        }
                    }
                    catch
                    {
                        try
                        {
                            MaterialDesignThemes.Wpf.TimePicker time = (MaterialDesignThemes.Wpf.TimePicker)_grid.Children[i];
                            if ((time.Name == "start_pick" && time.Text == String.Empty) || (time.Name == "end_pick" && time.Text == String.Empty))
                            {
                                switch (time.Name)
                                {
                                    case "start_pick":
                                        str_res += "Начальное время бронирования,";
                                        break;
                                    case "end_pick":
                                        str_res += "Конечное время бронирования,";
                                        break;

                                }
                                f = true;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            if (f)
            {
                str_res = str_res.Remove(str_res.Length - 1, 1);
                str_res += ".";

                WpfMessageBox.Show("Обнаружены пустые поля: " + str_res, "Ошибка заполнения формы", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return f;

        }



        public static bool checkEmpty_aut(StackPanel _stack)
        {
            bool f = false;
            string str_res = "";
            for (int i = 0; i < _stack.Children.Count; i++)
            {
                try
                {
                    TextBox tb = (TextBox)_stack.Children[i];
                    if (tb.Text == String.Empty && tb.IsEnabled == true)
                    {
                        f = true;
                        str_res += "Логин,";
                       
                    }
                }
                catch
                {
                    try
                    {
                        PasswordBox pb = (PasswordBox)_stack.Children[i];
                        if (pb.Password == String.Empty)
                        {
                            str_res += "Пароль,";
                            f = true;
                          
                        }
                    }
                   
                    catch
                    {
                        continue;
                    }
                }
            }
            
            if (f)
            {
                str_res = str_res.Remove(str_res.Length - 1, 1);
                str_res += ".";

                WpfMessageBox.Show("Обнаружены пустые поля: " + str_res, "Ошибка заполнения формы", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return f;

        }




        public static List<Border> addGlobalBorder()
        {
            List<Border> g_bor = new List<Border>();
            var dates = db.getAllDates();
            if (dates != null)
            {
                for (int i = 0; i < dates.Count; i++)
                {
                    var start = db.getStartOrder(dates[i]);
                    var end = db.getEndOrder(dates[i]);

                    for (int j = 0; j < start.Count; j++)
                    {


                        var st = Convert.ToDateTime(start[j]).Hour;
                        var ed = Convert.ToDateTime(end[j]).Hour;
                        var num = calcPcRange(db.getPcRange(dates[i], Convert.ToDateTime(start[j]).Hour, Convert.ToDateTime(end[j]).Hour));

                       var list= convertTime(st, ed);
                        st = list[0];
                        ed = list[1];
                        if (st > ed)
                        {
                            int c = st;
                            st = ed;
                            ed = c;

                        }
                        if (st >= 0 && ed >= 0)
                        {

                            for (int k = 0; k < num.Count; k++)
                            {
                                for (int n = st; n <= ed; n++)
                                {
                                    int pcNum = calcSimplePcChange(num)[k];
                                    var new_bor = new Border()
                                    {
                                        Uid = pcNum.ToString() + "_" + n.ToString() + "_" + dates[i].ToString(),
                                    };

                                    g_bor.Add(new_bor);


                                }
                            }
                        }
                        else
                        {
                           
                            WpfMessageBox.Show("Что то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            
                        }
                    }
                }

            }

            return g_bor;
        }

        public static List<int> convertTime(int st, int ed)
        {
            List<int> list = new List<int>();
            if (st > ed && ed <= 8)
            {
                st -= 11;
                ed += 13;
            }
            else
            {
                if (st <= 8)
                    st += 12;
                else if (st >= 12)
                    st -= 11;
                else
                    st = -1;


                if (ed <= 8)
                    ed += 12;
                else if (ed >= 12)
                    ed -= 11;
                else
                    ed = 22;
            }

          

            if (st < 1)
                st = -1;
            if (ed > 21)
                ed = -1;
            list.Add(st);
            list.Add(ed);
            return list;
        }

        public static string createChangeString(int _pcNum, List<int> _list)
        {
            string res = string.Empty;
            for (int i = 0; i < _list.Count; i++)
            {
                if (_pcNum == _list[i])
                {
                    _list.RemoveAt(i);
                    break;
                }

            }
            for (int i = 0; i < _list.Count; i++)
            {
                res += "pc" + _list[i] + ",";
            }
            if(!string.IsNullOrEmpty(res))
            {
                res = res.Remove(res.Length - 1);
                return res;
            }
            else
            {
                return null;
            }
            
            
        }

         public static string updateTime(string _input)
        {
            if (int.TryParse(_input, out var res))
            {
                if (_input.Length > 0 && _input.Length < 3)
                {
                    return _input + ":00";
                }
                else
                {
                    if (!string.IsNullOrEmpty(_input))
                    {
                        WpfMessageBox.Show("Неправильный формат времени", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                        return string.Empty;

                   
                }
            }
            else
            {
                if (!DateTime.TryParse(_input, out DateTime dt))
                {
                    if (!string.IsNullOrEmpty(_input))
                    {
                        WpfMessageBox.Show("Неправильный формат времени", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    return string.Empty;
                }
                else
                {
                    
                    return _input;
                }
            }
        }

        public static string checkInputString(string input)
        {
            string res = "";
            List<string> split_s = input.Split(',').ToList();
            for (int i = 0; i < split_s.Count; i++)
            {
                var i_count = split_s[i].Split('-').ToList().Count;
                for (int j = split_s.Count - 1; j >= 0; j--)
                {
                    if (i != j)
                    {
                        var j_count = split_s[j].Split('-').ToList().Count;
                        if (i_count==1&&j_count==1)
                        {
                            if (split_s[i] == split_s[j])
                            {
                                split_s.Remove(split_s[j]);
                                if (j != split_s.Count)
                                    j++;
                            }
                        }
                       else
                        {

                        }
                    }

                }
            }
            foreach (var str in split_s)
            {
                res += str + ",";
            }
            res = res.Remove(res.Length - 1);
            return res;
        }
       
    }
}
