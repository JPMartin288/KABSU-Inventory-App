/*
Copyright 2019 Shant Haik, Daley Keister, Grady Salzman, & Jacob Schilmoeller

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/
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
