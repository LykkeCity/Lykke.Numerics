using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;

namespace System.Numerics.Tests
{
    public class BigDecimalAssertions : NumericAssertions<BigDecimal>
    {
        public BigDecimalAssertions(BigDecimal value) 
            : base(value)
        {
            
        }

        public AndConstraint<BigDecimalAssertions> Be(
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            var bd = BigDecimal.Parse(expected);
            
            Execute.Assertion
                .ForCondition(!(Subject is null) && Subject.ToString() == expected)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:value} to be {0}{reason}, but found {1}.", bd, Subject);

            return new AndConstraint<BigDecimalAssertions>(this);
        }
    }
}