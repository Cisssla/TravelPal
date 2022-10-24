using TravelPal.Enums;

namespace TravelPal.Models;

public class Travel
{
    public string Destination { get; set; }
    public Countries Country { get; set; }

    public Travel(string destination, Countries country)
    {
        Destination = destination;
        Country = country;
    }

    public virtual string GetInfo()
    {
        return Destination;
    }
}
