////using Newtonsoft.Json.Linq;
////using RestSharp;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Windows;

////namespace RecipeApp
////{
////    public class RecipeSorter
////    {
////        //public enum SortCriteria
////        //{
////        //    Breakfast,
////        //    Lunch,
////        //    Dinner
////        //}

////        //public List<Recipe> SortRecipes(List<Recipe> recipes, SortCriteria sortCriteria)
////        //{
////        //    switch (sortCriteria)
////        //    {
////        //        case SortCriteria.Breakfast:
////        //            return FilterRecipesByCategory(recipes, "Breakfast");
////        //        case SortCriteria.Lunch:
////        //            return FilterRecipesByCategory(recipes, "Lunch");
////        //        case SortCriteria.Dinner:
////        //            return FilterRecipesByCategory(recipes, "Dinner");
////        //        default:
////        //            // Keine Sortierung
////        //            return recipes;
////        //    }
////        //}

////        //private List<Recipe> FilterRecipesByCategory(List<Recipe> recipes, string category)
////        //{
////        //    return recipes.Where(r => r.Category.ToLower() == category.ToLower()).ToList();
////        //}
////    }
////}


////using System;
////using System.Collections.Generic;
////using System.Windows;
////using RestSharp;
////using Newtonsoft.Json.Linq;

////namespace RecipeApp
////{
////    public partial class MainWindow : Window
////    {
////        private const string MealDbApiUrl = "https://www.themealdb.com/api/json/v1/1/search.php";

////        public MainWindow()
////        {
////            InitializeComponent();
////        }

////        private void SearchButton_Click(object sender, RoutedEventArgs e)
////        {
////            string query = SearchTextBox.Text;
////            if (!string.IsNullOrWhiteSpace(query))
////            {
////                var recipes = SearchRecipes(query);
////                DisplayRecipes(recipes);
////            }
////            else
////            {
////                MessageBox.Show("Bitte geben Sie einen Suchbegriff ein.");
////            }
////        }

////        // SEARCH RECIPE
////        private List<Recipe> SearchRecipes(string query)
////        {
////            var client = new RestClient($"{MealDbApiUrl}?s={query}");
////            var response = client.Get(new RestRequest());

////            if (response.IsSuccessful)
////            {
////                var content = response.Content;
////                var json = JObject.Parse(content);

////                if (json["meals"] != null)
////                {
////                    var recipes = new List<Recipe>();

////                    foreach (var result in json["meals"])
////                    {
////                        var recipeId = (string)result["idMeal"]; // Use "idMeal" as recipeId
////                        var recipe = new Recipe
////                        {
////                            Label = (string)result["strMeal"],
////                            Url = (string)result["strSource"],
////                            Ingredients = GetIngredients(recipeId),
////                            ImageUrl = (string)result["strMealThumb"],
////                            Instructions = (string)result["strInstructions"]
////                        };

////                        recipes.Add(recipe);
////                    }
////                    return recipes;
////                }
////                else
////                {
////                    MessageBox.Show("Keine Rezepte gefunden.");
////                    return new List<Recipe>();
////                }
////            }
////            else
////            {
////                MessageBox.Show("Fehler beim Abrufen der Rezepte. Bitte versuchen Sie es erneut.");
////                return new List<Recipe>();
////            }
////        }
////        private List<string> GetIngredients(string recipeId)
////        {
////            var client = new RestClient($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={recipeId}");
////            var response = client.Get(new RestRequest());

////            if (response.IsSuccessful)
////            {
////                var content = response.Content;
////                var json = JObject.Parse(content);

////                var ingredients = new List<string>();

////                var result = json["meals"][0];
////                for (int i = 1; i <= 20; i++)
////                {
////                    var ingredient = (string)result[$"strIngredient{i}"];
////                    var measure = (string)result[$"strMeasure{i}"];
////                    if (!string.IsNullOrWhiteSpace(ingredient))
////                    {
////                        ingredients.Add($"{measure} {ingredient}".Trim());
////                    }
////                }

////                return ingredients;
////            }
////            else
////            {
////                MessageBox.Show("Fehler beim Abrufen der Zutaten. Bitte versuchen Sie es erneut.");
////                return new List<string>();
////            }
////        }



////        private void DisplayRecipes(List<Recipe> recipes)
////        {
////            RecipeListBox.ItemsSource = recipes;
////        }

////        private void RecipeListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
////        {
////            if (RecipeListBox.SelectedItem != null)
////            {
////                var selectedRecipe = (Recipe)RecipeListBox.SelectedItem;
////                OpenRecipeDetailsWindow(selectedRecipe);
////            }
////        }

////        private void OpenRecipeDetailsWindow(Recipe recipe)
////        {
////            RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(recipe);
////            recipeDetailsWindow.ShowDialog();
////        }

////        private void RecipeUrlHyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
////        {
////            // Öffne das Rezept-URL im Standardwebbrowser
////            System.Diagnostics.Process.Start(e.Uri.ToString());
////            e.Handled = true;
////        }
////    }
////}

