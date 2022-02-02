using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TikoTask.Data.Entities
{
    public class City
    {
        [Required]
        public string Name { get; set; }
    }
}
