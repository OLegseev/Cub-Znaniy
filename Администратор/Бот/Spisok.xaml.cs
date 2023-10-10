using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using static Авторассылка.AqvtootvShablon;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для Spisok.xaml
    /// </summary>
    public partial class Spisok : Page
    {
        string connstring = MainWindow.connstringmain;
        public List<TodoItem> items = new List<TodoItem>();
        public Spisok()
        {
            InitializeComponent();
            Log();
            icTodoList.ItemsSource = items;
        }
        public class TodoItem
        {
            public string tipe { get; set; }//group name
            public string coll { get; set; }//type
            public string name { get; set; }
        }
        public bool Log()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from groupp";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);
                    sus[2] = Convert.ToString(dr[2]);
                    sus[3] = Convert.ToString(dr[3]);
                    sus[4] = Convert.ToString(dr[4]);
                    items.Add(new TodoItem() { tipe = sus[2], coll = sus[3], name = sus[4] });
                }
                myConnection.Close();
                return true;


            }
            catch
            {
                myConnection.Close();
                return false;
            }
            //private void Button_Click(object sender, RoutedEventArgs e)
            //{
            //    GR.Visibility = Visibility.Hidden;   
            //}

            //private void Button_Click_1(object sender, RoutedEventArgs e)
            //{
            //    if (Convert.ToString(bt1.Content) == "Остановить")
            //    {
            //        bt1.Content = "Возобновить";
            //    }
            //    else
            //    {
            //        bt1.Content = "Остановить";
            //    }
            //}
        }
    }
}
