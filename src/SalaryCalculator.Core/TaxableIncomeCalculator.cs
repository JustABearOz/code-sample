
namespace SalaryCalculator.Core
{
	public class TaxableIncomeCalculator : ISalaryCalculatorStep
	{
		public void Apply(SalaryBreakdown salaryBrakdown)
		{
			salaryBrakdown.TaxableIncome = salaryBrakdown.Salary - salaryBrakdown.Superannutation;
		}
	}
}
