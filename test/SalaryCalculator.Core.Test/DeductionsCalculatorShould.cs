
namespace SalaryCalculator.Core.Test
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;

	[TestClass]
	public class DeductionsCalculatorShould
	{
		private Mock<IDeductionCalculatorStep>? mockDeductionStep;

		private DeductionsCalculator? target;

		[TestInitialize]
		public void Initialise()
		{
			this.mockDeductionStep = new Mock<IDeductionCalculatorStep>();

			this.target = new DeductionsCalculator(new IDeductionCalculatorStep[]
			{
				this.mockDeductionStep.Object
			});
		}

		[TestMethod]
		[DataRow(100000f, 100000f)]
		[DataRow(1.23f, 1f)]
		[DataRow(9352.2546f, 9352f)]
		public void RoundTaxableIncomeBeforeApplyingDeductions(float taxableIncome, float expectedAmount)
		{
			var salaryPackage = new SalaryBreakdown()
			{
				TaxableIncome = taxableIncome,
			};

			this.target?.Apply(salaryPackage);

			this.mockDeductionStep?.Verify(v => v.Apply(salaryPackage, expectedAmount), Times.Once());
		}
	}
}
