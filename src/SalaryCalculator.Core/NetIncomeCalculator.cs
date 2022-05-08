namespace SalaryCalculator.Core
{
	using System.Linq;

	public class NetIncomeCalculator : ISalaryCalculatorStep
	{
		public void Apply(SalaryBreakdown salaryBrakdown)
		{
			salaryBrakdown.NetIncome = salaryBrakdown.TaxableIncome
				- salaryBrakdown.DeductionAmounts.Sum(deduction => deduction.Amount);
		}
	}
}
