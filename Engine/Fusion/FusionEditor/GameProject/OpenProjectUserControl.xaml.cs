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
    /// Interaction logic for OpenProjectUserControl.xaml
    /// </summary>
    public partial class OpenProjectUserControl : UserControl
    {
        public static SolidColorBrush primaryBrushButtonColor = new SolidColorBrush(Color.FromArgb(255, 64, 68, 75));
        public static SolidColorBrush secondaryBrushButtonColor = new SolidColorBrush(Color.FromArgb(255, 111, 120, 135));
        public static SolidColorBrush selectedBrushBorderColor = new SolidColorBrush(Color.FromArgb(255, 94, 47, 122));

        public OpenProjectUserControl()
        {
            InitializeComponent();
        }

        private void openProjectFinalButton_MouseEnter(object sender, MouseEventArgs e)
        {
            openProjectFinalBackground.Background = secondaryBrushButtonColor;
        }

        private void openProjectFinalButton_MouseLeave(object sender, MouseEventArgs e)
        {
            openProjectFinalBackground.Background = primaryBrushButtonColor;
        }

        private void cancelFinalButton_MouseEnter(object sender, MouseEventArgs e)
        {
            cancelFinalBackground.Background = secondaryBrushButtonColor;
        }

        private void cancelFinalButton_MouseLeave(object sender, MouseEventArgs e)
        {
            cancelFinalBackground.Background = primaryBrushButtonColor;
        }

        private void openProjectFinalButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void cancelFinalButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }
    }
}
