# AnySizeInteger Library Scope

This document describes the extent of completeness for the AnySizeInteger
library in its first version.

## Constructors

### From numerical data types

An AnySizeInteger must be possible to construct from any kind of number in the
hosting language.

All integer types should have no problem in being converted to AnySizeInteger.

Converting back from AnySizeInteger to a host integer data type should
implicitly return only the bits of the number that fit the limits of the
desired data type. For example if the least significant 8 bits of an
AnySizeIntger are all ones, and the conversion goes towards a `byte` data type
the result would be 255 in decimal representation; however, if the same 8 bits
are converted into a `sbyte` data type the result would be seen as -1 in decimal
representation.

**Notes:**

- When converting floating point numbers to AnySizeInteger data type, or any
other number type with decimal parts; the converted number must be expanded to
its full decimal notation representation, and then the fractional part must be
truncated.
- Ideally, when converting a floating point number to its expanded decimal
representation, the conversion should be done using round-trip representation.

### From String

An AnySizeIntger must be possible to construct from a string if the string is
made entirely of decimal digits, with an optional sign in the first position.

The string must match the following RegEx: `^(-|+)?[0-9]+$`

**Note:**

- AnySizeIntegers constructed from string vary from $-(10^{2,147,483,647}-1)$ to
$+(10^{2,147,483,648}-1)$. That is a string of 2,147,483,648 nines long; if the
number is negative (starts with a `-` sign) the string can hold
2,147,483,647 nines after the `-` sign.
- This is a limitation from the .Net platform.

### From another AnySizeInteger

An AnySizeInteger must be possible to construct from another AnySizeInteger.

### From Arrays of integer data type

The idea behind constructing an AnySizeInteger from an array is to define rules
to pack and unpack an AnySizeInteger to enable transport of data in a compact
form between multiple different applications.

Importing from arrays of numbers should mean something similar to have an
ordered list of digits.

The array `[0,1,2,3,4,5,6,7,8,9]` of `ulong` or `uint` should be equivalent to
have the following expression:

$B = 2^{32}$

$N = 0 + 1 B + 2 B^2 + 3 B^3 + 4 B^4 + 5 B^5 + 6 B^6 + 7 B^7 + 8 B^8 + 9 B^9$

In decimal notation.

## Implicit Conversions

To allow a smooth integration of the class with all numeric types in the host,
implicit conversions must be defined for numeric data types.

This would allow the following expression to be used in the code:

```CS
AnySizeInteger A = new AnySizeInteger(10);

AnySizeInteger B = A + 10;
```

Without implicit conversions, typing expressions with integer number constants
or variables would be a nightmare.

***Warning***

- Implicit conversions for floating point, or any other data type with decimal
representation, might introduce hard to spot bugs. The following code should
give an idea of the kind of trap:

    ```CS
    AnySizeInteger A = new AnySizeInteger(4);
    AnySizeInteger B = A * 1.5;
    Console.WriteLine(B);
    ```

- The output of the above code would be:

    ```txt
    4
    ```

    Not `6` as one might have expected.

    We cannot guarantee the expression `A * 1.5` would result in a number within
    the limits of the integer part of a `double` data type ($± 10^{308}$).
    Hence, the double is converted first to AnySizeInteger and the operation is
    carried after; this truncates `1.5` to `1`.
