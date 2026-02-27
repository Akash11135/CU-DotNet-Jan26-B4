
//class NotificationService
//{
//    public void Notify(INotification notification, string message)
//    {
//        Console.WriteLine("Logging notification...");

//        notification.Send(message);

//        Console.WriteLine("Notification sent successfully");
//    }
//}

namespace OCP
{

    //class NotificationService
    //{
    //    //service
    //    public void Send(string type, string message)
    //    {

    //        if (type == "Email")
    //        {

    //            Console.WriteLine("Sending Email: " + message);
    //        }
    //        else if (type == "SMS")
    //        {
    //            Console.WriteLine("Sending SMS: " + message);
    //        }
    //        else if (type == "WhatsApp")
    //        {
    //            Console.WriteLine("Sending WhatsApp: " + message);
    //        }else if(type ==" Discord")
    //        {
    //            Console.WriteLine("Sending Discord: " + message);

    //        }
    //    }
    //}


    class Email : IMessage
    {

        public void send(string message)
        {
            Console.WriteLine("Method : Email "+" Message : "+message);
        }
    }


    internal class Program 
    {
        static void Main(string[] args)
        {
            Email e = new Email();
            e.send("Hi how are you.");

        }
    }
}
