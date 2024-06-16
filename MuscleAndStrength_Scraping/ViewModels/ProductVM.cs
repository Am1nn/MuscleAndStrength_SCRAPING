using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleAndStrength_SCRAPING.ViewModels
{
    public  class ProductVM
    {

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl {  get; set; }
        public decimal Price { get; set; }
    }
}
