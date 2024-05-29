using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RezeptAnwendung
{
    public partial class RecipeDetailsWindow : Window
    {
        private Recipe _recipe;

        public RecipeDetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe;
            DisplayRecipeDetails(recipe);
        }

        private void DisplayRecipeDetails(Recipe recipe)
        {
            TitleLabel.Content = recipe.Label;
            IngredientsTextBox.Text = string.Join("\n", recipe.Ingredients);
            CookingInstructionsTextBox.Text = recipe.Instructions;
            CurrentRatingLabel.Content = $"Aktuelle Bewertung: {recipe.Rating}";

            if (!string.IsNullOrWhiteSpace(recipe.ImageUrl))
            {
                RecipeImage.Source = new BitmapImage(new Uri(recipe.ImageUrl));
            }
            else
            {
                RecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/NoImageAvailable.jpg"));
            }
        }

        private void RateButton_Click(object sender, RoutedEventArgs e)
        {
            if (RatingComboBox.SelectedItem != null)
            {
                var selectedRating = (ComboBoxItem)RatingComboBox.SelectedItem;
                if (double.TryParse(selectedRating.Content.ToString(), out double rating))
                {
                    _recipe.Rating = rating;
                    CurrentRatingLabel.Content = $"Aktuelle Bewertung: {rating}";
                }
                else
                {
                    MessageBox.Show("Ungültige Bewertung.");
                }
            }
            else
            {
                MessageBox.Show("Bitte eine Bewertung auswählen.");
            }
        }
    }
}
