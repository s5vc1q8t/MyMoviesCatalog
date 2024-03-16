using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Producer { get; set; }
        public string Rating { get; set; }
        public List<Style> Styles { get; set; }
    }
    public class Style
    {
        public int Id { get; set; }
        [Required]
        public string Styles { get; set; }
    }
}

