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
using Microsoft.Office.Interop.Excel;
using Page = System.Windows.Controls.Page;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для AddDz.xaml
    /// </summary>
    public partial class AddDz : Page
    {
        string connstring = MainWindow.connstringmain1;
        public AddDz()
        {
            InitializeComponent();

            var dtas = TypeAd.visiter.Where(x => x.lesson_date == TypeAd.Person.lesdate+" 0:00:00" && x.lesson_time == TypeAd.Person.lesdat).ToList();
            tb.Text = dtas[0].lesson_date + " " + dtas[0].lesson_time + "\n" + dtas[0].num_group + " " + dtas[0].Name_group + "\n" + dtas[0].fio_employee;

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"select * from homework where id_employee = {dtas[0].id_employee} ";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[1] = Convert.ToString(dr[1]);
                    lab.Text = sus[1];
                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }





        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dtas = TypeAd.visiter.Where(x => x.lesson_date == TypeAd.Person.lesdate + " 0:00:00" && x.lesson_time == TypeAd.Person.lesdat).ToList();

            if (TypeAd.Person.stat != "3"||dtas[0].fio_employee== TypeAd.Person.fio)
            {
                updater(TypeAd.Person.dzid);
            }
            else
            {
                MessageBox.Show("Вы не можете выдать домашнее задание на чужое занятие");
            }
            
        }
        public void updater(string id)
        {
            string hr = "";
            var dtas = TypeAd.visiter.Where(x => x.lesson_date == TypeAd.Person.lesdate + " 0:00:00" && x.lesson_time == TypeAd.Person.lesdat).ToList();
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"insert into [Homework] ([id_employee],[Homework_text]) values({dtas[0].id_employee},'{lab.Text}') select * from homework";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[2] = Convert.ToString(dr[2]);
                    hr = sus[2];
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
                sqlCmd.CommandText = $"update lesson set Id_homework = {hr} where Lesson_date ='{dtas[0].lesson_date}' and Lesson_time ='{dtas[0].lesson_time}'  ";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[5];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[2] = Convert.ToString(dr[2]);
                    hr = sus[2];
                }
                myConnection.Close();


            }
            catch
            {
                myConnection.Close();

            }
            MessageBox.Show("Домашне задание успешно выдано!");
            NavigationService.GoBack();
        }
    }
}
