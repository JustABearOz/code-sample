
namespace SalaryCalculator.Core
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class PayPacketCalculator : ISalaryCalculatorStep
	{
		public void Apply(SalaryBreakdown salaryBrakdown)
		{
			if (salaryBrakdown == null)
			{
				return;
			}

			var payPerPeriod = salaryBrakdown?.PayFrequency?.CalculePeriodPay(salaryBrakdown.NetIncome) ?? 0;

			salaryBrakdown.PayPerPeriod = (float)Math.Round(payPerPeriod, 2);
		}
	}
}
