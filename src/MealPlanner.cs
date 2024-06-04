
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RezeptAnwendung
{
    public class MealPlanner
    {
        private const string FilePath = "mealplan.xml";
        private List<string> MealPlan { get; set; }

        public MealPlanner()
        {
            MealPlan = new List<string>();
        }

        public void AddRecipe(Recipe recipe)
        {
            MealPlan.Add(recipe.Label);  // Speichern Sie nur den Namen des Rezepts
            Serialize();
        }

        public string GetMealPlanContent()
        {
            if (MealPlan.Count == 0) return "No meals planned.";

            return string.Join("\n", MealPlan);  // Gibt die Liste der Gerichtnamen zurück
        }

        public void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            using (FileStream fs = new FileStream(FilePath, FileMode.Create))
            {
                serializer.Serialize(fs, MealPlan);
            }
        }

        public void Deserialize()
        {
            if (File.Exists(FilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                using (FileStream fs = new FileStream(FilePath, FileMode.Open))
                {
                    MealPlan = (List<string>)serializer.Deserialize(fs);
                }
            }
        }
    }
}
