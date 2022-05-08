
namespace SalaryCalculator.Core.PayFrequencies
{
	public class MonthlyPayFrequency : PayFrequency
	{
		public MonthlyPayFrequency()
			: base('M', "Month", "Monthly")
		{
		}

		public override float CalculePeriodPay(float netIncome)
		{
			return netIncome / 12; // 12 months a year
		}
	}
}
