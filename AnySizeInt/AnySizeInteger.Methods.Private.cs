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

        private static int GetHashcode(ulong[] digits)
        {
            if ((digits is null) || (digits.Length == 0))
            {
                throw new NullReferenceException(nameof(digits));
            }

            int result = (int)digits[0];
            for (int i = 1; i < digits.Length; i++)
            {
                result ^= (int)digits[i];
            }

            return result;
        }

        private static string ToStringInteger(float f)
        {
            string f_str = f.ToString("G9", CultureInfo.InvariantCulture);

            return NumberStringSplit(f_str);
        }

        private static string ToStringInteger(double d)
        {
            string d_str = d.ToString("G17", CultureInfo.InvariantCulture);
            return NumberStringSplit(d_str);
        }

        private static string ToStringInteger(decimal d)
        {
            return d.ToString(CultureInfo.InvariantCulture).Split(".")[0];
        }

        private static string NumberStringSplit(string n_str)
        {
            char[] splitter = ['e', 'E'];
            string[] n_parts = n_str.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            int pwr10 = n_parts.Length > 1 ? Convert.ToInt32(n_parts[1]) : 0;

            splitter = ['.'];
            string[] number_parts = n_parts[0].Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            string integer_part = number_parts[0];
            string decimal_part = number_parts.Length > 1 ? number_parts[1] : "0";

            int i = 0;
            while (pwr10 > 0)
            {
                integer_part += i < decimal_part.Length ? decimal_part[i] : "0";
                pwr10--;
                i++;
            }

            return integer_part;
        }

    }
}
