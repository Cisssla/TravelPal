using TravelPal.Enums;

namespace TravelPal.Models;

public class Trip : Travel
{
    public TripTypes Type { get; set; }

	public Trip(TripTypes type, string destination, Countries country)
		: base(destination, country)
	{
		Type = type;
	}

	public override string GetInfo()
	{
		return Type.ToString();
	}
}