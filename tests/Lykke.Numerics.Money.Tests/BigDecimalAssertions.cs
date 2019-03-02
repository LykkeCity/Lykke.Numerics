using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;

namespace Lykke.Numerics.Money.Tests
{
    public class BigDecimalAssertions : NumericAssertions<Money>
    {
        public BigDecimalAssertions(Money value) 
            : base(value)
        {
            
        }

        public AndConstraint<BigDecimalAssertions> Be(
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            var bd = Money.Parse(expected);
            
            Execute.Assertion
                .ForCondition(!(Subject is null) && Subject.ToString() == expected)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:value} to be {0}{reason}, but found {1}.", bd, Subject);

            return new AndConstraint<BigDecimalAssertions>(this);
        }
    }
}