using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetProjectClient.Request.Create
{
    public class SecretCreateDTO
    {
        public string Password { get; set; }

        [Required(ErrorMessage = "Lifetime is required")]
        public string Lifetime { get; set; }

        [Required(ErrorMessage = "CreatedAt is required")]
        public DateTime? CreatedAt { get; set; }
        public int? MessageId { get; set; }
    }
}