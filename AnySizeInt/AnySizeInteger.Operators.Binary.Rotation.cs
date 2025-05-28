using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySizeInt
{
  public partial class AnySizeInteger
  {
    // Note: 
    // AnySizeInteger shift left moves bits in 'a'
    // to the left without losing bits when bits reach the left end
    // of the digits array. The digits array 

    // If a negative value of 'b' is passed, the operation is equivalent 
    // to a right shift in the absolute value of b. 
    // If b is negative and ABS(b) > number of bits in a, the result is Zero,
    public static AnySizeInteger operator <<(AnySizeInteger a, int b)
    {
      return ShiftLeft(a, b);
    }

    // Note: 
    // AnySizeInteger shift right moves bits in 'a'
    // to the right discarding the least significant bit. 
    // If 'b' is positive and 'b' > number of bits in 'a', the result is Zero,

    // If a negative value of 'b' is passed, the operation is equivalent 
    // to a left shift in the absolute value of b, and the returned value
    // will be greater than 'a'.
    public static AnySizeInteger operator >>(AnySizeInteger A, int n)
    {
      return ShiftRight(A, n);
    }
  }
}
