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
        /// AnySizeInteger default constructor returns zero.
        /// </summary>
        public AnySizeInteger()
        {
            digits = [0];
            negative = false;
            hashcode = GetHashcode(digits);
        }

        /// <summary>
        /// AnySizeInteger constructor for int data type
        /// </summary>
        /// <param name="n">The int value converted to AnySizeInteger</param>
        public AnySizeInteger(int n)
        {
            long tmp = n;
            negative = n < 0;
            if (negative)
            {
                tmp *= -1;
            }

            digits = new ulong[] { (uint)tmp };

            hashcode = GetHashcode(digits);
        }

        /// <summary>
        /// AnySizeInteger constructor for signed byte (sbyte) data type
        /// </summary>
        /// <param name="n">The byte value converted to AnySizeInteger</param>
        public AnySizeInteger(sbyte n)
            : this((int)n)
        {
        }

        /// <summary>
        /// AnySizeInteger constructor for short data type
        /// </summary>
        /// <param name="n">The short value converted to AnySizeInteger</param>
        public AnySizeInteger(short n)
            : this((int)n)
        {
        }

        public AnySizeInteger(long n)
        {
            if (n == long.MinValue)
            {
                digits = new ulong[] { 0, 0, 1 };
                negative = true;
                hashcode = GetHashcode(digits);
                return;
            }

            if (n <= int.MaxValue && n >= int.MinValue)
            {
                digits = new ulong[1];
            }
            else
            {
                digits = new ulong[2];
            }

            long tmp = n;
            negative = n < 0;
            if (negative)
            {
                tmp *= -1;
            }

            digits[0] = (uint)tmp;
            if (digits.Length == 2)
            {
                digits[1] = (uint)(tmp >> 32);
            }

            hashcode = GetHashcode(digits);
        }


        /// <summary>
        /// AnySizeInteger constructor for uint data type
        /// </summary>
        /// <param name="n">The uint value converted to AnySizeInteger</param>
        public AnySizeInteger(uint n)
        {
            digits = new ulong[] { n };
            negative = false;
            hashcode = GetHashcode(digits);
        }

        /// <summary>
        /// AnySizeInteger constructor for byte data type
        /// </summary>
        /// <param name="n">The byte value converted to AnySizeInteger</param>
        public AnySizeInteger(byte n)
            : this((uint)n)
        {
        }

        /// <summary>
        /// AnySizeInteger constructor for unsigned short data type
        /// </summary>
        /// <param name="n">The ushort value converted to AnySizeInteger</param>
        public AnySizeInteger(ushort n)
            : this((uint)n)
        {
        }

        /// <summary>
        /// AnySizeInteger constructor for unsigned long data type
        /// </summary>
        /// <param name="n">The ulong value converted to AnySizeInteger</param>
        public AnySizeInteger(ulong n)
        {
            if (n > uint.MaxValue)
            {
                digits = new ulong[2];
                digits[0] = (uint)n;
                digits[1] = (uint)(n >> 32);
            }
            else
            {
                digits = new ulong[] { (uint)n };
                hashcode = (int)n;
            }

            negative = false;
            hashcode = GetHashcode(digits);
        }

        /// <summary>
        /// AnySizeInteger constructor for a decimal number, in text representation
        /// </summary>
        /// <param name="s">The string that represents the number</param>
        /// <remarks>
        /// The string must represent a valid signed integer number;
        /// optional sign character as first left character in string,
        /// with no space between the sign and the first digit on the left.
        /// No decimal separators allowed.
        /// Empty or null strings throw exception 'ArgumentNullException'
        /// White spaces are trimmed off the string on both ends before the conversion.
        /// </remarks>
        public AnySizeInteger(string? s)
        {

            if (String.IsNullOrWhiteSpace(s))
            {
                digits = [0];
                negative = false;
                hashcode = GetHashcode(digits);
                return;
            }

            s = s.Trim();
            if (s[0] == '-' && s.Length == 1)
            {
                throw new ArgumentException("Invalid character in number", nameof(s));
            }

            negative = false;
            if (s[0] == '-')
            {
                negative = true;
            }

            int start = negative ? 1 : 0;

            AnySizeInteger result = new(0);

            for (int i = start; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                {
                    throw new ArgumentException("Invalid character in number", nameof(s));
                }

                AnySizeInteger d = new((int)(s[i] - '0'));
                result = d + (result * 10);
            }

            this.digits = new ulong[result.digits.Length];
            Array.Copy(result.digits, this.digits, result.digits.Length);
            this.hashcode = result.hashcode;
            if (digits.Length == 1 && digits[0] == 0UL)
            {
                negative = false;
            }
        }

        /// <summary>
        /// AnySizeInteger constructor for float data type
        /// </summary>
        /// <param name="f">The float value</param>
        /// <remarks>
        /// The argument is converted to it's full decimal representation;
        /// all integer digits are fully written and then converted to AnySizeInteger type
        /// </remarks>
        public AnySizeInteger(float f)
            : this(ToStringInteger(f))
        {
        }

        /// <summary>
        /// AnySizeInteger constructor for double data type
        /// </summary>
        /// <param name="f">The double value</param>
        /// <remarks>
        /// The argument is converted to it's full decimal representation;
        /// all integer digits are fully written and then converted to AnySizeInteger type
        /// </remarks>
        public AnySizeInteger(double d)
            : this(ToStringInteger(d))
        {
        }

        /// <summary>
        /// AnySizeInteger constructor for decimal data type
        /// </summary>
        /// <param name="f">The decimal value</param>
        /// <remarks>
        /// The argument is converted to it's full decimal representation;
        /// all integer digits are fully written and then converted to AnySizeInteger type
        /// </remarks>
        public AnySizeInteger(decimal d)
            : this(ToStringInteger(d))
        {
        }

        /// <summary>
        /// AnySizeInteger constructor for AnySizeInteger data type
        /// </summary>
        /// <param name="n">The AnySizeInteger value</param>
        public AnySizeInteger(AnySizeInteger? n)
        {
            if (n is null)
            {
                digits = [0];
                negative = false;
                hashcode = GetHashcode(digits);
            }
            else
            {
                digits = new ulong[n.len()];
                n.digits.CopyTo(digits, 0);
                negative = n.negative;
                hashcode = n.hashcode;
            }
        }

        /// <summary>
        /// AnySizeInteger constructor for binary representation.
        /// </summary>
        /// <param name="d">The array of uint digits, representing a polynomial expression.</param>
        /// <param name="n">Is negative number.</param>
        /// <remarks>
        /// Array is stored in something similar to Little Endian order.
        /// 
        /// </remarks>
        private AnySizeInteger(uint[] d, bool n)
        {
            ArgumentNullException.ThrowIfNull(d);

            // right trim zeroes
            int upperLimit;
            for (upperLimit = d.Length - 1;
                upperLimit > 0 && d[upperLimit] == 0;
                upperLimit--) ;

            // copy significant digits
            digits = new ulong[upperLimit + 1];
            Array.Copy(d, 0, digits, 0, upperLimit + 1);

            // Zero is always positive
            if (digits.Length == 1 && digits[0] == 0)
            {
                negative = false;
                hashcode = GetHashcode(digits);
                return;
            }

            negative = n;
            hashcode = GetHashcode(digits);
        }

        /// <summary>
        /// AnySizeInteger constructor for binary representation.
        /// </summary>
        /// <param name="d">The array of ulong digits, representing a polynomial expression.</param>
        /// <param name="n">Is negative number.</param>
        private AnySizeInteger(ulong[] d, bool n)
        {
            ArgumentNullException.ThrowIfNull(d);

            // remove zeroes to the left
            int upperLimit;
            for (upperLimit = d.Length - 1;
                upperLimit > 0 && d[upperLimit] == 0;
                upperLimit--) ;

            // copy significant digits
            digits = new ulong[upperLimit + 1];
            Array.Copy(d, 0, digits, 0, upperLimit + 1);

            if (digits.Length == 1 && digits[0] == 0)
            {
                negative = false;
                hashcode = 0;
                return;
            }

            negative = n;
            hashcode = GetHashcode(digits);
        }

        //// ToDo: Implement byte array conversion

        //public AnySizeInteger(byte[] arr, bool negative=false)
        //{
        //    if (arr == null)
        //    {
        //        throw new ArgumentNullException(nameof(arr));
        //    }

        //    arr.CopyTo(digits, 0);
        //}
    }
}
