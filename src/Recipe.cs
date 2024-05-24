using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class Recipe
    {
        public string Label { get; set; }
        public List<string> Ingredients { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Instructions { get; set; } // Neue Eigenschaft für die Zubereitungsanleitung
    }
}


