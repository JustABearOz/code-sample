using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Core
{
	public interface ISalaryCalculatorStep
	{
		void Apply(SalaryBreakdown salaryBrakdown);
	}
}
