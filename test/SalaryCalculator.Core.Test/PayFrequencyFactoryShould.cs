
namespace SalaryCalculator.Core.Test;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator.Core.PayFrequencies;

[TestClass]
public class PayFrequencyFactoryShould
{
    private PayFrequencyFactory? target;

    [TestInitialize]
    public void Initialise()
    {
        this.target = new PayFrequencyFactory();
    }

    [TestMethod]
    [DataRow('W', typeof(WeeklyPayFrequency))]
    [DataRow('w', typeof(WeeklyPayFrequency))]
    [DataRow('F', typeof(FortnightlyPayFrequency))]
    [DataRow('f', typeof(FortnightlyPayFrequency))]
    [DataRow('M', typeof(MonthlyPayFrequency))]
    [DataRow('m', typeof(MonthlyPayFrequency))]
    public void ReturnTheCorrectPayFrequency(char payFrequencyKey, Type expectedPayFrequencyType)
    {
        var resolvedPayFrequency = this.target?.GetPayFrequency(payFrequencyKey);

        Assert.AreEqual(resolvedPayFrequency?.GetType(), expectedPayFrequencyType);
    }

    [TestMethod]
    public void ReturnNullForInvalidPayFrequency()
    {
        // 'Q' is not a valid key for a pay frequency
        var result = target?.GetPayFrequency('Q');

        Assert.IsNull(result);
    }
}