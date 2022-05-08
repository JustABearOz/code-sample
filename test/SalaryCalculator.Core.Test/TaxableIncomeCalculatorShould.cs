
namespace SalaryCalculator.Core.Test
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class TaxableIncomeCalculatorShould
	{
		private TaxableIncomeCalculator? target;

		[TestInitialize]
		public void Initialise()
		{
			this.target = new TaxableIncomeCalculator();
		}

		[TestMethod]
		[DataRow(100000f, 9500f, 90500f)]
		[DataRow(65000f, 6175f, 58825)]
		[DataRow(10f, 0.95f, 9.05f)]
		public void CalculateTaxableIncome(float salary, float super, float expectedResult)
		{
			var salaryBreakdown = new SalaryBreakdown()
			{
				Salary = salary,
				Superannutation = super,
			};

			this.target?.Apply(salaryBreakdown);

			Assert.AreEqual(salaryBreakdown.TaxableIncome, expectedResult);
		}
	}
}
