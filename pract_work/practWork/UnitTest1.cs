using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace PracticalWork;


public static class Functions
{
    
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static bool IsEv(int n)
    {
        return n % 2 == 0;
    }

    public static int maxofT(int a, int b)
    {
        return Math.Max(a, b);
    }

    public static double Divide(double a, double b)
    {
        if(b == 0)
        {
            throw new ArgumentException("деление на ноль");
        }
        return a / b;
    }

}



[TestFixture]

public class FunctTest
{


    [Test]

    public void TestAddPos()
    {
        Assert.That(Functions.Add(2,2), Is.EqualTo(4));
    }

    [Test]
    public void TeastaddNegative()
    {
        Assert.That(Functions.Add(-2, -5), Is.EqualTo(-7));
    }
    [Test]
    public void TestIsEvenTrue()
    {
        
        Assert.That(Functions.IsEv(4), Is.True);
    }

    [Test]
    public void TestIsEvenFalse()
    {
        
        Assert.That(Functions.IsEv(7), Is.False);
    }

    

    [Test]
    public void TestMaxFirst()
    {
        
        Assert.That(Functions.maxofT(10, 5), Is.EqualTo(10));
    }

    [Test]
    public void TestMaxSecond()
    {
       
        Assert.That(Functions.maxofT(1, 9), Is.EqualTo(9));
    }

    

    [Test]
    public void TestDivideSimple()
    {
       
        Assert.That(Functions.Divide(10, 2), Is.EqualTo(5.0));
    }

    [Test]
    public void TestDivideByZero()
    {
        
        Assert.That(() => Functions.Divide(10, 0), Throws.TypeOf<ArgumentException>());
    }

}