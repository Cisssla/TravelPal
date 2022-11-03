using System;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        private User signedInUser;
        private bool updatedUserSuccess;
        private bool noInputs;
        private bool isUserAdmin;
        private TravelsWindow travelsWindow;
        
        public UserDetailsWindow(UserManager userManager, TravelManager travelManager, TravelsWindow travelsWindow)
        {
            InitializeComponent();

            cbxNewCountry.ItemsSource = Enum.GetValues(typeof(Countries));
            this.userManager = userManager;
            this.travelManager = travelManager;
            this.signedInUser = userManager.SignedInUser as User;
            this.travelsWindow = travelsWindow;

           
            FieldsWithUserData();

            



        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //visar användarnamn och land för den inloggade
        private void FieldsWithUserData()
        {
            txtNewUsername.Text = userManager.SignedInUser.Username;
            cbxNewCountry.Text = userManager.SignedInUser.Location.ToString();
            cbxNewCountry.IsEditable = true;
            cbxNewCountry.IsReadOnly = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Password;
            string confirmPassword = txtConfNewPassword.Password;
            Countries location = (Countries)cbxNewCountry.SelectedItem;

            updatedUserSuccess = true;

            UpdateNewUsername(username);
            UpdateNewPassword(password, confirmPassword);
            UpdateNewLocation(location);
            travelsWindow.WelcomeMessage();
            if (noInputs)
            {
                Close();
            }
            else if (updatedUserSuccess)
            {
                MessageBox.Show("Your user details have been updated!");
               
                Close();

                
            }

        }



        private void UpdateNewLocation(Countries location)
        {
            userManager.SignedInUser.Location = location;

        }

        private void UpdateNewPassword(string password, string confirmPassword)
        {
            if (!string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(confirmPassword))
            {
                noInputs = false;

                //kolla ifall det är minst 5 tecken i lösenordet
                if (ValidatePasswordLength(password))
                {
                    //kolla så att password och confirmpassword e samma 
                    if (password == confirmPassword)
                    {
                        userManager.UpdatePassword(userManager.SignedInUser, password);
                    }
                    else
                    {
                        updatedUserSuccess = false;
                        MessageBox.Show("Password dosen't match, try again", "warning");
                    }
                }

            }

        }
        private bool ValidatePasswordLength(string password)
        {
            if (password.Length >= 5)
            {
                return true;
            }
            else
            {
                updatedUserSuccess = false;
                MessageBox.Show("Password need to be at least 5 characters long, try again", "warning");
                return false;
            }
        }

        private void UpdateNewUsername(string username)
        {
            if (username != userManager.SignedInUser.Username)
            {
                noInputs = false;

                if (ValidateUsernameLength(username))
                {
                    updatedUserSuccess = userManager.UpdateUsername(userManager.SignedInUser, username);
                    
                    if (!updatedUserSuccess)
                    {
                        MessageBox.Show("Username is already taken, try again", "warning", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                noInputs = true;
            }
        }

        private bool ValidateUsernameLength(string username)
        {
            if (username.Length >= 3)
            {
                return true;
            }
            else
            {
                updatedUserSuccess = false;
                MessageBox.Show("Username need to have at least 3 characters, try again", "warning", MessageBoxButton.OK);
                return false;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
