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
      if (IsPrime(number) && IsPrime(number + 2) && IsPrime(number + 4))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Check if a number and number + 2 and number + 4 and number + 6 are all prime numbers.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if number and number + 2 and number + 4 and number + 6 are all prime numbers, false otherwise.</returns>
    public static bool IsPrimeQuadruplet(int number)
    {
      if (IsPrime(number) && IsPrime(number + 2) && IsPrime(number + 6) && IsPrime(number + 8))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Check if a number and number + 4 are both prime numbers.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if number and number + 4 are all prime numbers, false otherwise.</returns>
    public static bool IsCousinPrime(int number)
    {
      if (IsPrime(number) && IsPrime(number + 4))
      {
        return true;
      }

      return false;
    }

    public static bool IsCircularPrime(int number)
    {
      if (number < 1)
      {
        return false;
      }

      if (number < 9 && IsPrime(number))
      {
        return true;
      }

      foreach (var item in GetCircular(number))
      {

      }

      return false;
    }

    public static List<int> GetCircular(int number)
    {
      List<int> result = new List<int>();
      if (number < 9)
      {
        result.Add(number);
      }
      else if (number < 100)
      {
        result.Add(number);
        if (number.ToString().Substring(0, 1) != number.ToString().Substring(1, 1))
        {
          result.Add(int.Parse(number.ToString().Substring(1, 1) + number.ToString().Substring(0, 1)));
        }
      }
      else
      {
        // 123 231 312
        for (int i = 0; i < number.ToString().Length - 1; i++)
        {
          // TODO
          result.Add(int.Parse(number.ToString().Substring(i, number.ToString().Length - 1)));
        }
      }

      return result;
    }

    public static bool IsCubanPrime(int number)
    {
      // Of the form x 3 − y 3 x − y {\displaystyle {\tfrac {x^{3}-y^{3}}{x-y}}} where x = y + 1. 
      int x = number;
      int y = number - 1;
      if (IsPrime(((x * x * x)-(y * y * y))/(x-y)))
      {
        return true;
      }

      x = number;
      y = number - 2;
      if (IsPrime(((x * x * x) - (y * y * y)) / (x - y)))
      {
        return true;
      }

      return false;
    }

    public static bool IsCullenPrime(int number)
    {
      // Of the form n×2n + 1. 
      // the two first numbers are 3 and 393050634124102232869567034555427371542904833
      int x = number;
      return IsPrime((x * (2 * x)) + 1);
    }

    public static bool IsEmirp(int number)
    {
      // prime reverse is emirp
      // IsPrime(int.Parse((string)number.ToString().Reverse())) doesn't work
      return IsPrime(number) && IsPrime(int.Parse(ReverseString(number)));
    }

    public static string ReverseString(int number)
    {
      string result = string.Empty;
      for (int i = number.ToString().Length - 1; i >= 0; i--)
      {
        result += number.ToString()[i];
      }

      return result;
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

    public static bool IsFactorialPrime(int number) 
    {
      // Of the form n! − 1 or n! + 1. 
      return IsPrime(number) && IsFactorial(number);
    }

    public static bool IsFactorial(int number)
    {
      for (int i = 1; i < number; i++)
      {
        if (Factorial(i) == number + 1 || Factorial(i) == number - 1)
        {
          return true;
        }
      }

      return false;
    }

    public static int Factorial(int number)
    {
      int result = 1;
      for (int i = 1; i <= number; i++)
      {
        result *= i;
      }

      return result;
    }
  }
}
