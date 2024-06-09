
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using NLog;
using RezeptAnwendung;

namespace RezeptAnwendung
{
    public partial class RecipeDetailsWindow : Window
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private Recipe _recipe;
        private MealPlanner _mealPlanner;

        public RecipeDetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            DisplayRecipeDetails(recipe);
            _recipe = recipe;
            _mealPlanner = new MealPlanner();
            DataContext = _recipe;
            Logger.Info($"Opened details window for recipe '{recipe.Label}'.");
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
            Logger.Info($"Navigated to recipe URL: {e.Uri}");
        }

        private void AddToMealPlanButton_Click(object sender, RoutedEventArgs e)
        {
            _mealPlanner.Deserialize();
            _mealPlanner.AddRecipe(_recipe);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Logger.Info($"Closed details window for recipe '{_recipe.Label}'.");
        }
    }
}
