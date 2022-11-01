using TravelPal.Enums;
using TravelPal.InterFaces;

namespace TravelPal.Models;

public class Admin : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Location { get; set; }
    public Admin(string username, string password, Countries location)
    {
        Username = username;
        Password = password;
        Location = location;
    }

}



