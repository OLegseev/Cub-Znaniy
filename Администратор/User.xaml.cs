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
using Telegram.Bot.Types;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Авторассылка.Администратор
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Page
    {
        string connstring = MainWindow.connstringmain1;
        public class std
        {
            public string Fio { get; set; }
            public string Login { get; set; }

            public string Role { get; set; }
            public string ID { get; set; }
        }
        public List<std> stds = new List<std>();

        public User()
        {
            InitializeComponent();
            
            SqlConnection myConnection = new SqlConnection();
            string name = "d";
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"select * from employee where [id_accaunt] = {TypeAd.Person.name}";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);

                    Name.Text = sus[1];
                }
                myConnection.Close();




            }
            catch
            {
                myConnection.Close();
            }
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"select * from accaunt where [id_accaunt] = {TypeAd.Person.name}";
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
                    name = sus[3];
                    str.Text = sus[1];
                    str_Copy.Text = sus[2];


                }
                myConnection.Close();




            }
            catch
            {
                myConnection.Close();
            }
            string chang = "";
            if (name == "1")
            {
                chang = "Администратор";
            }
            else if (name == "2")
            {
                chang = "Менеджер";
            }
            else if (name == "3")
            {
                chang = "Преподаватель";
            }
            tb.Text = "Роль: " + chang;
            if (chang != "Администратор")
            {
                //ex.Visibility = Visibility.Hidden;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
               SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"update accaunt set[login] = '{str.Text}', [password] = '{str_Copy.Text}' where id_accaunt =  {TypeAd.Person.name}";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
               
                myConnection.Close();



                MessageBox.Show("Успешно обновлено");
            }
            catch
            {

                MessageBox.Show("Неверно заполненные данные");
                myConnection.Close();
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"select Fio,[Login],[Role_name],Accaunt.id_accaunt from [Employee] join Accaunt on Accaunt.id_accaunt = Employee.id_accaunt join [Role] on [Role].id_Role = Accaunt.id_Role";
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
                    stds.Add(new std { Fio = sus[0], Login = sus[1], Role = sus[2], ID = sus[3] });
                    
                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
        }
    }
}
