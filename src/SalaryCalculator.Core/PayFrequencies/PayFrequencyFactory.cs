namespace SalaryCalculator.Core.PayFrequencies
{
	using System.Linq;

	public class PayFrequencyFactory
	{
		// static list of pay frequencies, ideally this would be loaded from an external repository
		private static IPayFrequency[] allPayFrequencies = new IPayFrequency[]
		{
			new WeeklyPayFrequency(),
			new FortnightlyPayFrequency(),
			new MonthlyPayFrequency(),
		};

		public IPayFrequency? GetPayFrequency(char payFrequencyKey)
		{
			// Make sure we are comparing upper case only
			if (!char.IsUpper(payFrequencyKey))
			{
				payFrequencyKey = char.ToUpper(payFrequencyKey);
			}

			return allPayFrequencies.FirstOrDefault(p => p.Key.Equals(payFrequencyKey));
		}
	}
}