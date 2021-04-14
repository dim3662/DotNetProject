using System;
using DotNetProject.Contracts;

namespace DotNetProject.Models
{
    public class SecretUpdateModel : ISecretIdentity, IMessageContainer
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Lifetime { get; set; }
        
        public DateTime? CreatedAt { get; set; }

        public int? MessageId { get; set; }
    }
}