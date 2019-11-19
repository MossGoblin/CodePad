using System;
using System.Collections.Generic;

namespace ToolBox
{
    public class MathP
    {
        public SortedDictionary<ulong, bool> Checked { get; private set; }
        
        public MathP()
        {
            Checked = new SortedDictionary<ulong, bool>();
        }

        public SortedDictionary<ulong, bool> GetCached()
        {
            return Checked;
        }
        private ulong Primeable(ulong candidate)
        {
            if (candidate < 1)
            {
                throw new ArgumentException("Candidate number must be a positive integer larger than 1");
            }
            return candidate;
        }

        private ulong Validated(ulong candidate)
        {
            if (candidate < 0)
            {
                throw new ArgumentException("Number must be a positive integer");
            }
            return candidate;
        }


        public bool IsPrime(ulong candidate) // check if a candidate integer is prime
        {
            // validate input for zero or negative
            ulong number = Primeable(candidate);

            // exclude even numbers
            if (number > 2ul && number % 2ul == 0)
            {
                Checked.Add(number, false);
                return false;
            }

            // handle 2
            if (number == 2ul)
            {
                Checked.Add(number, true);
                return true;
            }

            // check if the candidate has already been cached
            if (Checked.ContainsKey(number))
            {
                return Checked[number];
            }

            // new candidate
            for (int count = 3; count < Math.Sqrt((double)number); count++)
            {
                if (number % (ulong)count == 0)
                {
                    Checked.Add(number, false);
                    return false;
                }
            }
            Checked.Add(number, true);
            return true;
        }


        public List<ulong> PrimesBelow(ulong upperBound)
        {
            List<ulong> result = new List<ulong>();
            ulong number = Primeable(upperBound);

            // check the upperBound itself
            IsPrime(number);

            for (ulong count = 2; count < number; count++)
            {
                // see if the counter has already been checked
                if (Checked.ContainsKey(count) && Checked[count])
                {
                    result.Add(count);
                }
                if (!Checked.ContainsKey(count))
                {
                    if (IsPrime(count))
                    {
                        result.Add(count);
                    }
                }
            }

            return result;
        }

        
        public List<ulong> PrimesInRange(ulong lowerBound, ulong upperBound)
        {
            List<ulong> result = new List<ulong>();
            ulong numberLow = Primeable(lowerBound);
            ulong numberHigh = Primeable(upperBound);

            // check the bounds themselves
            IsPrime(numberLow);
            IsPrime(numberHigh);

            for (ulong count = numberLow; count < numberHigh; count++)
            {
                // see if the counter has already been checked
                if (Checked.ContainsKey(count) && Checked[count])
                {
                    result.Add(count);
                }
                if (!Checked.ContainsKey(count))
                {
                    if (IsPrime(count))
                    {
                        result.Add(count);
                    }
                }
            }

            return result;
        }

        public List<ulong> Factors(ulong number)
        {
            ulong target = Validated(number);
            List<ulong> result = new List<ulong>();

            for (ulong count = 1; count <= (target / 2ul); count++)
            {
                if (target % count == 0)
                {
                    result.Add(count);
                }
            }

            return result;
        }

        public List<ulong> PrimeFactors(ulong number)
        {
            ulong target = Validated(number);
            List<ulong> result = new List<ulong>();

            for (ulong count = 1; count <= (target / 2ul); count++)
            {
                if (target % count == 0 && IsPrime(count))
                {
                    result.Add(count);
                }
            }

            return result;
        }

        public List<ulong> CommonFactors(ulong first, ulong second)
        {
            ulong number_one = Validated(first);
            ulong number_two = Validated(second);

            List<ulong> factors_one = Factors(number_one);
            List<ulong> factors_two = Factors(number_two);

            foreach (var factor in factors_two)
            {
                if (!factors_one.Contains(factor))
                {
                    factors_two.Remove(factor);
                }
            }

            return factors_two;
        }

        public List<ulong> CommonPrimeFactors(ulong first, ulong second)
        {
            ulong number_one = Primeable(first);
            ulong number_two = Primeable(second);

            List<ulong> factors_one = PrimeFactors(number_one);
            List<ulong> factors_two = PrimeFactors(number_two);

            foreach (var factor in factors_two)
            {
                if (!factors_one.Contains(factor))
                {
                    factors_two.Remove(factor);
                }
            }

            return factors_two;
        }

        public bool Coprime(ulong first, ulong second)
        {
            ulong number_one = Validated(first);
            ulong number_two = Validated(second);

            List<ulong> factors_one = Factors(number_one);
            List<ulong> factors_two = Factors(number_two);

            foreach (var factor in factors_two)
            {
                if (!factors_one.Contains(factor))
                {
                    factors_two.Remove(factor);
                }
            }

            if (factors_two.Count == 1 && factors_two[0] == 1)
            {
                return true;
            }

            return false;
        }

        public ulong GreatestPrimeFactor(ulong first, ulong second)
        {
            ulong number_one = Validated(first);
            ulong number_two = Validated(second);

            List<ulong> factors_one = Factors(number_one);
            List<ulong> factors_two = Factors(number_two);

            foreach (var factor in factors_two)
            {
                if (!factors_one.Contains(factor))
                {
                    factors_two.Remove(factor);
                }
            }

            ulong result = 0;
            foreach (var factor in factors_two)
            {
                if (factor > result)
                {
                    result = factor;
                }
            }

            return result;
        }

        public static bool IsInteger(ValueType value)
        {         
            return (value is SByte || value is Int16 || value is Int32 
                    || value is Int64 || value is Byte || value is UInt16  
                    || value is UInt32 || value is UInt64 
                    || value is BigInteger); 
        }
    }
}

// Allow getting the collected primes only as a ReadOnly
// Add overloads that receive int and cast them to ulong - should the overloads be separated for better code reading?

// TODO + MTHD check is a number is prime
// TODO + MTHD number of primes up to a value
// TODO + MTHD number of primes in a range
// TODO : MTHD estimate number of primes up until N (for large values of x, π(x) is approximately equal to x/ln(x))
// TODO : MTHD estimate number of primes in a range(see above for a range) - this might be unnecessary [include the previous one as default]
// TODO + MTHD divisors of N (for N = 12 => 1, 2, 3, 4, 6 and 12)
// TODO + MTHD prime divisors of N (for N = 12 => 1, 2 and 3)
// TODO . MTHD all common divisors (what are the common divisors of 12 and 15; see factors of N)
// TODO . MTHD all common prime divisors (what are the common prime divisors of 12 and 15; see prime factors of N)
// TODO . MTHD check if two numbers are coprime ()
// TODO . MTHD greatest common factors (6 is GCF for 12 and 18)