using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
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
using Page = System.Windows.Controls.Page;

namespace Авторассылка.Администратор
{
    /// <summary>
    /// Логика взаимодействия для ScheduleDetails.xaml
    /// </summary>
    public partial class ScheduleDetails : Page
    {
        public class Details
        {
            public string id { get; set; }
            public string zan { get; set; }
        }
        public class infod
        {
            public string curzan { get; set; }
        }

        public ScheduleDetails()
        {
            InitializeComponent();
        }
        public string datalist;
        public ScheduleDetails(date dates)
        {
            InitializeComponent();
            TbCurDay.Text = dates.date_name + " " + dates.date_value;
            datalist = dates.date_value;
            List<Details> details = new List<Details>();
            details.Add(new Details { id = "09:00 - 10:00", zan = dates.zan1 });
            details.Add(new Details { id = "10:00 - 11:00", zan = dates.zan2 });
            details.Add(new Details { id = "11:00 - 12:00", zan = dates.zan3 });
            details.Add(new Details { id = "12:00 - 13:00", zan = dates.zan4 });
            details.Add(new Details { id = "13:00 - 14:00", zan = dates.zan5 });
            details.Add(new Details { id = "14:00 - 15:00", zan = dates.zan6 });
            details.Add(new Details { id = "15:00 - 16:00", zan = dates.zan7 });
            details.Add(new Details { id = "16:00 - 17:00", zan = dates.zan8 });
            details.Add(new Details { id = "17:00 - 18:00", zan = dates.zan9 });
            Rasp.ItemsSource = details.ToList();
        }

        private void Rasp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {



            string test = (Rasp.SelectedItem as Details).zan;
            if ((Rasp.SelectedItem as Details).zan == null)
            {
                if (TypeAd.Person.stat != "3")
                {
                    string[] mas = Convert.ToString((Rasp.SelectedItem as Details).id).Split(' ');
                    TypeAd.Person.lesdat = mas[0] + ":00";
                    TypeAd.Person.lesdate = datalist;

                    NavigationService.Navigate(new AddLesson());
                }
            }
            else
            {
                string[] mas = Convert.ToString((Rasp.SelectedItem as Details).id).Split(' ');
                TypeAd.Person.lesdat = mas[0] + ":00";
                TypeAd.Person.lesdate = datalist;
                NavigationService.Navigate(new AddDz());
            }


        }
    }
}
