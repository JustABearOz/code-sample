
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
			salaryBrakdown.PayPerPeriod = salaryBrakdown?.PayFrequency?.CalculePeriodPay(salaryBrakdown.NetIncome) ?? 0;
		}
	}
}
