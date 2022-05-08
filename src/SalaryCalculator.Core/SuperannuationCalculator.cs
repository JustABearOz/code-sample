namespace SalaryCalculator.Core
{
	public class SuperannuationCalculator : ISalaryCalculatorStep
	{
		// Ideally this would be configurable somewhere,
		// possibly linked to a start date
		private const float superRate = 9.5f;

		public void Apply(SalaryBreakdown salaryBrakdown)
		{
			// Calculate super amount
			 var superAmount = salaryBrakdown.Salary * (superRate / 100);

			// Round up to the nearest cent
			salaryBrakdown.Superannutation = Convert.ToSingle(Math.Round(superAmount, 2, MidpointRounding.ToPositiveInfinity));
		}
	}
}
