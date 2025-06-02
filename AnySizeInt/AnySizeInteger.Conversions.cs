using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySizeInt
{
    public partial class AnySizeInteger
    {
        public static implicit operator AnySizeInteger(ulong n)
        {
            return new AnySizeInteger(n);
        }

        public static implicit operator AnySizeInteger(long n)
        {
            return new AnySizeInteger(n);
        }

        public static implicit operator AnySizeInteger(uint n)
        {
            return new AnySizeInteger(n);
        }

        public static implicit operator AnySizeInteger(int n)
        {
            return new AnySizeInteger(n);
        }

        public static implicit operator AnySizeInteger(ushort n)
        {
            return new AnySizeInteger(n);
        }

        public static implicit operator AnySizeInteger(short n)
        {
            return new AnySizeInteger(n);
        }

        public static implicit operator AnySizeInteger(Byte n)
        {
            return new AnySizeInteger(n);
        }

        public static implicit operator AnySizeInteger(SByte n)
        {
            return new AnySizeInteger(n);
        }

        public static explicit operator AnySizeInteger(double n)
        {
            return new AnySizeInteger(n);
        }

        public static explicit operator AnySizeInteger(float n)
        {
            return new AnySizeInteger(n);
        }

        public static explicit operator AnySizeInteger(decimal n)
        {
            return new AnySizeInteger(n);
        }
    }
}
