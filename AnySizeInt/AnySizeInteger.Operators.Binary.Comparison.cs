using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySizeInt
{
  public partial class AnySizeInteger
  {
    public static bool operator ==(AnySizeInteger a, AnySizeInteger b)
    {
      if ((a is null) || (b is null))
      {
        return false;
      }

      if (System.Object.ReferenceEquals(a, b))
      {
        return true;
      }

      // if signs are different...
      if (a.negative ^ b.negative)
      {
        return false;
      }

      // if lengths are different...
      if (a.Len() != b.Len())
      {
        return false;
      }

      for (int i = 0; i < a.len(); i++)
      {
        if (a.digits[i] != b.digits[i])
        {
          return false;
        }
      }

      return true;
    }

    public static bool operator !=(AnySizeInteger a, AnySizeInteger b)
    {
      if (System.Object.ReferenceEquals(a, b))
      {
        return false;
      }

      if ((a is null) && (b is null))
      {
        return false;
      }

      if ((a is null) || (b is null))
      {
        return true;
      }

      // if signs are different...
      if (a.negative ^ b.negative)
      {
        return true;
      }

      // if lengths are different...
      if (a.Len() != b.Len())
      {
        return true;
      }


      for (int i = 0; i < a.len(); i++)
      {
        if (a.digits[i] != b.digits[i])
        {
          return true;
        }
      }

      return false;
    }

    public static bool operator <(AnySizeInteger a, AnySizeInteger b)
    {
      if (a is null)
      {
        throw new NullReferenceException(nameof(a));
      }

      if (b is null)
      {
        throw new NullReferenceException(nameof(b));
      }

      if (System.Object.ReferenceEquals(a, b))
      {
        return false;
      }


      if (a.negative && !b.negative)
      {
        return true;
      }

      if (!a.negative && b.negative)
      {
        return false;
      }

      int maxlen = (a.len() > b.len() ? a.len() : b.len()) - 1;

      ulong aDigit = a.digits[0];
      ulong bDigit = b.digits[0];

      for (int i = maxlen; i >= 0; i--)
      {
        aDigit = i >= a.len() ? 0 : a.digits[i];
        bDigit = i >= b.len() ? 0 : b.digits[i];

        if (aDigit != bDigit)
        {
          break;
        }
      }

      return a.negative ?
           aDigit > bDigit :
           aDigit < bDigit;
    }

    public static bool operator >(AnySizeInteger a, AnySizeInteger b)
    {
      if (a is null)
      {
        throw new NullReferenceException(nameof(a));
      }

      if (b is null)
      {
        throw new NullReferenceException(nameof(b));
      }

      if (System.Object.ReferenceEquals(a, b))
      {
        return false;
      }

      if (!a.negative && b.negative)
      {
        return true;
      }

      if (a.negative && !b.negative)
      {
        return false;
      }

      int maxlen = (a.len() > b.len() ? a.len() : b.len()) - 1;

      ulong aDigit = a.digits[0];
      ulong bDigit = b.digits[0];

      for (int i = maxlen; i >= 0; i--)
      {
        aDigit = i >= a.len() ? 0 : a.digits[i];
        bDigit = i >= b.len() ? 0 : b.digits[i];

        if (aDigit != bDigit)
        {
          break;
        }
      }

      return !a.negative ?
           aDigit > bDigit :
           aDigit < bDigit;
    }

    public static bool operator <=(AnySizeInteger a, AnySizeInteger b)
    {
      if (a is null)
      {
        throw new NullReferenceException(nameof(a));
      }

      if (b is null)
      {
        throw new NullReferenceException(nameof(b));
      }

      if (System.Object.ReferenceEquals(a, b))
      {
        return false;
      }

      if (a.negative && !b.negative)
      {
        return true;
      }

      if (!a.negative && b.negative)
      {
        return false;
      }

      int maxlen = (a.len() > b.len() ? a.len() : b.len()) - 1;

      ulong aDigit = a.digits[0];
      ulong bDigit = b.digits[0];

      for (int i = maxlen; i >= 0; i--)
      {
        aDigit = i >= a.len() ? 0 : a.digits[i];
        bDigit = i >= b.len() ? 0 : b.digits[i];

        if (aDigit != bDigit)
        {
          break;
        }
      }

      return a.negative ?
           aDigit > bDigit :
           aDigit < bDigit;
    }

    public static bool operator >=(AnySizeInteger a, AnySizeInteger b)
    {
      if (a is null)
      {
        throw new NullReferenceException(nameof(a));
      }

      if (b is null)
      {
        throw new NullReferenceException(nameof(b));
      }

      if (System.Object.ReferenceEquals(a, b))
      {
        return false;
      }

      if (!a.negative && b.negative)
      {
        return true;
      }

      if (a.negative && !b.negative)
      {
        return false;
      }

      if (a == b)
      {
        return true;
      }

      int maxlen = (a.len() > b.len() ? a.len() : b.len()) - 1;

      ulong aDigit = a.digits[0];
      ulong bDigit = b.digits[0];


      for (int i = maxlen; i >= 0; i--)
      {
        aDigit = i >= a.len() ? 0 : a.digits[i];
        bDigit = i >= b.len() ? 0 : b.digits[i];

        if (aDigit != bDigit)
        {
          break;
        }
      }

      return !a.negative ?
           aDigit > bDigit :
           aDigit < bDigit;
    }
  }
}
