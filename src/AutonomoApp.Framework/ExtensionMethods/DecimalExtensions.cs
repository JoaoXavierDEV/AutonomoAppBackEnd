namespace AutonomoApp.Framework.ExtensionMethods;

public static class DecimalExtensions
{
    public static decimal Round(this decimal value)
    {
        return value.Round(2, MidpointRounding.AwayFromZero);
    }

    public static decimal Round(this decimal value, MidpointRounding midpointRounding)
    {
        return Math.Round(value, 2, midpointRounding);
    }

    public static decimal Round(this decimal value, int casas, MidpointRounding midpointRounding)
    {
        return Math.Round(value, casas, midpointRounding);
    }
}

