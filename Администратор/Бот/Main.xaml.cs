using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
       
        public Main()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new New_group());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Rassylka());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Spisok());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new AqvtootvShablon());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(bt1.Content) == "Запустить ботов")
            {
                bt1.Content = "Остановить ботов";
            }
            else
            {
                bt1.Content = "Запустить ботов";
            }
            frm.NavigationService.Navigate(new Bots());
       
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Trackxaml());
        }

        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Block());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainAdmin());
        }
    }
}
