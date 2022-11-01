using System.Collections.Generic;
using TravelPal.Models;

namespace TravelPal.Managers;

public class TravelManager
{

    public List<Travel> travels = new();
    private UserManager userManager;
    private User signedInUser;
    public TravelManager(UserManager userManager)
    {
        this.userManager = userManager;
        this.signedInUser = userManager.SignedInUser as User;
    }

    //lägg till en resa
    public void AddTravel(Travel travel)
    {
        travels.Add(travel); 
        signedInUser.travels.Add(travel);
    }

    //ta bort en resa
    public void RemoveTravel(Travel travel)
    {
        Travel selectedTravel = new();
        travels.Remove(selectedTravel);
    }
}