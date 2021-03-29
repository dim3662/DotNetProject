using System;
using System.Collections.Generic;

namespace DotNetProject.DotNetProjectBLL.Contracts
{
    public interface IMessageBLL
    {
        Message createNew(string message);

        Message getById(Guid id);
        
        ICollection<Message> getAll();
    }
}