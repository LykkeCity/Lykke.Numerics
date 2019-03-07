using System;
using JetBrains.Annotations;

namespace Lykke.Numerics.Money
{
    public partial struct UMoney
    {
        /// <summary>
        ///    Adds two UMoney values and returns the result.
        /// </summary>
        /// <param name="left">
        ///    The first value to add.
        /// </param>
        /// <param name="right">
        ///    The second value to add.
        /// </param>
        /// <returns>
        ///    The sum of left and right. The sum's scale equals to the left or right scale, whichever is larger. 
        /// </returns>
        [Pure]
        public static UMoney Add(
            UMoney left,
            UMoney right)
        {
            return Create(left._value + right._value);
        }

        /// <summary>
        ///    Returns the smallest integral value that is greater than or equal to the specified decimal number.
        /// </summary>
        /// <param name="value">
        ///    A value to ceil.
        /// </param>
        /// <returns>
        ///    The smallest integral value that is greater than or equal to the value parameter. The scale is preserved.
        /// </returns>
        [Pure]
        public static UMoney Ceiling(
            UMoney value)
        {
            return new UMoney(Money.Ceiling(value._value));
        }

        /// <summary>
        ///    Divides one UMoney value by another and returns the result.
        /// </summary>
        /// <param name="left">
        ///    A value to be divided.
        /// </param>
        /// <param name="right">
        ///    A value to divide by.
        /// </param>
        /// <returns>
        ///    The quotient of the division. The quotient's scale equals to the left or right scale, whichever is larger.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        ///    Divisor is zero.
        /// </exception>
        /// <remarks>
        ///    Result will be rounded to the scale of either left scale, or right scale, whichever is larger.
        ///    For example, 1 / 2 = 0, 1 / 3 = 0, 1.0 / 3 = 0.3, 1.0 / 4.00 = 0.25
        /// </remarks>
        [Pure]
        public static UMoney Divide(
            UMoney left,
            UMoney right)
        {
            return new UMoney(left._value / right._value);
        }

        /// <summary>
        ///    Rounds a specified UMoney number to the closest integer toward negative infinity.
        /// </summary>
        /// <param name="value">
        ///    A value to floor.
        /// </param>
        /// <returns>
        ///    The smallest integral value that is lower than or equal to the value parameter. The scale is preserved.
        /// </returns>
        [Pure]
        public static UMoney Floor(
            UMoney value)
        {
            return new UMoney(Money.Floor(value._value));
        }

        /// <summary>
        ///    Multiplies two specified UMoney values.
        /// </summary>
        /// <param name="left">
        ///    The multiplicand.
        /// </param>
        /// <param name="right">
        ///    The multiplier.
        /// </param>
        /// <returns>
        ///    The result of multiplying left and right.
        /// </returns>
        /// <remarks>
        ///    Result will be rounded to the scale of either left scale, or right scale, whichever is larger.
        ///    For example, 0.5 * 0.5 = 0.2, 1.1 * 1.1 = 1.2, 1.10 * 1.1 = 1.21
        /// </remarks>
        [Pure]
        public static UMoney Multiply(
            UMoney left,
            UMoney right)
        {
            return new UMoney(left._value * right._value);
        }
        
        /// <summary>
        ///    Rounds a value to the nearest integer.
        /// </summary>
        /// <param name="value">
        ///    A value to round.
        /// </param>
        /// <returns>
        ///    The integer that is nearest to the value parameter. If value is halfway between two integers,
        ///    one of which is even and the other odd, the even number is returned.
        /// </returns>
        [Pure]
        public static UMoney Round(
            UMoney value)
        {
            return new UMoney(Money.Round(value._value));
        }

        /// <summary>
        ///    Rounds a UMoney value to the nearest integer. A parameter specifies how to round the value if it
        ///    is midway between two other numbers.
        /// </summary>
        /// <param name="value">
        ///    A value to round.
        /// </param>
        /// <param name="mode">
        ///    A value that specifies how to round value if it is midway between two other numbers.
        /// </param>
        /// <returns>
        ///    The integer that is nearest to the value parameter. If value is halfway between two numbers, one
        ///    of which is even and the other odd, the mode parameter determines which of the two numbers is returned.
        /// </returns>
        [Pure]
        public static UMoney Round(
            UMoney value,
            MidpointRounding mode)
        {
            return new UMoney(Money.Round(value._value, mode));
        }

        /// <summary>
        ///    Rounds a value to a specified number of decimal places.
        /// </summary>
        /// <param name="value">
        ///    A value to round.
        /// </param>
        /// <param name="scale">
        ///    A value that specifies the number of decimal places to round to.
        /// </param>
        /// <returns>
        ///    The number equivalent to value rounded to decimals number of decimal places.
        /// </returns>
        [Pure]
        public static UMoney Round(
            UMoney value,
            int scale)
        {
            return new UMoney(Money.Round(value._value, scale));
        }

        /// <summary>
        ///    Rounds a value to a specified number of decimal places. A parameter specifies how to round the value
        ///    if it is midway between two other numbers.
        /// </summary>
        /// <param name="value">
        ///    A value to round.
        /// </param>
        /// <param name="scale">
        ///    A value that specifies the number of decimal places to round to.
        /// </param>
        /// <param name="mode">
        ///    A value that specifies how to round value if it is midway between two other numbers.
        /// </param>
        /// <returns>
        ///    The number equivalent to value rounded to decimals number of decimal places. If value is halfway between
        ///    two numbers, one of which is even and the other odd, the mode parameter determines which of the two
        ///    numbers is returned.
        /// </returns>
        [Pure]
        public static UMoney Round(
            UMoney value,
            int scale,
            MidpointRounding mode)
        {
            return new UMoney(Money.Round(value._value, scale, mode));
        }

        /// <summary>
        ///    Subtracts one specified Money value from another.
        /// </summary>
        /// <param name="left">
        ///    The minuend.
        /// </param>
        /// <param name="right">
        ///    The subtrahend.
        /// </param>
        /// <returns>
        ///    The result of subtracting right from left.
        /// </returns>
        /// <exception cref="OverflowException">
        ///    Result is lower than zero.
        /// </exception>
        [Pure]
        public static UMoney Subtract(
            UMoney left,
            UMoney right)
        {
            if (right > left)
            {
                throw new OverflowException();
            }
            
            return new UMoney(left._value - right._value);
        }

        /// <summary>
        ///    Returns the integral digits of the specified Money. Any fractional digits are discarded.
        /// </summary>
        /// <param name="value">
        ///    A value to truncate.
        /// </param>
        /// <returns>
        ///    The result of value rounded toward zero, to the nearest whole number. The scale is not preserved.
        /// </returns>
        [Pure]
        public static UMoney Truncate(
            UMoney value)
        {
            return new UMoney(Money.Truncate(value._value));
        }

        #region Operators

        public static UMoney operator ++(UMoney value)
        {
            return value + 1;
        }

        public static UMoney operator --(UMoney value)
        {
            return value - 1;
        }

        public static UMoney operator +(UMoney left, UMoney right)
        {
            return Add(left, right);
        }
        
        public static UMoney operator -(UMoney left, UMoney right)
        {
            return Subtract(left, right);
        }
        
        public static UMoney operator *(UMoney left, UMoney right)
        {
            return Multiply(left, right);
        }
        
        public static UMoney operator /(UMoney left, UMoney right)
        {
            return Divide(left, right);
        }
        
        // Money
        
        public static Money operator +(UMoney left, Money right)
        {            
            return left._value + right;
        }
        
        public static Money operator +(Money left, UMoney right)
        {
            return left + right._value;
        }
        
        public static Money operator -(UMoney left, Money right)
        {
            return left._value - right;
        }
        
        public static Money operator -(Money left, UMoney right)
        {
            return left - right._value;
        }
        
        public static Money operator *(UMoney left, Money right)
        {
            return left._value * right;
        }
        
        public static Money operator *(Money left, UMoney right)
        {
            return left * right._value;
        }
        
        public static Money operator /(UMoney left, Money right)
        {
            return left._value / right;
        }
        
        public static Money operator /(Money left, UMoney right)
        {
            return left / right._value;
        }
        
        #endregion
    }
}