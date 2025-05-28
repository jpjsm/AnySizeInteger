using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySizeInt
{
    public partial class AnySizeInteger
    {
        /// <summary>
        /// Returns the AnySizeInteger as a ULong structure
        /// </summary>
        /// <returns>The length of the number in 32 bits units</returns>
        /// <remarks>
        /// Returned value will be truncated.
        /// Returned value is a positive number regardless of AnySizeInteger sign.
        /// </remarks>
        public ulong ToUlong()
        {
            if (digits.Length == 1)
            {
                return digits[0];
            }
            return (digits[1] << 32) | (digits[0]);
        }

    }
}
