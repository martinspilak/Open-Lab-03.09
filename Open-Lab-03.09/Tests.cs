using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace Open_Lab_03._09
{
    [TestFixture]
    public class Tests
    {

        private Numbers numbers;

        private const int RandMaxNum = 1000;
        private const int RandSeed = 309309309;
        private const int RandTestCasesCount = 96;

        [OneTimeSetUp]
        public void Init() => numbers = new Numbers();

        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(7, true)]
        [TestCase(10, false)]
        [TestCaseSource(nameof(GetRandom))]
        public void IsPrimeNumberTest(int num, bool expected) =>
            Assert.That(numbers.IsPrimeNumber(num), Is.EqualTo(expected));

        // this implementation is pretty unoptimized
        // https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var primes = Enumerable.Range(2, RandMaxNum - 2).ToList();

                for (var j = 2; j < RandMaxNum; j++)
                    if (primes.Contains(j))
                        for (var k = j * j; k < RandMaxNum; k += j)
                            primes.Remove(k);

                var state = rand.Next(2) == 0;

                var num = state ? primes[rand.Next(primes.Count)] : rand.Next(2, RandMaxNum);
                
                yield return new TestCaseData(num, state || primes.Contains(num));
            }
        }

    }
}
