using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Model;
using VkNet;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot;
using MaterialDesignThemes.Wpf;
using System.Xml.Linq;
using System.Runtime.ConstrainedExecution;

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для Bots.xaml
    /// </summary>
    public class Program
    {
        static string connstring = MainWindow.connstringmain;
        public List<TodoItem> items = new List<TodoItem>();
        public class TodoItem
        {
            public string tipe { get; set; }//group name
            public string coll { get; set; }//type
            public string name { get; set; }
            public string token { get; set; }
        }
        public bool Log()
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
                    items.Add(new TodoItem() { tipe = sus[2], coll = sus[3], name = sus[4], token = sus[1] });
                }
                myConnection.Close();
                return true;


            }
            catch
            {
                myConnection.Close();
                return false;
            }
        }
        static ITelegramBotClient bot;

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            var idu = update.Id;
            var message = update.Message;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = Program.connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"insert into users_track(date_user,text_user,code_user) values('" + DateTime.Now + "','" + message.Text.ToLower() + "','" + Convert.ToString(idu) + "')";

                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);

                    sus[2] = Convert.ToString(dr[2]);

                }

                myConnection.Close();



            }
            catch
            {
                myConnection.Close();

            }

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                
                
                try
                {
                    
                    for (int i = 0; i < bd.items.Count; i++)
                    {
                        if (bd.items[i].uslovie.ToLower() == message.Text.ToLower() && bd.items[i].name == per)
                        {
                            await botClient.SendTextMessageAsync(message.Chat, bd.items[i].text);

                            SqlConnection myConnection1 = new SqlConnection();

                            myConnection1.ConnectionString = Program.connstring;
                            SqlCommand sqlCmd1 = new SqlCommand();
                            try
                            {
                                sqlCmd1.CommandType = CommandType.Text;
                                sqlCmd1.CommandText = @"insert into users_track(date_user,text_adm,code_user) values('" + DateTime.Now + "','" + bd.items[i].name + "','" + Convert.ToString(idu) + "')";

                                sqlCmd1.Connection = myConnection1;
                                myConnection1.Open();
                                //sqlCmd.ExecuteNonQuery();
                                SqlDataReader dr1 = sqlCmd1.ExecuteReader();
                                string[] sus = new string[3];
                                while (dr1.Read())
                                {
                                    sus[0] = Convert.ToString(dr1[0]);

                                    sus[2] = Convert.ToString(dr1[2]);

                                }

                                myConnection1.Close();



                            }
                            catch
                            {
                                myConnection1.Close();

                            }









                            return;
                        }
                    }
                    await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");

                }
                catch { }


                //if (message.Text.ToLower() == "/start")
                //{
                //    await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                //    return;
                //}
                //await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        public static string per = "TelegaTest";
        public static void Main123(string token, string name)
        {
            bot = new TelegramBotClient(token);
            per = name;

        var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );

        }
    }

    public class bd
    {
        static string connstring = MainWindow.connstringmain;
        public static List<TodoItem> items = new List<TodoItem>();
        public class TodoItem
        {
            public string text { get; set; }//group name
            public string tip { get; set; }//type
            public string name { get; set; }
            public string stat { get; set; }
            public string uslovie { get; set; }
        }
        public static bool Log()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from texts_avt";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                sqlCmd.ExecuteNonQuery();
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
                    sus[6] = Convert.ToString(dr[6]);
                    items.Add(new TodoItem() { text = sus[2], tip = sus[3], name = sus[4], stat = sus[5], uslovie = sus[6] });
                }
                myConnection.Close();
                return true;


            }
            catch
            {
                myConnection.Close();
                return false;
            }
        }
}
    public partial class Bots : Page
    {
        static string connstring = MainWindow.connstringmain;
        public List<TodoItem> items = new List<TodoItem>();
        public Bots()
        {
            InitializeComponent();
            
            bd.Log();
            Log();
            icTodoList.ItemsSource = items;
            Logining();
            try
            {
                for (int i = 0; i < items.Count; i++)
                {
                    non(i);
                }
            }
            catch { }
            
        }
        public void non(int i)
        {
            if (items[i].tipe == "Vk")
            {
                Task.Run(() => Main1(items[i].token, items[i].coll, items[i].name));
            }
            else
            {
                Task.Run(() => Program.Main123(items[i].token, items[i].name));
            }
        }
            

    










































        public class TodoItem
        {
            public string tipe { get; set; }//group name
            public string coll { get; set; }//type
            public string name { get; set; }
            public string token { get; set; }
        }
        public bool Log()
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
                    items.Add(new TodoItem() { tipe = sus[2], coll = sus[3], name = sus[4],token = sus[1] });
                }
                myConnection.Close();
                return true;


            }
            catch
            {
                myConnection.Close();
                return false;
            }
        }
        public static VkApi api = new VkApi();
        static public void fuuu(string coll, string name)
        {
            var s = api.Groups.GetLongPollServer(Convert.ToUInt32(coll));
            var poll = api.Groups.GetBotsLongPollHistory(
               new BotsLongPollHistoryParams()
               { Server = s.Server, Ts = s.Ts, Key = s.Key, Wait = 10 });
            if (poll?.Updates != null)
            {

                foreach (var a in poll.Updates)
                {
                    if (a.Type == GroupUpdateType.MessageNew)
                    {
                        try
                        {
                            string userMessage = a.Message.Text.ToLower();
                            long? userID = a.Message.PeerId;
                            e(userMessage, userID,  name);
                        }
                        catch { }
                    }
                }
            }


        }
        public static string text12 = "Приветик";
        public bool Logining()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"Select * from texts_avt";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);

                    sus[2] = Convert.ToString(dr[2]);

                }
                text12 = sus[2];
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
        static void Main1(string token, string id, string name)
        {

            try
            {


                api.Authorize(new ApiAuthParams() { AccessToken = token });
                while (true) // Бесконечный цикл, получение обновлений
                {

                    fuuu(id,name);

                }
            }
            catch
            {
                Thread.Sleep(300000);
                Main1(token, id,name);
            }
        }



        public static void e(string message, long? userID, string name)
        {
            string connstring = MainWindow.connstringmain1;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connstring;
            string mes = "";
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"select Homework_text from Student join Visit on visit.id_student = Student.id_student join Lesson on lesson.id_lesson = Visit.id_lesson join homework on Homework.Id_homework = Lesson.id_lesson where Code = '{message}'";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                //sqlCmd.ExecuteNonQuery();
                SqlDataReader dr = sqlCmd.ExecuteReader();
                string[] sus = new string[3];
                while (dr.Read())
                {
                    sus[0] = Convert.ToString(dr[0]);
                    if (sus[0]!=null)
                    {
                        if (sus[0] != "")
                        {
                            mes += sus[0] + " \n";
                        }

                    }
                }
                myConnection.Close();
                if (mes!="")
                {
                    SendMessage("Ваши домашние задания :\n"+mes, userID);
                }


            }
            catch
            {
                myConnection.Close();
            }
            

            if (message.ToLower() == "человек")
            {
                SendMessage("Сейчас позовем", userID);
                SendMessage("С вами хочет связаться пользователь "+Convert.ToString(userID), 236051979);
            }
            bool klos = false;
            if (message.Contains("привет"))
            {
                SendMessage("Привет", userID);
            }
            if (message.Contains("а"))
            {
                SendMessage("б", userID);
            }


            if (klos == false)
            {
                if (message.ToLower().Contains("бебра"))
                {


                    SqlConnection myConnection1 = new SqlConnection();

                    myConnection1.ConnectionString = Bots.connstring;
                    SqlCommand sqlCmd1 = new SqlCommand();
                    try
                    {
                        sqlCmd1.CommandType = CommandType.Text;
                        sqlCmd1.CommandText = @"insert into ban_list(code_user) values('" + userID + "')";

                        sqlCmd1.Connection = myConnection1;
                        myConnection1.Open();
                        //sqlCmd.ExecuteNonQuery();
                        SqlDataReader dr = sqlCmd1.ExecuteReader();
                        string[] sus = new string[3];
                        while (dr.Read())
                        {
                            sus[0] = Convert.ToString(dr[0]);

                            sus[2] = Convert.ToString(dr[2]);

                        }

                        myConnection1.Close();
                        SendMessage("Вы попали в блок лист", userID);


                    }
                    catch
                    {
                        myConnection1.Close();

                    }
                }
                else
                {

                    try
                    {


                        for (int i = 0; i < bd.items.Count; i++)
                        {
                            if (bd.items[i].uslovie.ToLower() == message.ToLower() && bd.items[i].name == name)
                            {
                                SendMessage(bd.items[i].text, userID);
                            }
                        }


                    }
                    catch { }
                }


            }
        }
        public static void SendMessage(string message, long? userID)
        {
            try
            {


                Random rnd = new Random();
                api.Messages.Send(new MessagesSendParams
                {
                    RandomId = rnd.Next(),
                    UserId = userID,
                    Message = message
                });
            }
            catch { }

        }


    }
}
