using System;
using System.Linq;

namespace DotNetProject
{
    public class Message
    {
        public int Id { get; set; }

        public string message { get; }

        public Message(string message)
        {
            this.message = message;
        }

    }
}