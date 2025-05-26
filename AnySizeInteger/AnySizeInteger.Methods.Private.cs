using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katedra
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
  }
}
