using System.Collections.Generic;
using System.Windows;
using TravelPal.InterFaces;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private List<IUser> users = new();
        private UserManager userManager = new();

        public MainWindow()
        {
            InitializeComponent();

            
        }

        //logga in för att komma till travelwindow
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            
            users = userManager.GetAllUsers();

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            bool isFoundUser = userManager.SignInUser(username, password);
            bool isUserAdmin = userManager.CheckIfAdmin();

            if (isFoundUser)
            {
                TravelManager travelManager = new(userManager);
                TravelsWindow travelsWindow = new(userManager, isUserAdmin, travelManager);
                travelsWindow.Show();

                Close();
            }

            else
            {
                MessageBox.Show("Username or password is incorrect", "Warning");
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);

            registerWindow.Show();

        }
    }
}
