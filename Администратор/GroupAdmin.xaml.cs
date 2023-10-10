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
    /// Логика взаимодействия для GroupAdmin.xaml
    /// </summary>
    public partial class GroupAdmin : Page
    {
        string connstring = MainWindow.connstringmain1;
        public class std
        {
            public string GroupNum { get; set; }
            public string GroupName { get; set; }
            public string Long { get; set; }
            public string LessonCount { get; set; }

        }
        public List<std> stds = new List<std>();
        public List<std> emptylist = new List<std>();
        public GroupAdmin()
        {
            InitializeComponent();
            if (TypeAd.Person.stat == "3")
            {
                sot.Visibility = Visibility.Hidden;
                bot.Visibility = Visibility.Hidden;
            }
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"select*from [group] join direction on [group].id_direction = Direction.id_direction";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[8];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);
                    sus[2] = Convert.ToString(dr[2]);
                    sus[3] = Convert.ToString(dr[3]);
                    sus[4] = Convert.ToString(dr[4]);
                    sus[5] = Convert.ToString(dr[5]);
                    sus[6] = Convert.ToString(dr[6]);
                    stds.Add(new std { GroupNum = sus[2], GroupName = sus[4], Long = sus[5], LessonCount = sus[6] });

                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
            sst.ItemsSource = stds;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGroupAdmin());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public bool mais()
        {
            std selectedit = (std)sst.SelectedItem;
            MessageBoxResult result = MessageBox.Show($" Вы действительно хотите удалить этоу группу?\n Внимание! \n Вы не сможете больше назначать занятия этой группе!\n", "Удаление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                stds.Clear();
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = connstring;
                SqlCommand sqlCmd = new SqlCommand();
                try
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $" delete from [group] where [Num_group] = '{selectedit.GroupNum}'";

                    sqlCmd.Connection = myConnection;
                    myConnection.Open();
                    //sqlCmd.ExecuteNonQuery();
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    string[] sus = new string[5];
                    while (dr.Read())
                    {
                    }
                    myConnection.Close();



                }
                catch
                {
                    myConnection.Close();
                    return false;
                }

                sst.ItemsSource = null;
                sst.ItemsSource = stds;
                return true;
            }
            else
            {
                return true;
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mais();
            sst.ItemsSource = stds;
            NavigationService.Navigate(new GroupAdmin());
        }

        private void sst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
