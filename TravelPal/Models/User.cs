using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.InterFaces;

namespace TravelPal.Models;

public class User : IUser
{
    public List<Travel> travels { get; set; } = new();
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Location { get; set; }
    

    public User(string username, string password, Countries location)
	{
        Username = username;
        Password = password;
        Location = location;

	}
    
}
