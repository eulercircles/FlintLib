namespace FLib.Scheduling
{
	public enum Months
	{
		UNDEFINED = 0,
		January = 1,
		February = 2,
		March = 3,
		April = 4,
		May = 5,
		June = 6,
		July = 7,
		August = 8,
		September = 9,
		October = 10,
		November = 11,
		December = 12
	}

	public enum MonthlyStyles
	{
		OnDay,
		FirstDay,
		LastDay
	}

	public enum SemiMonthlyStyles
	{
		UNDEFINED,
		FirstAndFifteenth,
		FifteenthAndLast
	}

	public enum CorrectionMethods
	{
		None,
		Before,
		After
	}
}
