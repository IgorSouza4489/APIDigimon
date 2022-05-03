using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Digimon
    {
        [Key]
        public string name { get; set; }
        public string img { get; set; }
        public string level { get; set; }


    }
}
