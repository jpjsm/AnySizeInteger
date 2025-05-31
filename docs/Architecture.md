# AnySizeInteger Architecture

The idea behind the AnySizeInteger library is to be able to do integer math
for any size of integer; because there's always a limit in computers, we would
like such limit to be so big that's unlikely we'll ever reach it.

Numbers in AnySizeInteger are represented in a similar way numbers are written
in decimal notation; as an implicit polynomial of powers of a base, where each
power is multiplied by a digit from the base.

An AnySizeIntger is represented by a sign field, an array of base 2^32
digits, and a hashcode value; the array index indicates the power of 2^32
applied to the digit.

As an example, the following decimal number:

`4,475,909,128,614,416,493,485,689,423,417,672,529,955,905,318,382,457,129,602,946,176,313,508,885,239,553,977,221,120`

would be represented as:

`{positive, [0,1,2,3,4,5,6,7,8,9], 1}`

In decimal notation:

$$
\begin{align*}
&B = 2^{32} \\
&N = 9 B^9 + 8 B^8 + 7 B^7 + 6 B^6 + 5 B^5 + 4 B^4 + 3 B^3 + 2 B^2 + 1 B + 0 \\
\end{align*}
$$

An important concept to emphasize:

> ***Digits are stored in reverse order than the way decimal numbers are
written; the least significative digit is the first on the left, and the most
significative digit is the one at the last position to the right***

