using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PrimeLibrary.UnitTest
{
  [TestClass]
  public class UnitTestPrimeMethods
  {
    [DataTestMethod]
    [DynamicData(nameof(GetExpectedResults), DynamicDataSourceType.Method)]
    public void TestMethod_Generique(int source1, int source2, params int[] expected)
    {
      var result = Primes.GetPrimesBetweenTwoNumbers(source1, source2).ToArray();
      CollectionAssert.AreEquivalent(expected, result);
    }

    public static IEnumerable<object[]> GetExpectedResults()
    {
      yield return new object[] { 2, 3, 2, 3 };
      yield return new object[] { 2, 5, 2, 3, 5 };
      yield return new object[] { 2, 7, 2, 3, 5, 7 };
      yield return new object[] { 2, 9, 2, 3, 5, 7 };
      yield return new object[] { 2, 11, 2, 3, 5, 7, 11 };
    }
  }
}
