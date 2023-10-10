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
    /// Логика взаимодействия для AddLessonAdmin.xaml
    /// </summary>
    public partial class AddLessonAdmin : Page
    {
        string connstring = MainWindow.connstringmain;
        public List<string> lis = new List<string>();
        public List<string> lis1 = new List<string>();
        public List<string> lis2 = new List<string>();
        public AddLessonAdmin()
        {
            InitializeComponent();
            datet.Text = TypeAd.Person.datapary;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from groupp_les";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    lis.Add(sus[0]);
                    sus[1] = Convert.ToString(dr[1]);

                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
            cb.ItemsSource = lis;
            SqlConnection myConnection1 = new SqlConnection();
            myConnection1.ConnectionString = connstring;
            SqlCommand sqlCmd1 = new SqlCommand();
            try
            {
                sqlCmd1.CommandType = CommandType.Text;
                sqlCmd1.CommandText = @"Select * from Autorize";
                sqlCmd1.Connection = myConnection1;
                myConnection1.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr1 = sqlCmd1.ExecuteReader();
                string[] sus = new string[5];
                while (dr1.Read())
                {
                    sus[3] = Convert.ToString(dr1[3]);
                    lis1.Add(sus[3]);
                    sus[1] = Convert.ToString(dr1[1]);

                }
                myConnection1.Close();



            }
            catch
            {
                myConnection1.Close();
            }
            cb1.ItemsSource = lis1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string idn = "0";
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from Autorize where fio = '"+cb1.Text+"'";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    idn = sus[0];

                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }



            SqlConnection myConnection1 = new SqlConnection();
            myConnection1.ConnectionString = connstring;
            SqlCommand sqlCmd1 = new SqlCommand();
            try
            {


                sqlCmd1.CommandType = CommandType.Text;
                sqlCmd1.CommandText = @"insert into lesson(les_group,date_para,time_para,les_prep) values("+cb.Text+",'"+datet.Text+ "','"+timet.Text+"',"+idn+")";
                sqlCmd1.Connection = myConnection1;
                myConnection1.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr1 = sqlCmd1.ExecuteReader();
                myConnection1.Close();


            }
            catch
            {
                myConnection1.Close();

            }
        }

        private void cb_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
