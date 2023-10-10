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
using VkNet;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.Collections.ObjectModel;
using VkNet.Enums.Filters;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для Rassylka.xaml
    /// </summary>
    public partial class Rassylka : Page
    {
  
        string connstring = MainWindow.connstringmain;
        public Rassylka()
        {
            InitializeComponent();
            Log();
            cb.ItemsSource = lis;

        }
        public List<string> lis = new List<string>();
        public List<string> lis2 = new List<string>();
        public bool Log()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from texts_ras";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);
                    lis.Add(sus[1]);
                    sus[2] = (string)dr[2];
                    lis2.Add(sus[2]);
                }
                myConnection.Close();
                if (Convert.ToInt32(sus[0]) > 0)
                {

                    lab.Text = sus[2];
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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rass();
        }
        public bool rass()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"insert into texts_ras(date_inc,text_ras) values('" + DateTime.Now + "','" + lab.Text + "')";
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
        public static VkApi api = new VkApi();
        public static void SendMessage(string message, long? userID)
        {
            try
            {


                Random rnd = new Random();
                api.Messages.Send(new MessagesSendParams
                {
                    RandomId = rnd.Next(),
                    UserId = userID,
                    Message = message
                });
            }
            catch { }

        }
   
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //var ids = api.Groups.GetMembers(new GroupsGetMembersParams() { GroupId = "219286842", Fields = UsersFields.All });

            api.Authorize(new ApiAuthParams() { AccessToken = "vk1.a.avKxf8bQt3DTkaXM0fTiDP67RPdgClOIvdcDLuIGnXugVGtZOM9QTxjZ0qNsEy4kuGav2xyrPID0cnstXLcIo_YU_WnF8KTdEpYovH12qCbqm2UCe-BSa3KKTQuKu_sibix__p5HqLGlF8atUJOPXRQ76puUPMySl9Zi2IGkxcUe7OmTNw_CO34mZfNkbWIwJE-AGef4qw0ZJ5clShpxzQ" });
            //for (int i = 0; i < ids.Count; i++)
            //{
                SendMessage(Convert.ToString(lab.Text), 236051979);
            //}
           
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task.Run(()=> Console.WriteLine());
            tas();
        }
        public void tas()
        {
            for (int i = 0; i < lis2.Count; i++)
            {
                if (cb.Text == lis[i])
                {
                    lab.Text = lis2[i];
                }

            }
        }
    }
}
