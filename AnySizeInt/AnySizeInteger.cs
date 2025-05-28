namespace AnySizeInt
{
  public partial class AnySizeInteger
  {
    // AnySizeInteger data structure

    // The array of digits, representing a polynomial expression in base 2^32
    // The index in the array is the power of the base 
    protected readonly ulong[] digits;

    // The sign of the number: Is the number negative
    protected readonly bool negative;

    // To conform with .Net framework, objects need to provide a hash code value.
    // For efficiency, the hash code is precalculated for every AnySizeInteger
    // AnySizeInteger are immutable objects; once created they never change value
    protected readonly int hashcode;
  }
}
