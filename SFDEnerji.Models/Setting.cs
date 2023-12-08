using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFDEnerji.Models
{
    public class Setting:BaseModel
    {
        public string Logo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Slogan1 { get; set; }
        public string Slogan2 { get; set; }
        public string ActionButtonText { get; set; }
        public string ActionButtonLink { get; set; }
        public string ActionButtonIcon { get; set; }
        public string LearnMoreText { get; set; }
        public string LearnMoreLink { get; set; }
    }
}
