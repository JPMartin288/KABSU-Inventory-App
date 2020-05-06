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
    /// Interaction logic for AdditionalInfoWindow.xaml
    /// </summary>
    public partial class AdditionalInfoWindow : Window
    {
        public event Action<AdditionalInfo> Check;
        private AdditionalInfo info;
        /// <summary>
        /// Constructor for the window, which takes an object containing potential fields
        /// with which to populate.
        /// </summary>
        /// <param name="info">An object containing the sample's additional info not stored in the card.</param>
        public AdditionalInfoWindow(AdditionalInfo info)
        {
            this.info = info;
            InitializeComponent();
        }

        /// <summary>
        /// Event handler on closing the window. Store all relevant data in an Additional Info object, and returns it
        /// to whoever was looking for it on window creation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (uxSpeciesText.Text != null)
                info.Species = uxSpeciesText.Text;
            if (uxCityText.Text != null)
                info.City = uxCityText.Text;
            if (uxStateText.Text != null)
                info.State = uxStateText.Text;
            if (uxCountryText.Text != null)
                info.Country = uxCountryText.Text;
            if (uxValidBox.SelectedItem != null && uxValidBox.SelectedItem == uxValidTrue)
                info.Valid = true;
            else if (uxValidBox.SelectedItem != null)
                info.Valid = false;
            if (Check != null)
                Check(info); //Sends the object to any other window currently looking
        }

        /// <summary>
        /// Event handler on window load. Populates the window with previously stored fields, if any.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxInfoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            uxSpeciesText.Text = info.Species;
            uxCityText.Text = info.City;
            uxStateText.Text = info.State;
            uxCountryText.Text = info.Country;
            if (info.Valid)
                uxValidBox.SelectedItem = uxValidTrue;
            else
                uxValidBox.SelectedItem = uxValidFalse;
        }
    }
}
