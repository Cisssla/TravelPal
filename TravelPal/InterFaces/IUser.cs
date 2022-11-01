using TravelPal.Enums;

namespace TravelPal.InterFaces;

public interface IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Location { get; set; }

    
}
