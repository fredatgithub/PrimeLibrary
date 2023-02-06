using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PrimeLibrary.UnitTest
{
  [TestClass]
  public class UnitTestPrimeMethods
  {
    [DataTestMethod]
    [TestCategory("GetPrimesBetweenTwoNumbers")]
    [DynamicData(nameof(GetExpectedResultsForPrimesBetweenTwoNumbers), DynamicDataSourceType.Method)]
    public void TestMethod_Generique(int source1, int source2, params int[] expected)
    {
      var result = Primes.GetPrimesBetweenTwoNumbers(source1, source2).ToArray();
      CollectionAssert.AreEquivalent(expected, result);
    }

    public static IEnumerable<object[]> GetExpectedResultsForPrimesBetweenTwoNumbers()
    {
      yield return new object[] { 2, 3, 2, 3 };
      yield return new object[] { 2, 5, 2, 3, 5 };
      yield return new object[] { 2, 7, 2, 3, 5, 7 };
      yield return new object[] { 2, 9, 2, 3, 5, 7 };
      yield return new object[] { 2, 11, 2, 3, 5, 7, 11 };
    }

    [DataTestMethod]
    [TestCategory("IsPrimeTriplet")]
    [DataRow(3, true)]
    [DataRow(5, false)]
    [DataRow(101, false)]
    [DataRow(191, false)]
    public void TestMethod_IsPrimeTriplet(int source, bool expected)
    {
      var result = Primes.IsPrimeTriplet(source);
      Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [TestCategory("IsPrimeQuadruplet")]
    [DataRow(11, true)]
    [DataRow(101, true)]
    [DataRow(191, true)]
    [DataRow(821, true)]
    public void TestMethod_IsPrimeQuadruplet(int source, bool expected)
    {
      var result = Primes.IsPrimeQuadruplet(source);
      Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [TestCategory("GetCircular")]
    [DynamicData(nameof(GetExpectedResultsForCircularPrimes), DynamicDataSourceType.Method)]
    public void TestMethod_GetCircular(int source, params int[] expected)
    {
      var result = Primes.GetCircular(source).ToArray();
      Assert.AreEqual(expected, result);
    }

    public static IEnumerable<object[]> GetExpectedResultsForCircularPrimes()
    {
      yield return new object[] { 3, 3 };
      yield return new object[] { 9, 9 };
      //yield return new object[] { 11, 11 };
      //yield return new object[] { 13, 13 };
      //yield return new object[] { 17, 17 };
      //yield return new object[] { 19, 19 };
      //yield return new object[] { 113, 131, 311, 113 };
    }

    [TestMethod]
    public void TestMethod_GetCircular_3()
    {
      var source = 3;
      var expected = new List<int> { 3 };
      var result = Primes.GetCircular(source);
      CollectionAssert.AreEquivalent(expected, result);
    }

    [TestMethod]
    public void TestMethod_GetCircular_11()
    {
      var source = 11;
      var expected = new List<int> { 11 };
      var result = Primes.GetCircular(source);
      CollectionAssert.AreEquivalent(expected, result);
    }

    [TestMethod]
    public void TestMethod_GetCircular_13()
    {
      var source = 13;
      var expected = new List<int> { 13, 31 };
      var result = Primes.GetCircular(source);
      CollectionAssert.AreEquivalent(expected, result);
    }

    [TestMethod]
    [TestCategory("IsCubanPrime")]
    [DataRow(6, false)]
    [DataRow(7, true)]
    [DataRow(19, false)]
    [DataRow(37, true)]
    [DataRow(61, false)]
    [DataRow(127, true)]
    [DataRow(331, true)]
    [DataRow(397, false)]
    [DataRow(547, true)]
    [DataRow(631, true)]
    [DataRow(13, true)]
    [DataRow(109, true)]
    [DataRow(193, false)]
    [DataRow(433, false)]
    [DataRow(769, true)]
    public void TestMethod_IsCubanPrime(int source, bool expected)
    {
      //7, 19, 37, 61, 127, 271, 331, 397, 547, 631, 919, 1657, 1801, 1951, 2269, 2437, 2791, 3169, 3571, 4219, 4447, 5167, 5419, 6211, 7057, 7351, 8269, 9241, 10267, 11719, 12097, 13267, 13669, 16651, 19441, 19927, 22447, 23497, 24571, 25117, 26227, 27361, 33391, 35317 
      // 13, 109, 193, 433, 769, 1201, 1453, 2029, 3469, 3889, 4801, 10093, 12289, 13873, 18253, 20173, 21169, 22189, 28813, 37633, 43201, 47629, 60493, 63949, 65713, 69313, 73009, 76801, 84673, 106033, 108301, 112909, 115249 
      var result = Primes.IsCubanPrime(source);
      Assert.AreEqual(expected, result);

    }

    [DataTestMethod]
    [TestCategory("IsCousinPrime")]
    [DataRow(3, true)]
    [DataRow(4, false)]
    [DataRow(7, true)]
    [DataRow(13, true)]
    [DataRow(19, true)]
    [DataRow(37, true)]
    [DataRow(43, true)]
    [DataRow(67, true)]
    [DataRow(79, true)]
    [DataRow(97, true)]
    [DataRow(103, true)]
    [DataRow(109, true)]
    [DataRow(127, true)]
    [DataRow(163, true)]
    [DataRow(193, true)]
    [DataRow(223, true)]
    [DataRow(229, true)]
    [DataRow(277, true)]
    public void TestMethod_IsCousinPrime(int source, bool expected)
    {
      var result = Primes.IsCousinPrime(source);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow(3, true)]
    [DataRow(5, false)]
    public void TestMethod_IsCullenPrime(int source, bool expected) 
    {
      var result = Primes.IsCullenPrime(source); 
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow(13, true)]
    [DataRow(17, true)]
    [DataRow(31, true)]
    [DataRow(37, true)]
    [DataRow(71, true)]
    [DataRow(73, true)]
    [DataRow(79, true)]
    [DataRow(97, true)]
    [DataRow(107, true)]
    [DataRow(113, true)]
    [DataRow(149, true)]
    [DataRow(157, true)]
    [DataRow(167, true)]
    [DataRow(179, true)]
    [DataRow(199, true)]
    [DataRow(311, true)]
    [DataRow(337, true)]
    [DataRow(347, true)]
    [DataRow(359, true)]
    [DataRow(389, true)]
    [DataRow(701, true)]
    [DataRow(709, true)]
    [DataRow(733, true)]
    [DataRow(739, true)]
    [DataRow(743, true)]
    [DataRow(751, true)]
    [DataRow(761, true)]
    [DataRow(769, true)]
    [DataRow(907, true)]
    [DataRow(937, true)]
    [DataRow(941, true)]
    [DataRow(953, true)]
    [DataRow(967, true)]
    [DataRow(971, true)]
    [DataRow(983, true)]
    [DataRow(991, true)]
    public void TestMethod_IsEmirp(int source, bool expected)
    {
      // 13, 17, 31, 37, 71, 73, 79, 97, 107, 113, 149, 157, 167, 179, 199, 311, 337, 347, 359, 389, 701, 709, 733, 739, 743, 751, 761, 769, 907, 937, 941, 953, 967, 971, 983, 991

      var result = Primes.IsEmirp(source); 
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod_Reverse_for_IsEmirp() 
    {
      var source = 13;
      var expected = 31;
      string resultTmp2 = source.ToString();
      string resultTmp = (string)resultTmp2.Reverse();
      var result = int.Parse(resultTmp);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod_ReverseString()
    {
      var source = 13;
      string expected = "31";
      var result = Primes.ReverseString(source); 
      Assert.AreEqual(expected, result);
    }
  }
}
