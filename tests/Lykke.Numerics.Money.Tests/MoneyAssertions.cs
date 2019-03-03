using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;

namespace Lykke.Numerics.Money.Tests
{
    public class MoneyAssertions : NumericAssertions<Money>
    {
        public MoneyAssertions(Money value) 
            : base(value)
        {
            
        }

        public AndConstraint<MoneyAssertions> Be(
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            var money = Money.Parse(expected);
            
            Execute.Assertion
                .ForCondition(!(Subject is null) && Subject.CompareTo(money) == 0)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:value} to be {0}{reason}, but found {1}.", money, Subject);

            return new AndConstraint<MoneyAssertions>(this);
        }
    }
}