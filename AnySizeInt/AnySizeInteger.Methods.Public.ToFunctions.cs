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
        /// 
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public byte[] AnySizeIntegerDigitsToBytes()
        {
            byte[] result = new byte[digits.Length * sizeof(uint)];

            for (int i = 0; i < digits.Length; i++)
            {
                byte[] digitBytes = BitConverter.GetBytes((uint)digits[i]);
                Array.Copy(digitBytes, 0, result, i * sizeof(uint), digitBytes.Length);
            }

            return result;
        }

        public static ulong[] AnySizeIntegerDigitsFromBytes(byte[] bytes)
        {
            int digitsLen = bytes.Length / sizeof(uint);
            if (digitsLen * sizeof(uint) != bytes.Length)
            {
                throw new ArgumentException($"{nameof(bytes)} length is not a multiple of sizeof(uint).");
            }

            ulong[] digits = new ulong[digitsLen];
            for (int i = 0; i < digitsLen; i++)
            {
                uint digit = BitConverter.ToUInt32(bytes, i * sizeof(uint));
                digits[i] = digit;
            }

            return digits;
        }
    }
}
