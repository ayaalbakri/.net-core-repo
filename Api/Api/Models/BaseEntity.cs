using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
