using System;
using System.ComponentModel;
using System.Globalization;

namespace Lykke.Numerics
{
    internal class MoneyTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context,
            Type sourceType)
        {
            return sourceType == typeof(string) 
                || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            return Money.Parse((string) value);
        }
    }
}