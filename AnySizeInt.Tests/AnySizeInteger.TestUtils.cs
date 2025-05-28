using System.Reflection;

namespace AnySizeInt.Tests
{
    public static class TestExtensions
    {
        public static (ulong[] digits, bool negative, int hashcode) GetInners(this AnySizeInteger a)
    {
        ArgumentNullException.ThrowIfNull(a);

        Type anysizeintegerType = typeof(AnySizeInteger);
        FieldInfo? digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo? negativeInfo = anysizeintegerType.GetField("negative", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo? hashcodeInfo = anysizeintegerType.GetField("hashcode", BindingFlags.NonPublic | BindingFlags.Instance);

        if ((digitsInfo is null) || (negativeInfo is null) || (hashcodeInfo is null))
        {
            throw new NullReferenceException($"one or more of ['{nameof(digitsInfo)}, {nameof(negativeInfo)}, {nameof(hashcodeInfo)}']");
        }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        int digitsLen = ((ulong[])digitsInfo.GetValue(a)).Length;
        ulong[] digitsValue = new ulong[digitsLen];
        Array.Copy((ulong[])digitsInfo.GetValue(a), digitsValue, digitsLen);
        #pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8605 // Unboxing a possibly null value.
        bool negativeValue = (bool)negativeInfo.GetValue(a);
        int hashcodeValue = (int)hashcodeInfo.GetValue(a);
#pragma warning restore CS8605 // Unboxing a possibly null value.

        return (digitsValue, negativeValue, hashcodeValue);
    }
    }
}