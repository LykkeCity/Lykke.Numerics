using System;
using System.ComponentModel;
using System.Numerics;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Lykke.Numerics.Money
{
	[ImmutableObject(true)]
    [Serializable, PublicAPI]
    public readonly partial struct Money
    {
	    private static readonly Regex MoneyFormat = new Regex(@"^[+-]?\d+\.?\d*$", RegexOptions.Compiled);
	    
	    private readonly int _precision;
	    private readonly int _scale;
	    private readonly BigInteger _significand;
	    private readonly int _trailingZeroesCount;

	    
        public Money(
	        BigInteger significand,
	        int scale)
		{
			if (scale < 0)
			{
				throw new ArgumentException("Should be greater or equal to zero.", nameof(scale));
			}

			_scale = scale;
			_significand = significand;
			(_precision, _trailingZeroesCount) = CalculatePrecisionAndTrailingZeroesCount(_significand, _scale);
		}

        
        private int EffectivePrecision
	        => _precision - _trailingZeroesCount;

        private int EffectiveScale
	        => _scale - _trailingZeroesCount;

        private BigInteger TrimmedSignificand
	        => _trailingZeroesCount != 0 ? _significand / (10 * _trailingZeroesCount) : _significand;

        
        [Pure]
        public override int GetHashCode()
        {
	        unchecked
	        {
		        return (EffectiveScale * 397) ^ TrimmedSignificand.GetHashCode();
	        }
        }

        [Pure]
        public override string ToString()
        {
	        var s = BigInteger.Abs(_significand).ToString("R");

	        if (_scale > 0)
	        {
		        s = s.PadLeft(_scale + 1, '0');
		        s = s.Insert(s.Length - _scale, ".");
	        }

	        if (_significand.Sign < 0)
	        {
		        s = "-" + s;
	        }

	        return s;
        }

        /// <summary>
        ///    Converts the decimal to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A decimal value to convert.
        /// </param>
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter.
        /// </returns>
        [Pure]
        public static Money Create(
	        decimal value)
        {
	        var (significand, scale) = value.GetSignificandAndScale();
	        
	        return new Money(significand, scale);
        }
        
        /// <summary>
        ///    Converts the decimal to its Money equivalent, rounded according to the specified accuracy.
        /// </summary>
        /// <param name="value">
        ///    A decimal value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter, rounded according to
        ///    the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        decimal value,
	        int accuracy)
        {
	        var (significand, scale) = value.GetSignificandAndScale();
	        var money = new Money(significand, scale);

	        return scale == accuracy ? money : Round(money, accuracy);
        }

        /// <summary>
        ///    Converts the BigInteger to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A BigInteger value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        BigInteger value,
	        int accuracy)
        {
	        return new Money(value * Pow10(accuracy), accuracy);
        }
        
        /// <summary>
        ///    Converts the byte to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A byte value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        byte value,
	        int accuracy)
        {
	        return Create((BigInteger) value, accuracy);
        }
        
        /// <summary>
        ///    Converts the sbyte to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A sbyte value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        sbyte value,
	        int accuracy)
        {
	        return Create((BigInteger) value, accuracy);
        }
        
        /// <summary>
        ///    Converts the short to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A short value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        short value,
	        int accuracy)
        {
	        return Create((BigInteger) value, accuracy);
        }
        
        /// <summary>
        ///    Converts the ushort to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A ushort value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        ushort value,
	        int accuracy)
        {
	        return Create((BigInteger) value, accuracy);
        }
        
        /// <summary>
        ///    Converts the int to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A int value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        int value,
	        int accuracy)
        {
	        return Create((BigInteger) value, accuracy);
        }
        
        /// <summary>
        ///    Converts the uint to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A uint value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        uint value,
	        int accuracy)
        {
	        return Create((BigInteger) value, accuracy);
        }
        
        /// <summary>
        ///    Converts the long to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A long value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        long value,
	        int accuracy)
        {
	        return Create((BigInteger) value, accuracy);
        }
        
        /// <summary>
        ///    Converts the ulong to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A ulong value to convert.
        /// </param>
        /// <param name="accuracy">
        ///    An accuracy of target value.
        /// </param> 
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter with the specified accuracy.
        /// </returns>
        [Pure]
        public static Money Create(
	        ulong value,
	        int accuracy)
        {
	        return Create((BigInteger) value, accuracy);
        }
        
        /// <summary>
        ///    Converts the string representation of a number to its Money equivalent.
        /// </summary>
        /// <param name="value">
        ///    A string that contains the number to convert.
        /// </param>
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///    The value parameter is null.
        /// </exception>
        /// <exception cref="FormatException">
        ///    The value parameter is not in the correct format.
        /// </exception>
        [Pure]
        public static Money Parse(
	        [NotNull] string value)
        {
	        if (value == null)
	        {
		        throw new ArgumentNullException(nameof(value));
	        }

	        if (!MoneyFormat.IsMatch(value))
	        {
		        throw new FormatException($"Specified value [{value}] does not match Money format [{MoneyFormat}]");
	        }

	        var decimalAndFractionalParts = value.Split('.');

	        switch (decimalAndFractionalParts.Length)
	        {
		        case 1:
		        {
			        var significand = BigInteger.Parse(value);
		        
			        return new Money(significand, 0);
		        }
		        case 2:
		        {
			        value = string.Concat(decimalAndFractionalParts);
			        
			        var significand = BigInteger.Parse(value);
			        var scale = decimalAndFractionalParts[1].Length;
		        
			        return new Money(significand, scale);
		        }
		        default:
			        throw new FormatException();
	        }
        }

        /// <summary>
        ///    Tries to convert the string representation of a number to its Money equivalent,
        ///    and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">
        ///    The string representation of a number.
        /// </param>
        /// <param name="result">
        ///    When this method returns, contains the Money equivalent to the number that is contained in value,
        ///    or zero if the conversion fails. The conversion fails if the value parameter is null or is not
        ///    of the correct format. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        ///    true if value was converted successfully. Otherwise, false.
        /// </returns>
        [Pure]
        public static bool TryParse(
	        [NotNull] string value,
	        out Money result)
        {
	        try
	        {
		        result = Parse(value);

		        return true;
	        }
	        catch (Exception)
	        {
		        result = 0;

		        return false;
	        }
        }
        
        private static (int, int) CalculatePrecisionAndTrailingZeroesCount(
	        BigInteger significand,
	        int scale)
        {
	        var precision = 0;
	        var trailingZeroesCount = 0;

	        var precisionCalculated = false;
	        var trailingZeroesCountCalculated = false;

	        var tmp = significand;

	        while (!precisionCalculated || !trailingZeroesCountCalculated)
	        {
		        if (!precisionCalculated)
		        {
			        if (tmp >= 1)
			        {
				        precision++;
			        }
			        else
			        {
				        precisionCalculated = true;
			        }
		        }

		        if (!trailingZeroesCountCalculated)
		        {
			        if (tmp % 10 == 0 && trailingZeroesCount < scale)
			        {
				        trailingZeroesCount++;
			        }
			        else
			        {
				        trailingZeroesCountCalculated = true;
			        }
		        }

		        tmp /= 10;
	        }

	        return (precision, trailingZeroesCount);
        }

        private static (BigInteger, BigInteger) EqualizeSignificands(
	        Money left,
	        Money right)
        {
	        if (left._scale == right._scale)
	        {
		        return (left._significand, right._significand);
	        }
	        else
	        {
		        var leftExponent = 0;
		        var rightExponent = 0;
		        
		        if (left._scale > right._scale)
		        {
			        rightExponent = left._scale - right._scale;
		        }
		        else
		        {
			        leftExponent = right._scale - left._scale;
		        }

		        var leftSignificand  = left._significand  * Pow10(leftExponent);
		        var rightSignificand = right._significand * Pow10(rightExponent);

		        return (leftSignificand, rightSignificand);
	        }
        }

        private static BigInteger Pow10(
	        int scale)
        {
	        return BigInteger.Pow(10, scale);
        }
    }
}