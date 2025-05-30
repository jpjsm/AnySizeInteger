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
            bool isnegative = false;
            if (n < 0)
            {
                isnegative = true;
                n = -n;
            }

            string n_str = ToStringInteger(n);
            n_str = isnegative ? "-" + n_str : n_str;
            return new AnySizeInteger(n_str);
        }

        public static explicit operator AnySizeInteger(float n)
        {
            bool isnegative = false;
            if (n < 0)
            {
                isnegative = true;
                n = -n;
            }

            string n_str = ToStringInteger(n);
            n_str = isnegative ? "-" + n_str : n_str;
            return new AnySizeInteger(n_str);
        }

        public static explicit operator AnySizeInteger(decimal n)
        {
            bool isnegative = false;
            if (n < 0)
            {
                isnegative = true;
                n = -n;
            }

            string n_str = ToStringInteger(n);
            n_str = isnegative ? "-" + n_str : n_str;
            return new AnySizeInteger(n_str);
        }
    }
}
