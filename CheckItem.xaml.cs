using System;
using System.Collections.Generic;
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

namespace Авторассылка
{
    /// <summary>
    /// Логика взаимодействия для CheckItem.xaml
    /// </summary>
    public partial class CheckItem : Page
    {
        public CheckItem()
        {
            InitializeComponent();
        }
    }
}

//public static VkApi api = new VkApi();
//static public void fuuu()
//{
//    try
//    {
//        var s = api.Groups.GetLongPollServer(207499199);
//        var poll = api.Groups.GetBotsLongPollHistory(
//           new BotsLongPollHistoryParams()
//           { Server = s.Server, Ts = s.Ts, Key = s.Key, Wait = 25 });
//        if (poll?.Updates != null)
//        {

//            foreach (var a in poll.Updates)
//            {
//                if (a.Type == GroupUpdateType.MessageNew)
//                {
//                    string userMessage = a.Message.Text.ToLower();
//                    long? userID = a.Message.PeerId;
//                    e(userMessage, userID);
//                }
//            }
//        }
//    }
//    catch { }

//}
//static void Main1(string[] args)
//{

//    try
//    {


//        api.Authorize(new ApiAuthParams() { AccessToken = "31429b2b19826235bc53757b1d9d9b42736aba751e51646897833788d265c865c5825b813f974ac502d55" });
//        while (true) // Бесконечный цикл, получение обновлений
//        {

//            fuuu();

//        }
//    }
//    catch
//    {
//        Console.WriteLine("???");
//        Thread.Sleep(300000);
//        Main1(args);
//    }
//}
//public static void e(string message, long? userID)
//{
//    try
//    {


//        if (message == "гений евгеньевич") SendMessage("Леша, ты заебал моего бота засерать", userID);
//        if (message == "начать") SendMessage(" Этот бот предназначен для выдачи расписания для Серпуховского Колледжа." +
//            " \n\n Чтоб получить расписани для 1 корпуса напишите номер группы. " +
//            " \n\n Чтоб получить расписани для преподавателей 1 корпуса напишите !фамилия_преподавателя. " +
//            " \n\n Чтоб получать рассылку при обновлении добавьте ? преред любой из команд. " + "\n\n Все диалоги доступны к прчтению администраторам, на отправляйте боту личные данные или конфиденциальную информацию" +
//            "\n\n Для связи с разработчиком есть беседа в закрепе группы.", userID);

//    }
//    catch { }


//}
//public static void SendMessage(string message, long? userID)
//{
//    try
//    {


//        Random rnd = new Random();
//        api.Messages.Send(new MessagesSendParams
//        {
//            RandomId = rnd.Next(),
//            UserId = userID,
//            Message = message
//        });
//    }
//    catch { }

//}

//private void Button_Click(object sender, RoutedEventArgs e)
//{
//    api.Authorize(new ApiAuthParams() { AccessToken = "31429b2b19826235bc53757b1d9d9b42736aba751e51646897833788d265c865c5825b813f974ac502d55" });

//    SendMessage(tb1.Text, Convert.ToInt32(tb2.Text));
//}
