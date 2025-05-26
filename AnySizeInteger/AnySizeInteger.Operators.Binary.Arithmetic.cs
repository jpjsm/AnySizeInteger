using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katedra
{
  public partial class AnySizeInteger
  {
    public static AnySizeInteger operator +(AnySizeInteger a, AnySizeInteger b)
    {
      if (a == null || b == null)
      {
        return null;
      }

      if (a.IsPositive() ^ b.IsPositive())
      {
        if (a.IsPositive())
        {
          return a - (-b);
        }
        else
        {
          return b - (-a);
        }
      }

      bool n = a.negative;
      int alen = a.len();
      int blen = b.len();
      int longest = alen > blen ? alen : blen;
      uint[] d = new uint[longest + 1];

      ulong result = 0UL;
      for (int i = 0; i < longest; i++)
      {
        if (i < alen)
        {
          result += a.digits[i];
        }

        if (i < blen)
        {
          result += b.digits[i];
        }

        d[i] = (uint)result;
        result >>= 32;
      }

      return new AnySizeInteger(d, n);
    }

    public static AnySizeInteger operator -(AnySizeInteger a, AnySizeInteger b)
    {
      if (a == null || b == null)
      {
        return null;
      }

      if (a.IsPositive() ^ b.IsPositive())
      {
        return a + (-b);
      }

      bool reverse;
      bool sign = a.negative;
      if (sign)
      {
        reverse = b < a;
      }
      else
      {
        reverse = b > a;
      }

      AnySizeInteger minuend = a;
      AnySizeInteger subtrahend = b;
      if (reverse)
      {
        minuend = b;
        subtrahend = a;
        sign = !sign;
      }

      int len = minuend.digits.Length;
      int slen = subtrahend.digits.Length;
      uint[] d = new uint[len];


      ulong s = 0UL;
      ulong m = 0UL;
      bool carry = false;
      for (int i = 0; i < len; i++)
      {
        m = minuend.digits[i];

        if (i < slen)
        {
          s += subtrahend.digits[i];
        }

        if (s > m)
        {
          m += 0x100000000UL;
          carry = true;
        }

        d[i] = (uint)(m - s);

        if (carry)
        {
          s = 1UL;
          carry = false;
        }
      }

      return new AnySizeInteger(d, sign);
    }

    public static AnySizeInteger operator *(AnySizeInteger a, AnySizeInteger b)
    {
      if (a == null || b == null)
      {
        return null;
      }

      bool sign = a.negative ^ b.negative;
      ulong[] digits = new ulong[a.Len() + b.Len()];
      AnySizeInteger A = a;
      AnySizeInteger B = b;
      if (b.Len() > a.Len())
      {
        A = b;
        B = a;
      }

      // Get coefficients
      ulong[,] coefs = new ulong[A.Len(), B.Len()];
      Parallel.For(0, A.len(), (i) =>
      {
        for (int k = 0; k < B.len(); k++)
        {
          coefs[i, k] = A.digits[i] * B.digits[k];
        }
      });

      // Add coefficients of the same power
      for (int i = 0; i < A.len(); i++)
      {
        for (int j = 0; j < B.len(); j++)
        {
          digits[i + j] += coefs[i, j];
        }
      }

      // Passing carry to the next digit
      for (int i = 0; i < digits.Length - 1; i++)
      {
        if (digits[i] > uint.MaxValue)
        {
          digits[i + 1] += digits[i] >> 32;
          digits[i] = (uint)digits[i];
        }
      }

      return new AnySizeInteger(digits, sign);
    }

    public static AnySizeInteger operator /(AnySizeInteger a, AnySizeInteger b)
    {
      if (a == null || b == null)
      {
        return null;
      }

      if (b == Zero)
      {
        throw new DivideByZeroException();
      }

      return IntegerDivision(a, b).Item1;
    }

    public static AnySizeInteger operator %(AnySizeInteger a, AnySizeInteger b)
    {
      if (a == null || b == null)
      {
        return null;
      }

      if (b == Zero)
      {
        throw new DivideByZeroException();
      }

      return IntegerDivision(a, b).Item2;
    }
  }
}
