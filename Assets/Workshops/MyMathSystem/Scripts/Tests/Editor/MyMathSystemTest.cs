using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyMathSystemTest
{
    private static int[] ValuesA = new int[] { -1, -2, -3, 0, 1, 2, 3 };
    private static int[] ValuesB = new int[] { -1, -2, -3, 0, 1, 2, 3 };
    
    [Test]
    public void Add_ResultIs15_When5And10()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int sum = myMathSystem.Add(5, 10);

        // Assert
        Assert.That(sum, Is.EqualTo(15));
    }

    [Test]
    public void Subtract_ResultIs5_When10And5()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int difference = myMathSystem.Subtract(10, 5);

        // Assert
        Assert.That(difference, Is.EqualTo(5));
    }

    [Test]
    public void Divide_ResultIs2_When10And5()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int quotient = myMathSystem.Divide(10, 5);

        // Assert
        Assert.That(quotient, Is.EqualTo(2));
    }

    [Test]
    public void Add_ResultIsCorrect_WhenValues(
        [ValueSource("ValuesA")] int valuesA, 
        [ValueSource("ValuesB")] int valuesB )
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int sum = myMathSystem.Add(valuesA, valuesB);

        // Assert
        Assert.That(sum, Is.EqualTo(valuesA + valuesB));
    }
    

    [Test]
    public void Subtract_ResultIsCorrect_WhenValues(
        [ValueSource("ValuesA")] int valuesA,
        [ValueSource("ValuesB")] int valuesB)
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int difference = myMathSystem.Subtract(valuesA, valuesB);

        // Assert
        Assert.That(difference, Is.EqualTo(valuesA - valuesB));
    }

    [Test]
    public void Divide_ResultIsCorrect_WhenValues(
        [ValueSource("ValuesA")] int valuesA,
        [ValueSource("ValuesB")] int valuesB)
    {
        // Arrange
        if (valuesB == 0)
        {
            return;
        }

        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int quotient = myMathSystem.Divide(valuesA, valuesB);

        // Assert
        Assert.That(quotient, Is.EqualTo(valuesA / valuesB));
    }

    [Test]
    public void Divide_ThrowsException_WhenDivideByZero()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => myMathSystem.Divide(10, 0));
    }

    [Test]
    public void Multiply_ResultIs50_When10And5()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int product = myMathSystem.Multiply(10, 5);

        // Assert
        Assert.That(product, Is.EqualTo(50));
    }

    [Test]
    public void Multiply_ResultIsCorrect_WhenValues(
        [ValueSource("ValuesA")] int valuesA,
        [ValueSource("ValuesB")] int valuesB)
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int product = myMathSystem.Multiply(valuesA, valuesB);

        // Assert
        Assert.That(product, Is.EqualTo(valuesA * valuesB));
    }
}
