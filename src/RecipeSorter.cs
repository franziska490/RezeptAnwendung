using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezeptAnwendung
{
    public class RecipeSorter
    {
        public enum SortCriteria
        {
            Breakfast,
            Lunch,
            Dinner
        }

        public List<Recipe> SortRecipes(List<Recipe> recipes, SortCriteria sortCriteria)
        {
            switch (sortCriteria)
            {
                case SortCriteria.Breakfast:
                    return FilterRecipesByCategory(recipes, "Breakfast");
                case SortCriteria.Lunch:
                    return FilterRecipesByCategory(recipes, "Lunch");
                case SortCriteria.Dinner:
                    return FilterRecipesByCategory(recipes, "Dinner");
                default:
                    // Keine Sortierung
                    return recipes;
            }
        }

        private List<Recipe> FilterRecipesByCategory(List<Recipe> recipes, string category)
        {
            return recipes.Where(r => r.Category.ToLower() == category.ToLower()).ToList();
        }
    }
}
