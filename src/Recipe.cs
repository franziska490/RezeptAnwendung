using System.Collections.Generic;

namespace RezeptAnwendung
{
    public class Recipe
    {
        public string Label { get; set; }
        public string Url { get; set; }
        public List<string> Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public string Instructions { get; set; }
        public double Rating { get; set; }
    }
}
