using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task2.Model
{
    public class TagToUser
    {
        [Key]
        public Guid EntityId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [Required]
        public Guid TagId { get; set; }

        public Tag? Tag { get; set; }

    }
}
