using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace System.Numerics
{
	[ImmutableObject(true)]
    [Serializable, PublicAPI]
    public readonly partial struct BigDecimal
    {
	    private readonly int _precision;
	    private readonly int _scale;
	    private readonly BigInteger _significand;
	    private readonly int _trailingZeroesCount;
	    
	    
	    public BigDecimal(
		    decimal value)
        {
	        var bits = (uint[]) (object) decimal.GetBits(value);

	        _scale = (int)((bits[3] >> 16) & 31);

			const decimal bitsMultiplier = 4294967296m;
			
	        var significand = (bits[2] * bitsMultiplier * bitsMultiplier) + (bits[1] * bitsMultiplier) + bits[0];

	        if (value < 0)
	        {
		        significand = significand * -1;
	        }
	        
	        _significand = new BigInteger(significand);
	        (_precision, _trailingZeroesCount) = CalculatePrecisionAndTrailingZeroesCount(_significand, _scale);
        }

	    public BigDecimal(
		    int value)
		    : this(value, 0)
	    {
		    
	    }
	    
	    public BigDecimal(
		    long value)
		    : this(value, 0)
	    {
		    
	    }
	    
	    public BigDecimal(
		    uint value)
		    : this(value, 0)
	    {
		    
	    }
	    
	    public BigDecimal(
		    ulong value)
		    : this(value, 0)
	    {
		    
	    }
	    
	    [SuppressMessage("ReSharper", "IntroduceOptionalParameters.Global")]
	    public BigDecimal(
		    BigInteger value)
			: this(value, 0)
	    {
		    
	    }
	    
        public BigDecimal(
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
        
        public static BigDecimal Zero
			=> new BigDecimal(0);
        
        public static BigDecimal One
	        => new BigDecimal(1);

        
        private int EffectivePrecision
	        => _precision - _trailingZeroesCount;

        private int EffectiveScale
	        => _scale - _trailingZeroesCount;

        private BigInteger TrimmedSignificand
	        => _trailingZeroesCount != 0 ? _significand / (10 * _trailingZeroesCount) : _significand;

        
        private (BigInteger, BigInteger) EqualizeSignificands(
	        BigDecimal other)
        {
	        return EqualizeSignificands(this, other);
        }
        
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

        [Pure]
        public static BigDecimal Parse(
	        [NotNull] string value)
        {
	        if (value == null)
	        {
		        throw new ArgumentNullException(nameof(value));
	        }

	        var decimalAndFractionalParts = value.Split('.');

	        switch (decimalAndFractionalParts.Length)
	        {
		        case 1:
		        {
			        var significand = BigInteger.Parse(value);
		        
			        return new BigDecimal(significand, 0);
		        }
		        case 2:
		        {
			        value = string.Concat(decimalAndFractionalParts);
			        
			        var significand = BigInteger.Parse(value);
			        var scale = decimalAndFractionalParts[1].Length;
		        
			        return new BigDecimal(significand, scale);
		        }
		        default:
			        throw new FormatException();
	        }
        }

        [Pure]
        public static bool TryParse(
	        [NotNull] string value,
	        out BigDecimal result)
        {
	        try
	        {
		        result = Parse(value);

		        return true;
	        }
	        catch (Exception)
	        {
		        result = default;

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
	        BigDecimal left,
	        BigDecimal right)
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