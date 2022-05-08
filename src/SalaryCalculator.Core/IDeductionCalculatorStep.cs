
namespace SalaryCalculator.Core
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public interface IDeductionCalculatorStep
	{
		void Apply(SalaryBreakdown salary, float roundedTaxableIncome);
	}
}
