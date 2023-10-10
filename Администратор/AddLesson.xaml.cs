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
    /// Логика взаимодействия для AddLesson.xaml
    /// </summary>
    public partial class AddLesson : Page
    {
        string connstring = MainWindow.connstringmain1;
        public List<string> idstd = new List<string>();
        public List<string> lis = new List<string>();
        public List<string> lis1 = new List<string>();
        public List<string> lis2 = new List<string>();
        public AddLesson()
        {
            InitializeComponent();
            datet.Text = TypeAd.Person.lesdate;
            timet.Text = TypeAd.Person.lesdat;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"select Num_group,Name_group from [group] join Direction on [group].id_direction = Direction.id_direction";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    lis.Add(sus[0]);
                    sus[1] = Convert.ToString(dr[1]);

                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
            cb.ItemsSource = lis;
            SqlConnection myConnection1 = new SqlConnection();
            myConnection1.ConnectionString = connstring;
            SqlCommand sqlCmd1 = new SqlCommand();
            try
            {
                sqlCmd1.CommandType = CommandType.Text;
                sqlCmd1.CommandText = @"Select * from employee";
                sqlCmd1.Connection = myConnection1;
                myConnection1.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr1 = sqlCmd1.ExecuteReader();
                string[] sus = new string[5];
                while (dr1.Read())
                {
                    sus[1] = Convert.ToString(dr1[1]);
                    lis1.Add(sus[1]);

                }
                myConnection1.Close();



            }
            catch
            {
                myConnection1.Close();
            }
            cb1.ItemsSource = lis1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string idn = "0";
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from employee where fio = '" + cb1.Text + "'";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    idn = sus[0];

                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
            string idless = "";
            

            SqlConnection myConnection1 = new SqlConnection();
            myConnection1.ConnectionString = connstring;
            SqlCommand sqlCmd1 = new SqlCommand();
            try
            {
                

                sqlCmd1.CommandType = CommandType.Text;
                sqlCmd1.CommandText = $"insert into [Lesson] ([id_employee],[Lesson_date],[Lesson_time]) values({idn},'{datet.Text}','{timet.Text}') select * from Lesson where Lesson_date = '{datet.Text}' and [Lesson_time] = '{timet.Text}'";
                sqlCmd1.Connection = myConnection1;
                myConnection1.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr1 = sqlCmd1.ExecuteReader();

                string[] sus = new string[5];
                while (dr1.Read())
                {
                    sus[4] = Convert.ToString(dr1[4]);
                    idless = sus[4];

                }
                myConnection1.Close();
            }
            catch
            {
                myConnection1.Close();

            }
            string idgr = "";
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"select * from [group] where Num_group = '{cb.Text}'";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    idgr = sus[0];

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
                sqlCmd.CommandText = $"select Student.id_student from student join Student_group on Student.id_student = Student_group.id_student where Student_group.id_Group = {idgr}";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    idstd.Add(sus[0]);

                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }

            try
            {
                for (int i = 0; i < idstd.Count; i++)
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"insert into [Visit] ([Lesson_date],[Lesson_time],[id_lesson],[id_student]) values('{datet.Text}','{timet.Text}', {idless}, {idstd[i]})";
                    sqlCmd.Connection = myConnection;
                    myConnection.Open();
                    //sqlCmd.ExecuteNonQuery();
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    string[] sus = new string[5];
                    while (dr.Read())
                    {
                        sus[0] = Convert.ToString(dr[0]);
                        idstd.Add(sus[0]);

                    }
                    myConnection.Close();
                }


            }
            catch
            {
                myConnection.Close();
            }
            MessageBox.Show("Занятие успешно назначено!");
            NavigationService.Navigate(new ScheduleDetails());
        }
        private void cb_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
