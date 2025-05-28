using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySizeInt
{
  public partial class AnySizeInteger
  {
    private static ulong GetNumberMask(ulong n)
    {
      ulong h = 0;

      while (n != 0)
      {
        n >>= 1;
        h = (h << 1) | 1UL;
      }

      return h;
    }

    private static int GetHashcode(ulong[] digits)
    {
      if ((digits is null) || (digits.Length == 0))
      {
        throw new NullReferenceException(nameof(digits));
      }

      int result = ((int)digits[0]) ^ (int)(digits[0] >> 32);
      for (int i = 1; i < digits.Length; i++)
      {
        result ^= (((int)digits[i]) ^ (int)(digits[i] >> 32));
      }

      return result;
    }
  }
}
