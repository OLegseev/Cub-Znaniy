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
    /// Логика взаимодействия для AddPrepAdmin.xaml
    /// </summary>
    public partial class AddPrepAdmin : Page
    {
        string connstring = MainWindow.connstringmain1;
        public AddPrepAdmin()
        {
            InitializeComponent();
           
        }
        public bool Meth()
        {
            string chang = "";
            if (cb.Text == "Администратор")
            {
                chang = "1";
            }
            else if (cb.Text == "Менеджер")
            {
                chang = "2";
            }
            else if (cb.Text == "Преподаватель")
            {
                chang = "3";
            }
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"insert into [Accaunt] ([Login],[Password] ,[id_Role]) values('{str.Text}','{str_Copy.Text}',{chang}) ";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                myConnection.Close();


            }
            catch
            {
                myConnection.Close();
                MessageBox.Show("Некоректные данные!");
                NavigationService.Navigate(new PrepAdmin());
                return false;
            }
            string idacc = "";
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"select * from accaunt where [Login] = '{str.Text}'";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    idacc = sus[0];

                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
                MessageBox.Show("Некоректные данные!");
                NavigationService.Navigate(new PrepAdmin());
                return false;
            }
            try
            {


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"insert into [Employee] ([Fio],[id_accaunt]) values('{gr.Text}',{idacc}) ";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                myConnection.Close();


            }
            catch
            {
                myConnection.Close();
                MessageBox.Show("Некоректные данные!");
                NavigationService.Navigate(new PrepAdmin());
                return false;
            }
            MessageBox.Show("Сотрудник успешно добавлен!");
            NavigationService.Navigate(new PrepAdmin());
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Meth();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
