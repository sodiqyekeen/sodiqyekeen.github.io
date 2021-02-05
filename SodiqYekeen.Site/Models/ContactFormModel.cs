using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SodiqYekeen.Site.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [MinLength(3, ErrorMessage = "Please enter at least {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        [MinLength(4, ErrorMessage = "Please enter at least {1} characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please write me something.")]
        [MinLength(10, ErrorMessage = "Please enter at least {1} characters")]
        public string Message { get; set; }

        public string  ReCaptcha { get; set; }
    }
}
