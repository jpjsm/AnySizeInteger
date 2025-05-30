using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySizeInt
{
    public partial class AnySizeInteger
    {
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            AnySizeInteger? other = obj as AnySizeInteger;

            if (other is null)
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
            StringBuilder result = new();

            if (this.negative)
            {
                result.Append('-');
            }

            AnySizeInteger t = new(this.digits, false);

            AnySizeInteger q, r;
            while (t >= 10)
            {
                (q, r) = IntegerDivision(t, 10);
                t = q;
                result.Append(r.digits[0]);
            }

            result.Append(t.digits[0]);

            return ReverseString(result.ToString());
        }
    }
}
