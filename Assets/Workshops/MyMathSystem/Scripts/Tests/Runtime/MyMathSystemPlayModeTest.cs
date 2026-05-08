using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyMathSystemPlayModeTest
{
    [UnityTest]
    public IEnumerator Add_ResultIs15_When5And10_()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();
        
        // Act
        int sum = myMathSystem.Add(5, 10);
        
        // Await
        yield return new WaitForSeconds(0.2f);
        
        // Assert
        Assert.That(sum, Is.EqualTo(15));
    }

    [UnityTest]
    public IEnumerator Subtract_ResultIs5_When10And5_()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int difference = myMathSystem.Subtract(10, 5);

        // Await
        yield return new WaitForSeconds(0.2f);

        // Assert
        Assert.That(difference, Is.EqualTo(5));
    }

    [UnityTest]
    public IEnumerator Divide_ResultIs2_When10And5_()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int quotient = myMathSystem.Divide(10, 5);

        // Await
        yield return new WaitForSeconds(0.2f);

        // Assert
        Assert.That(quotient, Is.EqualTo(2));
    }

    [UnityTest]
    public IEnumerator Multiply_ResultIs50_When10And5_()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        MyMathSystem myMathSystem = gameObject.AddComponent<MyMathSystem>();

        // Act
        int product = myMathSystem.Multiply(10, 5);

        // Await
        yield return new WaitForSeconds(0.2f);

        // Assert
        Assert.That(product, Is.EqualTo(50));
    }
}
