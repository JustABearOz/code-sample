namespace SalaryCalculator.Core.PayFrequencies
{
	public interface IPayFrequency
	{
		string Description { get; }

		char Key { get; }

		string Name { get; }

		float CalculePeriodPay(float netIncome);
	}
}