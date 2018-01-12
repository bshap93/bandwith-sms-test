using System;
using Bandwidth.Net;
using Bandwidth.Net.Api;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace bandwith_app
{
    class Program
    {
        static void Main(string[] args)
        {


            Run().Wait();
            //var message = await client.Message.SendAsync(new MessageData
            //{
            //    From = "+12345678901", // This must be a Bandwidth number on your account
            //    To = "+12345678902",
            //    Text = "Hello world."
            //});
            //Console.WriteLine($"Message Id is {message.Id}");

            Console.WriteLine("Hello World!");
        }



        private async static Task<String> callApp()
        {
            var client = new Client(
                "u-fwk263frxigg4zr55jstzhy", // <-- note, this is not the same as the username you used to login to the portal
                "t-sm4c4fkhfsd5ost6mhp6g2q",
                "5ldktuz4zdysutpft6ijkvds62a3dfnghk6iu2i"
            );

            //var application = await client.Application.CreateAsync(new CreateApplicationData { Name = "MyFirstApp" });

            //Console.WriteLine(application.Id); //will return Id of created application

            //Console.WriteLine(application.Instance.Name); //will make request to Catapult API to get application data

            //Console.WriteLine(application.Instance.Name); //will use cached application's data


            var messageId = await client.Message.SendAsync(new MessageData
            {
                From = "+14355656022", // This must be a Bandwidth number on your account
                To = "+12817347494",
                Text = "Hello world.",
                ReceiptRequested = MessageReceiptRequested.All,
                CallbackUrl = "https://requestb.in/13hg11c1"
            });


            var message = await client.Message.GetAsync(messageId);


            Console.WriteLine($"{message.From} -> {message.To}: {message.Text}");
            Console.WriteLine($"DeliveryState: {message.DeliveryState}");
            Console.WriteLine($"State: {message.State}");

            Console.ReadLine();Console.WriteLine(" Enter to re-check state");
            message = await client.Message.GetAsync(messageId);

            Console.WriteLine($"DeliveryState: {message.DeliveryState}");
            Console.WriteLine($"State: {message.State}");

            // put breakpoint here to inspect message object

            Console.ReadLine();


            return messageId;
        }


        public static async Task Run()
        {
            var client = new Client(
                "u-fwk263frxigg4zr55jstzhy", // <-- note, this is not the same as the username you used to login to the portal
                "t-sm4c4fkhfsd5ost6mhp6g2q",
                "5ldktuz4zdysutpft6ijkvds62a3dfnghk6iu2i"
            );
            //Please fill these constants
            var messageId = await client.Message.SendAsync(new MessageData
            {
                From = "+14355656022",
                To = "+12817347494",
                Text = "Thank you for susbcribing to Unicorn Enterprises!",
                Media = new[] { "https://i.imgur.com/YkkBXgo.png" },
                CallbackUrl = "https://requestb.in/1gprrv61"
            });
            Console.WriteLine($"Created message with id {messageId}");

            var message = await client.Message.GetAsync(messageId);

            Console.WriteLine($"{message.From} -> {message.To}: {message.Text}");
            Console.WriteLine($"DeliveryState: {message.DeliveryState}");
            Console.WriteLine($"State: {message.State}");

            Console.ReadLine(); Console.WriteLine(" Enter to re-check state");
            message = await client.Message.GetAsync(messageId);

            Console.WriteLine($"DeliveryState: {message.DeliveryState}");
            Console.WriteLine($"State: {message.State}");

            // put breakpoint here to inspect message object

            Console.ReadLine();

        }
    }
}
