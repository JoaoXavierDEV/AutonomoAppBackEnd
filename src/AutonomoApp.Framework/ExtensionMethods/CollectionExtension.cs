using AutonomoApp.Framework.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutonomoApp.Framework
{
    public static partial class CollectionExtension
    {
        public static IEnumerable<T> ExecuteStep<T>(this IEnumerable<int> list, int step, Func<IEnumerable<int>, IEnumerable<T>> action)
        {
            List<T> list2 = new List<T>();
            if (list != null)
            {
                for (int i = 0; i < list.Count(); i += step)
                {
                    list2.AddRange(action(list.Skip(i).Take(step)));
                }
            }

            return list2;
        }

        public static void ExecuteStep<T>(this IEnumerable<T> list, int step, Action<IEnumerable<T>> action)
        {
            for (int i = 0; i < list.Count(); i += step)
            {
                action(list.Skip(i).Take(step));
            }
        }

        public static IQueryable<T> WhereIfHasData<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> expression)
        {
            return queryable.WhereIfHasData(expression, returnEvenWithoutData: false);
        }

        public static IQueryable<T> WhereIfHasData<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> expression, bool returnEvenWithoutData)
        {
            IQueryable<T> queryable2 = queryable.Where(expression);
            if (returnEvenWithoutData)
            {
                return queryable2;
            }

            if (queryable2.Count() == 0)
            {
                return queryable;
            }

            return queryable2;
        }

        public static string ToStringJoined<T>(this IEnumerable<T> values, string separator, string lastSeparator = null, string textToBeFormattedForEachItem = null, bool throwException = false)
        {
            //if (values == null || values.None())
            if (values == null)
            {
                if (throwException)
                {
                    throw new ArgumentNullException(nameof(values));
                }

                return null;
            }

            if (lastSeparator == null)
            {
                lastSeparator = separator;
            }

            if (textToBeFormattedForEachItem.IsNullOrWhiteSpace())
            {
                return String.Join(separator, lastSeparator, values);
            }

            return String.Join(separator, lastSeparator, values.Select((T x) => textToBeFormattedForEachItem.Fmt(x)));
        }
    }




    public static partial class CollectionExtension
    {
        public static void ExecuteForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            source?.ToList().ForEach(action);
        }

        public static void ExecuteForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            int index = 0;
            source.ExecuteForEach(delegate (T x)
            {
                action(x, index++);
            });
        }

        public static IEnumerable<T> ExecuteForEach<T>(this IEnumerable<T> source, Action<T> action, Func<T, bool> predicate)
        {
            source.Where(predicate).ToList().ForEach(action);
            return source;
        }

        public static void RemoveItem<T>(this ICollection<T> owner, Func<T, bool> predicate)
        {
            owner.Remove(owner.Where(predicate).FirstOrDefault());
        }

        public static void ChangeItem<T>(this IList<T> owner, Func<T, bool> predicate, T newItem)
        {
            T val = owner.Where(predicate).FirstOrDefault();
            if (val != null)
            {
                int index = owner.IndexOf(val);
                owner[index] = newItem;
            }
        }

        public static bool CollectionEquals<T>(this IEnumerable<T> owner, IEnumerable<T> other)
        {
            return owner.SequenceEqual(other);
        }

        public static Type GetCollectionItemType<T>(this IEnumerable<T> owner)
        {
            return owner.GetType().GetGenericArguments()[0];
        }

        public static IEnumerable<T> FastReverse<T>(this IEnumerable<T> owner)
        {
            for (int i = owner.Count() - 1; i >= 0; i--)
            {
                yield return owner.ToList()[i];
            }
        }

        public static void SafeAdd<T>(this ICollection<T> owner, T item)
        {
            if (!owner.Contains(item))
            {
                owner.Add(item);
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem, Func<TSource, bool> canContinue)
        {
            TSource current = source;
            while (canContinue(current))
            {
                yield return current;
                current = nextItem(current);
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem) where TSource : class
        {
            return source.FromHierarchy(nextItem, (TSource s) => s != null);
        }

        public static TSource SingleOrDefault<TSource>(this IQueryable<TSource> source, string errorMessage)
        {
            try
            {
                return source.SingleOrDefault();
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(FormatErrorMessage(ex, errorMessage), ex.InnerException);
            }
            catch (InvalidOperationException ex2)
            {
                throw new InvalidOperationException(FormatErrorMessage(ex2, errorMessage), ex2.InnerException);
            }
            catch (Exception ex3)
            {
                throw new Exception(FormatErrorMessage(ex3, errorMessage));
            }
        }

        private static string FormatErrorMessage(Exception ex, string errorMessage)
        {
            if (errorMessage.IsNullOrEmpty())
            {
                return ex.Message;
            }

            return "{0} {1}Erro Original: {2}".Fmt(errorMessage, System.Environment.NewLine, ex.Message);
        }

        public static TSource SingleOrDefault<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, string errorMessage)
        {
            try
            {
                return source.SingleOrDefault(predicate);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(FormatErrorMessage(ex, errorMessage), ex.InnerException);
            }
            catch (InvalidOperationException ex2)
            {
                throw new InvalidOperationException(FormatErrorMessage(ex2, errorMessage), ex2.InnerException);
            }
            catch (Exception ex3)
            {
                throw new Exception(FormatErrorMessage(ex3, errorMessage));
            }
        }

        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, int elements)
        {
            return (from x in source.Select((TSource value, int index) => new
            {
                Index = index,
                Value = value
            })
                    group x by x.Index / elements into x
                    select x.Select(y => y.Value).ToList()).ToList();
        }
    }
}
