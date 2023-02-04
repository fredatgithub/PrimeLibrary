using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrimeLibrary
{
    public static class Primes
    {
    /// <summary>
    /// Compute if a number is a prime.
    /// </summary>
    /// <param name="number">The number to be checked if it is prime or not.</param>
    /// <returns>Returns True if the number is a prime, False otherwise.</returns>
    public static bool IsPrime(int number)
    {
      if (number <= 1)
      {
        return false;
      }

      if (number == 2 || number == 3 || number == 5)
      {
        return true;
      }

      if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0)
      {
        return false;
      }

      for (int divisor = 7; divisor <= Math.Sqrt(number); divisor += 2)
      {
        if (number % divisor == 0)
        {
          return false;
        }
      }

      return true;
    }

    /// <summary>Calculate if a big Integer number is prime.</summary>
    /// <param name="number">The number to calculate its primality.</param>
    /// <returns>Returns True if the number is a prime, False otherwise.</returns>
    public static bool IsPrime(BigInteger number)
    {
      if (number.IsEven)
      {
        return false;
      }

      if (number.Sign == 0 || number.Sign == -1)
      {
        return false; // calculate only positive numbers
      }

      if (number == 2 || number == 3 || number == 5)
      {
        return true;
      }

      if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0)
      {
        return false;
      }

      BigInteger squareRoot = (BigInteger)Math.Pow(Math.E, BigInteger.Log(number) / 2);
      for (BigInteger divisor = 7; divisor < squareRoot; divisor += 2)
      {
        if (number % divisor == 0)
        {
          return false;
        }
      }

      return true;
    }

    public static BigInteger Sqrt(this BigInteger n)
    {
      if (n == 0) return 0;
      if (n > 0)
      {
        int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
        BigInteger root = BigInteger.One << (bitLength / 2);

        while (!IsSquartRoot(n, root))
        {
          root += n / root;
          root /= 2;
        }

        return root;
      }

      throw new ArithmeticException("Not a Number");
    }

    public static bool IsSquartRoot(BigInteger bigIntegerNumber, BigInteger root)
    {
      BigInteger lowerBound = root * root;
      BigInteger upperBound = (root + 1) * (root + 1);

      return bigIntegerNumber >= lowerBound && bigIntegerNumber < upperBound;
    }

    /// <summary>Calculate the number of primes lesser or equal to a number.</summary>
    /// <param name="number">The limit to count the number of primes.</param>
    /// <returns>The number of primes lesser or equal to the number.</returns>
    public static int Pi(int number)
    {
      int result = 0;
      if (number <= 1)
      {
        return 0;
      }

      if (number == 2)
      {
        return 1;
      }

      result++;

      for (int i = 3; i <= number; i += 2)
      {
        if (IsPrime(i))
        {
          result++;
        }
      }

      return result;
    }

    /// <summary>
    /// Check if a number and number + 2 and number + 4 are all prime numbers.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if number and number + 2 and number + 4 are all prime numbers, false otherwise.</returns>
    public static bool IsPrimeTriplet(int number)
    {
      if (number.ToString().Substring(number.ToString().Length - 1, 1) != "7")
      {
        return false;
      }

      if (IsPrime(number) && IsPrime(number + 2) && IsPrime(number + 4))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Check if a number and number + 2 and number + 4 are all prime numbers.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if number and number + 2 and number + 4 are all prime numbers, false otherwise.</returns>
    public static bool IsPrimeTriplet(BigInteger number)
    {
      if (number.ToString().Substring(number.ToString().Length - 1, 1) != "7")
      {
        return false;
      }

      if (IsPrime(number) && IsPrime(number + 2) && IsPrime(number + 4))
      {
        return true;
      }

      return false;
    }

    public static List<int> GetEcartBetweenPrimes(int startNumber, int endNumber)
    {
      var result = new List<int>();
      var listOfPrimes = new List<int>();
      for (int i = startNumber; i <= endNumber; i++)
      {
        if (IsPrime(i))
        {
          listOfPrimes.Add(i);
        }
      }

      for (int i = 0; i < listOfPrimes.Count - 1; i++)
      {
        result.Add(listOfPrimes[i + 1] - listOfPrimes[i]);
      }

      return result;
    }

    public static List<int> GetPrimesBetweenTwoNumbers(int from, int to)
    {
      int count = to - from + 1;
      var primes = Enumerable.Range(from, count)
        .Where(n => IsPrime(n))
                       .Select(n => n)
                       .ToList();
      return primes;
    }

    public static List<ulong> GetPrimesBetweenTwoNumbers(ulong from, ulong to)
    {
      ulong count = to - from + 1;
      var numbers = new List<ulong>();
      for (ulong i = from; i <= to; i++)
      {
        numbers.Add(i);
      }

      var primes = numbers
        .Where(n => IsPrime(n))
                       .Select(n => n)
                       .ToList();
      return primes;
    }

    public static List<int> GetPrimesBetweenTwoNumbersWithForLoop(int from, int to)
    {
      List<int> result = new List<int>();
      for (int i = from; i <= to; i++)
      {
        if (IsPrime(i))
        {
          result.Add(i);
        }
      }

      return result;
    }

    public static IEnumerable<int> GetPrimeFromFile(string fileNameWithfullPath)
    {
      List<string> resultAsString = new List<string>();
      List<int> resultAsInteger = new List<int>();
      if (string.IsNullOrEmpty(fileNameWithfullPath))
      {
        return resultAsInteger;
      }

      try
      {
        using (StreamReader sr = new StreamReader(fileNameWithfullPath))
        {
          string line = string.Empty;
          while ((line = sr.ReadLine()) != null)
          {
            resultAsString.Add(line);
          }
        }
      }
      catch (Exception)
      {
        return resultAsInteger;
      }

      foreach (string numberAsString in resultAsString)
      {
        _ = int.TryParse(numberAsString, out int tmpNumber);
        resultAsInteger.Add(tmpNumber);
      }

      return resultAsInteger;
    }
  }
}
