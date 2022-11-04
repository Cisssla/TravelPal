using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.InterFaces;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            cbxCountry.ItemsSource = Enum.GetValues(typeof(Countries));

            this.userManager = userManager;


        }

        // användaren kan skapa ett konto, kollar så att inte användarnamnet är upptaget, kollar så att password matchar med confirmpassword, alla fields måste vara ifyllda
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
           
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            Countries location = (Countries)cbxCountry.SelectedItem;

            User user = new(username, password, location);

            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Password) && !string.IsNullOrEmpty(txtConfPassword.Password) && cbxCountry != null)
            {
                if (txtPassword.Password == txtConfPassword.Password)
                {
                    if (this.userManager.AddUser(user))
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Username is already taken, try again", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("Password don't match, try again!", "Warning");
                }

            }
            else
            {
                MessageBox.Show("All fields must be filled!", "Warning");
            }



        }

        //combobox med länder
        private void cbxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
