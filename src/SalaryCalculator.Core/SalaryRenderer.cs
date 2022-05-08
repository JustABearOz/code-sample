namespace SalaryCalculator.Core
{
	using System;
	using System.Globalization;

	/// <summary>
	/// Renderer for salary.
	/// </summary>
	public class SalaryRenderer
	{
		private readonly Action<string> writeMessage;

		public SalaryRenderer(Action<string> writeMessage)
		{
			this.writeMessage = writeMessage;
		}

		public void RenderSalaryPackage(SalaryBreakdown salaryPackage)
		{
			this.writeMessage($"Gross package: {salaryPackage.Salary:c}");
			this.writeMessage($"Superannuation: {salaryPackage.Superannutation:c}");
			this.writeMessage(string.Empty);
			this.writeMessage($"Taxable Income: {salaryPackage.TaxableIncome:c}");
			this.writeMessage(string.Empty);
			this.writeMessage($"Deductions");

			salaryPackage.DeductionAmounts.ForEach(d =>
			{
				this.writeMessage($"{d.Description}: {d.Amount:c}");
			});

			this.writeMessage(string.Empty);

			this.writeMessage($"Net Income: {salaryPackage.NetIncome:c}");
			this.writeMessage($"Pay packet: {salaryPackage.PayPerPeriod:c} per {salaryPackage?.PayFrequency?.Name?.ToLower(CultureInfo.CurrentCulture) ?? String.Empty}");

			this.writeMessage(string.Empty);
		}
	}
}