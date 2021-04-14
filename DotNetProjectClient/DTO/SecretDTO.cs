using System;

namespace DotNetProjectClient.DTO
{
    public class SecretDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public MessageDTO Message { get; set; }
        public string Lifetime { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}