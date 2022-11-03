using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TravelPal.Enums;
using TravelPal.InterFaces;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        UserManager userManager;
        private User signedInUser;
        private bool isUserAdmin;
        private TravelManager travelManager;
        public string newUsername;
        public string newPassword;
        Countries newLocation;

        
        

        public TravelsWindow(UserManager userManager, bool isUserAdmin, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            WelcomeMessage();

            signedInUser = userManager.SignedInUser as User;

            this.isUserAdmin = isUserAdmin;
            this.travelManager = travelManager;

            UpdateTravelList();

            if (isUserAdmin)
            {
                btnAdd.IsEnabled = false;
                btnDetails.IsEnabled = false;
                btnInfo.IsEnabled = false;
                btnUser.IsEnabled = false;
                
            }

            

        }

        public void WelcomeMessage()
        {
            txtWelcome.Text = $"Welcome {userManager.SignedInUser.Username}👋";
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();

        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            
            UserDetailsWindow userDetailsWindow = new(userManager, travelManager, this);
            userDetailsWindow.Show();
            

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("With TravelPal you travel safely and comfortably to wonderful destinations all over the world. With us can you choose from a wide range of trips, from all inclusive vacations to work trips, a get away weekend and much more. Find bargains among our last minute trips or book your next trip well in advance to get that room with its own pool at your favorite hotel. You can also choose to tailor your dream trip by packaging your trip yourself", "Travel With TravelPal", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(userManager, travelManager);
            addTravelWindow.ShowDialog();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //tar bort markerad resa från listan

            ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;
           
            
            if (selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;
                travelManager.RemoveTravel(selectedTravel);
                lvTravels.Items.Remove(lvTravels.SelectedItem);
            }
            else
            {
                MessageBox.Show("You have to selecte a travel from your list, Try again!", "Warning");
            }



        }


        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            // visar detaljer av markerad resa

            ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;
                TravelDetailsWindow travelDetailsWindow = new(selectedTravel);
                travelDetailsWindow.Show();
            }
           else
            {
                MessageBox.Show("You have to selecte a travel from your list, Try again!", "Warning");
            }


        }

        private void UpdateTravelList()
        {
            if (!isUserAdmin)
            {
                foreach (Travel travel in signedInUser.travels)
                {
                    ListViewItem listViewItem = new();
                    listViewItem.Tag = travel;
                    listViewItem.Content = travel.GetInfo();
                    lvTravels.Items.Add(listViewItem);
                }
            }
            else
            {
                foreach (Travel travel in travelManager.travels)
                {
                    ListViewItem listViewItem = new();
                    listViewItem.Tag = travel;
                    listViewItem.Content = travel.GetInfo();
                    lvTravels.Items.Add(listViewItem);
                }

            }

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lvTravels.Items.Clear();
            UpdateTravelList();
        }

    }
}
