using TravelPal.Enums;

namespace TravelPal.Models;

public class Vacation : Travel
{
    public bool AllInclusive { get; set; }

	public Vacation(bool allInclusive, string destination, Countries countries, string travelers)
		: base(destination, countries, travelers)
	{
		AllInclusive = allInclusive;
	}

	//info om resan
	public override string GetInfo()
	{
		return base.GetInfo();
	}
}
