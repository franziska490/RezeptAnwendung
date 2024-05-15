using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using RezeptAnwendung;

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
            PreparationTextBox.Text = recipe.Preparation;

            if (!string.IsNullOrWhiteSpace(recipe.ImageUrl))
            {
                RecipeImage.Source = new BitmapImage(new Uri(recipe.ImageUrl));
            }
            else
            {
                // Wenn kein Bild verfügbar ist, setze ein Standardbild
                RecipeImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/NoImageAvailable.jpg"));
            }
        }

        private void RecipeUrlHyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            // Öffne das Rezept-URL im Standardwebbrowser
            System.Diagnostics.Process.Start(e.Uri.ToString());
            e.Handled = true;
        }
    }
}