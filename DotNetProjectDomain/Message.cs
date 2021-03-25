using System;
using System.Linq;

namespace DotNetProject
{
    public class Message
    {
        public Guid Id { get; set; }

        public string message { get; }

        public Message(string message)
        {
            this.message = message;
        }

        // static void Main(string[] args)
        // {
        //     Secret msg = new Secret();
        //     msg.Message = new Message("asd");
        //     Console.WriteLine("Hello");
        //     Console.WriteLine(msg.Message.message);
        // }
    }
}