using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.InterFaces;

namespace TravelPal.Models;

public class User : IUser
{
    public List<Travel> travels = new();
}
