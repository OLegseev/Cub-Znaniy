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
using VkNet.Model;
using VkNet.Model.Attachments;
using Page = System.Windows.Controls.Page;
using Авторассылка.Администратор;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для AddStudenAdmin.xaml
    /// </summary>
    public partial class AddStudenAdmin : Page
    {
        string connstring = MainWindow.connstringmain1;
        
        string idstudent = MainWindow.idstudent;
        public class std
        {
            public string Datep { get; set; }
            public string Timepar { get; set; }
            public string Dz { get; set; }
            public string Markotm { get; set; }
            public string Pos { get; set; }
            public string Markotmhz { get; set; }
        }
        public List<std> stds = new List<std>();

        public string Id;
        public string Fio_stud;
        public string Birth;
        public string Phone;
        public string Mail;
        public string Gender;
        public string Code;
        public string FioPar;
        public string FioPhon;
        public string ParGen;
        public string ParMail;

        public string IdGroup;
        public string Namegr;
        public string Leslong;
        public string LesCount;
        public string treaty;

        public string SrBal;
        public string Posesh;
        public int cos = 0;

        public AddStudenAdmin()
        {
            InitializeComponent();

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();


            SqlConnection myConnection1 = new SqlConnection();
            myConnection1.ConnectionString = connstring;
            SqlCommand sqlCmd1 = new SqlCommand();
            try
            {

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"SELECT Student.id_student, Fio,Student.Birthday,Student.Phone,Student.Mail,Student.[id_gender],Code,Parents.Fio_parents,Parents.Parents_phone,Parents.id_gender,Parents.Mail FROM Student join Parents on Student.id_parents=Parents.id_parents  where Student.id_student = " + idstudent;
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                

                while (dr.Read())
                {
                    Id = Convert.ToString(dr[0]);
                    Fio_stud = Convert.ToString(dr[1]);
                    Birth = Convert.ToString(dr[2]);
                    Phone = Convert.ToString(dr[3]);
                    Mail = Convert.ToString(dr[4]);
                    Gender = Convert.ToString(dr[5]);
                    Code = Convert.ToString(dr[6]);
                    FioPar = Convert.ToString(dr[7]);
                    FioPhon = Convert.ToString(dr[8]);
                    ParGen = Convert.ToString(dr[9]);
                    ParMail = Convert.ToString(dr[10]);
                }
            }
            catch
            {
                myConnection.Close();
            }
            myConnection.Close();
            idStud.Text = ""+ Id;
            fioStuf.Text = "" + Fio_stud;
            Dateb.Text = "Дата рождения: " + Birth;
            phoned.Text = "Телефон ребенка: " + Phone;
            maild.Text = "Почта ребенка: " + Mail;
            if (Gender=="1")
            {
                polst.Text = "Пол: Муж.";
            }
            else
            {
                polst.Text = "Пол: Жен.";
            }
            botcod.Text = "Код доступа к боту: " + Code;

            parName.Text = "Фио Родителя: " + FioPar;
            parPhon.Text = "Телефон родителя: " + FioPhon;
            if (ParGen == "1")
            {
                PolRod.Text = "Пол родителя: Муж.";
            }
            else
            {
                PolRod.Text = "Пол родителя:: Жен.";
            }
            MailRod.Text = "Почта родителя: " + ParMail;






            try
            {

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"SELECT [Group].Num_group,Direction.[Name_group],Direction.[Lessons_long],Direction.[Lessons_count],Treaty.id_treaty FROM Student join Student_group on Student.id_student = Student_group.id_student join [Group] on [Group].id_Group=Student_group.id_Group join Treaty on Treaty.id_treaty = Student.id_treaty join Direction on [group].id_direction = Direction.id_direction where Student.id_student = " + idstudent;
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();


                while (dr.Read())
                {

                    IdGroup = Convert.ToString(dr[0]);
                    Namegr = Convert.ToString(dr[1]);
                    Leslong = Convert.ToString(dr[2]);
                    LesCount = Convert.ToString(dr[3]);
                    treaty = Convert.ToString(dr[4]);
                }
                myConnection.Close();
            }
            catch
            {
                myConnection.Close();
            }

            groupn.Text +=""+ IdGroup;
            secname.Text += "Направление: " + Namegr;
            longes.Text += "Длительность: " + Leslong;
            countes.Text += "Количество: " + LesCount;
            dogn.Text += "Договор: " + treaty;

            int smark = 0;
            int pos = 0;
            
            try
            {

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"select COUNT(*) from Visit where id_student = " + idstudent;
                sqlCmd.Connection = myConnection;
                myConnection.Open();

                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[6];

                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);

                }
                cos = Convert.ToInt32(sus[0]);
                myConnection.Close();
            }
            catch
            {
                myConnection.Close();
            }
          
            try
            {

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"select [Visit_stud],[Mark] from Visit where id_student = " + idstudent;
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    string[] sus = new string[6];
                    while (dr.Read())
                    {
                        sus[0] = Convert.ToString(dr[0]);
                        if (sus[0] == "Да")
                        {
                            pos += 1;
                        }
                        sus[1] = Convert.ToString(dr[1]);
                        smark += Convert.ToInt32(sus[1]);
                    }
                    smark = Convert.ToInt32(sus[1])/cos;
                    pos = (cos / pos) * 100;

                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
            srbal.Text = smark.ToString();
            srpoas.Text = pos.ToString();
            
            string[] sus1 = new string[8];
            try
            {

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"select * from Visit where id_student =" + idstudent;
                sqlCmd.Connection = myConnection;
                
                myConnection.Open();

                SqlDataReader dr = sqlCmd.ExecuteReader();
               

                while (dr.Read())
                {
                    sus1[0] = Convert.ToString(dr[0]);
                    sus1[1] = Convert.ToString(dr[1]);
                    sus1[2] = Convert.ToString(dr[2]);
                    sus1[3] = Convert.ToString(dr[3]);
                    sus1[4] = Convert.ToString(dr[4]);
                    sus1[5] = Convert.ToString(dr[5]);
                    sus1[6] = Convert.ToString(dr[6]);

                    try
                    {

                        sqlCmd1.CommandType = CommandType.Text;
                        sqlCmd1.CommandText = @"select Homework.Homework_text from Lesson join Homework on Homework.Id_homework = Lesson.Id_homework where id_lesson = " + sus1[2];
                        sqlCmd1.Connection = myConnection1;
                        myConnection1.Open();

                        SqlDataReader dr1 = sqlCmd1.ExecuteReader();
                        string[] sus = new string[6];

                        while (dr1.Read())
                        {
                            sus[0] = Convert.ToString(dr1[0]);
                        }

                        myConnection1.Close();
                        if (sus1[4]=="Нет")
                        {

                        }
                        else
                        {
                            stds.Add(new std() { Datep = Convert.ToString(sus1[0]), Timepar = Convert.ToString(sus1[1]), Dz = Convert.ToString(sus[0]), Markotm = Convert.ToString(sus1[5]), Pos = Convert.ToString(sus1[4]), Markotmhz = Convert.ToString(sus1[6]) });

                        }

                    }
                    catch
                    {
                        myConnection1.Close();
                    }
                }
                
                myConnection.Close();
            }
            catch
            {
                myConnection.Close();
            }
            





















            st.ItemsSource = stds;
        }

        private void groupn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new InsertGroup());
        }
    }
}
