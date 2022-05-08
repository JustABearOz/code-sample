namespace SalaryCalculator.Core
{
	public class Range<T> where T: IComparable<T>
	{
		public Range(T startValue, T endValue)
		{		
			StartValue = startValue;
			EndValue = endValue;
		}

		public T StartValue { get; private set; }

		public T EndValue { get; private set; }

		public bool Includes(T value)
		{
			ArgumentNullException.ThrowIfNull(value, nameof(value));
			ArgumentNullException.ThrowIfNull(this.StartValue, nameof(this.StartValue));
			ArgumentNullException.ThrowIfNull(this.EndValue, nameof(this.EndValue));

			return value.CompareTo(this.StartValue) >= 0 && value.CompareTo(this.EndValue) <= 0;
		}
	}
}
