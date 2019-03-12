namespace Lykke.Numerics
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