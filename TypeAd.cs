using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Авторассылка
{
    internal class TypeAd
    {
        public class Person
        {
            public static string stat;
            public static string name ;
            public static string Login;
            public static string Pas;
            public static string sellesid;
            public static string fio;
            public static string datapary;
            public static string dzid;
            public static string lesdat;
            public static string lesdate;
        }
        public partial class visited
        {
            public string id_employee { get; set; }
            public string lesson_date { get; set; }
            public string lesson_time { get; set; }
            public string id_homework { get; set; }
            public string id_lesson { get; set; }
            public string id_student { get; set; }
            public string num_group { get; set; }
            public string Name_group { get; set; }
            public string fio_employee { get; set; }
        }
        public static List<visited> visiter = new List<visited>();
    }
}
