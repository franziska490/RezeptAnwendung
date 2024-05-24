using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RecipeApp
{
    public partial class RecipeDetailsWindow : Window
    {
        public RecipeDetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            DisplayRecipeDetails(recipe);
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
    }
}
