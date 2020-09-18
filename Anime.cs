using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebScraping
{
    [Table("anime")]
    public class Anime
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string imgsrc { get; set; }
  

        public Anime(string name,  string link)
        {
            this.name = name;
            this.link = link;
        }
    }
}
//string img_src, int id
//this.img_src = img_src;
//this.id = id;