# AnySizeInteger Architecture

The idea behind the AnySizeInteger library is to be able to do integer math
for any size of integer; because there's always a limit in computers, we would
like such limit to be so big that's unlikely we'll ever reach it.

Numbers in AnySizeInteger are represented similarly as numbers are written in
decimal notation; as an implicit polynomial of powers of a base, where each
power is multiplied by a digit from the base.

***Important***

> AnySizeInteger digits are base 2^32.

An AnySizeIntger is represented by a sign field, an array of base 2^32
digits, and a hash value; the value of the index into the array indicates
the power of 2^32 applied to the digit.

***Important***

> AnySizeInteger digits are base 2^32.

> From now on any mention to *digit* refers to AnySizeDigits! Unless explicitly
stated a different base.

As an example, the following decimal number:

$N = 4,475,909,128,614,416,493,485,689,423,417,672,529,955,905,318,382,457,129,602,946,176,313,508,885,239,553,977,221,120$

would be represented as:

`{sign=positive, digits=[0,1,2,3,4,5,6,7,8,9], hashcode=1}`

In decimal notation:

$B = 2^{32}$

$N = 0 + 1 B + 2 B^2 + 3 B^3 + 4 B^4 + 5 B^5 + 6 B^6 + 7 B^7 + 8 B^8 + 9 B^9$

An important concept to emphasize:

> ***Digits are stored in reverse order than the way decimal numbers are
written; the least significative digit is the first on the left, and the most
significative digit is the one at the last position to the right***

## Data Representation

An AnySizeInteger number is represented as:

- `protected readonly bool negative`
- `protected readonly ulong[] digits`
- `protected readonly int hashcode`

### Why `ULONG`?

If digits in AnySizeInteger are defined between 0 and 4,294,967,295; a `uint`
data type should be enough to hold any digit.

The reason to use `ulong` instead of `uint` is to simplify long-running sums of
digits and have a place to keep track of the carries.

If AnySizeInteger digits type were `uint`, to add two numbers you would have to
cast each digit to `ulong`, add the digits, check for carry and keep it
separately, save the resulting digit, add the carry to the next power. Trying to
add multiple digits at a time would be laborious.

On the other hand using `ulong` data type to store the digits simplifies the
task. First, you can add all columns of digits separately; second, the resulting
array of digit sums

Let's say you have a list with thousands of AnySize3Integers, each number
of 200 digits, and you want to sum them.

# ***To Do***: complete the idea here

### Serialization
