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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for NoteWindow.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {
        public event Action<string> Check;
        private string notes;
        /// <summary>
        /// Default constructor when no notes exist.
        /// </summary>
        public NoteWindow()
        {
            notes = "";
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for the window, which takes a string containing misc. notes
        /// with which to populate.
        /// </summary>
        /// <param name="notes">misc. notes for the sample</param>
        public NoteWindow(string notes)
        {
            this.notes = notes;
            InitializeComponent();
        }

        /// <summary>
        /// Event handler on closing the window. Returns the notes text
        /// to whoever was looking for it on window creation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Check != null)
                Check(uxNotesText.Text); //Sends the object to any other window currently looking
        }

        /// <summary>
        /// Event handler on window load. Populates the text box with existing notes, if any.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteWindow_Loaded(object sender, RoutedEventArgs e)
        {
            uxNotesText.Text = notes;
        }
    }
}
