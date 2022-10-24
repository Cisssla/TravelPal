using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.InterFaces;
using TravelPal.Models;

namespace TravelPal.Managers;


public class TravelManager
{
    public List<Travel> travels = new();

    public void AddTravel(Travel travel)
    {
        Travel newTravel = new();

        travels.Add(newTravel);

        
    }

    public void RemoveTravel(Travel travel)
    {
        Travel newTravel = new();

        travels.Remove(newTravel);
    }


}

