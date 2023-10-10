using System;
using System.Collections.Generic;
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
using VkNet;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.Net;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Application = System.Windows.Application;
using Image = System.Windows.Controls.Image;
using Авторассылка.Администратор;
using System.Data.SqlClient;
using System.Data;
using User = Авторассылка.Администратор.User;
//Install-Package VkNet -Version 1.42.0

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string idstudent;
        public static string connstringmainDog = @"Data Source=DESKTOP-0FEJ4PK;Initial Catalog=KZ;Integrated Security=True";
        public static string connstringmain = @"Data Source=DESKTOP-0FEJ4PK;Initial Catalog=BotKZ;Integrated Security=True";
        public static string connstringmain1 = @"Data Source=DESKTOP-0FEJ4PK;Initial Catalog=ClubOfKnowlage;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
            string derr = System.AppDomain.CurrentDomain.BaseDirectory;
            im.Source = new BitmapImage(new Uri(derr + "/logo-light dpo-1.png", UriKind.Absolute));
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = connstringmain1;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"select * from employee where [id_accaunt] = '{TypeAd.Person.name}'";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);
                    TypeAd.Person.fio = sus[1]; ;
                    fios.Text = sus[1];
                }
                myConnection.Close();




            }
            catch
            {
                myConnection.Close();
            }
            if (TypeAd.Person.stat == "2")
            {
                sot.Visibility = Visibility.Hidden;
                bot.Visibility = Visibility.Hidden;
            }
            if (TypeAd.Person.stat == "3")
            {
                sot.Visibility = Visibility.Hidden;
                bot.Visibility = Visibility.Hidden;
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
            this.Close();

        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new StudAdmin());
        }

       

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Schedule());
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new DzAdmin());
        }

 

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new GroupAdmin());
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new PrepAdmin());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Main());
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frm.NavigationService.Navigate(new User());
        }
    }
}
