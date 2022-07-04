using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AutonomoApp.Business.Extensions;

public static class EnumExtensions
{
    /// <summary>
    ///    Pega a descrição do DataAnnotaion ou o Nome do campo
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

}
