using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NLog;

namespace RezeptAnwendung
{
    public class MealPlanner
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private const string FilePath = "mealplan.xml";
        private List<string> MealPlan { get; set; }

        public MealPlanner()
        {
            MealPlan = new List<string>();
        }

        public void AddRecipe(Recipe recipe)
        {
            MealPlan.Add(recipe.Label);  // Save only the recipe name
            Serialize();
            Logger.Info($"Added recipe '{recipe.Label}' to meal plan.");
        }

        public void Clear()
        {
            MealPlan.Clear();
            Serialize();
            Logger.Info("Cleared meal plan.");
        }

        public string GetMealPlanContent()
        {
            if (MealPlan.Count == 0) return "No meals planned.";

            return string.Join("\n", MealPlan);  // Return the list of dish names
        }

        public void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            using (FileStream fs = new FileStream(FilePath, FileMode.Create))
            {
                serializer.Serialize(fs, MealPlan);
            }
            Logger.Info("Serialized meal plan to file.");
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
                Logger.Info("Deserialized meal plan from file.");
            }
        }
    }
}
