using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Windows.Controls;

namespace RezeptAnwendung
{
    public partial class MainWindow : Window
    {
        private const string MealDbApiUrl = "https://www.themealdb.com/api/json/v1/1/search.php";

        public List<string> Categories { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            // Lade die Mahlkategorien
            LoadMealCategories();
        }

        private async void LoadMealCategories()
        {
            try
            {
                Categories = await GetMealCategoriesAsync();
                CategoryComboBox.ItemsSource = Categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Mahlkategorien: {ex.Message}");
            }
        }

        private async Task<List<string>> GetMealCategoriesAsync()
        {
            var client = new RestClient("https://www.themealdb.com/api/json/v1/1/categories.php");
            var request = new RestRequest();
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var content = response.Content;
                var json = JObject.Parse(content);

                return json["categories"].Select(c => (string)c["strCategory"]).ToList();
            }
            else
            {
                throw new Exception("Fehler beim Abrufen der Mahlkategorien.");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchTextBox.Text.Trim();
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
            var client = new RestClient($"{MealDbApiUrl}?s={query}");
            var response = client.Get(new RestRequest());

            if (response.IsSuccessful)
            {
                var content = response.Content;
                var json = JObject.Parse(content);

                if (json["meals"] != null)
                {
                    return json["meals"].Select(result => new Recipe
                    {
                        Label = (string)result["strMeal"],
                        Url = (string)result["strSource"],
                        Ingredients = GetIngredients((string)result["idMeal"]),
                        ImageUrl = (string)result["strMealThumb"],
                        Instructions = (string)result["strInstructions"]
                    }).ToList();
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

        private List<string> GetIngredients(string recipeId)
        {
            var client = new RestClient($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={recipeId}");
            var response = client.Get(new RestRequest());

            if (response.IsSuccessful)
            {
                var content = response.Content;
                var json = JObject.Parse(content);

                var ingredients = new List<string>();

                var result = json["meals"][0];
                for (int i = 1; i <= 20; i++)
                {
                    var ingredient = (string)result[$"strIngredient{i}"];
                    var measure = (string)result[$"strMeasure{i}"];
                    if (!string.IsNullOrWhiteSpace(ingredient))
                    {
                        ingredients.Add($"{measure} {ingredient}".Trim());
                    }
                }

                return ingredients;
            }
            else
            {
                MessageBox.Show("Fehler beim Abrufen der Zutaten. Bitte versuchen Sie es erneut.");
                return new List<string>();
            }
        }

        private void DisplayRecipes(List<Recipe> recipes)
        {
            RecipeListBox.ItemsSource = recipes;
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            System.Diagnostics.Process.Start(e.Uri.ToString());
            e.Handled = true;
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem != null)
            {
                string selectedCategory = CategoryComboBox.SelectedItem.ToString();
                MessageBox.Show($"Ausgewählte Kategorie: {selectedCategory}");
            }
        }
    }
}
