using TravelPal.Enums;

namespace TravelPal.Models;

public class Vacation : Travel
{
    public bool AllInclusive { get; set; }

	public Vacation(bool allInclusive, string destination, Countries countries)
		: base(destination, countries)
	{
		AllInclusive = allInclusive;
	}

	public override string GetInfo()
	{
		return AllInclusive.ToString();
	}
}
