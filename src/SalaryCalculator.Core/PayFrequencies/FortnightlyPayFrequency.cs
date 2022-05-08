
namespace SalaryCalculator.Core.PayFrequencies
{
	public class FortnightlyPayFrequency : PayFrequency
	{
		public FortnightlyPayFrequency()
			: base('F', "Fortnight", "Fortnightly")
		{
		}
		public override float CalculePeriodPay(float netIncome)
		{
			return netIncome / 26; // 26 fortnights per year
		}
	}
}
