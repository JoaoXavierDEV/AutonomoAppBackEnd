using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Business.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }



    }

    public static class EntityTeste
    {
        public static bool IsDefaultValue(this object owner, Type targetType = null)
        {
            if (owner == null) return true;
            targetType = targetType ?? owner.GetType();
            object obj = (targetType.IsValueType ? Activator.CreateInstance(targetType) : null);
            return owner.Equals(obj) || Convert.ChangeType(owner, targetType).Equals(obj);
        }



        public static bool IsDefaultValue<T>(this object owner)
        {
            return owner.IsDefaultValue(typeof(T));
        }
    }

}
