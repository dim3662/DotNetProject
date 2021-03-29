using System;

namespace DotNetProject
{
    public class Secret
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public Message Message { get; set; }
        public string Lifetime { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}