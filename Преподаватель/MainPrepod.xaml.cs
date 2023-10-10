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

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для MainPrepod.xaml
    /// </summary>
    public partial class MainPrepod : Page
    {
        public MainPrepod()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new ParyPrep());
        }

        private void Button_Clic1k(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new GroupPrep());
        }

        private void Button_Clic2k(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new InfPrep());
        }
    }
}
