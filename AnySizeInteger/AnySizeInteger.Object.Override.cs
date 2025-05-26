using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katedra
{
  public partial class AnySizeInteger
  {
    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }

      AnySizeInteger other = obj as AnySizeInteger;

      if (other == null)
      {
        return false;
      }

      return this == other;
    }

    public override int GetHashCode()
    {
      return hashcode;
    }

    public override string ToString()
    {
      StringBuilder result = new StringBuilder();
      if (this.negative)
      {
        result.Append("- ");
      }

      for (ulong i = this.Len() - 1; i >= 0; i--)
      {
        result.AppendFormat("{0}:", this.digits[i]);
      }

      result.Remove(result.Length - 1, 1);
      return result.ToString();
    }
  }
}
