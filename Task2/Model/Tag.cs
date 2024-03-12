using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task2.Model
{
    public class Tag
    {
        public Guid TagId { get; set; }
        [Required]
        public string Value { get; set; } = default!;
        [Required]
        public string Domain { get; set; } = default!;
        [JsonIgnore]
        public List<TagToUser>? TagToUsers { get; set; }

    }
}
