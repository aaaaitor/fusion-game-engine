using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;

namespace FusionEditor.GameProject
{
    /// <summary>
    /// Interaction logic for ProjectBrowser.xaml
    /// </summary>
    public partial class ProjectBrowser : Window
    {
        public static SolidColorBrush primaryBrushButtonColor = new SolidColorBrush(Color.FromArgb(255, 64, 68, 75));
        public static SolidColorBrush secondaryBrushButtonColor = new SolidColorBrush(Color.FromArgb(255, 111, 120, 135));
        public static SolidColorBrush selectedBrushBorderColor = new SolidColorBrush(Color.FromArgb(255, 94, 47, 122));

        public static LinearGradientBrush linearGradientBrush = new LinearGradientBrush();

        public ProjectBrowser()
        {
            InitializeComponent();

            linearGradientBrush.StartPoint = new Point(0, 0);
            linearGradientBrush.EndPoint = new Point(1, 1);
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 163, 25, 243), 0.0));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 150, 46, 209), 0.10));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 128, 55, 170), 0.20));
            linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 94, 47, 122), 1.0));

            titleText.Foreground = linearGradientBrush;
        }

        private void openProjectButton_MouseEnter(object sender, MouseEventArgs e)
        {
            openProjectButtonBackground.Background = secondaryBrushButtonColor;
        }

        private void openProjectButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (openProjectButton.IsChecked == false) { openProjectButtonBackground.Background = primaryBrushButtonColor; }
        }

        private void openProjectButton_Checked(object sender, RoutedEventArgs e)
        {
            openProjectButtonBackground.BorderBrush = linearGradientBrush;
            if (createProjectButton.IsChecked == true) { createProjectButton.IsChecked = false; }
            openProjectButtonBackground.Background = secondaryBrushButtonColor;
        }

        private void openProjectButton_Unchecked(object sender, RoutedEventArgs e)
        {
            openProjectButtonBackground.Background = primaryBrushButtonColor;
            openProjectButtonBackground.BorderBrush = primaryBrushButtonColor;
        }

        private void createProjectButton_MouseEnter(object sender, MouseEventArgs e)
        {
            createProjectButtonBackground.Background = secondaryBrushButtonColor;
        }

        private void createProjectButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (createProjectButton.IsChecked == false) { createProjectButtonBackground.Background = primaryBrushButtonColor; }
        }

        private void createProjectButton_Checked(object sender, RoutedEventArgs e)
        {
            createProjectButtonBackground.BorderBrush = linearGradientBrush;
            if (openProjectButton.IsChecked == true) { openProjectButton.IsChecked = false; }
            createProjectButtonBackground.Background = secondaryBrushButtonColor;
        }

        private void createProjectButton_Unchecked(object sender, RoutedEventArgs e)
        {
            createProjectButtonBackground.Background = primaryBrushButtonColor;
            createProjectButtonBackground.BorderBrush = primaryBrushButtonColor;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (openProjectButton.IsChecked == true) { textStackPanel.Margin = new Thickness(-800,0,0,0); }
            if (createProjectButton.IsChecked == true) { textStackPanel.Margin = new Thickness(-1600,0,0,0); }
            if (openProjectButton.IsChecked == false && createProjectButton.IsChecked == false) { textStackPanel.Margin = new Thickness(0); }
        }
    }
}
