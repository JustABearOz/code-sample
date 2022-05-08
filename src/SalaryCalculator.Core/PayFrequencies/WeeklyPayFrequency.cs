
namespace SalaryCalculator.Core.PayFrequencies
{
	public class WeeklyPayFrequency : PayFrequency
	{
		public WeeklyPayFrequency()
			: base('W', "Week", "Weekly")
		{
		}

		public override float CalculePeriodPay(float netIncome)
		{
			return netIncome / 52; // 52 weeks a year
		}
	}
}
