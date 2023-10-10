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
    /// Логика взаимодействия для AddGroupAdmin.xaml
    /// </summary>
    public partial class AddGroupAdmin : Page
    {
        string connstring = MainWindow.connstringmain1;
        public class std
        {
            public string ID { get; set; }

            public string Name { get; set; }

        }
        public List<std> stds = new List<std>();
        public List<string> stds1 = new List<string>();
        public AddGroupAdmin()
        {

            InitializeComponent();

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"select * from direction";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);

                    stds.Add(new std { Name = sus[1], ID = sus[0] });
                    stds1.Add(sus[1]);
                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }

            str.ItemsSource = stds1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string idgr = "";
            for (int i = 0; i < stds.Count; i++)
            {
                if (stds[i].Name == str.Text)
                {
                    idgr = stds[i].ID;
                }
            }
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"insert into [Group](id_direction,Num_group) values({idgr},'{gr.Text}')";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                myConnection.Close();

                
            }
            catch
            {
                myConnection.Close();
               
            }
            MessageBox.Show("Группа успешно добавлена!");
            NavigationService.Navigate(new GroupAdmin());
        }
    }
}
