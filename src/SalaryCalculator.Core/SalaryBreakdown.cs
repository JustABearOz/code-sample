
namespace SalaryCalculator.Core
{
	using System.Collections.Generic;
	using SalaryCalculator.Core.PayFrequencies;

	public class SalaryBreakdown
	{
		public float Salary { get; set; }

		public float Superannutation { get; set; }

		public float TaxableIncome { get; set; }

		public float NetIncome { get; set; }

		public float PayPerPeriod { get; set; }

		public List<DeductionAmount> DeductionAmounts { get; set; } = new List<DeductionAmount>();

		public IPayFrequency? PayFrequency { get; set; }
	}
}
