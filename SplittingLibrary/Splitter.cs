using System;
using System.Collections.Generic;
using System.Linq;

namespace SplittingLibrary;
public class Splitter
{
    public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
    {
        if (numberOfPeople == 0)
            throw new ArgumentException("Number of people cannot be zero.");

        return totalAmount / numberOfPeople;
    }

    public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        if (mealCosts == null || mealCosts.Count == 0)
            throw new ArgumentException("Meal costs dictionary cannot be null or empty.");

        var tipAmounts = new Dictionary<string, decimal>();
        decimal totalCost = mealCosts.Values.Sum();
        decimal tip = totalCost * (decimal)(tipPercentage / 100);

        foreach (var entry in mealCosts)
        {
            decimal percentage = entry.Value / totalCost;
            decimal individualTip = tip * percentage;
            tipAmounts.Add(entry.Key, individualTip);
        }

        return tipAmounts;
    }
    public decimal TipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
    {
        if (numberOfPatrons == 0)
            throw new ArgumentException("Number of patrons cannot be zero.");

        decimal totalAmount = price * (1 + (decimal)(tipPercentage / 100));
        return totalAmount / numberOfPatrons;
    }
}
