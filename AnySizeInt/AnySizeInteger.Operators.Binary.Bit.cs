using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySizeInt
{
  public partial class AnySizeInteger
  {
    public static AnySizeInteger? operator &(AnySizeInteger a, AnySizeInteger b)
    {
      if ((a is null) || (b is null))
      {
        return null;
      }

      throw new NotImplementedException();
    }

    public static AnySizeInteger? operator |(AnySizeInteger a, AnySizeInteger b)
    {
      if ((a is null) || (b is null))
      {
        return null;
      }

      throw new NotImplementedException();
    }

    public static AnySizeInteger? operator ^(AnySizeInteger a, AnySizeInteger b)
    {
      if ((a is null) || (b is null))
      {
        return null;
      }

      throw new NotImplementedException();
    }

  }
}
