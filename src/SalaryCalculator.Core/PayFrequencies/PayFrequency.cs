
namespace SalaryCalculator.Core.PayFrequencies
{
	public class PayFrequency : IPayFrequency
	{
		private readonly char key;

		private readonly string name;

		private readonly string description;

		public PayFrequency(char key, string name, string description)
		{
			this.key = key;
			this.description = description;
			this.name = name;
		}

		public string Name => this.name;

		public char Key => this.key;

		public string Description => this.description;
	}
}
