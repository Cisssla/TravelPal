using System;
using System.Collections.Generic;
using TravelPal.InterFaces;
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

        PopulateTravelsList();
    }

    //
    private void PopulateTravelsList()
    {
        foreach (IUser user in userManager.users)
        {
            if (user.Username == "Gandalf")
            {
                User gandalf = user as User;
                foreach (Travel travel in gandalf.travels)
                {
                    travels.Add(travel);
                }
            }
        }
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