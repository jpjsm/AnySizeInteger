using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySizeInt
{
  public partial class AnySizeInteger
  {
    /// <summary>
    /// Returns the arithmentic addition inverse ==> a + (-a) = 0
    /// </summary>
    /// <param name="a">value</param>
    /// <returns></returns>
    public static AnySizeInteger operator -(AnySizeInteger a)
    {
      if (a is null)
      {
        return Zero;
      }

      return new AnySizeInteger(a.digits, !a.negative);
    }

    public static AnySizeInteger operator ~(AnySizeInteger a)
    {
      if (a is null || a == Zero)
      {
        return One;
      }

      ulong[] invertedigits = new ulong[a.digits.Length];

      for (int i = 0; i < a.digits.Length; i++)
      {
        invertedigits[i] = ~a.digits[i];
      }

      // leading zeroes in highest order digit
      // should not be flipped.
      invertedigits[a.digits.Length - 1] = GetNumberMask(a.digits[a.digits.Length - 1]) & invertedigits[a.digits.Length - 1];

      return new AnySizeInteger(invertedigits, a.negative);
    }
  }
}
