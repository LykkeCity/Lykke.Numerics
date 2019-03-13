namespace Lykke.Numerics.Tests.Utils
{
    public static class MoneyExtensions
    {
        public static MoneyAssertions Should(
            this Money instance)
        {
            return new MoneyAssertions(instance); 
        } 
    }
}