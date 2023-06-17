using MessBox;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;

namespace Branirovanie
{
    class DataBase : Config
    {
        public DataTable cur_dt { get; set; }
        private readonly MySqlConnection conn = new MySqlConnection("server="+conf_server+"; username="+conf_username+"; password="+conf_password+"; database="+conf_database+"; CharacterSet="+conf_CharacterSet+"; AllowPublicKeyRetrieval="+conf_AllowPublicKeyRetrieval+";");
       // private readonly MySqlConnection conn1 = new MySqlConnection("server=localhost;username=root;password=qwerty1;database=club;CharacterSet =utf8; AllowPublicKeyRetrieval=True");
      
        
       
        
        
        public void openConnection()
        {
         
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    

                }
                catch (MySqlException ex) { WpfMessageBox.Show("Проблемы с подключением к базе данных","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error); };
            }

        }
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }


        public bool checkClient(string username, string phone)
        {
           
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                
                try
                {
                    conn.Open();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                    return true;
                }
                
                MySqlCommand comClient = new MySqlCommand("CALL CheckClient(@username,@phone);", conn);
                comClient.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                comClient.Parameters.Add("@username", MySqlDbType.VarChar).Value = username; 
                comClient.ExecuteNonQuery();
                if (comClient.ExecuteScalar() != null)
                {

                   // MessageBox.Show("Пользователь уже существует", "Добавлять не нужно", MessageBoxButton.OK, MessageBoxImage.Error);
                    closeConnection();
                    return true;
                }
                else
                {
                   // MessageBox.Show("Пользователя нет", "Добавлять  нужно", MessageBoxButton.OK, MessageBoxImage.Error);
                    closeConnection();
                    return false;
                }
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                closeConnection();
                return true;
            }
            
            
        }


        public void addClient(string username, string phone)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
                }
                    try
                    {
                       
                        MySqlCommand addCommand = new MySqlCommand("CALL AddClient (@username, @phone);", conn);
                        addCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                        addCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                        addCommand.ExecuteNonQuery();
             
                
                    }
                    catch(Exception ex)
                    {
                         WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    closeConnection();
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return;
            }


        }

        public int getIdClient(string username, string phone)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }
                int k;
                try
                {
                    
                    MySqlCommand searchIdCommand = new MySqlCommand("Select id from club.`Client` where name=@username and phone=@phone;", conn);
                    searchIdCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                    searchIdCommand.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                    k= Convert.ToInt32 (searchIdCommand.ExecuteScalar());
 
                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    closeConnection();
                    return 0;
                }

                closeConnection();
                return k;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return 0;
            }
        }


        public int getIdClient(int orId)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }
                int k;
                try
                {
                    
                    MySqlCommand searchIdCommand = new MySqlCommand("Select id from club.`ClubOrder` where id=@id;", conn);
                    searchIdCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = orId;
                    k = Convert.ToInt32(searchIdCommand.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    closeConnection();
                    return -1;
                }

                closeConnection();
                return k;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return 0;
            }

        }

        public int getIdClientToday(int orId)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return -1;
                }
                int k;
                try
                {
                    
                    MySqlCommand searchIdCommand = new MySqlCommand("Select idclient from club.`TodayOrders` where id=@id;", conn);
                    searchIdCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = orId;
                    k = Convert.ToInt32(searchIdCommand.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    closeConnection();
                    return -1;
                }

                closeConnection();
                return k;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return -1;
            }
        }

        public List<string> getClientFromId(int clientId)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                var cur_list = new List<string>();
                try
                {
                    
                    MySqlCommand searchIdCommand = new MySqlCommand("Select name,phone from club.`Client` where id=@id;", conn);
                    searchIdCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = clientId;
                    var MyDataReader = searchIdCommand.ExecuteReader();

                    while (MyDataReader.Read())
                    {
                        cur_list.Add(MyDataReader.GetString(0));
                        cur_list.Add(MyDataReader.GetString(1));
                    }
                    MyDataReader.Close();
                    closeConnection();
                    if (cur_list.Count != 0)
                        return cur_list;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    closeConnection();
                    return null;
                }
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }


        }

        public void addOrder(DateTime _date, string _start, string _end, int _idClient,string _pcRange,  string _comment)
        {
            
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    MySqlCommand addCommand = new MySqlCommand("CALL AddOrder(@_date, @_start, @_end,@_idClient,@_pcRange,@_comment,@_pcCount,@_timeCount);", conn);
                    addCommand.Parameters.Add("@_date", MySqlDbType.DateTime).Value = _date;
                    addCommand.Parameters.Add("@_start", MySqlDbType.VarChar).Value = _start;
                    addCommand.Parameters.Add("@_end", MySqlDbType.VarChar).Value = _end;
                    addCommand.Parameters.Add("@_idClient", MySqlDbType.Int32).Value = _idClient;
                    addCommand.Parameters.Add("@_pcRange", MySqlDbType.VarChar).Value = _pcRange;
                    addCommand.Parameters.Add("@_comment", MySqlDbType.VarChar).Value = _comment;
                    addCommand.Parameters.Add("@_pcCount", MySqlDbType.Int32).Value = getPcCount(DesignFunctions.calcPcRange(_pcRange));
                    addCommand.Parameters.Add("@_timeCount", MySqlDbType.Int32).Value = calcTime(_start,_end);
                    addCommand.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                closeConnection();
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return;
            }

        }

        public void addOrder(DateTime _date, string _start, string _end, int _idClient, string _pcRange)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    MySqlCommand addCommand = new MySqlCommand("CALL AddOrder_short(@_date, @_start, @_end,@_idClient,@_pcRange,@_pcCount,@_timeCount);", conn);
                    addCommand.Parameters.Add("@_date", MySqlDbType.DateTime).Value = _date;
                    addCommand.Parameters.Add("@_start", MySqlDbType.VarChar).Value = _start;
                    addCommand.Parameters.Add("@_end", MySqlDbType.VarChar).Value = _end;
                    addCommand.Parameters.Add("@_idClient", MySqlDbType.Int32).Value = _idClient;
                    addCommand.Parameters.Add("@_pcRange", MySqlDbType.VarChar).Value = _pcRange;
                    addCommand.Parameters.Add("@_pcCount", MySqlDbType.Int32).Value = getPcCount(DesignFunctions.calcPcRange(_pcRange));
                    addCommand.Parameters.Add("@_timeCount", MySqlDbType.Int32).Value = calcTime(_start, _end);
                    addCommand.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                closeConnection();
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return;
            }
        }


        public void deleteOrder(int idOr,string table)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    MySqlCommand delCommand = new MySqlCommand("delete from club.`"+table+"`where id=@id ;", conn);
                    delCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = idOr;
                    delCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                closeConnection();
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return;
            }
        }

        


        public int calcTime(string _start, string _end)
        {
            int start = 0, end = 0;
            
            try
            {
                if (Convert.ToDateTime(_start).Hour <=8)
                {
                    start = Convert.ToDateTime(_start).Hour + 12;
                }
                else if (Convert.ToDateTime(_start).Hour >= 12)
                {
                    start = Convert.ToDateTime(_start).Hour - 12;
                }
                if (Convert.ToDateTime(_end).Hour <= 8)
                {
                    end = Convert.ToDateTime(_end).Hour + 12;
                }
                else if (Convert.ToDateTime(_end).Hour >= 12)
                {
                    end = Convert.ToDateTime(_end).Hour - 12;
                }
                
                return Math.Abs(start - end);
            }
            catch
            {
                MessageBox.Show("Что то не так со временем....","Ошибка определения длительности сеанса");
                return -1;
            }
        }

        public int getPcCount(List<int> _num)
        {
           
            int pc, ps;
            pc = ps = 0;

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
                        pc++;
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
                               
                                 pc += Math.Abs(_num[i] - _num[i + 1]) + 1;
                                
                                i++;
                            }
                        }
                    }
                }
            }

            return pc;
        }

        public bool haveOrder(DateTime dt)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                while (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        Thread.Sleep(1000);
                    }
                }
                MySqlCommand comClient = new MySqlCommand("Select * from club.`ClubOrder` where Date=@date;", conn);
                comClient.Parameters.Add("@date", MySqlDbType.DateTime).Value = dt;
                comClient.ExecuteNonQuery();
                if (comClient.ExecuteScalar() != null)
                {

                    
                    return true;
                }
                else
                {
                  
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Проблемы с соединением");
                closeConnection();
                return false;
            }
            
        }

        public List<string> getStartOrder(DateTime dt)
        {
            List<string> str = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                
                MySqlCommand comClient = new MySqlCommand("Select  starttime from club.`ClubOrder` where Date=@date;", conn);
                comClient.Parameters.Add("@date", MySqlDbType.DateTime).Value = dt;
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    str.Add(MyDataReader.GetString(0));
                }
                MyDataReader.Close();
                if (str.Count!=0)
                    return str;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }

        public List<string> getStartOrderToday()
        {
            List<string> str = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }

                MySqlCommand comClient = new MySqlCommand("Select  starttime from club.`TodayOrders`;", conn);
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    str.Add(MyDataReader.GetString(0));
                }
                MyDataReader.Close();
                if (str.Count != 0)
                    return str;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }

        public List<string> getEndOrder(DateTime dt)
        {
            List<string> str = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select  endtime from club.`ClubOrder` where Date=@date;", conn);
                comClient.Parameters.Add("@date", MySqlDbType.DateTime).Value = dt;
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    str.Add(MyDataReader.GetString(0));
                }
                MyDataReader.Close();
                if (str.Count!=0)
                    return str;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }
        public List<string> getEndOrderToday()
        {
            List<string> str = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select  endtime from club.`TodayOrders`", conn);
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    str.Add(MyDataReader.GetString(0));
                }
                MyDataReader.Close();
                if (str.Count != 0)
                    return str;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }

        public string getPcRange(DateTime dt)
        {
            string str = String.Empty;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select PcRange fromclub.`ClubOrder` where Date=@date;", conn);
                comClient.Parameters.Add("@date", MySqlDbType.DateTime).Value = dt;
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    str+= MyDataReader.GetString(0)+",";
                }
                MyDataReader.Close();
                if (str != String.Empty)
                    return str.Remove(str.Length - 1);
                else
                    return str; 
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }

        public string getPcRange(DateTime dt,int _start, int _end)
        {
            string str = String.Empty;
            
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }

                MySqlCommand comClient = new MySqlCommand("Select PcRange from club.`cluborder` where date=@date and (starttime=@start and endtime=@end);", conn);
                comClient.Parameters.Add("@date", MySqlDbType.DateTime).Value = dt;
                comClient.Parameters.Add("@start", MySqlDbType.Time).Value = TimeSpan.FromHours((double)_start);
                comClient.Parameters.Add("@end", MySqlDbType.Time).Value = TimeSpan.FromHours((double)_end);
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    str += MyDataReader.GetString(0) + ",";
                }
                MyDataReader.Close();
                if (str != String.Empty)
                    return str.Remove(str.Length - 1);
                else
                    return str;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }


        public string getPcRange(int _orId)
        {
            string str = String.Empty;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }

                MySqlCommand comClient = new MySqlCommand("Select PcRange from club.`ClubOrder` where id=@orId;", conn);
                comClient.Parameters.Add("@orId", MySqlDbType.Int32).Value = _orId;
                
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    str = MyDataReader.GetString(0);
                }
                MyDataReader.Close();
                if (str != String.Empty)
                    return str;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }

        public string getPcRangeToday(int _orId)
        {
            string str = String.Empty;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }

                MySqlCommand comClient = new MySqlCommand("Select PcRange from club.`TodayOrders` where id=@orId;", conn);
                comClient.Parameters.Add("@orId", MySqlDbType.Int32).Value = _orId;

                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    str = MyDataReader.GetString(0);
                }
                MyDataReader.Close();
                if (str != String.Empty)
                    return str;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }

        public List<int> getAllIdOrder()
        {
            List<int> items = new List<int>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select id from club.`ClubOrder`", conn);

                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    items.Add(MyDataReader.GetInt32(0));
                }
                MyDataReader.Close();
                if (items.Count != 0)
                    return items;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }

        }
    

        public int getOrderId(DateTime _date,  int _start, int _end, string _pcRange)
        {
            int id = 0;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return -1;
                }

                MySqlCommand comClient = new MySqlCommand("Select id from club.`ClubOrder` where Date=@date and StartTime=@start and EndTime=@end and PcRange=@pcRange;", conn);
                comClient.Parameters.Add("@date", MySqlDbType.DateTime).Value = _date;
                comClient.Parameters.Add("@start", MySqlDbType.Time).Value = TimeSpan.FromHours((double)_start);
                comClient.Parameters.Add("@end", MySqlDbType.Time).Value = TimeSpan.FromHours((double)_end);
                comClient.Parameters.Add("@pcRange", MySqlDbType.VarChar).Value = _pcRange;
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                   id=MyDataReader.GetInt32(0);
                }
                MyDataReader.Close();
                    return id;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return -1;
            }
        }

        public int getOrderIdToday( int _start, int _end, string _pcRange)
        {
            int id = 0;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return -1;
                }

                MySqlCommand comClient = new MySqlCommand("Select id from club.`TodayOrders` where  StartTime=@start and EndTime=@end and PcRange=@pcRange;", conn);
                comClient.Parameters.Add("@start", MySqlDbType.VarChar).Value = _start+":00";
                comClient.Parameters.Add("@end", MySqlDbType.VarChar).Value =_end+":00";
                comClient.Parameters.Add("@pcRange", MySqlDbType.VarChar).Value = _pcRange;
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    id = MyDataReader.GetInt32(0);
                }
                MyDataReader.Close();
                return id;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return -1;
            }
        }

        public  List<DateTime> getAllDates()
        {
            List<DateTime> dates = new List<DateTime>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select DISTINCT Date from club.`ClubOrder`", conn);
                
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    dates.Add(MyDataReader.GetDateTime(0));
                }
                MyDataReader.Close();
                if (dates.Count != 0)
                    return dates;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
            
        }

        public List<string> getIdWithPcRange()
        {
            List<string> res = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select id,pcrange from club.`ClubOrder`", conn);

                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    res.Add(Convert.ToString(MyDataReader.GetInt32(0))+ "_" + MyDataReader.GetString(1));
                    
                }
                MyDataReader.Close();
                if (res.Count != 0)
                    return res;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
            
        }


        public List<string> getIdWithPcRange(DateTime _dt)
        {
            List<string> res = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select id,pcrange from club.`ClubOrder` where date=@date", conn);
                comClient.Parameters.Add("@date", MySqlDbType.DateTime).Value = _dt;
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    res.Add(Convert.ToString(MyDataReader.GetInt32(0)) + "_" + MyDataReader.GetString(1));

                }
                MyDataReader.Close();
                if (res.Count != 0)
                    return res;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }

        }


        public List<string> getIdWithPcRangeToday()
        {
            List<string> res = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select id,pcrange from club.`TodayOrders`", conn);
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    res.Add(Convert.ToString(MyDataReader.GetInt32(0)) + "_" + MyDataReader.GetString(1));

                }
                MyDataReader.Close();
                if (res.Count != 0)
                    return res;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }

        }

        public List<string> getTooltipData(int clientId,int orderId)
        {
            List<string> res = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("CALL GetTooltip(@ClientId,@OrderId);", conn);
                comClient.Parameters.Add("@ClientId", MySqlDbType.Int32).Value = clientId;
                comClient.Parameters.Add("@OrderId", MySqlDbType.Int32).Value = orderId;

                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    
                    if (!MyDataReader.IsDBNull(2))
                    {
                        res.Add(MyDataReader.GetString(0));
                        res.Add(MyDataReader.GetString(1)); 
                        res.Add(MyDataReader.GetString(2));
                    }
                    else
                    {
                        res.Add(MyDataReader.GetString(0));
                        res.Add(MyDataReader.GetString(1));
                    }

                }
                MyDataReader.Close();
                if (res.Count != 0)
                    return res;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null; 
            }

        }



        public List<int> getIdOrdersToDate(DateTime _dt)
        {
            List<int> res = new List<int>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                MySqlCommand comClient = new MySqlCommand("Select id from club.`ClubOrder` where date=@date", conn);
                comClient.Parameters.Add("@date", MySqlDbType.DateTime).Value = _dt;
                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    res.Add(MyDataReader.GetInt32(0));

                }
                MyDataReader.Close();
                closeConnection();
                if (res.Count != 0)
                    return res;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }


        public void setPcRange(string _pcRange, int _idOr)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    openConnection();
                    MySqlCommand setCommand = new MySqlCommand("Update ClubOrder set pcRange=@pc where id=@id;", conn);
                    setCommand.Parameters.Add("@pc", MySqlDbType.VarChar).Value = _pcRange;
                    setCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = _idOr;
                    setCommand.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                closeConnection();
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return;
            }
        }

        public ObservableCollection<Items> getSource()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                ObservableCollection<Items> cur_items = new ObservableCollection<Items>();
                MySqlCommand com = new MySqlCommand("Select id,date,startTime,endTime,idClient,pcRange,comment from club.`ClientOrder`", conn);
                try
                {
                   
                DateTime dt = new DateTime();

                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            Items item = new Items();
                            item.id = (int)dr[0];
                            dt = (DateTime)dr[1];
                            item.date = dt.Date.ToString().Remove(10);
                            item.start_time = dr[2].ToString();
                            item.end_time = dr[3].ToString();
                            item.idClient = dr[4].ToString();
                            item.pcRange = (string)dr[5];
                            if(!dr.IsDBNull(6))
                            {
                                item.comment = (string)dr[6];
                            }
                            else
                            {
                                item.comment = "";
                            }
                            item.selected = false;

                            cur_items.Add(item);
                        }
                    
                    }




                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                closeConnection();
                return cur_items;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
        }


        public bool checkChangeClientOrder(DataView _view)
        {
            if (_view == cur_dt.AsDataView())
                return false;
            else
                return true;
        }


        public void addClientOrder(DateTime _date, string _start, string _end, int _idClient, string _pcRange, string _comment)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    
                    MySqlCommand addCommand = new MySqlCommand("CALL AddClientOrder(@_date, @_start, @_end,@_idClient,@_pcRange,@_comment);", conn);
                    addCommand.Parameters.Add("@_date", MySqlDbType.DateTime).Value = _date;
                    addCommand.Parameters.Add("@_start", MySqlDbType.VarChar).Value = _start;
                    addCommand.Parameters.Add("@_end", MySqlDbType.VarChar).Value = _end;
                    addCommand.Parameters.Add("@_idClient", MySqlDbType.Int32).Value = _idClient;
                    addCommand.Parameters.Add("@_pcRange", MySqlDbType.VarChar).Value = _pcRange;
                    addCommand.Parameters.Add("@_comment", MySqlDbType.VarChar).Value = _comment;
                    addCommand.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                closeConnection();
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return;
            }
        }

        public void addClientOrder(DateTime _date, string _start, string _end, int _idClient, string _pcRange)
        {

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    
                    MySqlCommand addCommand = new MySqlCommand("CALL AddClientOrder_short(@_date, @_start, @_end,@_idClient,@_pcRange);", conn);
                    addCommand.Parameters.Add("@_date", MySqlDbType.DateTime).Value = _date;
                    addCommand.Parameters.Add("@_start", MySqlDbType.VarChar).Value = _start;
                    addCommand.Parameters.Add("@_end", MySqlDbType.VarChar).Value = _end;
                    addCommand.Parameters.Add("@_idClient", MySqlDbType.Int32).Value = _idClient;
                    addCommand.Parameters.Add("@_pcRange", MySqlDbType.VarChar).Value = _pcRange;
                    addCommand.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                closeConnection();
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return;
            }
        }


        public List<string> getAutentification(string _log, string _pass)
        {
            var str = string.Empty;
            List<string> res = new List<string>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                
                MySqlCommand comClient = new MySqlCommand("SELECT login,role_idrole FROM club.user WHERE user.login = @log and user.pass = @pas; ", conn);
                comClient.Parameters.Add("@log", MySqlDbType.VarChar).Value = _log;
                comClient.Parameters.Add("@pas", MySqlDbType.VarChar).Value = _pass;

                MySqlCommand setcmd = new MySqlCommand("SET character_set_results=utf8", conn);
                int n = setcmd.ExecuteNonQuery();
                setcmd.Dispose();

                var MyDataReader = comClient.ExecuteReader();

                while (MyDataReader.Read())
                {
                    res.Add(MyDataReader.GetString(0));
                    res.Add(MyDataReader.GetString(1));
                }
                MyDataReader.Close();
                if (res.Count != 0)
                    return res;
                else
                    return null;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;
            }
            
        }

        public void addFood(List<string> list, decimal total)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MySqlCommand FoodOrder = new MySqlCommand("insert into club.`FoodOrder`(Total,customer) values (@total,@customer); ", conn);
                FoodOrder.Parameters.Add("@total", MySqlDbType.Decimal).Value = total;
                FoodOrder.Parameters.Add("@customer", MySqlDbType.VarChar).Value = Properties.Settings.Default.Curuser;
                FoodOrder.ExecuteNonQuery();

                var id = 0;
                MySqlCommand comid = new MySqlCommand("select id from club.`FoodOrder` where id=LAST_INSERT_ID();", conn);
                var MyDataReader = comid.ExecuteReader();

                while (MyDataReader.Read())
                {
                    id = MyDataReader.GetInt32(0);
                    
                }
                MyDataReader.Close();


                for (int i = 0; i < list.Count; i++)
                {
                    var split = list[i].Split('|');
                    var rest = "";
                    switch (split[0])
                    {
                        case "Престо":
                            rest = "Presto";
                            break;
                        case "Subway": 
                            rest = "Subway";
                            break;
                        case "Верона":
                           rest = "Verona";
                            break;
                        case "Якида и Фигаро":
                           rest= "Yakida";
                            break;
                    }
                    MySqlCommand comRest = new MySqlCommand("Insert into club.`"+rest+"`(idOrder,FoodName,Price,Count) values(@id,@foodname,@price,@count) ;", conn);
                    decimal.TryParse(split[2], out decimal dec_res);
                    int.TryParse(split[3], out int int_res);
                    comRest.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    comRest.Parameters.Add("@foodname", MySqlDbType.VarChar).Value = split[1];
                    comRest.Parameters.Add("@price", MySqlDbType.Decimal).Value = Convert.ToDecimal(split[2]);
                    comRest.Parameters.Add("@count", MySqlDbType.Int32).Value = Convert.ToInt32(split[3]);
                    comRest.ExecuteNonQuery();
                }
                closeConnection();
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return;

            }
            

        }


        public ObservableCollection<FoodOrderClass> getSourceFoodOrder()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                ObservableCollection<FoodOrderClass> cur_items = new ObservableCollection<FoodOrderClass>();
                MySqlCommand com = new MySqlCommand("Select id,total,customer from club.`FoodOrder`", conn);
                try
                {
                    openConnection();


                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            FoodOrderClass item = new FoodOrderClass();
                            item.id = (int)dr[0];
                            item.total = dr[1].ToString();
                            item.customerName = dr[2].ToString();
                            cur_items.Add(item);
                        }

                    }




                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                closeConnection();
                return cur_items;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;

            }
        }

        public ObservableCollection<RestouranOrder> getSource(string name)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    openConnection();
                }
                catch (MySqlException ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                ObservableCollection<RestouranOrder> cur_items = new ObservableCollection<RestouranOrder>();
                MySqlCommand com = new MySqlCommand("Select id,idOrder,foodName,price,count from club.`"+name+"`;", conn);
                try
                {
                    openConnection();


                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            RestouranOrder item = new RestouranOrder();
                            item.id = (int)dr[0];
                            item.idOrder = (int)dr[1];
                            item.foodName = dr[2].ToString();
                            item.price = Convert.ToDecimal(dr[3]);
                            item.count = (int)dr[4];
                            cur_items.Add(item);
                        }

                    }




                }
                catch (Exception ex)
                {
                    WpfMessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                closeConnection();
                return cur_items;
            }
            else
            {
                WpfMessageBox.Show("Проблемы с соединением", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                closeConnection();
                return null;

            }
        }
    }


   

    public class Items: INotifyPropertyChanged
    {
        private int _id;
        private string _date;
        private string _start_time;
        private string _end_time;
        private string _idClient;
        private string _pcRange;
        private string _comment;
        private bool _selected;

        public int id
        {
            get { return _id; } 
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }
        public string date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("date");
            }
        }
        public string start_time
        {
            get { return _start_time; }
            set
            {
                _start_time = value;
                OnPropertyChanged("start_time");
            }
        }
        public string end_time
        {
            get { return _end_time; }
            set
            {
                _end_time = value;
                OnPropertyChanged("end_time");
            }
        }
        public string idClient
        {
            get { return _idClient; }
            set
            {
                _idClient = value;
                OnPropertyChanged("idClient");
            }
        }
        public string pcRange
        {
            get { return _pcRange; }
            set
            {
                _pcRange = value;
                OnPropertyChanged("pcrange");
            }
        }
        public string comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged("comment");
            }
        }
        public bool selected 
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("selected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
       

    }
    public class FoodOrderClass : INotifyPropertyChanged
    {
        private int _id;
        private string _total;
        private string _customerName;
        private bool _selected;

        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }
        public string total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged("total");
            }
        }
        public string customerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                OnPropertyChanged("customerName");
            }
        }  
        public bool selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("selected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
    public class RestouranOrder : INotifyPropertyChanged
    {
        private int _id;
        private int _idOrder;
        private string _foodName;
        private decimal _price;
        private int _count;

        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }
        public int idOrder
        {
            get { return _idOrder; }
            set
            {
                _idOrder = value;
                OnPropertyChanged("idOrder");
            }
        }
        public string foodName
        {
            get { return _foodName; }
            set
            {
                _foodName = value;
                OnPropertyChanged("foodName");
            }
        }
        public decimal price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("price");
            }
        }
        public int count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged("count");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }

}
