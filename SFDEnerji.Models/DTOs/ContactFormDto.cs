using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFDEnerji.Models.DTOs
{
    public class ContactFormDto:ContactForm
    {
       
        public int MessageLength { get; set; }
    }
}
