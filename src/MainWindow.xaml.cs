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
        private const string CategoryApiUrl = "https://www.themealdb.com/api/json/v1/1/categories.php";
        private const string LookupApiUrl = "https://www.themealdb.com/api/json/v1/1/lookup.php?i=";

        public List<string> Categories { get; private set; }
        private MealPlanner mealPlanner;

        public MainWindow()
        {
            InitializeComponent();
            mealPlanner = new MealPlanner();
            mealPlanner.Deserialize();
            DisplayMealPlan();

            // Load meal categories
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
                MessageBox.Show($"Error loading meal categories: {ex.Message}");
            }
        }

        private async Task<List<string>> GetMealCategoriesAsync()
        {
            var client = new RestClient(CategoryApiUrl);
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
                throw new Exception("Error fetching meal categories.");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchTextBox.Text.Trim();
            string selectedCategory = CategoryComboBox.SelectedItem as string;
            if (!string.IsNullOrWhiteSpace(query))
            {
                var recipes = SearchRecipes(query, selectedCategory);
                DisplayRecipes(recipes);
            }
            else
            {
                MessageBox.Show("Please enter a search term.");
            }
        }

        private List<Recipe> SearchRecipes(string query, string category)
        {
            var client = new RestClient($"{MealDbApiUrl}?s={query}");
            var response = client.Get(new RestRequest());

            if (response.IsSuccessful)
            {
                var content = response.Content;
                var json = JObject.Parse(content);

                if (json["meals"] != null)
                {
                    var recipes = json["meals"].Select(result => new Recipe
                    {
                        Label = (string)result["strMeal"],
                        Url = (string)result["strSource"],
                        Ingredients = GetIngredients((string)result["idMeal"]),
                        ImageUrl = (string)result["strMealThumb"],
                        Instructions = (string)result["strInstructions"],
                        Category = (string)result["strCategory"]
                    }).ToList();

                    if (!string.IsNullOrEmpty(category))
                    {
                        recipes = recipes.Where(r => r.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    return recipes;
                }
                else
                {
                    MessageBox.Show("No recipes found.");
                    return new List<Recipe>();
                }
            }
            else
            {
                MessageBox.Show("Error fetching recipes. Please try again.");
                return new List<Recipe>();
            }
        }

        private List<string> GetIngredients(string recipeId)
        {
            var client = new RestClient($"{LookupApiUrl}{recipeId}");
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
                MessageBox.Show("Error fetching ingredients. Please try again.");
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
                MessageBox.Show($"Selected Category: {selectedCategory}");
            }
        }

        private void DisplayMealPlan()
        {
            MealPlanTextBox.Text = mealPlanner.GetMealPlanContent();
        }

        private void ShowRecipeDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var recipe = (sender as Button)?.DataContext as Recipe;
            if (recipe != null)
            {
                var detailsWindow = new RecipeDetailsWindow(recipe);
                detailsWindow.Show();
            }
        }

        private void AddToMealPlanButton_Click(object sender, RoutedEventArgs e)
        {
            var recipe = (sender as Button)?.DataContext as Recipe;
            if (recipe != null)
            {
                mealPlanner.AddRecipe(recipe);
                DisplayMealPlan();
            }
        }
    }
}
