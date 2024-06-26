using System;
using Xunit;
using SplittingLibrary;

namespace SplittingTests;

public class SplitterTests
{
    [Fact]
    public void SplitAmount_EqualSplit_ReturnsCorrectAmount()
    {
        // Arrange
        var splitter = new Splitter();
        decimal totalAmount = 100;
        int numberOfPeople = 5;

        // Act
        decimal splitAmount = splitter.SplitAmount(totalAmount, numberOfPeople);

        // Assert
        Assert.Equal(20, splitAmount);
    }

    [Fact]
    public void SplitAmount_ZeroPeople_ThrowsArgumentException()
    {
        // Arrange
        var splitter = new Splitter();
        decimal totalAmount = 100;
        int numberOfPeople = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => splitter.SplitAmount(totalAmount, numberOfPeople));
    }

    [Fact]
    public void SplitAmount_DecimalAmount_ReturnsCorrectAmount()
    {
        // Arrange
        var splitter = new Splitter();
        decimal totalAmount = 99.99m;
        int numberOfPeople = 3;

        // Act
        decimal splitAmount = splitter.SplitAmount(totalAmount, numberOfPeople);

        // Assert
        Assert.Equal(33.33m, splitAmount);
    }

    [Fact]
    public void CalculateTip_ValidInputs_ReturnsCorrectTipAmounts()
    {
        // Arrange
        var splitter = new Splitter();
        var mealCosts = new Dictionary<string, decimal>
    {
        {"Alice", 20m},
        {"Bob", 30m},
        {"Charlie", 25m}
    };
        float tipPercentage = 15;

        // Act
        var tipAmounts = splitter.CalculateTip(mealCosts, tipPercentage);

        // Assert
        Assert.Equal(3, tipAmounts.Count);
        Assert.Equal(3.00m, Math.Round(tipAmounts["Alice"], 2));
        Assert.Equal(4.50m, Math.Round(tipAmounts["Bob"], 2));
        Assert.Equal(3.75m, Math.Round(tipAmounts["Charlie"], 2));
    }
    [Fact]
    public void TipPerPerson_ValidInputs_ReturnsCorrectTipAmountPerPerson()
    {
        // Arrange
        var splitter = new Splitter();
        decimal price = 100m;
        int numberOfPatrons = 5;
        float tipPercentage = 20;

        // Act
        decimal tipPerPerson = splitter.TipPerPerson(price, numberOfPatrons, tipPercentage);

        // Assert
        Assert.Equal(24m, tipPerPerson);
    }
}

