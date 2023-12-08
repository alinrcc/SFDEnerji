using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFDEnerji.Models
{
    [Table("Metas")]
    public class Meta:BaseModel
    {
        public string? MetaName { get; set; } 
        public string? MetaProperty { get; set; }
        public string MetaContent { get; set; }
        public virtual ICollection<Page> Pages { get; set; }=new List<Page>();
        public virtual ICollection<Project> Projects { get; set; }=new List<Project>();
        public virtual ICollection<Service> Services { get; set; }=new List<Service>();
        
    }
}
