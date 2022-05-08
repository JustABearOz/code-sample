using System.Globalization;
using SalaryCalculator.Core;
using SalaryCalculator.Core.PayFrequencies;

Console.Write("Enter your salary package amount: ");

var package = Console.ReadLine();

if (!float.TryParse(package, out var packageValue))
{
	Console.Error.WriteLine($"'{package}' is not a valid value");

	// Early exit
	return;
}

Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");

var payFrequencyConsoleKey = Console.ReadKey().KeyChar;

// Close out the write line from above
Console.WriteLine();

var payFrequency = new PayFrequencyFactory().GetPayFrequency(payFrequencyConsoleKey);

if (payFrequency == null)
{
	Console.Error.WriteLine($"'{payFrequencyConsoleKey}' is not a valid pay frequency option");

	// early exit
	return;
}

var calculations = new ISalaryCalculatorStep[]
	{
		new SuperannuationCalculator(),
		new TaxableIncomeCalculator(),
		new DeductionsCalculator(new IDeductionCalculatorStep[]
		{
			new MedicareLevyCalculator(),
			new BudgetRepairLevyCalculator(),
			new IncomeTaxCalculator(),
		}),
		new NetIncomeCalculator(),
		new PayPacketCalculator(),
	};

// Calculate pay packet items
var calculation = new SalaryCalculation(calculations);

var salaryPackage = new SalaryBreakdown() { PayFrequency = payFrequency, Salary = packageValue };

calculation.Apply(salaryPackage);

var renderer = new SalaryRenderer(message => Console.WriteLine(message));

renderer.RenderSalaryPackage(salaryPackage);

Console.WriteLine();
Console.WriteLine("Press any key to end...");
Console.ReadKey(false);