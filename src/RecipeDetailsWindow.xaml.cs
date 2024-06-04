

using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RezeptAnwendung
{
    public partial class RecipeDetailsWindow : Window
    {
        private Recipe _recipe;
        private MealPlanner _mealPlanner;
        public RecipeDetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            DisplayRecipeDetails(recipe);
            _recipe = recipe;
            _mealPlanner = new MealPlanner();
            DataContext = _recipe;
        }

        private void DisplayRecipeDetails(Recipe recipe)
        {
            TitleLabel.Content = recipe.Label;
            IngredientsTextBox.Text = string.Join("\n", recipe.Ingredients);
            CookingInstructionsTextBox.Text = recipe.Instructions;

            if (!string.IsNullOrWhiteSpace(recipe.ImageUrl))
            {
                RecipeImage.Source = new BitmapImage(new Uri(recipe.ImageUrl));
            }
            else
            {
                RecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/NoImageAvailable.jpg"));
            }
        }

        private void RecipeUrlHyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
            e.Handled = true;
        }

        private Recipe Get_recipe()
        {
            return _recipe;
        }

        private void AddToMealPlanButton_Click(object sender, RoutedEventArgs e, Recipe _recipe)
        {
            _mealPlanner.Deserialize();
            _mealPlanner.AddRecipe(_recipe);
            MessageBox.Show($"Wurde zum Essensplan hinzugefügt!");
        }
    }
}



