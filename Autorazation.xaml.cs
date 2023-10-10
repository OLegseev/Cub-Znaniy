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
using System.Management;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для Autorazation.xaml
    /// </summary>
    public partial class Autorazation : Window
    {
        string connstring = MainWindow.connstringmain1;
        public Autorazation()
        {
            InitializeComponent();
            string derr = System.AppDomain.CurrentDomain.BaseDirectory;
            im.Source = new BitmapImage(new Uri(derr + "/logo-light dpo-1.png", UriKind.Absolute));
            SavedA();

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
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
                    CheckBd.Check check = new CheckBd.Check();
                    check.Fulling();
                    MainWindow window = new MainWindow();

                    // Закрытие текущего окна
                    

                    // Открытие нового окна
                    window.Show();
                    this.Close();

                }
            }

        }
        public bool SavedA()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            SqlConnection myConnection1 = new SqlConnection();
            myConnection1.ConnectionString = connstring;
            SqlCommand sqlCmd1 = new SqlCommand();
            var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
            var result = searcher.Get();
            string disk = "";
            foreach (var drive in result)
            {
                var serialNumber = drive.GetPropertyValue("SerialNumber").ToString();
                disk = Convert.ToString(serialNumber);
                break;
            }
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from Saved_acc";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);
                    sus[2] = Convert.ToString(dr[2]);
                    if (sus[1] == disk)
                    {
                        sqlCmd1.CommandType = CommandType.Text;
                        sqlCmd1.CommandText = $"select * from accaunt where [id_accaunt] = '{sus[2]}'";
                        sqlCmd1.Connection = myConnection1;
                        myConnection1.Open();
                        //sqlCmd.ExecuteNonQuery();
                        SqlDataReader dr1 = sqlCmd1.ExecuteReader();
                        string[] sus1 = new string[3];
                        while (dr1.Read())
                        {
                            TypeAd.Person.name = sus[2];
                            log.Text = Convert.ToString(dr1[1]);
                            pas.Password = Convert.ToString(dr1[2]);
                            cb.IsChecked = true;
                            
                        }
                        myConnection1.Close();

                        myConnection.Close();
                        return true;
                        
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch
            {
                myConnection.Close();
                return false;
            }



            return false;

        }
        public bool Putting()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
                var result = searcher.Get();
                string disk = "";
                foreach (var drive in result)
                {
                    var serialNumber = drive.GetPropertyValue("SerialNumber").ToString();
                    disk = Convert.ToString(serialNumber);
                    break;
                }
                
                sqlCmd.CommandType = CommandType.Text;


                sqlCmd.CommandText = $"insert into Saved_acc([id_pc],[id_accaunt]) values('{disk}','" + id + "')";
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
                sqlCmd.CommandText = $"select * from accaunt where [Login] = '{log.Text}'and [Password] = '{pas.Password}'";
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
                    TypeAd.Person.name=sus[0];  
                    TypeAd.Person.Login = sus[1];
                    TypeAd.Person.Pas = sus[2];
                    TypeAd.Person.stat = sus[3];
                }
                myConnection.Close();
                if (Convert.ToInt32(sus[0]) > 0)
                {
                    id = sus[0];

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
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();

            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
