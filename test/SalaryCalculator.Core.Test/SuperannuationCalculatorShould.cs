using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculator.Core.Test
{
	[TestClass]
	public class SuperannuationCalculatorShould
	{
		private SuperannuationCalculator target;

		[TestInitialize]
		public void Initialise()
		{
			target = new SuperannuationCalculator();
		}

		[TestMethod]
		[DataRow(100000, 9500)]
		[DataRow(65000, 6175)]
		[DataRow(1, 0.10f)] // Test for rounding to the nearest cent.
		public void CalculateSuperannuationCorrectly(float salary, float expectedResult)
		{
			var salaryBreakdown = new SalaryBreakdown()
			{
				Salary = salary,
			};

			target.Apply(salaryBreakdown);

			Assert.AreEqual(expectedResult, salaryBreakdown.Superannutation);
		}
	}
}
