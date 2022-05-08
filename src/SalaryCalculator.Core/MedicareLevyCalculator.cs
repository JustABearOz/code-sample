using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Core
{
	public class MedicareLevyCalculator : IDeductionCalculatorStep
	{
		private List<(Range<float> incomeRange, Func<float, float> calculation)> levyRateCalculations = new List<(Range<float> incomeRange, Func<float, float> calculation)>
		{
			new (new Range<float>(0f, 21335f), (taxableIncome) => 0f),
			new (new Range<float>(21336f, 26668f), (taxableIncome) => (taxableIncome - 21335f) * 0.1f),
			new (new Range<float>(26669f, float.MaxValue), (taxableIncome) => taxableIncome * 0.02f),
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
				Description = "Medicare Levy",
			});
		}
	}
}
