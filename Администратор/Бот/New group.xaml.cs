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
using System.Security.Cryptography;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для New_group.xaml
    /// </summary>
    public partial class New_group : Page
    {
        string connstring = MainWindow.connstringmain;
        public New_group()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Inc();


            MessageBox.Show("Группа успешно добавлена");
            NavigationService.GoBack();
        }
        public bool Inc()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"insert into groupp(connecting,tipe,name_group,Callback_id) values('" + str.Text + "','" + cb.Text + "','" + gr.Text + "','" + str_Copy.Text + "')";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();

                myConnection.Close();
                MessageBox.Show("Группа успешно добавлена");
                return true;



            }
            catch
            {
                myConnection.Close();
                MessageBox.Show("Группа не добавлена");
                return false;
            }
        }
    }
}
