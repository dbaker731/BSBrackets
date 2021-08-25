using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        // we are setting password length here
        // TODO: actual password validation
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
