using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailProject.Models
{
    public class MailViewModel
    {
        [Required(ErrorMessage ="You must Enter the Address of the Recipient")]
        [Display(Name ="Recipient Address"), DataType(DataType.EmailAddress)]
        public string To { get; set; }
        [Required(ErrorMessage = "You must Write a Subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "You must Write  Message"), Display(Name ="Enter Your Message")]
        public string Body { get; set; }
    }
}
