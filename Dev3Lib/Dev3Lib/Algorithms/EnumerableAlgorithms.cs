using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace Dev3Lib.Algorithms
{
    public static class EnumerableAlgorithms
    {
        [DebuggerStepThrough]
        public static void SafeForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null)
                return;
            items.ForEach(action);
        }

        private static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            var en = items.GetEnumerator();
            while (en.MoveNext())
                action(en.Current);
        }

        [DebuggerStepThrough]
        public static T SafeFind<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            T item;
            if (items.SafeTryFind(predicate, out item))
                return item;
            else
                return default(T);
        }

        [DebuggerStepThrough]
        public static T SafeFind<T>(this IEnumerable<T> items, Predicate<T> predicate, T defaultValueIfNotFind)
        {
            T item;
            if (items.SafeTryFind(predicate, out item))
                return item;
            else
                return defaultValueIfNotFind;
        }

        [DebuggerStepThrough]
        public static void SafeFind<T>(this IEnumerable<T> items, Predicate<T> predicate,
            Action<T> actionIfFound)
        {
            T item;
            if (items.SafeTryFind(predicate, out item))
            {
                actionIfFound(item);
            }
        }

        [DebuggerStepThrough]
        public static bool SafeTryFind<T>(this IEnumerable<T> items, Predicate<T> predicate, out T item)
        {
            item = default(T);
            if (items == null)
            {
                return false;
            }

            var en = items.GetEnumerator();
            while (en.MoveNext())
            {
                if (predicate(en.Current))
                {
                    item = en.Current;
                    return true;
                }
            }

            return false;
        }



        [DebuggerStepThrough]
        public static List<T> SafeFindAll<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null)
                return new List<T>();

            return items.FindAll(predicate);
        }

        public static List<T> SafeFindAll<T>(this IEnumerable items, Predicate<T> predicate)
        {
            if (items == null)
                return new List<T>();

            var en = items.GetEnumerator();
            List<T> filteredItems = new List<T>();
            while (en.MoveNext())
            {
                if (predicate((T)en.Current))
                    filteredItems.Add((T)en.Current);
            }

            return filteredItems;
        }

        private static List<T> FindAll<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            var list = items as List<T>;
            if (list != null)
                return list.FindAll(predicate);

            var arr = items as T[];
            if (arr != null)
                return new List<T>(Array.FindAll<T>(arr, predicate));

            List<T> results = new List<T>();

            var en = items.GetEnumerator();

            while (en.MoveNext())
            {
                if (predicate(en.Current))
                    results.Add(en.Current);
            }

            return results;
        }

        [DebuggerStepThrough]
        public static int SafeCount<T>(this IEnumerable<T> items)
        {
            if (items == null)
                return 0;

            if (items is IList)
                return ((IList)items).Count;

            if (items is T[])
                return ((T[])items).Length;

            return items.Count(null);
        }

        [DebuggerStepThrough]
        public static int SafeCount<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null)
                return 0;
            else
                return items.Count(predicate);
        }

        private static int Count<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            int count = 0;
            if (predicate == null)
            {
                if (items is IList)
                    return ((IList)items).Count;

                if (items is T[])
                    return ((T[])items).Length;


                var en = items.GetEnumerator();
                while (en.MoveNext())
                    count++;
                return count;
            }
            else
            {
                if (items is List<T>)
                    return ((List<T>)items).FindAll(predicate).Count;

                if (items is T[])
                    return Array.FindAll((T[])items, predicate).Length;

                var en = items.GetEnumerator();
                while (en.MoveNext())
                {
                    if (predicate(en.Current))
                        count++;
                }
                return count;
            }
        }

        [DebuggerStepThrough]
        public static List<OutT> SafeConvertAll<InputT, OutT>(this IEnumerable<InputT> items, Converter<InputT, OutT> converter)
        {
            if (items == null)
                return new List<OutT>();

            var items1 = items as List<InputT>;
            if (items1 != null)
                return items1.ConvertAll(n => converter(n));

            List<OutT> list = new List<OutT>(items.Count(null));
            var en = items.GetEnumerator();
            while (en.MoveNext())
            {
                list.Add(converter(en.Current));
            }

            return list;
        }

        [DebuggerStepThrough]
        public static List<OutT> SafeConvertAllItems<InputT, OutT>(this IEnumerable<InputT> items, Converter<InputT, IEnumerable<OutT>> converter)
        {
            List<OutT> list = new List<OutT>();

            items.SafeForEach(n => list.AddRange(converter(n).SafeToEnumerable()));
            return list;
        }

        [DebuggerStepThrough]
        public static T[] SafeToArray<T>(this IEnumerable<T> items)
        {
            if (items == null)
                return new T[] { };

            if (items is T[])
                return (T[])items;

            if (items is List<T>)
                return ((List<T>)items).ToArray();

            T[] rets = (T[])Array.CreateInstance(typeof(T), items.Count(null));
            int index = 0;
            var en = items.GetEnumerator();

            while (en.MoveNext())
            {
                rets[index++] = en.Current;
            }

            return rets;
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> SafeToEnumerable<T>(this IEnumerable<T> items)
        {
            if (items == null)
                return new T[] { };
            else
                return items;
        }

        [DebuggerStepThrough]
        public static bool SafeExists<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            T item;
            return items.SafeTryFind(predicate, out item);
        }

        [DebuggerStepThrough]
        public static bool SafeIsEqual<T>(this IEnumerable<T> source, IEnumerable<T> target)
        {
            return !(source.SafeExists(n => !target.SafeExists(m => Comparer<T>.Default.Compare(m, n) == 0))
                || target.SafeExists(n => !source.SafeExists(m => Comparer<T>.Default.Compare(m, n) == 0)));
        }

        [DebuggerStepThrough]
        public static bool SafeIsEqual<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> compare)
        {
            return !(source.SafeExists(n => !target.SafeExists(m => compare(m, n)))
                || target.SafeExists(n => !source.SafeExists(m => compare(m, n))));
        }

        [DebuggerStepThrough]
        public static bool IsNullOrEmpty(this IEnumerable source)
        {
            if (source == null)
                return true;

            var en = source.GetEnumerator();
            if (en.MoveNext())
                return false;
            else
                return true;
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> SafeTake<T>(this IEnumerable<T> source, int returnCount)
        {
            if (source.IsNullOrEmpty())
                return new T[] { };
            else
            {
                List<T> list = new List<T>();

                int count = 0;
                var en = source.GetEnumerator();

                while (en.MoveNext())
                {
                    if (count++ == returnCount)
                        break;
                    list.Add(en.Current);
                }

                return list;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> SafeTakeFirstHalf<T>(this IEnumerable<T> source)
        {
            var count = source.SafeCount();

            if (count == 0)
                return new T[] { };

            if (IsOddCount(count))
            {
                return source.SafeTake(count / 2 + 1);
            }
            else
            {
                return source.SafeTake(count / 2);
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> SafeTakeSecondHalf<T>(this IEnumerable<T> source)
        {
            List<T> list = new List<T>(source.SafeToEnumerable());

            source.SafeTakeFirstHalf().SafeForEach(
                n => list.Remove(n)
                );

            return list;

        }

        [DebuggerStepThrough]
        public static bool SafeIsOddCount<T>(this IEnumerable<T> source)
        {
            return IsOddCount(source.SafeCount());
        }

        private static bool IsOddCount(int count)
        {
            decimal val = Convert.ToInt64(count);
            return !(Math.Round(val / 2, 0) == val / 2);
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> SafeGetOverlapped<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> compare)
        {
            if (source.IsNullOrEmpty() || target.IsNullOrEmpty())
                return new T[] { };

            return source.SafeFindAll(n => target.SafeExists(m => compare(n, m)));
        }

        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return true;

            return !source.GetEnumerator().MoveNext();
        }

        public static int GetPosition<T>(this IEnumerable<T> source, T obj) where T : class
        {
            int i = 0;
            var en = source.GetEnumerator();
            while (en.MoveNext())
            {
                if (Object.ReferenceEquals(en.Current, obj))
                    return i;
                else
                    i++;
            }

            throw new PostionNotFoundException();
        }

        public static T SafeLastOrDefault<T>(this IEnumerable<T> items)
        {
            if (items.IsNullOrEmpty())
                return default(T);


            {
                var list = items as IList<T>;
                if (list != null)
                    return list[list.Count - 1];
            }

            {
                var list = items as IList;
                if (list != null)
                    return (T)list[list.Count - 1];
            }

            var en = items.GetEnumerator();
            T last = default(T);
            while (en.MoveNext())
                last = en.Current;

            return last;

        }

        public static void SafeForeach(this IEnumerable items, Action<object> action)
        {
            foreach (var obj in items)
            {
                action(obj);
            }
        }

        public static List<T> SafeConvertAll<T>(this IEnumerable items, Func<object, T> func)
        {
            List<T> itemList = new List<T>();
            foreach (var obj in items)
            {
                itemList.Add(func(obj));
            }

            return itemList;
        }

        
    }
}
