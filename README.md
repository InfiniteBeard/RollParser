# Introduction
***Equation Parser for roll playing games***

This is a program for parsing equations that contain not only typical mathematical operaterations such as addition and subtraction but also dice rolls.

# Features

## Supported Numbers
Currently only integers are supported.

## Supported Operators
The currently supported operators are (in order of operations):
* ***d*** - Dice roll operator. The operand on the left of the 'd' specifies the number of dice. The operand on the right of the 'd' specifies the dice type. E.g. 2d6 means that a six sided die will be rolled twice. Each roll of the six sided die will be added together and the resulting sum will be the output of the dice roll operator.
* ***\**** - Typical multiplication operator
* ***+*** - Typical addition operator
* ***-*** - Typical subratraction operator

# Usage

There are some rules that must be followed:

## Binary opertors must be given two operands.


This means that you can't have two binary operators follow directly after each other:

***WRONG***
> 2 + + 2

And you can't start or finish an equation with a binary operator

***WRONG***
> \+ 2 + 2
>
> 2 + 2 +

## Dice operators second operand (dice type) can't be 0

Since dice type specifies how many faces the die has, the dice operator does not support a dice type of 0

***WRONG***
> 4d0




