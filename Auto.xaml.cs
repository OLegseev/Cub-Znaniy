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
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        string connstring = MainWindow.connstringmain;
        public Auto()
        {
            InitializeComponent();
           
            SavedA();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (log.Text == "" || pas.Password == "")
            {
                MessageBox.Show("Один из элементов пустой");
            }
            else
            {
                if (Logining())
                {
                    if ((bool)cb.IsChecked)
                    {
                        Putting();
                    }
                    if (TypeAd.Person.stat == "Admin")
                    {
                        NavigationService.Navigate(new MainAdmin());
                    }
                    else
                    {
                        NavigationService.Navigate(new MainPrepod());
                    }
                    
                    
                }
            }
            
        }
        public bool SavedA()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from saved";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);
                }
                myConnection.Close();
                if (Convert.ToInt32(sus[0]) > 0)
                {
                    log.Text = sus[1];
                    cb.IsChecked = true;    
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch
            {
                myConnection.Close();
                return false;
            }
        }
        public bool Putting()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"insert into saved(login_a) values('" + id + "')" ;
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                myConnection.Close();

                    return true;
            }
            catch
            {
                myConnection.Close();
                return false;
            }
        }
        string id = "";
        public bool Logining()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from Autorize where login_a = '" + log.Text + "' and password_a = '" + pas.Password + "'";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = (string)dr[1];
                    sus[2] = (string)dr[2];
                    sus[3] = Convert.ToString(dr[3]);
                    sus[4] = Convert.ToString(dr[4]);
                }
                myConnection.Close();
                if (Convert.ToInt32(sus[0])>0)
                {
                    id = sus[1];
                    TypeAd.Person.stat = sus[4];
                    TypeAd.Person.name = sus[3];

                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch
            {
                myConnection.Close();
                return false;
            }
        }
    }
}
