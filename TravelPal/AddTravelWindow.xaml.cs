using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        UserManager userManager;
        TravelManager travelManager;
        User signedInUser;
        public AddTravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            cbxCountry.ItemsSource = Enum.GetValues(typeof(Countries));
            cbxTripOrVacation.ItemsSource = Enum.GetValues(typeof(TripOrVacation));
            cbxTripType.ItemsSource = Enum.GetValues(typeof(TripTypes));
            this.userManager = userManager;
            this.travelManager = travelManager;
            this.signedInUser = userManager.SignedInUser as User;

        }


        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cbxTripOrVacation.SelectedItem.ToString() == TripOrVacation.Vacation.ToString())
            {
                chbAllInclusive.Visibility = Visibility.Visible;
                cbxTripType.Visibility = Visibility.Hidden;
                lblTripType.Visibility = Visibility.Hidden;
            }
            else
            {
                cbxTripType.Visibility = Visibility.Visible;
                lblTripType.Visibility = Visibility.Visible;
                chbAllInclusive.Visibility = Visibility.Hidden;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string destination = txtDestination.Text;
            string travelers = txtTravelers.Text;
            Countries location = (Countries)cbxCountry.SelectedItem;

            Travel travel;
            if (cbxTripOrVacation.SelectedItem.ToString() == TripOrVacation.Vacation.ToString())
            {
                travel = new Vacation(chbAllInclusive.IsChecked == true, destination, location, travelers);
            }
            else
            {
                travel = new Trip(Enum.Parse<TripTypes>(cbxTripType.SelectedItem.ToString()), destination, location, travelers);
            }

            if (!string.IsNullOrEmpty(txtDestination.Text) && !string.IsNullOrEmpty(txtTravelers.Text) && cbxCountry != null)
            {

                travelManager.AddTravel(travel);
                MessageBox.Show("Your travel has been added to your list", "Travel added", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("All fields must be filled!", "Warning");
            }
        }

        private void cbxTripType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
