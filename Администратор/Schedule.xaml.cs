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

    public partial class date
    {
        public string date_name { get; set; }
        public string date_value { get; set; }
        public string zan1 { get; set; }
        public string zan2 { get; set; }
        public string zan3 { get; set; }
        public string zan4 { get; set; }
        public string zan5 { get; set; }
        public string zan6 { get; set; }
        public string zan7 { get; set; }
        public string zan8 { get; set; }
        public string zan9 { get; set; }

    }
    public partial class lesson
    {
        public string date { get; set; }
        public string time { get; set; }


    }
   
    public partial class Schedule : Page
    {
        public string connstring = MainWindow.connstringmain1;
        public Schedule()
        {
            InitializeComponent();
            List<date> dates = new List<date>();
            List<lesson> les = new List<lesson>();
            DateTime start_day = DateTime.Now.Date.AddDays(-(DateTime.Now.Date.DayOfWeek == 0 ? 7 : (int)DateTime.Now.Date.DayOfWeek) + 1);
            dates.Add(new date { });
            dates[0].zan1 = "09:00 - 10:00";
            dates[0].zan2 = "10:00 - 11:00";
            dates[0].zan3 = "11:00 - 12:00";
            dates[0].zan4 = "12:00 - 13:00";
            dates[0].zan5 = "13:00 - 14:00";
            dates[0].zan6 = "14:00 - 15:00";
            dates[0].zan7 = "15:00 - 16:00";
            dates[0].zan8 = "16:00 - 17:00";
            dates[0].zan9 = "17:00 - 18:00";
            dates.Add(new date { date_name = "Понедельник", date_value = start_day.ToShortDateString() });
            dates.Add(new date { date_name = "Вторник", date_value = start_day.AddDays(1).ToShortDateString() });
            dates.Add(new date { date_name = "Среда", date_value = start_day.AddDays(2).ToShortDateString() });
            dates.Add(new date { date_name = "Четверг", date_value = start_day.AddDays(3).ToShortDateString() });
            dates.Add(new date { date_name = "Пятница", date_value = start_day.AddDays(4).ToShortDateString() });
            dates.Add(new date { date_name = "Суббота", date_value = start_day.AddDays(5).ToShortDateString() });
            //dates.Add(new date { date_name = "Воскресенье", date_value = start_day.AddDays(6).ToShortDateString() });

            TypeAd.visiter.Clear();
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"select employee.id_employee,lesson.Lesson_date,lesson.Lesson_time,Lesson.Id_homework,Visit.id_student, Num_group,Name_group,employee.Fio from lesson join visit on lesson.id_lesson = visit.id_lesson join student on visit.id_student=Student.id_student join Student_group on Student_group.id_student=Student.id_student join [group] on [group].id_Group = Student_group.id_Group join Direction on [group].id_direction = Direction.id_direction join employee on employee.id_employee = lesson.id_employee ";
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
                    sus[7] = Convert.ToString(dr[7]);
                    
                    TypeAd.visiter.Add(new TypeAd.visited { id_employee = sus[0], lesson_date = sus[1], lesson_time = sus[2], id_homework = sus[3], id_student = sus[4], num_group = sus[5], Name_group = sus[6], fio_employee = sus[7] });
                }
                myConnection.Close();
            }
            catch
            {
                myConnection.Close();
            }

            for (int h = 0; h < TypeAd.visiter.Count; h++)
            {
                for (int i = 0; i < 7; i++)
                {

                    if (TypeAd.visiter[h].lesson_date == dates[i].date_value + " 0:00:00")
                    {
                        string[] mas = dates[0].zan1.Split(' ');
                        mas[0] += ":00";
                        if (mas[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan1 = TypeAd.visiter[h].num_group +"\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }
                        string[] mas1 = dates[0].zan2.Split(' ');
                        mas1[0] += ":00";
                        if (mas1[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan2 = TypeAd.visiter[h].num_group + "\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }
                        string[] mas2 = dates[0].zan3.Split(' ');
                        mas2[0] += ":00";
                        if (mas2[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan3 = TypeAd.visiter[h].num_group + "\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }
                        string[] mas3 = dates[0].zan4.Split(' ');
                        mas3[0] += ":00";
                        if (mas3[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan4 = TypeAd.visiter[h].num_group + "\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }
                        string[] mas4 = dates[0].zan5.Split(' ');
                        mas4[0] += ":00";
                        if (mas4[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan5 = TypeAd.visiter[h].num_group + "\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }
                        string[] mas5 = dates[0].zan6.Split(' ');
                        mas5[0] += ":00";
                        if (mas5[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan6 = TypeAd.visiter[h].num_group + "\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }
                        string[] mas6 = dates[0].zan7.Split(' ');
                        mas6[0] += ":00";
                        if (mas6[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan7 = TypeAd.visiter[h].num_group + "\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }
                        string[] mas7 = dates[0].zan8.Split(' ');
                        mas7[0] += ":00";
                        if (mas7[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan8 = TypeAd.visiter[h].num_group + "\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }
                        string[] mas8 = dates[0].zan9.Split(' ');
                        mas8[0] += ":00";
                        if (mas8[0] == TypeAd.visiter[h].lesson_time)
                        {
                            dates[i].zan9 = TypeAd.visiter[h].num_group + "\n" + TypeAd.visiter[h].Name_group + "\n" + TypeAd.visiter[h].fio_employee;
                            break;
                        }



                    }

                }
            }



            Rasp.ItemsSource = dates.ToList();

        }
        private void Rasp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Rasp.SelectedIndex < 1)
            {
                return;
            }
            NavigationService.Navigate(new ScheduleDetails((Rasp.SelectedItem as date)));
        }
    }
}
