using TravelPal.Enums;

namespace TravelPal.Models;

public class Travel
{
    public string Destination { get; set; }
    public Countries Country { get; set; }
    public string Travelers { get; set; }

    public Travel(string destination, Countries country, string travelers)
    {
        Destination = destination;
        Country = country;
        Travelers = travelers;
    }

    public Travel()
    {
    }

    // info om resan
    public virtual string GetInfo()
    {
        return $"{Destination}";
    }
}
