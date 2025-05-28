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
    /// Returns the length of the number in 32 bits units
    /// </summary>
    /// <returns>The length of the number in 32 bits units</returns>
    public ulong Len()
    {
      return (ulong)digits.Length;
    }

    public ulong BitsLength()
    {
      ulong head = this.digits[digits.Length - 1];
      ulong headbits = 0;
      while (head != 0)
      {
        head >>= 1;
        headbits++;
      }

      return headbits + 32UL * ((ulong)this.digits.LongLength - 1);
    }

    public bool IsPositive()
    {
      return !negative;
    }

    public bool IsNegative()
    {
      return negative;
    }

    public static int Uint2Int(uint n)
    {
      long l = ((long)n);
      return (int)l;
    }

    public static void Swap(ref AnySizeInteger A, ref AnySizeInteger B)
    {
      AnySizeInteger t = A;
      A = B;
      B = t;
    }

    public static string  ReverseString(string s)
    {
      char[] charArray = s.ToCharArray();
      Array.Reverse(charArray);
      
      return new string(charArray);
    }

    private int len()
    {
      return digits.Length;
    }

  }
}
