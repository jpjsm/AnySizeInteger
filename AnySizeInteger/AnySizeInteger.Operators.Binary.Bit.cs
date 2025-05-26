using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katedra
{
  public partial class AnySizeInteger
  {
    public static AnySizeInteger operator &(AnySizeInteger a, AnySizeInteger b)
    {
      if (((object)a == null) || ((object)b == null))
      {
        return null;
      }

      throw new NotImplementedException();
    }

    public static AnySizeInteger operator |(AnySizeInteger a, AnySizeInteger b)
    {
      if (((object)a == null) || ((object)b == null))
      {
        return null;
      }

      throw new NotImplementedException();
    }

    public static AnySizeInteger operator ^(AnySizeInteger a, AnySizeInteger b)
    {
      if (((object)a == null) || ((object)b == null))
      {
        return null;
      }

      throw new NotImplementedException();
    }

  }
}
