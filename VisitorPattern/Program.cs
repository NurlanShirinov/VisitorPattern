using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{

    ////Problem

    //interface INotificationSender
    //{
    //    void Send(string message);
    //    void SetupEmail();
    //    void SetupText();
    //}

    //public class InvoiceNotificationSender : INotificationSender
    //{
    //    public void Send(string message)
    //    {
    //        Console.WriteLine($"Notification sent : {message}");
    //    }

    //    public void SetupEmail()
    //    {
    //        Console.WriteLine("Setup email");
    //    }

    //    public void SetupText()
    //    {
    //        Console.WriteLine("Setup Text");
    //    }
    //}

    //public class MarketingNotificationSender : INotificationSender
    //{
    //    public void Send(string message)
    //    {
    //        Console.WriteLine($"Notification sent : {message}");
    //    }

    //    public void SetupEmail()
    //    {
    //        Console.WriteLine("Setup Email");
    //    }

    //    public void SetupText()
    //    {
    //        Console.WriteLine("Setup Text");
    //    }
    //}
    /// <summary>
    /// ////////////////////////////////////////////////////////
    /// </summary>




    public interface IVisitor
    {
        void Visit(INotificationSender notificationSender);
    }



   public interface INotificationSender
    {
        void Send(string message);
        void Accept(IVisitor visitor);
    }

    public class EmailVisitor : IVisitor
    {
        public void Visit(INotificationSender notificationSender)
        {
            Console.WriteLine("Setup email");
        }

    
    }

    public class TextVisitor : IVisitor
    {
        public void Visit(INotificationSender notificationSender)
        {
            Console.WriteLine("Setup text");
        }
    }

    public class WebsocketVisitor : IVisitor
    {
        public void Visit(INotificationSender notificationSender)
        {
            Console.WriteLine("Setup websocket");
        }
    }



    public class InvoiceNotificationSender : INotificationSender
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public void Send(string message)
        {
            Console.WriteLine($"Notification sent: {message}");
        }


    }

    public class MarketingNotificationSender : INotificationSender
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public void Send(string message)
        {
            Console.WriteLine($"Notification sent: {message}");
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            //Problem
            //var notificationSender1 = new InvoiceNotificationSender();
            //notificationSender1.SetupEmail();
            //notificationSender1.SetupText();
            //notificationSender1.Send("Invoice");

            //var notificationSender2 = new InvoiceNotificationSender();
            //notificationSender2.SetupEmail();
            //notificationSender2.SetupText();
            //notificationSender2.Send("Marketing");


            //Correct

            var emailVisitor = new EmailVisitor();
            var textVisitor = new TextVisitor();
            var websocketVisitor = new WebsocketVisitor();

            var notificationSender1 = new InvoiceNotificationSender();
            notificationSender1.Accept(emailVisitor);
            notificationSender1.Accept(textVisitor);
            notificationSender1.Send("Invoice");

            var notificationSender2 = new MarketingNotificationSender();
            notificationSender2.Accept(emailVisitor);
            notificationSender2.Accept(textVisitor);
            notificationSender2.Accept(websocketVisitor);
            notificationSender2.Send("Marketing");

        }
    }
}
