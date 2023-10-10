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
    /// Логика взаимодействия для Trackxaml.xaml
    /// </summary>
    public partial class Trackxaml : Page
    {
        List<string> lil = new List<string>();
        public Trackxaml()
        {
            InitializeComponent();
            bd.Log();
            for (int i = 0; i < bd.items.Count; i++)
            {
                if (!lil.Contains(bd.items[i].UsersCode))
                {
                    lil.Add(bd.items[i].UsersCode);
                }
                
            }
            cb.ItemsSource = lil;
            
        }
        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = bd.items.Where(x => x.UsersCode == cb.Text);
            dg.ItemsSource = a.ToList();
        }
        public class bd
        {
            static string connstring = MainWindow.connstringmain;
            public static List<TodoItem> items = new List<TodoItem>();
            public class TodoItem
            {
                public string SendsDate { get; set; }//group name
                public string UsersText { get; set; }//type
                public string UsersCode { get; set; }
                public string BotText { get; set; }
               
            }
            public static bool Log()
            {

                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = connstring;
                SqlCommand sqlCmd = new SqlCommand();
                try
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = @"Select * from users_track";
                    sqlCmd.Connection = myConnection;
                    myConnection.Open();
                    sqlCmd.ExecuteNonQuery();
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    string[] sus = new string[5];
                    while (dr.Read())
                    {
                        sus[0] = Convert.ToString(dr[0]);
                        sus[1] = Convert.ToString(dr[1]);
                        sus[2] = Convert.ToString(dr[2]);
                        sus[3] = Convert.ToString(dr[3]);
                        sus[4] = Convert.ToString(dr[4]);
                        items.Add(new TodoItem() { SendsDate = sus[1], UsersText = sus[2], UsersCode = sus[3], BotText = sus[4] });
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
        }

        
    }

}
