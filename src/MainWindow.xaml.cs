using System;
using System.Collections.Generic;
using System.Windows;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RezeptAnwendung
{
    public partial class MainWindow : Window
    {
        private const string EdamamApiKey = "8018ed233ad047a53b5af7c3241052da";
        private const string EdamamApiUrl = "https://api.edamam.com/search";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchTextBox.Text;
            if (!string.IsNullOrWhiteSpace(query))
            {
                var recipes = SearchRecipes(query);
                DisplayRecipes(recipes);
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen Suchbegriff ein.");
            }
        }

        private List<Recipe> SearchRecipes(string query)
        {
            var client = new RestClient($"{EdamamApiUrl}?q={query}&app_id=c948850f&app_key=8018ed233ad047a53b5af7c3241052da");
            var response = client.Get(new RestRequest());


            if (response.IsSuccessful)
            {
                var content = response.Content;
                var json = JObject.Parse(content);

                if (json["hits"] != null)
                {
                    var recipes = new List<Recipe>();

                    foreach (var hit in json["hits"])
                    {
                        var recipeJson = hit["recipe"];
                        var recipe = new Recipe
                        {
                            Label = (string)recipeJson["label"],
                            Url = (string)recipeJson["url"],
                            Ingredients = recipeJson["ingredientLines"].ToObject<List<string>>(),
                            Preparation = (string)recipeJson["preparation"],
                            ImageUrl = (string)recipeJson["image"]
                        };
                        recipes.Add(recipe);
                    }
                    return recipes;
                }
                else
                {
                    MessageBox.Show("Keine Rezepte gefunden.");
                    return new List<Recipe>();
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Abrufen der Rezepte. Bitte versuchen Sie es erneut.");
                return new List<Recipe>();
            }
        }

        private void DisplayRecipes(List<Recipe> recipes)
        {
            RecipeListBox.ItemsSource = recipes;
        }

        private void RecipeListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                var selectedRecipe = (Recipe)RecipeListBox.SelectedItem;
                OpenRecipeDetailsWindow(selectedRecipe);
            }
        }

        private void OpenRecipeDetailsWindow(Recipe recipe)
        {
            RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(recipe);
            recipeDetailsWindow.ShowDialog();
        }

        private void RecipeUrlHyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            // Öffne das Rezept-URL im Standardwebbrowser
            System.Diagnostics.Process.Start(e.Uri.ToString());
            e.Handled = true;
        }


    }

    public class Recipe
    {
        public string Label { get; set; }
        public List<string> Ingredients { get; set; }
        public string Url { get; set; }
        public string Preparation { get; set; }
        public string ImageUrl { get; set; }
    }
}