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
    /// Логика взаимодействия для Block.xaml
    /// </summary>
    public partial class Block : Page
    {
        public Block()
        {
            InitializeComponent();
            bd.Log();
            dg.ItemsSource = bd.items.ToList();
        }
        public class bd
        {
            static string connstring = MainWindow.connstringmain;
            public static List<TodoItem> items = new List<TodoItem>();
            public class TodoItem
            {
               
                public string UsersId { get; set; }//type


            }
            public static bool Log()
            {

                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = connstring;
                SqlCommand sqlCmd = new SqlCommand();
                try
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = @"Select * from ban_list";
                    sqlCmd.Connection = myConnection;
                    myConnection.Open();
                    sqlCmd.ExecuteNonQuery();
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    string[] sus = new string[2];
                    while (dr.Read())
                    {
                        sus[0] = Convert.ToString(dr[0]);
                        sus[1] = Convert.ToString(dr[1]);
                        items.Add(new TodoItem() {  UsersId = sus[1] });
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
