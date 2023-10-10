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
using System.Runtime.InteropServices;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для Avtoot.xaml
    /// </summary>
    public partial class Avtoot : Page
    {
        string connstring = MainWindow.connstringmain;
        public Avtoot()
        {
            InitializeComponent();
            Groupp();
            cb_Copy.ItemsSource = gr;
          
        }
        public List<string> lis = new List<string>();
        public List<string> lis2 = new List<string>();
        public List<string> l = new List<string>();
        public List<string> gr = new List<string>();


        public bool Groupp()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from groupp";
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
                    sus[4] = Convert.ToString(dr[4]);
                    gr.Add(sus[4]);
                    l.Add(sus[2]);
                }
                myConnection.Close();
                if (Convert.ToInt32(sus[0]) > 0)
                {

                   
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


      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rass();
            MessageBox.Show("Успешно добавлено");
        }
        public bool rass()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                int y = 0;
                string typer = "";
                foreach (var item in gr)
                {

                    if (cb_Copy.Text == gr[y])
                    {
                        typer = l[y];
                    }
                    y++;
                }

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"insert into texts_avt(date_inc,text_avt,tipe,groupName,stat,socset) values('" + DateTime.Now + "','" + lab1.Text + "','" + typer + "','" + cb_Copy.Text + "','Остановить','" + lab.Text + "')";
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

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
