using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Core
{
	public class SalaryCalculation
	{
		private readonly IEnumerable<ISalaryCalculatorStep> calculations;

		public SalaryCalculation(IEnumerable<ISalaryCalculatorStep> calculations)
		{
			this.calculations = calculations;
		}

		public void Apply(SalaryBreakdown salaryPackage)
		{
			foreach (var calculation in this.calculations)
			{
				calculation.Apply(salaryPackage);
			}
		}
	}
}
