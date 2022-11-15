using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Firstname { get; private set; }

        [Required]
        public string Lastname { get; private set; }
    }
}

