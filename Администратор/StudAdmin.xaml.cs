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
using System.ComponentModel.Design;
using System.Data.Common;
using VkNet.Model;
using System.Collections.ObjectModel;
using System.Collections;
using VkNet.Model.Attachments;
using Page = System.Windows.Controls.Page;
using System.Reflection.Emit;
using Label = System.Windows.Controls.Label;
using Авторассылка.Администратор;
using Microsoft.Office.Interop.Excel;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для StudAdmin.xaml
    /// </summary>
    public partial class StudAdmin : Page
    {
        string connstring = MainWindow.connstringmain1;
        public List<string> lis = new List<string>();
        

        
        public class std
        {
            public string Id { get; set; }
            public  string Fio_stud { get; set; }
            public  string Birth { get; set; }
            public  string Sr_mark { get; set; }
            public  string Posesh { get; set; }
            public  string Groupp_incl { get; set; }
            public string Phone { get; set; }
            public string Parents_phone { get; set; }
            public string Morf { get; set; }
            public string Colors { get; set; }

        }
        public List<std> stds = new List<std>();
        public List<std> stdssearch = new List<std>();
        public StudAdmin()
        {
            InitializeComponent();

            SqlConnection myConnection = new SqlConnection();
            SqlConnection myConnection1 = new SqlConnection();
            SqlConnection myConnection2 = new SqlConnection();
            myConnection.ConnectionString = connstring; 
            myConnection1.ConnectionString = connstring;
            myConnection2.ConnectionString = connstring;
            SqlConnection myConnection3 = new SqlConnection();
            myConnection3.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            SqlCommand sqlCmd1 = new SqlCommand();
            SqlCommand sqlCmd2 = new SqlCommand();
            SqlCommand sqlCmd3 = new SqlCommand();
            try
            {
                if (TypeAd.Person.stat != "3")
                {


                    sqlCmd3.CommandType = CommandType.Text;
                    sqlCmd3.CommandText = @"Select * from studwithout";
                    sqlCmd3.Connection = myConnection3;
                    myConnection3.Open();

                    SqlDataReader dr3 = sqlCmd3.ExecuteReader();
                    string[] sus3 = new string[6];

                    while (dr3.Read())
                    {
                        sus3[0] = Convert.ToString(dr3[0]);
                        sus3[1] = Convert.ToString(dr3[1]);
                        sus3[2] = Convert.ToString(dr3[2]);
                        sus3[3] = Convert.ToString(dr3[3]);


                        stds.Add(new std() { Fio_stud = sus3[1], Groupp_incl = "Группа: НЕТ ", Birth = "День рождения: " + sus3[2], Phone = "Телефона: " + sus3[3], Id = sus3[0], Colors = "#FFFFCCCC", Morf = ":(", Sr_mark = "0", Posesh = "0" });

                    }

                    myConnection.Close();
                }
            }
            catch
            {

            }
            try
            {
                









                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select fio,Num_group, Birthday,Phone,Parents_phone,id_student from students join [group] on students.id_group = [group].id_group";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[7];
                
                    while (dr.Read())
                    {
                        sus[0] = Convert.ToString(dr[0]);
                        sus[1] = Convert.ToString(dr[1]);
                        sus[2] = Convert.ToString(dr[2]);
                        sus[3] = Convert.ToString(dr[3]);
                        sus[4] = Convert.ToString(dr[4]);
                        sus[5] = Convert.ToString(dr[5]);


                     sqlCmd2.CommandType = CommandType.Text;
                    sqlCmd2.CommandText = @"select COUNT(*) from Visit where id_student = " + sus[5];
                    sqlCmd2.Connection = myConnection2;
                    myConnection2.Open();

                    SqlDataReader dr2 = sqlCmd2.ExecuteReader();
                    string[] sus2 = new string[6];

                    while (dr2.Read())
                    {
                        sus2[0] = Convert.ToString(dr2[0]);

                    }
                    myConnection2.Close();
                    int smark = 0;
                    int pos = 0;
                    sqlCmd1.CommandType = CommandType.Text;
                    sqlCmd1.CommandText = @"select [Visit_stud],[Mark] from Visit where id_student = " + sus[5];
                    sqlCmd1.Connection = myConnection1;
                    myConnection1.Open();

                    SqlDataReader dr1 = sqlCmd1.ExecuteReader();
                    string[] sus1 = new string[6];
                    string morff = ":)";
                    while (dr1.Read())
                    {
                        try
                        {
                            sus1[0] = Convert.ToString(dr1[0]);
                            if (sus1[0] == "Да")
                            {
                                pos += 1;
                            }
                            sus1[1] = Convert.ToString(dr1[1]);
                            smark += Convert.ToInt32(sus1[1]);
                        }
                        catch
                        {

                        }
                    }
                    try
                    {
                        smark /= Convert.ToInt32(sus2[0]);
                    }
                    catch
                    {
                        smark = 0;
                    }
                    
                    try
                    {
                        pos = (Convert.ToInt32(sus2[0]) / pos) * 100;
                    }
                    catch (Exception)
                    {
                        pos = 0;
                        
                    }
                    if (smark<8||pos < 70)
                    {
                        morff = ":(";
                    }
                    myConnection1.Close();






                    stds.Add(new std() { Fio_stud = sus[0], Groupp_incl = "Группа: "+sus[1], Birth = "День рождения: " + sus[2], Phone = "Телефона: " + sus[3], Parents_phone = "Телефон родителя: " + sus[4],Sr_mark= Convert.ToString(smark), Posesh = Convert.ToString(pos),Morf = morff,Id = sus[5],Colors = "#FFFBFBFB" });
                    
                    }
               


            }
            catch
            {
                myConnection.Close();
            }
            st.ItemsSource = stds;
        }
       



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudenAdmin());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            st.ItemsSource = stds;
            Search.Text = "";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void Frame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Label clickedGrid = (Label)sender;//лейбл поверх окон, получаю к нему доступ через sender
            Grid parent = clickedGrid.Parent as Grid;

            var textBox = parent.Children.OfType<TextBlock>().ToList();
            string idds = textBox[11].Text;
            for (int i = 0; i < stds.Count; i++)
            {
                try
                {
                    if (Convert.ToString(stds[i].Id) == idds)
                    {
                        if (stds[i].Colors == "#FFFFCCCC")
                        {
                            MainWindow.idstudent = idds;
                            NavigationService.Navigate(new InsertGroup());
                        }
                        else
                        {
                            MainWindow.idstudent = idds;
                            NavigationService.Navigate(new AddStudenAdmin());
                        }
                    }
                }
                catch { }

            }
















            
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            stdssearch.Clear();
            for (int i = 0; i < stds.Count; i++)
            {
                if (stds[i].Groupp_incl.Contains(Search.Text))
                {
                    stdssearch.Add(new std() { Fio_stud = stds[i].Fio_stud, Groupp_incl = stds[i].Groupp_incl, Birth = stds[i].Birth, Phone = stds[i].Phone, Parents_phone = stds[i].Parents_phone, Sr_mark = stds[i].Sr_mark, Posesh = stds[i].Posesh, Morf = stds[i].Morf, Id = stds[i].Id, Colors = stds[i].Colors });
                }
                else if (stds[i].Fio_stud.Contains(Search.Text))
                {
                    stdssearch.Add(new std() { Fio_stud = stds[i].Fio_stud, Groupp_incl = stds[i].Groupp_incl, Birth = stds[i].Birth, Phone = stds[i].Phone, Parents_phone = stds[i].Parents_phone, Sr_mark = stds[i].Sr_mark, Posesh = stds[i].Posesh, Morf = stds[i].Morf, Id = stds[i].Id, Colors = stds[i].Colors });
                }
                else if (stds[i].Morf.Contains(Search.Text))
                {
                    stdssearch.Add(new std() { Fio_stud = stds[i].Fio_stud, Groupp_incl = stds[i].Groupp_incl, Birth = stds[i].Birth, Phone = stds[i].Phone, Parents_phone = stds[i].Parents_phone, Sr_mark = stds[i].Sr_mark, Posesh = stds[i].Posesh, Morf = stds[i].Morf, Id = stds[i].Id, Colors = stds[i].Colors });
                }
            }
            st.ItemsSource = null;
            st.ItemsSource = stdssearch;
        }
    }
}
