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
    /// Логика взаимодействия для ParyAdmin.xaml
    /// </summary>
    public partial class ParyAdmin : Page
    {
        string connstring = MainWindow.connstringmain;
        public List<string> lis = new List<string>();
        public List<string> lis1 = new List<string>();
        public List<string> pn = new List<string>();
        public List<string> vt = new List<string>();
        public List<string> sr = new List<string>();
        public List<string> ch = new List<string>();
        public List<string> pt = new List<string>();
        public List<string> sb = new List<string>();
        
        public ParyAdmin()
        {
            InitializeComponent();
            DateTime date = DateTime.Now;
            int dayofweek = (int)date.DayOfWeek;
            if (dayofweek==1)
            {
                pnt.Text = Convert.ToString(DateTime.Today.ToString("dd/MM/yyyy"));
                vtt.Text = Convert.ToString(DateTime.Today.AddDays(1).ToString("dd/MM/yyyy"));
                srt.Text = Convert.ToString(DateTime.Today.AddDays(2).ToString("dd/MM/yyyy"));
                cht.Text = Convert.ToString(DateTime.Today.AddDays(3).ToString("dd/MM/yyyy"));
                ptt.Text = Convert.ToString(DateTime.Today.AddDays(4).ToString("dd/MM/yyyy"));
                sbt.Text = Convert.ToString(DateTime.Today.AddDays(5).ToString("dd/MM/yyyy"));


            }
            else if (dayofweek==2)
            {
                pnt.Text = Convert.ToString(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                vtt.Text = Convert.ToString(DateTime.Today.ToString("dd/MM/yyyy"));
                srt.Text = Convert.ToString(DateTime.Today.AddDays(1).ToString("dd/MM/yyyy"));
                cht.Text = Convert.ToString(DateTime.Today.AddDays(2).ToString("dd/MM/yyyy"));
                ptt.Text = Convert.ToString(DateTime.Today.AddDays(3).ToString("dd/MM/yyyy"));
                sbt.Text = Convert.ToString(DateTime.Today.AddDays(4).ToString("dd/MM/yyyy"));
            }
            else if (dayofweek == 3)
            {
                pnt.Text = Convert.ToString(DateTime.Today.AddDays(-2).ToString("dd/MM/yyyy"));
                vtt.Text = Convert.ToString(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                srt.Text = Convert.ToString(DateTime.Today.ToString("dd/MM/yyyy"));
                cht.Text = Convert.ToString(DateTime.Today.AddDays(1).ToString("dd/MM/yyyy"));
                ptt.Text = Convert.ToString(DateTime.Today.AddDays(2).ToString("dd/MM/yyyy"));
                sbt.Text = Convert.ToString(DateTime.Today.AddDays(3).ToString("dd/MM/yyyy"));
            }
            else if (dayofweek == 4)
            {
                pnt.Text = Convert.ToString(DateTime.Today.AddDays(-3).ToString("dd/MM/yyyy"));
                vtt.Text = Convert.ToString(DateTime.Today.AddDays(-2).ToString("dd/MM/yyyy"));
                srt.Text = Convert.ToString(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                cht.Text = Convert.ToString(DateTime.Today.ToString("dd/MM/yyyy"));
                ptt.Text = Convert.ToString(DateTime.Today.AddDays(1).ToString("dd/MM/yyyy"));
                sbt.Text = Convert.ToString(DateTime.Today.AddDays(2).ToString("dd/MM/yyyy"));
            }
            else if (dayofweek == 5)
            {
                pnt.Text = Convert.ToString(DateTime.Today.AddDays(-4).ToString("dd/MM/yyyy"));
                vtt.Text = Convert.ToString(DateTime.Today.AddDays(-3).ToString("dd/MM/yyyy"));
                srt.Text = Convert.ToString(DateTime.Today.AddDays(-2).ToString("dd/MM/yyyy"));
                cht.Text = Convert.ToString(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                ptt.Text = Convert.ToString(DateTime.Today.ToString("dd/MM/yyyy"));
                sbt.Text = Convert.ToString(DateTime.Today.AddDays(1).ToString("dd/MM/yyyy"));
            }
            else if (dayofweek == 6)
            {
                pnt.Text = Convert.ToString(DateTime.Today.AddDays(-5).ToString("dd/MM/yyyy"));
                vtt.Text = Convert.ToString(DateTime.Today.AddDays(-4).ToString("dd/MM/yyyy"));
                srt.Text = Convert.ToString(DateTime.Today.AddDays(-3).ToString("dd/MM/yyyy"));
                cht.Text = Convert.ToString(DateTime.Today.AddDays(-2).ToString("dd/MM/yyyy"));
                ptt.Text = Convert.ToString(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));
                sbt.Text = Convert.ToString(DateTime.Today.ToString("dd/MM/yyyy"));
            }
            else if (dayofweek == 7)
            {
                pnt.Text = Convert.ToString(DateTime.Today.AddDays(-6).ToString("dd/MM/yyyy"));
                vtt.Text = Convert.ToString(DateTime.Today.AddDays(-5).ToString("dd/MM/yyyy"));
                srt.Text = Convert.ToString(DateTime.Today.AddDays(-4).ToString("dd/MM/yyyy"));
                cht.Text = Convert.ToString(DateTime.Today.AddDays(-3).ToString("dd/MM/yyyy"));
                ptt.Text = Convert.ToString(DateTime.Today.AddDays(-2).ToString("dd/MM/yyyy"));
                sbt.Text = Convert.ToString(DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy"));

            }




            cdloader();





          
        }
        public  void cdloader()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from lesson";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[7];
                DateTime[] susu = new DateTime[4];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    sus[2] = Convert.ToString(dr[2]);
                    sus[4] = Convert.ToString(dr[4]);
                    susu[3] = Convert.ToDateTime(dr[3]);
                    
                    if (pnt.Text == Convert.ToString(susu[3].ToString("dd/MM/yyyy")))
                    {
                        pn.Add(sus[2] + " " + sus[4]);
                        lis.Add(sus[2] + " " + sus[4]);
                        lis1.Add(sus[0]);
                    }
                    else if(vtt.Text == Convert.ToString(susu[3].ToString("dd/MM/yyyy")))
                    {
                        vt.Add(sus[2] + " " + sus[4]);
                        lis.Add(sus[2] + " " + sus[4]); lis1.Add(sus[0]);
                    }
                    else if (srt.Text == Convert.ToString(susu[3].ToString("dd/MM/yyyy")))
                    {
                        sr.Add(sus[2] + " " + sus[4]); lis.Add(sus[2] + " " + sus[4]); lis1.Add(sus[0]);
                    }
                    else if (cht.Text == Convert.ToString(susu[3].ToString("dd/MM/yyyy")))
                    {
                        ch.Add(sus[2] + " " + sus[4]); lis.Add(sus[2] + " " + sus[4]); lis1.Add(sus[0]);
                    }
                    else if (ptt.Text == Convert.ToString(susu[3].ToString("dd/MM/yyyy")))
                    {
                        pt.Add(sus[2] + " " + sus[4]); lis.Add(sus[2] + " " + sus[4]); lis1.Add(sus[0]);
                    }
                    else if (sbt.Text == Convert.ToString(susu[3].ToString("dd/MM/yyyy")))
                    {
                        sb.Add(sus[2] + " " + sus[4]); lis.Add(sus[2] + " " + sus[4]); lis1.Add(sus[0]);
                    }
                   
                }
                myConnection.Close();



            }
            catch
            {
                myConnection.Close();
            }
            pnc.ItemsSource = pn;
                vtc.ItemsSource = vt;
            src.ItemsSource = sr;
            chc.ItemsSource = ch;
            ptc.ItemsSource = pt;
            sbc.ItemsSource = sb;











           
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            TypeAd.Person.datapary = pnt.Text;
            NavigationService.Navigate(new AddLessonAdmin());
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            TypeAd.Person.datapary = vtt.Text;
            NavigationService.Navigate(new AddLessonAdmin());
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            TypeAd.Person.datapary = srt.Text;
            NavigationService.Navigate(new AddLessonAdmin());
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            TypeAd.Person.datapary = cht.Text;
            NavigationService.Navigate(new AddLessonAdmin());
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            TypeAd.Person.datapary = ptt.Text;
            NavigationService.Navigate(new AddLessonAdmin());
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            TypeAd.Person.datapary = sbt.Text;
            NavigationService.Navigate(new AddLessonAdmin());
        }
        public void deleter(string id)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"DELETE FROM lesson WHERE id_les = "+id+"";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                myConnection.Close();

                
            }
            catch
            {
                myConnection.Close();
               
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int sch = 0;
            for (int i = 0; i < lis.Count; i++)
            {
                if (pnc.Text== lis[i])
                {
                    deleter(lis1[i]);
                }
            }
        }

        private void pnc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int sch = 0;
            for (int i = 0; i < lis.Count; i++)
            {
                if (vtc.Text == lis[i])
                {
                    deleter(lis1[i]);
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int sch = 0;
            for (int i = 0; i < lis.Count; i++)
            {
                if (src.Text == lis[i])
                {
                    deleter(lis1[i]);
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int sch = 0;
            for (int i = 0; i < lis.Count; i++)
            {
                if (chc.Text == lis[i])
                {
                    deleter(lis1[i]);
                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            int sch = 0;
            for (int i = 0; i < lis.Count; i++)
            {
                if (ptc.Text == lis[i])
                {
                    deleter(lis1[i]);
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            int sch = 0;
            for (int i = 0; i < lis.Count; i++)
            {
                if (sbc.Text == lis[i])
                {
                    deleter(lis1[i]);
                }
            }
        }
    }
}
