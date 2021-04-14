using System;
using DotNetProject.Contracts;

namespace DotNetProject
{
    public class Secret : IMessageContainer
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public Message Message { get; set; }
        public string Lifetime { get; set; }
        public DateTime? CreatedAt { get; set; }
        int? IMessageContainer.MessageId => this.Message.Id;
    }
}