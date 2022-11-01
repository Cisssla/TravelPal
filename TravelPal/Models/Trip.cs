using TravelPal.Enums;

namespace TravelPal.Models;

public class Trip : Travel
{
    public TripTypes Type { get; set; }

	public Trip(TripTypes type, string destination, Countries country, string travelers)
		: base(destination, country, travelers)
	{
		Type = type;
	}

	//info om resan
	public override string GetInfo()
	{
		return base.GetInfo();
	}
}