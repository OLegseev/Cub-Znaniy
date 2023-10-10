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

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для AqvtootvShablon.xaml
    /// </summary>
    public partial class AqvtootvShablon : Page
    {

        string connstring = MainWindow.connstringmain;
        public int sisse = 100;
        public List<TodoItem> items = new List<TodoItem>();
        public AqvtootvShablon()
        {
            InitializeComponent();
            

            Log();
            icTodoList.ItemsSource = items;
          
        }
        public bool Log()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from texts_avt";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[7];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);
                    sus[2] = Convert.ToString(dr[2]);
                    sus[3] = Convert.ToString(dr[3]);
                    sus[4] = Convert.ToString(dr[4]);
                    sus[5] = Convert.ToString(dr[5]);
                    sus[6] = Convert.ToString(dr[6]);
                    items.Add(new TodoItem() { Title = sus[4], Completion = sus[3],TextAvt = sus[2], Stat = sus[5], uslovie = sus[6] });
                }
                myConnection.Close();
                    return true;


            }
            catch
            {
                myConnection.Close();
                return false;
            }
        }


        public class TodoItem
        {
            public string Title { get; set; }//group name
            public string Completion { get; set; }//type
            public string TextAvt { get; set; }
            public string Stat { get; set; }
            public string uslovie { get; set; }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Avtoot());
        }
    }
}
