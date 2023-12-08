using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFDEnerji.Models.ViewModels
{
    public class HomeVm
    {
        public ContactForm ContactForm { get; set; }=new ContactForm();
        public List<Service> Services { get; set; }=new List<Service>();
        public List<Project> Projects { get; set; }=new List<Project>();

        public Setting Settings { get; set; }

    }
}
