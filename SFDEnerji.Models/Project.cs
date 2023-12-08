using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SFDEnerji.Models
{
    [Table("Projects")]
    public class Project:BaseModel
    {
        public string Content { get; set; }
        public string Slug { get; set; }
        public string Thumbnail { get; set; }
        public int ViewCount { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }=new List<Picture>();
        public virtual ICollection<Meta> Metas { get; set; }=new List<Meta>();
    }
}
