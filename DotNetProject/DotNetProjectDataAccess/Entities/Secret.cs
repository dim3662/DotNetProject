using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetProject.DotNetProjectDataAccess.Entities
{
    public class Secret
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Password { get; set; }
        public string Lifetime { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Message Message { get; set; }
    }
}