using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katedra
{
  public partial class AnySizeInteger
  {
    /// <summary>
    /// Shift Left: shifts all bits of A to the left, expanding the size A.
    /// </summary>
    /// <param name="A"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static AnySizeInteger ShiftLeft(AnySizeInteger A, AnySizeInteger n)
    {
      if (n < 0) return ShiftRight(A, -n);

      bool sign = A.negative;
      Tuple<AnySizeInteger, AnySizeInteger> qr = IntegerDivision(n, 32);

      if (qr.Item1 > Int32.MaxValue)
      {
        throw new ArithmeticException("Resulting size exceeds AnySizeInteger max size.");
      }

      int skipdigits = (int)(qr.Item1.digits[0]);
      int shiftbits = (int)qr.Item2.digits[0];

      ulong newlen = A.Len() + (ulong)skipdigits + 1UL;
      if (newlen > Int32.MaxValue)
      {
        throw new ArithmeticException("Resulting size exceeds AnySizeInteger max size.");
      }

      ulong[] digits = new ulong[(int)newlen];

      ConcurrentBag<int> carries = new ConcurrentBag<int>();
      Parallel.For(
        0, A.len(),
        i =>
          {
            int shiftedindex = i + skipdigits;
            digits[shiftedindex] = A.digits[i] << shiftbits;
            if ((digits[shiftedindex] & AnySizeInteger.all32zeroes) != 0UL)
            {
              carries.Add(shiftedindex);
            }
          });

      if (carries.Count > 0)
      {
        Parallel.ForEach(carries,
          i =>
            {
              digits[i + 1] |= (digits[i] & AnySizeInteger.all32zeroes) >> 32;
              digits[i] &= AnySizeInteger.all32ones;
            });
      }

      return new AnySizeInteger(digits, sign);
    }

    /// <summary>
    /// Shift Right: shifts all bits of A to the right, discarding least significant bits.
    /// </summary>
    /// <param name="A"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static AnySizeInteger ShiftRight(AnySizeInteger A, AnySizeInteger n)
    {
      if (n < 0) return ShiftLeft(A, -n);
      if (n >= A.BitsLength()) return new AnySizeInteger(new uint[] { 0 }, false);

      bool sign = A.negative;
      Tuple<AnySizeInteger, AnySizeInteger> qr = IntegerDivision(n, 32);

      if (qr.Item1 > Int32.MaxValue)
      {
        throw new ArithmeticException("Resulting size exceeds AnySizeInteger max size.");
      }

      int skipdigits = (int)(qr.Item1.digits[0]);
      int shiftbits = (int)qr.Item2.digits[0];

      throw new NotImplementedException();

      //return new AnySizeInteger(digits, sign);
    }

    /// <summary>
    /// Shift Left Circular: shifts all bits of A to the left, moving MSB to LSB.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static AnySizeInteger SLC(AnySizeInteger n)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Shift Right Circular: shifts all bits of A to the right, moving LSB to MSB.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static AnySizeInteger SRC(AnySizeInteger n)
    {
      throw new NotImplementedException();
    }
  }
}
