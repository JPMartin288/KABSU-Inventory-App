using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecordWindow recordWindow;
        SearchWindow searchWindow;
        /// <summary>
        /// Default constructor for MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the "Add New Record" Button, opens empty RecordWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            recordWindow = new RecordWindow();
            recordWindow.Show();
        }

        /// <summary>
        /// Event handler for the "Add New Record" Button, opens new SearchWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxModifyRecord_Click(object sender, RoutedEventArgs e)
        {
            searchWindow = new SearchWindow();
            searchWindow.Show();
        }
    }
}
