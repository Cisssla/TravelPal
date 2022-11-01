using System;
using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.InterFaces;
using TravelPal.Models;

namespace TravelPal.Managers;
public class UserManager
{
    public List<IUser> users { get; set; } = new();
    public List<IUser> GetAllUsers()
    {
        return users;
    }
    public IUser SignedInUser { get; set; }

    public UserManager()
    {
        ValidatedUser();
    }

    //skapa admin och user
    private void ValidatedUser()
    {
        Admin admin = new("admin", "password", Countries.Aruba);
        users.Add(admin);

        User cissi = new("Cissi", "hej", Countries.Bahamas);
        users.Add(cissi);

        User gandalf = new("Gandalf", "password", Countries.Bahamas);
        users.Add(gandalf);
        Vacation vacation1 = new(true,"Santiago", Countries.Chile,"3");
        gandalf.travels.Add(vacation1);
        Vacation vacation2 = new(false, "Helsinki", Countries.Finland, "7");
        gandalf.travels.Add(vacation2);
    }

    public bool AddUser(IUser newUser)
    {
        //lägg till användare i listan
      if (ValidateUsername(newUser.Username))
        {
            users.Add(newUser);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RemoveUser(IUser userToRemove)
    {
        //ta bort användare från listan
        users.Remove(userToRemove);
    }
     public bool UpdateUsername(IUser userToUpdate)
    {
        //uppdatera användare
        return true;
    }
    private bool ValidateUsername(string username)
    {
        //kolla om användarnamnet är upptaget
        foreach (IUser user in users)
        {
            if (user.Username == username)
            {
                return false;
            }
            
        }
        return true;

    }
    //logga in användaren
    public bool SignInUser(string username, string password)
    {
        foreach(IUser user in users)
        {
            if(user.Username == username && user.Password == password)
            {
                SignedInUser = user;
                return true;
            }
                
            
        }
        return false;
    }

    //kolla ifall användaren är admin
    public bool CheckIfAdmin()
    {
        if(SignedInUser is Admin)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }


}

