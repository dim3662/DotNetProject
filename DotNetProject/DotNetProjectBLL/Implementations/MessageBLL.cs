using System;
using System.Collections.Generic;
using DotNetProject.DotNetProjectBLL.Contracts;

namespace DotNetProject.DotNetProjectBLL.Implementations
{
    public class MessageBLL : IMessageBLL
    {
        public MessageBLL()
        {
        }

        public Message createNew(string message)
        {
            var result = new Message(message);
            return result;
        }

        public Message getById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Message> getAll()
        {
            throw new NotImplementedException();
        }
    }
}