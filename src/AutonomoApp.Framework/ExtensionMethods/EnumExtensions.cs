using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AutonomoApp.Framework.ExtensionMethods;

public static class EnumExtensions
{
    /// <summary>
    /// Pega a descrição do DataAnnotaion ou o Nome do campo
    /// </summary>
    /// <param name="value"></param>
    /// <returns>string</returns>
    public static string GetEnumDescription(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes != null && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }

    //public static string GetDescription(this Enum owner)
    //{
    //    FieldInfo field = owner.GetType().GetField(owner.ToString());
    //    DescriptionAttribute attribute = field.GetAttribute<DescriptionAttribute>();
    //    if (attribute != null)
    //    {
    //        return attribute.Description;
    //    }

    //    return owner.ToString();
    //}

    public static bool TryParseNullable<T>(string value, out T? result) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
            result = null;
            return false;
        }

        T result2 = default;
        if (Enum.TryParse(value, out result2))
        {
            result = result2;
            return true;
        }

        result = null;
        return false;
    }


    public static IList ListDescriptions<T>() where T : struct, IConvertible
    {
        return GetDescriptions<T>(Enum.GetValues(typeof(T)), order: true);
    }

    public static IList ListDescriptions<T>(bool order) where T : struct, IConvertible
    {
        return GetDescriptions<T>(Enum.GetValues(typeof(T)), order);
    }

    public static IList ListDescriptions<T>(T[] enumValues) where T : struct, IConvertible
    {
        return GetDescriptions<T>(enumValues, order: true);
    }

    public static IList ListDescriptions<T>(T[] enumValues, bool order) where T : struct, IConvertible
    {
        return GetDescriptions<T>(enumValues, order);
    }

    private static IList GetDescriptions<T>(Array enumValues, bool order) where T : struct, IConvertible
    {
        ArrayList arrayList = new ArrayList();
        foreach (Enum enumValue in enumValues)
        {
            arrayList.Add(new KeyValuePair<Enum, string>(enumValue, enumValue.GetEnumDescription()));
        }

        if (order)
        {
            arrayList.Sort(new DescriptionEntryComparer());
        }

        return arrayList;
    }

    public static T GetAttribute<T>(this Enum owner)
    {
        FieldInfo field = owner.GetType().GetField(owner.ToString());
        object obj = field.GetCustomAttributes(typeof(T), inherit: false).FirstOrDefault();
        return (T)obj;
    }

}

public class DescriptionEntryComparer : IComparer
{
    public int Compare(object x, object y)
    {
        KeyValuePair<Enum, string> keyValuePair = (KeyValuePair<Enum, string>)x;
        KeyValuePair<Enum, string> keyValuePair2 = (KeyValuePair<Enum, string>)y;
        return keyValuePair.Value.CompareTo(keyValuePair2.Value);
    }
}
