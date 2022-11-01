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
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        private Travel selectedTravel;

        public TravelDetailsWindow(Travel selectedTravel)
        {
            InitializeComponent();

            this.selectedTravel = new();

            txtDestination.Text = selectedTravel.Destination;
            txtCountry.Text = selectedTravel.Country.ToString();
            txtTravelers.Text = selectedTravel.Travelers.ToString();
            txtType.Text = selectedTravel.GetType() == typeof(Vacation) ? nameof(Vacation) : nameof(Trip);

            if (selectedTravel.GetType() == typeof(Vacation))
            {
                chbAllinclusive.Visibility = Visibility.Visible;
                chbAllinclusive.IsChecked = (selectedTravel as Vacation)!.AllInclusive;
                txtWorkOr.Visibility = Visibility.Hidden;
                lblWorkOr.Visibility = Visibility.Hidden;
            }
            else if (selectedTravel.GetType() == typeof(Trip))
            {
                chbAllinclusive.Visibility = Visibility.Hidden;
                txtWorkOr.Visibility = Visibility.Visible;
                lblWorkOr.Visibility = Visibility.Visible;
                switch ((selectedTravel as Trip)!.Type)
                {
                    case Enums.TripTypes.Leisure:
                        txtWorkOr.Text = nameof(Enums.TripTypes.Leisure);
                        break;

                    case Enums.TripTypes.Work:
                        txtWorkOr.Text = nameof(Enums.TripTypes.Work);
                        break;
                }

            }

        }

    }


}
