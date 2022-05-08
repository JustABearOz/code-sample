
namespace SalaryCalculator.Core
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class DeductionsCalculator : ISalaryCalculatorStep
	{
		private readonly IEnumerable<IDeductionCalculatorStep> deductionSteps;

		public DeductionsCalculator(IEnumerable<IDeductionCalculatorStep> deductionSteps)
		{
			this.deductionSteps = deductionSteps;
		}

		public void Apply(SalaryBreakdown salaryBrakdown)
		{
			// Round down to the nearest dollar for deductions
			var roundedTaxableIncome = Convert.ToSingle(Math.Floor(salaryBrakdown.TaxableIncome));

			foreach (var step in deductionSteps)
			{
				step.Apply(salaryBrakdown, roundedTaxableIncome);
			}
		}
	}
}
