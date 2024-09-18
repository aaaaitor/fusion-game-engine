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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FusionEditor.GameProject
{
    /// <summary>
    /// Interaction logic for NewProjectUserControl.xaml
    /// </summary>
    public partial class NewProjectUserControl : UserControl
    {
        public static SolidColorBrush primaryBrushButtonColor = new SolidColorBrush(Color.FromArgb(255, 64, 68, 75));
        public static SolidColorBrush secondaryBrushButtonColor = new SolidColorBrush(Color.FromArgb(255, 111, 120, 135));
        public static SolidColorBrush selectedBrushBorderColor = new SolidColorBrush(Color.FromArgb(255, 94, 47, 122));

        public NewProjectUserControl()
        {
            InitializeComponent();
        }

        private void createProjectFinalButton_MouseEnter(object sender, MouseEventArgs e)
        {
            createProjectFinalBackground.Background = secondaryBrushButtonColor;
        }

        private void createProjectFinalButton_MouseLeave(object sender, MouseEventArgs e)
        {
            createProjectFinalBackground.Background = primaryBrushButtonColor;
        }

        private void cancelFinalButton_MouseEnter(object sender, MouseEventArgs e)
        {
            cancelFinalBackground.Background = secondaryBrushButtonColor;
        }

        private void cancelFinalButton_MouseLeave(object sender, MouseEventArgs e)
        {
            cancelFinalBackground.Background = primaryBrushButtonColor;
        }

        private void cancelFinalButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void createProjectFinalButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as NewProject;
            var projectPath = vm.CreateProject(templateListBox.SelectedItem as ProjectTemplate);
            bool dialogResult = false;
            var win = Window.GetWindow(this);
            if (!string.IsNullOrEmpty(projectPath))
            {
                dialogResult = true;
            }
            win.DialogResult = dialogResult;
            win.Close();
        }

        private void browseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            browseBackground.Background = secondaryBrushButtonColor;
        }

        private void browseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            browseBackground.Background = primaryBrushButtonColor;
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }
    }
}
