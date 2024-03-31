using FusionEditor.GameProject;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FusionEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnMainWindowLoaded;
        }

        /// <summary>
        /// Executes when the main window is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnMainWindowLoaded;
            OpenProjectBrowserDialog();
        }

        /// <summary>
        /// Opens the engine browser dialog.
        /// </summary>
        private void OpenProjectBrowserDialog()
        {
            var projectBrowser = new ProjectBrowser();
            if (projectBrowser.ShowDialog() == false)
            {
                Application.Current.Shutdown();
            }
            else
            {

            }
        }
    }
}