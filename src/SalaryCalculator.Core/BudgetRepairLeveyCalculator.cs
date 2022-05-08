using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Core
{
	public class BudgetRepairLevyCalculator : IDeductionCalculatorStep
	{
		private List<(Range<float> incomeRange, Func<float, float> calculation)> levyRateCalculations = new List<(Range<float> incomeRange, Func<float, float> calculation)>
		{
			new (new Range<float>(0f, 180000f), (taxableIncome) => 0f),
			new (new Range<float>(180001f, float.MaxValue), (taxableIncome) => taxableIncome * 0.02f),
		};

		public void Apply(SalaryBreakdown salary, float roundedTaxableIncome)
		{
			if (roundedTaxableIncome < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(roundedTaxableIncome), "TaxableIncome must be greater than or equal to 0");
			}

			var levyRateCalculation = levyRateCalculations.First(r => r.incomeRange.Includes(roundedTaxableIncome));

			salary.DeductionAmounts.Add(new DeductionAmount()
			{
				Amount = levyRateCalculation.calculation(roundedTaxableIncome),
				Description = "Budget Repair Levy",
			});
		}
	}
}
