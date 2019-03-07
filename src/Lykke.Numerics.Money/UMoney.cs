using System;
using System.Numerics;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Lykke.Numerics.Money
{
	[PublicAPI]
    public readonly partial struct UMoney
    {
        private static readonly Regex UMoneyFormat = new Regex(@"^[+]?\d+\.?\d*$", RegexOptions.Compiled);
        
        private readonly Money _value;


        private UMoney(
	        Money value)
        {
	        if (value < 0)
	        {
		        throw new OverflowException("UMoney value should be greater or equal to zero.");
	        }

	        _value = value;
        }
        
        public UMoney(
            BigInteger significand,
            int scale) 
	        
	        : this(new Money(significand, scale))
        {
	        
        }
        

        [Pure]
        public override int GetHashCode()
            => _value.GetHashCode();

        [Pure]
        public override string ToString()
            => _value.ToString();
        
        
        /// <summary>
        ///    Converts the Money to its UMoney equivalent.
        /// </summary>
        /// <param name="value">
        ///    A Money value to convert.
        /// </param>
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter.
        /// </returns>
        [Pure]
        public static UMoney Create(
	        Money value)
        {
	        return new UMoney(value);
        }
        
        /// <summary>
        ///    Converts the decimal to its UMoney equivalent.
        /// </summary>
        /// <param name="value">
        ///    A decimal value to convert.
        /// </param>
        /// <returns>
        ///    A value that is equivalent to the number specified in the value parameter.
        /// </returns>
        [Pure]
        public static UMoney Create(
	        decimal value)
        {
	        return Create(Money.Create(value));
        }
        
        /// <summary>
        ///    Converts the decimal to its UMoney equivalent, rounded according to the specified accuracy.
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
        public static UMoney Create(
	        decimal value,
	        int accuracy)
        {
	        return Create(Money.Create(value));
        }

        /// <summary>
        ///    Converts the BigInteger to its UMoney equivalent.
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
        public static UMoney Create(
	        BigInteger value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
        }
        
        /// <summary>
        ///    Converts the byte to its UMoney equivalent.
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
        public static UMoney Create(
	        byte value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
        }
        
        /// <summary>
        ///    Converts the sbyte to its UMoney equivalent.
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
        public static UMoney Create(
	        sbyte value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
        }
        
        /// <summary>
        ///    Converts the short to its UMoney equivalent.
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
        public static UMoney Create(
	        short value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
        }
        
        /// <summary>
        ///    Converts the ushort to its UMoney equivalent.
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
        public static UMoney Create(
	        ushort value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
        }
        
        /// <summary>
        ///    Converts the int to its UMoney equivalent.
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
        public static UMoney Create(
	        int value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
        }
        
        /// <summary>
        ///    Converts the uint to its UMoney equivalent.
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
        public static UMoney Create(
	        uint value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
        }
        
        /// <summary>
        ///    Converts the long to its UMoney equivalent.
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
        public static UMoney Create(
	        long value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
        }
        
        /// <summary>
        ///    Converts the ulong to its UMoney equivalent.
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
        public static UMoney Create(
	        ulong value,
	        int accuracy)
        {
	        return Create(Money.Create(value, accuracy));
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
        /// <exception cref="FormatException">
        ///    The value parameter is not in the correct format.
        /// </exception>
        [Pure]
        public static UMoney Parse(
	        string value)
        {
	        if (TryParse(value, out var result))
	        {
		        return result;
	        }
	        else
	        {
		        throw new FormatException($"Specified value [{value}] does not match UMoney format [{UMoneyFormat}]");
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
	        string value,
	        out UMoney result)
        {
	        if (value != null && UMoneyFormat.IsMatch(value))
	        {
		        result = Create(Money.Parse(value));

		        return true;
	        }
	        else
	        {
		        result = default;

		        return false;
	        }
        }
    }
}