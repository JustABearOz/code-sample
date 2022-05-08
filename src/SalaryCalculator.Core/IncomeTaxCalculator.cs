using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Core
{
	public class IncomeTaxCalculator : IDeductionCalculatorStep
	{
		private List<(Range<float> incomeRange, Func<float, float> calculation)> levyRateCalculations = new List<(Range<float> incomeRange, Func<float, float> calculation)>
		{
			new (new Range<float>(0f, 18200f), (taxableIncome) => 0f),
			new (new Range<float>(18201f, 37000f), (taxableIncome) => (taxableIncome - 18200) * 0.19f),
			new (new Range<float>(37001f, 87000f), (taxableIncome) => 3572f + (taxableIncome - 37000) * 0.325f),
			new (new Range<float>(87001f, 180000f), (taxableIncome) => 19822f + (taxableIncome - 87000) * 0.37f),
			new (new Range<float>(180001f, float.MaxValue), (taxableIncome) => 54232f + (taxableIncome - 180000) * 0.47f),
		};

		public void Apply(SalaryBreakdown salary, float roundedTaxableIncome)
		{
			if (roundedTaxableIncome < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(roundedTaxableIncome), "Taxable Income must be greater than or equal to 0");
			}

			var taxRateCalculation = levyRateCalculations.First(r => r.incomeRange.Includes(roundedTaxableIncome));

			salary.DeductionAmounts.Add(new DeductionAmount()
			{
				Amount = Convert.ToSingle(Math.Ceiling(taxRateCalculation.calculation(roundedTaxableIncome))),
				Description = "Income Tax",
			});
		}
	}
}
