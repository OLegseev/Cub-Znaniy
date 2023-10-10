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
using MaterialDesignColors;
using Syncfusion.Windows.Shared;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для PrepAdmin.xaml
    /// </summary>
    public partial class PrepAdmin : Page
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
        public List<std> stdsfos = new List<std>();
        public List<std> emptylist = new List<std>();
        public List<std> stdsdel = new List<std>();
        public PrepAdmin()
        {
            InitializeComponent();
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
                    stds.Add(new std { Fio = sus[0], Login = sus[1],Role= sus[2], ID = sus[3] });
                    stdsfos.Add(new std { Fio = sus[0], Login = sus[1], Role = sus[2], ID = sus[3] });
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
            NavigationService.Navigate(new AddPrepAdmin());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string idsf;
             MessageBoxResult result = MessageBox.Show($" Вы действительно хотите удалить этого пользователя?\n Внимание! \n Вы не сможете больше получить доступ к этому аккаунту!\n При удалении своего аккаунта получить доступ можно будет только у разработчика!", "Удаление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                stds.Clear();
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = connstring;
                SqlCommand sqlCmd = new SqlCommand();
                try
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $" delete from [employee] where [FIO] = '{stdsdel[0].Fio}' delete from Saved_acc where id_accaunt = {stdsdel[0].ID} delete from [accaunt] where [Login] = '{stdsdel[0].Login}'  select Fio,[Login],[Role_name],Accaunt.id_accaunt from [Employee] join Accaunt on Accaunt.id_accaunt = Employee.id_accaunt join [Role] on [Role].id_Role = Accaunt.id_Role";

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
                        stdsfos.Add(new std { Fio = sus[0], Login = sus[1], Role = sus[2], ID = sus[3] });
                    }
                    myConnection.Close();



                }
                catch
                {
                    myConnection.Close();
                }

                sst.ItemsSource = emptylist;
                sst.ItemsSource = stds;
            }
            else
            {
                
            }

        }



        private void sst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                stdsdel.Clear();

                std selectedit = (std)sst.SelectedItem;
                stdsdel.Add(new std { Fio = selectedit.Fio, Login = selectedit.Login, Role = selectedit.Role, ID = selectedit.ID });
            }
            catch { }
            

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            stdsfos.Clear();
            for (int i = 0; i < stds.Count; i++)
            {
                if (stds[i].Fio.Contains(Search.Text))
                {
                    stdsfos.Add(new std() { Fio = stds[i].Fio, Login = stds[i].Login, Role = stds[i].Role, ID = stds[i].ID });
                }
                else if (stds[i].Login.Contains(Search.Text))
                {
                    stdsfos.Add(new std() { Fio = stds[i].Fio, Login = stds[i].Login, Role = stds[i].Role, ID = stds[i].ID });
                }
                else if (stds[i].ID.Contains(Search.Text))
                {
                    stdsfos.Add(new std() { Fio = stds[i].Fio, Login = stds[i].Login, Role = stds[i].Role, ID = stds[i].ID  });
                }
            }
            sst.ItemsSource = null;
            sst.ItemsSource = stdsfos;
        }
    }
}
