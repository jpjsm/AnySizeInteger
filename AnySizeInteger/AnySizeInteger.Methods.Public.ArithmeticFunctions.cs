using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katedra
{
    public partial class AnySizeInteger
    {
        /// <summary>
        /// Returns true if 'n' is odd
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool Odd(AnySizeInteger n)
        {
            if (n == null) throw new ArgumentNullException();

            return (1UL & n.digits[0]) == 1UL;
        }

        /// <summary>
        /// returns true if 'n' is even
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool Even(AnySizeInteger n)
        {
            if (n == null) throw new ArgumentNullException();

            return (1UL & n.digits[0]) == 0UL;
        }

        /// <summary>
        /// Returns the Quotient and Reminder of Numerator divided by Denominator
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        public static Tuple<AnySizeInteger, AnySizeInteger> IntegerDivision(
            AnySizeInteger numerator,
            AnySizeInteger denominator)
        {
            if (denominator == AnySizeInteger.Zero)
            {
                throw new DivideByZeroException();
            }

            AnySizeInteger f, p;
            AnySizeInteger reminder = new AnySizeInteger(numerator);
            AnySizeInteger quotient = Zero;

            while (reminder >= denominator)
            {
                f = denominator;
                p = One;
                while (reminder >= f)
                {
                    f <<= 1;
                    p <<= 1;
                }

                f >>= 1;
                p >>= 1;
                reminder -= f;
                quotient += p;
            }

            return new Tuple<AnySizeInteger, AnySizeInteger>(quotient, reminder);
        }

        /// <summary>
        /// Returns the greatest common divisor between A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static AnySizeInteger GCD(AnySizeInteger A, AnySizeInteger B)
        {
            if (A == Zero || B == Zero) throw new ArgumentNullException();

            if (A < B) return GCD(B, A);

            AnySizeInteger a = new AnySizeInteger(A);
            AnySizeInteger b = new AnySizeInteger(B);
            while (b != Zero)
            {
                a %= b;
                Swap(ref a, ref b);
            }

            return a;
        }

        /// <summary>
        /// Returns base 'b' elevated to the 'e' power
        /// </summary>
        /// <param name="b">base</param>
        /// <param name="e">exponent</param>
        /// <returns></returns>
        public static AnySizeInteger Power(AnySizeInteger b, AnySizeInteger e)
        {
            if (e < Zero) return Zero;

            if (b == Zero) return Zero;

            AnySizeInteger result = One;
            AnySizeInteger product = b;

            while (e != Zero)
            {
                if (Odd(e)) result *= product;
                product *= product;
                e >>= 1;
            }

            return result;
        }

        /// <summary>
        /// Returns base 'b' elevated to the 'e' power, modulo m
        /// </summary>
        /// <param name="b">base</param>
        /// <param name="e">exponent</param>
        /// <param name="m">modulus</param>
        /// <returns></returns>
        public static AnySizeInteger Modular_Power(AnySizeInteger b, AnySizeInteger e, AnySizeInteger m)
        {
            
            if (e < 0) return Zero;

            if (b == Zero) return Zero;

            if (m == One) return Zero;

            AnySizeInteger result = One;
            AnySizeInteger product = b;
            while (e != 0)
            {
                if (Odd(e))
                    result = (result * product) % m;

                product = (product * product) % m;
                e >>= 1;
            }

            return result;
        }

        /// <summary>
        /// Returns the integer value of the base 2 logarithm of A
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static AnySizeInteger Log2(AnySizeInteger A)
        {
            if (A.negative) throw new ArgumentOutOfRangeException(nameof(A), "Argument cannot be negative number.");

            ulong highbitscount = 0;
            ulong highestcoeff = A.digits[A.digits.Length - 1];
            while (highestcoeff > 0)
            {
                highbitscount++;
                highestcoeff >>= 1;
            }

            return new AnySizeInteger(32UL * ((ulong)A.Len() - 1L) + highbitscount);
        }

        /// <summary>
        /// Returns the Nth root of A
        /// </summary>
        /// <param name="n"></param>
        /// <param name="radical"></param>
        /// <returns></returns>
        public static AnySizeInteger NRoot(AnySizeInteger n, AnySizeInteger radical)
        {
            if (radical < AnySizeInteger.One)
            {
                throw new ArgumentOutOfRangeException("radical", "Must be a positive number greater than zero.");
            }

            if (n < AnySizeInteger.Zero && Even(radical))
            {
                Exception ex = null;
                throw new ArgumentOutOfRangeException("Even roots cannot be calculated for negative numbers.", ex);
            }

            if (n == AnySizeInteger.Zero || n == AnySizeInteger.One || n == AnySizeInteger.MinusOne)
            {
                return n;
            }

            bool positive = !n.negative;

            AnySizeInteger log = AnySizeInteger.Zero;
            AnySizeInteger t = positive ? new AnySizeInteger(n) : new AnySizeInteger(-n);
            while (t != 0)
            {
                log += AnySizeInteger.One;
                t >>= 1;
            }

            if (radical > log)
            {
                return positive ? 1L : -1L;
            }

            log /= radical;

            AnySizeInteger upper = ShiftLeft(AnySizeInteger.One, (log + 1));
            AnySizeInteger lower = ShiftLeft(AnySizeInteger.One, (log - 1));
            AnySizeInteger root = (upper + lower) >> 1;
            AnySizeInteger p, p1;

            while (true)
            {
                p = Power(root, radical);
                if (p > n)
                {
                    upper = root;
                    root = (upper + lower + 1) >> 1;
                    if (root == upper) root -= AnySizeInteger.One;
                    continue;
                }

                p1 = Power(root + 1, radical);
                if (p1 <= n)
                {
                    lower = root;
                    root = (upper + lower) >> 1;
                    continue;
                }

                break;
            }

            return positive ? root : -root;
        }

        /// <summary>
        /// Returns the integer value of the square root of A
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static AnySizeInteger Sqrt(AnySizeInteger A)
        {
            return NRoot(A, 2);
        }
    }
}
