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

namespace Авторассылка.Администратор
{
    /// <summary>
    /// Логика взаимодействия для InsertGroup.xaml
    /// </summary>
    public partial class InsertGroup : Page
    {
        string connstring = MainWindow.connstringmain1;
        public class std
        {
            public string ID { get; set; }
            public string Number { get; set; }
        }
        public List<std> stds = new List<std>();
        public List<string> stds1 = new List<string>();
        public InsertGroup()
        {
            InitializeComponent();
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
                    sus[2] = Convert.ToString(dr[2]);
                    sus[4] = Convert.ToString(dr[4]);

                    stds.Add(new std { ID = sus[0], Number = sus[2]+" " + sus[4] });
                    stds1.Add(sus[2] + " " + sus[4]);
                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"select * from student where id_student = {MainWindow.idstudent}";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[8];
                while (dr.Read())
                {
                    
                    Name.Text = Convert.ToString(dr[2]);
                    

                    stds.Add(new std { ID = sus[0], Number = sus[2] + " " + sus[4] });
                    stds1.Add(sus[2] + " " + sus[4]);
                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
            cb.ItemsSource = stds1;
        }
        public bool mainf()
        {
            string idgr = "";
            for (int i = 0; i < stds.Count; i++)
            {
                if (stds[i].Number == cb.Text)
                {
                    idgr = stds[i].ID;
                }
            }
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"insert into Student_group(id_student,id_Group) values({MainWindow.idstudent},{idgr})";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                myConnection.Close();
                

            }
            catch
            {
                myConnection.Close();
                MessageBox.Show("Студент небыл назначен!");
                return false;
            }
            try
            {


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"update student set [Code] = '{str.Text}' where id_student = {MainWindow.idstudent}";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                myConnection.Close();


            }
            catch
            {
                myConnection.Close();
                MessageBox.Show("Студент небыл назначен!");
                return false;
            }
            MessageBox.Show("Студент успешно назначен!");
            
            NavigationService.Navigate(new StudAdmin());
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainf();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
